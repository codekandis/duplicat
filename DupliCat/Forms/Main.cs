using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CodeKandis.DupliCat.Data;
using CodeKandis.DupliCat.Io;
using CodeKandis.DupliCat.Io.MetaData;
using CodeKandis.DupliCat.Serialization.Json;
using SharpKandis.Windows.Forms;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Forms;

/// <summary>
/// Represents the main form of the application.
/// </summary>
internal partial class Main:
	Form
{
	/// <summary>
	/// Represents the name of the error log file.
	/// </summary>
	private const string ERROR_LOG_NAME = "errors.log";

	/// <summary>
	/// Represents the path of the error log file.
	/// </summary>
	private readonly string errorLogPath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Main.ERROR_LOG_NAME );

	/// <summary>
	/// Represents the name of the projects file.
	/// </summary>
	private const string PROJECTS_FILE_NAME = "projects.json";

	/// <summary>
	/// Represents the path of the projects file.
	/// </summary>
	private readonly string projectsFilePath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Main.PROJECTS_FILE_NAME );

	/// <summary>
	/// Stores the projects.
	/// </summary>
	private ProjectListInterface? projectList;

	/// <summary>
	/// Stores the bindable data source of projects.
	/// </summary>
	private readonly BindableDataSource<ProjectInterface> projects = new BindableDataSource<ProjectInterface>();

	/// <summary>
	/// Stores the MD5 sets.
	/// </summary>
	private Md5SetListInterface? md5SetList;

	/// <summary>
	/// Stores the bindable data source of MD5 sets.
	/// </summary>
	private readonly BindableDataSource<Md5SetInterface> md5Sets = new BindableDataSource<Md5SetInterface>();

	/// <summary>
	/// Stores the files.
	/// </summary>
	private FileListInterface? fileList;

	/// <summary>
	/// Stores the bindable data source of files.
	/// </summary>
	private readonly BindableDataSource<FileInterface> files = new BindableDataSource<FileInterface>();

	/// <summary>
	/// Constructor method.
	/// </summary>
	public Main()
	{
		this.InitializeComponent();
	}

	/// <summary>
	/// Initializes the form.
	/// </summary>
	private void Initialize()
	{
		Application.ThreadException                += this.Application_ThreadException;
		Application.ApplicationExit                += this.Application_ApplicationExit;
		AppDomain.CurrentDomain.UnhandledException += this.AppGui_UnhandledException;

		this.projects.CurrentChanged += this.projects_CurrentChanged;
		this.projects.RefreshWith( this.projectList );
		this.cbxProjects.DataSource = this.projects;

		this.md5Sets.CurrentChanged += this.md5Sets_CurrentChanged;
		this.md5Sets.RefreshWith( this.md5SetList );
		this.lbxMd5Sets.DataSource = this.md5Sets;

		this.files.RefreshWith( this.fileList );
		this.lbxFiles.DataSource = this.files;

		this.LoadProjects();
	}

	/// <summary>
	/// Sets all necessary data bindings.
	/// </summary>
	private void SetDataBindings()
	{
		this.tbxNotes.DataBindings.Clear();
		this.tbxPath.DataBindings.Clear();
		this.tbxPatterns.DataBindings.Clear();

		if ( null == this.projects.Current )
		{
			this.tbxNotes.Clear();
			this.tbxPath.Clear();
			this.tbxPatterns.Clear();

			return;
		}

		this.tbxNotes.DataBindings.Add( "Text", this.projects.Current, "Notes" );
		this.tbxPath.DataBindings.Add( "Text", this.projects.Current, "Path" );
		this.tbxPatterns.DataBindings.Add( "Text", this.projects.Current, "Patterns" );
	}

	/// <summary>
	/// Sets the control states.
	/// </summary>
	private void SetControlStates()
	{
		bool enabledState = 0 != this.projects.DataSource.Count;

		this.cbxProjects.Enabled      = enabledState;
		this.tbxNotes.Enabled         = enabledState;
		this.btnRemoveProject.Enabled = enabledState;
		this.tbxPath.Enabled          = enabledState;
		this.tbxPatterns.Enabled      = enabledState;
		this.btnScan.Enabled          = enabledState;
		this.btnPurge.Enabled         = enabledState;
		this.btnFlag.Enabled          = enabledState;
		this.btnDelete.Enabled        = enabledState;
		this.btnEmptyDirs.Enabled     = enabledState;
		this.lbxMd5Sets.Enabled       = enabledState;
		this.lbxFiles.Enabled         = enabledState;
	}

	/// <summary>
	/// Changes the current project.
	/// </summary>
	private void ChangeProject()
	{
		this.SetDataBindings();

		if ( null == this.projects.Current?.Md5Sets )
		{
			this.md5SetList = null;
			this.md5Sets.RefreshWith( null );
			this.fileList = null;
			this.files.RefreshWith( null );

			this.lblTotal.Text = "0";

			return;
		}

		this.md5SetList = this.projects.Current.Md5Sets;
		this.md5Sets.RefreshWith( this.projects.Current.Md5Sets );

		this.lblTotal.Text = this.md5Sets.Count.ToString();
	}

	/// <summary>
	/// Changes the current MD5 set.
	/// </summary>
	private void ChangeMd5Set()
	{
		if ( null == this.md5Sets.Current?.Files )
		{
			this.fileList = null;
			this.files.RefreshWith( null );

			return;
		}

		this.fileList = this.md5Sets.Current.Files;
		this.files.RefreshWith( this.md5Sets.Current.Files );
	}

	/// <summary>
	/// Logs a message.
	/// </summary>
	/// <param name="message">The message to log.</param>
	private void Log( string message )
	{
		this.Invoke(
			() =>
			{
				this.tbxLog.AppendText( $"{message}{Environment.NewLine}" );
			}
		);
	}

	/// <summary>
	/// Logs an error message.
	/// </summary>
	/// <param name="message">The error message to log.</param>
	private void LogError( string message )
	{
		this.Invoke(
			() =>
			{
				this.tbxErrorLog.AppendText( $"{message}{Environment.NewLine}" );
			}
		);
	}

	/// <summary>
	/// Logs an error message to the error file.
	/// </summary>
	/// <param name="message">The error message to log.</param>
	private void LogErrorToFile( string message )
	{
		using FileStream   file         = File.Open( this.errorLogPath, FileMode.Create );
		using StreamWriter streamWriter = new StreamWriter( file );

		streamWriter.WriteLine( message );
	}

	/// <summary>
	/// Loads the projects.
	/// </summary>
	private void LoadProjects()
	{
		this.projectList = new ProjectListJsonFileDeserializer( this.projectsFilePath )
			.Deserialize();

		this.projects.RefreshWith(
			this.projectList
		);

		if ( 0 < this.projects.Count )
		{
			this.md5SetList = this.projects.Current.Md5Sets;
		}

		this.SetControlStates();
	}

	/// <summary>
	/// Saves the projects.
	/// </summary>
	private void SaveProjects()
	{
		new ProjectListJsonFileSerializer( this.projectsFilePath )
			.Serialize( this.projectList! );
	}

	/// <summary>
	/// Adds a new project.
	/// </summary>
	private void AddProject()
	{
		this.projects.Add(
			new Project()
		);

		this.SetControlStates();
	}

	/// <summary>
	/// Removes a project.
	/// </summary>
	private void RemoveProject()
	{
		this.projects.Remove(
			this.projects.Current
		);

		this.SetControlStates();
	}

	/// <summary>
	/// Opens the folder dialog.
	/// </summary>
	private void OpenFolderDialog()
	{
		if ( DialogResult.OK == this.fbdlgPath.ShowDialog( this.Parent ) )
		{
			this.tbxPath.Text = this.fbdlgPath.SelectedPath;
		}
	}

	/// <summary>
	/// Prepares the processing of files.
	/// </summary>
	/// <param name="accumulator">The accumulator to fetch the files to process.</param>
	/// <returns>The accumulated files to process.</returns>
	private FileListInterface PrepareProcessing( Func<IEnumerable<FileInterface>> accumulator )
	{
		FileListInterface filesToProcess = new FileList(
			accumulator()
		);

		this.Invoke(
			() =>
			{
				this.tbxLog.Clear();
				this.pnlLog.Show();
				this.tbxErrorLog.Clear();
				this.pnlErrorLog.Show();

				this.prbrProgress.Value   = 0;
				this.prbrProgress.Maximum = filesToProcess.Count;
				this.prbrProgress.Show();
			}
		);

		this.Log(
			$"Files: {filesToProcess.Count}"
		);

		return filesToProcess;
	}

	/// <summary>
	/// Increases the progress.
	/// </summary>
	private void IncreaseProgress()
	{
		this.Invoke(
			() => this.prbrProgress.Value++
		);
	}

	/// <summary>
	/// Postpares the processing of files.
	/// </summary>
	private void PostpareProcessing()
	{
		this.Invoke(
			() =>
			{
				this.prbrProgress.Hide();
				this.lblTotal.Text = this.md5Sets.Count.ToString();
			}
		);

		this.Log( "---" );
		this.Log( "... finished" );

		this.md5Sets.DataSource.ResetBindings();
	}

	/// <summary>
	/// Scans the directory.
	/// </summary>
	private void Scan()
	{
		Thread thread = new Thread(
			() =>
			{
				FileListInterface filesToProcess = this.PrepareProcessing(
					() => new DirectoryScanner()
						.Scan(
							this.tbxPath.Text,
							this.tbxPatterns.Text.Split( ' ' )
						)
				);

				Dictionary<string, FileListInterface> mappedFiles = new Dictionary<string, FileListInterface>();

				Md5FileChecksumDeterminatorInterface md5FileChecksumDeterminator = new Md5FileChecksumDeterminator();
				foreach ( FileInterface file in filesToProcess )
				{
					try
					{
						this.Log( "---" );
						this.Log( file.Path );

						string determinedMd5Checksum = md5FileChecksumDeterminator.Determine( file );
						bool   md5ChecksumExists     = mappedFiles.ContainsKey( determinedMd5Checksum );

						FileListInterface mappedFileList;
						if ( false == md5ChecksumExists )
						{
							mappedFileList                       = new FileList();
							mappedFiles[ determinedMd5Checksum ] = mappedFileList;
						}
						else
						{
							mappedFileList = mappedFiles[ determinedMd5Checksum ];
						}

						this.Log( "... succeeded" );

						mappedFileList.Add( file );
					}
					catch ( Exception exception )
					{
						this.LogError( "---" );
						this.LogError( file.Path );
						this.LogError( exception.Message );

						this.Log( "... failed" );
					}

					this.IncreaseProgress();
				}

				this.md5SetList = new Md5SetList();
				foreach ( KeyValuePair<string, FileListInterface> keyValuePair in mappedFiles )
				{
					this.md5SetList.Add(
						new Md5Set
						{
							Checksum = keyValuePair.Key,
							Files    = keyValuePair.Value
						}
					);
				}

				this.projects.Current.Md5Sets = this.md5SetList;

				this.md5Sets.Clear();
				this.md5Sets.RefreshWith( this.md5SetList );

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Purges the listing from single file entries.
	/// </summary>
	private void Purge()
	{
		for ( int n = this.md5SetList!.Count - 1; n >= 0; n-- )
		{
			if ( 2 >= this.md5SetList[ n ].Files.Count )
			{
				this.md5SetList.RemoveAt( n );
			}
		}

		this.md5Sets.DataSource.ResetBindings();
		this.lblTotal.Text = this.md5Sets.Count.ToString();
	}

	/// <summary>
	/// Flags all duplicates for deletion.
	/// </summary>
	private void Flag()
	{
		Thread thread = new Thread(
			() =>
			{
				FileListInterface filesToProcess = this.PrepareProcessing(
					() => this
						.md5SetList!
						.SelectMany(
							md5Set => md5Set.Files
						)
				);

				FileFlagger fileFlagger = new FileFlagger();
				for ( int n = 1; n < filesToProcess.Count; n++ )
				{
					this.Log( "---" );
					this.Log( filesToProcess[ n ].Path );

					try
					{
						fileFlagger.Flag( filesToProcess[ n ] );

						this.Log( "... succeeded" );
					}
					catch ( Exception exception )
					{
						this.LogError( "---" );
						this.LogError( filesToProcess[ n ].Path );
						this.LogError( exception.Message );

						this.Log( "... failed" );
					}

					this.IncreaseProgress();
				}

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Deletes all flagged duplicates.
	/// </summary>
	private void Delete()
	{
		Thread thread = new Thread(
			() =>
			{
				FileListInterface filesToProcess = this.PrepareProcessing(
					() => this
						.md5SetList!
						.SelectMany(
							md5Set => md5Set
								.Files
								.Where(
									file => file.FlagDeletion
								)
								.Reverse()
						)
				);

				FileDeleter fileDeleter = new FileDeleter();
				foreach ( FileInterface file in filesToProcess )
				{
					this.Log( "---" );
					this.Log( file.Path );

					try
					{
						fileDeleter.Delete( file );

						this.Log( "... succeeded" );
					}
					catch ( Exception exception )
					{
						this.LogError( "---" );
						this.LogError( file.Path );
						this.LogError( exception.Message );

						this.Log( "... failed" );
					}

					foreach ( Md5SetInterface md5Set in this.md5SetList! )
					{
						md5Set.Files.Remove( file );
					}

					this.IncreaseProgress();
				}

				this.Purge();

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Removes remaining empty directories.
	/// </summary>
	private void RemoveEmptyDirs()
	{
		Thread thread = new Thread(
			() =>
			{
				try
				{
					new RecursivelyEmptyDirectoryRemover()
						.Remove( this.tbxPath.Text );
				}
				catch ( Exception exception )
				{
					this.LogError( "---" );
					this.LogError( exception.Message );

					this.Log( "... failed" );
				}

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Lower cases all file extensions.
	/// </summary>
	private void LowerCaseExtensions()
	{
		Thread thread = new Thread(
			() =>
			{
				FileListInterface filesToProcess = this.PrepareProcessing(
					() => this
						.md5SetList!
						.SelectMany(
							md5Set => md5Set.Files
						)
				);

				FileExtensionLowerCaserInterface fileExtensionLowerCaser = new FileExtensionLowerCaser();
				foreach ( FileInterface file in filesToProcess )
				{
					this.Log( "---" );
					this.Log( file.Path );

					try
					{
						fileExtensionLowerCaser.LowerCase( file );

						this.Log( "... succeeded" );
					}
					catch ( Exception exception )
					{
						this.LogError( "---" );
						this.LogError( file.Path );
						this.LogError( exception.Message );

						this.Log( "... failed" );
					}

					this.IncreaseProgress();
				}

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Renames all files due to their meta data creation date.
	/// </summary>
	private void MetaData()
	{
		Thread thread = new Thread(
			() =>
			{
				FileListInterface filesToProcess = this.PrepareProcessing(
					() => this
						.md5SetList!
						.SelectMany(
							md5Set => md5Set.Files
						)
						.ToList()
				);

				MetaDataCreationDateExtractorInterface metaDataCreationDateExtractor = new MetaDataCreationDateExtractor();
				CreationDateParserInterface            creationDateParser            = new CreationDateParser();
				foreach ( FileInterface file in filesToProcess )
				{
					this.Log( "---" );
					this.Log( file.Path );

					string? creationDate;
					try
					{
						creationDate = metaDataCreationDateExtractor.Extract( file.Path );
					}
					catch ( Exception exception )
					{
						this.IncreaseProgress();

						this.LogError( "---" );
						this.LogError( file.Path );
						this.LogError( exception.Message );

						this.Log( "... failed" );

						continue;
					}

					if ( null == creationDate )
					{
						this.IncreaseProgress();

						this.Log( "... creationDate: <null>" );

						continue;
					}

					this.Log( $"... creationDate: {creationDate}" );

					try
					{
						string  fileDirectory = Path.GetDirectoryName( file.Path )!;
						string  fileExtension = Path.GetExtension( file.Path );
						string? newFileName   = creationDateParser.Parse( creationDate );

						if ( null == newFileName )
						{
							this.IncreaseProgress();

							this.Log( "... newFileName: <null>" );

							continue;
						}

						this.Log( $"... newFileName: {newFileName}" );

						string targetPath = $@"{fileDirectory}\{newFileName}{fileExtension}";

						new FileMover()
							.Move( file.Path, targetPath );

						this.Log( "... succeeded" );

						file.Path = targetPath;
					}
					catch ( Exception exception )
					{
						this.LogError( "---" );
						this.LogError( file.Path );
						this.LogError( $"[{creationDate}] {exception.Message}" );

						this.Log( "... failed" );
					}

					this.IncreaseProgress();
				}

				this.PostpareProcessing();
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Toggles the logs visibility.
	/// </summary>
	private void ToggleLogs()
	{
		this.pnlLog.Visible      = !this.pnlLog.Visible;
		this.pnlErrorLog.Visible = !this.pnlErrorLog.Visible;
	}

	/// <summary>
	/// Represents the event handler if a thread exception occured in the application.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void Application_ThreadException( object sender, ThreadExceptionEventArgs eventArgs )
	{
		this.LogErrorToFile( eventArgs.Exception.Message );
	}

	/// <summary>
	/// Represents the event handler if an application thread exception occured in the application.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void Application_ApplicationExit( object sender, EventArgs eventArgs )
	{
		Application.ThreadException -= this.Application_ThreadException;
	}

	/// <summary>
	/// Represents the event handler if a unhandled exception occured in the app GUI.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void AppGui_UnhandledException( object sender, UnhandledExceptionEventArgs eventArgs )
	{
		this.LogErrorToFile( ( ( Exception ) eventArgs.ExceptionObject ).Message );
	}

	/// <summary>
	/// Represents the event handler if the form has been loaded.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void this_Load( object sender, EventArgs eventArgs )
	{
		this.Initialize();
	}

	/// <summary>
	/// Represents the event handler if the current item of the bound data source of projects has been changed.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void projects_CurrentChanged( object sender, EventArgs eventArgs )
	{
		this.ChangeProject();
	}

	/// <summary>
	/// Represents the event handler if the current item of the bound data source of MD5 sets has been changed.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void md5Sets_CurrentChanged( object sender, EventArgs eventArgs )
	{
		this.ChangeMd5Set();
	}

	/// <summary>
	/// Represents the event handler if the `Load` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnLoad_Click( object sender, EventArgs eventArgs )
	{
		this.LoadProjects();
	}

	/// <summary>
	/// Represents the event handler if the `Save` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnSave_Click( object sender, EventArgs eventArgs )
	{
		this.SaveProjects();
	}

	/// <summary>
	/// Represents the event handler if the current item of the combo box of projects will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void cbxProjects_Format( object sender, ListControlConvertEventArgs eventArgs )
	{
		ProjectInterface project = ( ProjectInterface ) eventArgs.ListItem;

		eventArgs.Value = project.Path;
	}

	/// <summary>
	/// Represents the event handler if the `AddProject` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnAddProject_Click( object sender, EventArgs eventArgs )
	{
		this.AddProject();
	}

	/// <summary>
	/// Represents the event handler if the `RemoveProject` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnRemoveProject_Click( object sender, EventArgs eventArgs )
	{
		this.RemoveProject();
	}

	/// <summary>
	/// Represents the event handler if the text box of the path has been double clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void tbxPath_DoubleClick( object sender, EventArgs eventArgs )
	{
		this.OpenFolderDialog();
	}

	/// <summary>
	/// Represents the event handler if the `Scan` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnScan_Click( object sender, EventArgs eventArgs )
	{
		this.Scan();
	}

	/// <summary>
	/// Represents the event handler if the `Purge` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnPurge_Click( object sender, EventArgs eventArgs )
	{
		this.Purge();
	}

	/// <summary>
	/// Represents the event handler if the `Flag` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnFlag_Click( object sender, EventArgs eventArgs )
	{
		this.Flag();
	}

	/// <summary>
	/// Represents the event handler if the `Delete` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnDelete_Click( object sender, EventArgs eventArgs )
	{
		this.Delete();
	}

	/// <summary>
	/// Represents the event handler if the `Empty Dirs` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnEmptyDirs_Click( object sender, EventArgs eventArgs )
	{
		this.RemoveEmptyDirs();
	}

	/// <summary>
	/// Represents the event handler if the `Lower Case` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnLowerCase_Click( object sender, EventArgs eventArgs )
	{
		this.LowerCaseExtensions();
	}

	/// <summary>
	/// Represents the event handler if the `ExIf` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnMetaData_Click( object sender, EventArgs eventArgs )
	{
		this.MetaData();
	}

	/// <summary>
	/// Represents the event handler if the `Log` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void btnLog_Click( object sender, EventArgs eventArgs )
	{
		this.ToggleLogs();
	}

	/// <summary>
	/// Represents the event handler if the current item of the list box of MD5 sets will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void lbxMd5Sets_Format( object sender, ListControlConvertEventArgs eventArgs )
	{
		Md5SetInterface md5Set = ( Md5SetInterface ) eventArgs.ListItem;
		string index = this
			.md5Sets
			.IndexOf( md5Set )
			.ToString()
			.PadLeft(
				this
					.md5Sets
					.Count
					.ToString()
					.Length
			);

		eventArgs.Value = $"{index} :: {md5Set.Checksum}";
	}

	/// <summary>
	/// Represents the event handler if the current item of the list box of files will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void lbxFiles_Format( object sender, ListControlConvertEventArgs eventArgs )
	{
		FileInterface file = ( FileInterface ) eventArgs.ListItem;
		char prefix = false == file.FlagDeletion
			? '+'
			: '-';
		eventArgs.Value = $"{prefix} {file.Path}";
	}

	/// <summary>
	/// Represents the event handler if the list box of files has been double clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArgs">The arguments of the event.</param>
	private void lbxFiles_MouseDoubleClick( object sender, MouseEventArgs eventArgs )
	{
		int index = this.lbxFiles.IndexFromPoint( eventArgs.Location );
		if ( index != ListBox.NoMatches )
		{
			this.files[ index ].FlagDeletion = !this.files.Current.FlagDeletion;
		}
	}
}
