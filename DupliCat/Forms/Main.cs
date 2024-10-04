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
using SharpKandis.Collections.Generic;
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
	private ProjectListInterface projectList = new ProjectList();

	/// <summary>
	/// Stores the bindable data source of projects.
	/// </summary>
	private BindableDataSource<ProjectInterface> projects;

	/// <summary>
	/// Stores the MD5 sets.
	/// </summary>
	private Md5SetListInterface md5SetList = new Md5SetList();

	/// <summary>
	/// Stores the bindable data source of MD5 sets.
	/// </summary>
	private BindableDataSource<Md5SetInterface> md5Sets;

	/// <summary>
	/// Stores the files.
	/// </summary>
	private FileListInterface fileList = new FileList();

	/// <summary>
	/// Stores the bindable data source of files.
	/// </summary>
	private BindableDataSource<FileInterface> files;

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
		this.projects                =  new BindableDataSource<ProjectInterface>();
		this.projects.CurrentChanged += this.projects_CurrentChanged;
		this.projects.RefreshWith( this.projectList );
		this.cbxProjects.DataSource = this.projects;

		this.md5Sets                =  new BindableDataSource<Md5SetInterface>();
		this.md5Sets.CurrentChanged += this.md5Sets_CurrentChanged;
		this.md5Sets.RefreshWith( this.md5SetList );
		this.lbxMd5Sets.DataSource = this.md5Sets;

		this.files = new BindableDataSource<FileInterface>();
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
				this.tbxLog.AppendText( message );
				this.tbxLog.AppendText( Environment.NewLine );
			}
		);
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
			.Serialize( this.projectList );
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
	/// Scans the directory.
	/// </summary>
	private void Scan()
	{
		Thread thread = new Thread(
			() =>
			{
				this.Invoke(
					() =>
					{
						this.tbxLog.Clear();
						this.prbrProgress.Value = 0;
						this.prbrProgress.Show();
					}
				);

				Dictionary<string, FileListInterface> mappedFiles = new Dictionary<string, FileListInterface>();

				FileListInterface scannedFileList = new DirectoryScanner()
					.Scan(
						this.tbxPath.Text,
						this.tbxPatterns.Text.Split( ' ' )
					);

				this.Invoke(
					() =>
					{
						this.prbrProgress.Maximum = scannedFileList.Count;
					}
				);
				this.Log(
					$"Files: {scannedFileList.Count}"
				);

				Md5FileChecksumDeterminatorInterface md5FileChecksumDeterminator = new Md5FileChecksumDeterminator();
				foreach ( FileInterface file in scannedFileList )
				{
					try
					{
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
					catch ( Exception )
					{
						this.Log( "... failed" );
					}

					this.Invoke(
						() =>
						{
							this.prbrProgress.Value++;
						}
					);
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

				this.Invoke(
					() =>
					{
						this.prbrProgress.Hide();

						this.lblTotal.Text = this.md5Sets.Count.ToString();
					}
				);
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Purges the listing from single file entries.
	/// </summary>
	private void Purge()
	{
		for ( int n = this.md5SetList.Count - 1; n >= 0; n-- )
		{
			if ( 1 == this.md5SetList[ n ].Files.Count )
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
		foreach ( Md5SetInterface md5Set in this.md5SetList )
		{
			for ( int n = 1; n < md5Set.Files.Count; n++ )
			{
				md5Set.Files[ n ].FlagDeletion = true;
			}
		}

		this.md5Sets.DataSource.ResetBindings();
	}

	/// <summary>
	/// Deletes all flagged duplicates.
	/// </summary>
	private void Delete()
	{
		foreach ( Md5SetInterface md5Set in this.md5SetList )
		{
			md5Set
				.Files
				.Where(
					file =>
					{
						return file.FlagDeletion;
					}
				)
				.Reverse()
				.ForEach(
					file =>
					{
						if ( File.Exists( file.Path ) )
						{
							File.Delete( file.Path );
						}

						md5Set.Files.Remove( file );
					}
				);
		}

		this.md5Sets.DataSource.ResetBindings();
	}

	/// <summary>
	/// Removes remaining empty directories.
	/// </summary>
	private void RemoveEmptyDirs()
	{
		new RecursivelyEmptyDirectoryRemover()
			.Remove( this.tbxPath.Text );
	}

	/// <summary>
	/// Lower cases all file extensions.
	/// </summary>
	private void LowerCaseExtensions()
	{
		FileExtensionLowerCaserInterface fileExtensionLowerCaser = new FileExtensionLowerCaser();

		foreach ( Md5SetInterface md5Set in this.md5SetList )
		{
			foreach ( FileInterface file in md5Set.Files )
			{
				file.Path = fileExtensionLowerCaser.LowerCase( file.Path );
			}
		}

		this.md5Sets.DataSource.ResetBindings();
	}

	/// <summary>
	/// Renames all file due to their meta data creation date.
	/// </summary>
	private void MetaData()
	{
		Thread thread = new Thread(
			() =>
			{
				this.Invoke(
					() =>
					{
						this.tbxLog.Clear();
						this.prbrProgress.Value = 0;
						this.prbrProgress.Show();
					}
				);

				MetaDataCreationDateExtractorInterface metaDataCreationDateExtractor = new MetaDataCreationDateExtractor();
				int filesCount = this
					.md5SetList
					.SelectMany(
						md5Set => md5Set.Files
					)
					.Count();

				this.Invoke(
					() =>
					{
						this.prbrProgress.Maximum = filesCount;
					}
				);
				this.Log(
					$"Files: {this.files.Count}"
				);

				foreach ( Md5SetInterface md5Set in this.md5SetList )
				{
					foreach ( FileInterface file in md5Set.Files )
					{
						this.Log( file.Path );

						string creationDate = metaDataCreationDateExtractor.Extract( file.Path );

						if ( null == creationDate )
						{
							this.Log( "... <null>" );
						}
						else
						{
							this.Log( $"... {creationDate}" );

							string fileDirectory = Path.GetDirectoryName( file.Path );
							string fileExtension = Path.GetExtension( file.Path );
							string newFileName = DateTime
								.ParseExact( creationDate, "yyyy:MM:dd HH:mm:ss", null )
								.ToString( "yyyy-MM-dd HH.mm.ss" );

							try
							{
								string targetPath = $@"{fileDirectory}\{newFileName}{fileExtension}";

								new FileMover()
									.Move( file.Path, targetPath );

								this.Log( "... succeeded" );

								file.Path = targetPath;
							}
							catch ( Exception )
							{
								this.Log( "... failed" );
							}
						}

						this.Invoke(
							() =>
							{
								this.prbrProgress.Value++;
							}
						);
					}
				}

				this.Invoke(
					() =>
					{
						this.prbrProgress.Hide();
					}
				);
			}
		);
		thread.Start();
	}

	/// <summary>
	/// Toggles the log visibility.
	/// </summary>
	private void ToggleLog()
	{
		this.pnlLog.Visible = !this.pnlLog.Visible;
	}

	/// <summary>
	/// Represents the event handler if the form has been loaded.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void this_Load( object sender, EventArgs eventArguments )
	{
		this.Initialize();
	}

	/// <summary>
	/// Represents the event handler if the current item of the bound data source of projects has been changed.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void projects_CurrentChanged( object sender, EventArgs eventArguments )
	{
		this.ChangeProject();
	}

	/// <summary>
	/// Represents the event handler if the current item of the bound data source of MD5 sets has been changed.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void md5Sets_CurrentChanged( object sender, EventArgs eventArguments )
	{
		this.ChangeMd5Set();
	}

	/// <summary>
	/// Represents the event handler if the `Load` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnLoad_Click( object sender, EventArgs eventArguments )
	{
		this.LoadProjects();
	}

	/// <summary>
	/// Represents the event handler if the `Save` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnSave_Click( object sender, EventArgs eventArguments )
	{
		this.SaveProjects();
	}

	/// <summary>
	/// Represents the event handler if the current item of the combo box of projects will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void cbxProjects_Format( object sender, ListControlConvertEventArgs eventArguments )
	{
		ProjectInterface project = ( ProjectInterface ) eventArguments.ListItem;

		eventArguments.Value = project.Path;
	}

	/// <summary>
	/// Represents the event handler if the `AddProject` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnAddProject_Click( object sender, EventArgs eventArguments )
	{
		this.AddProject();
	}

	/// <summary>
	/// Represents the event handler if the `RemoveProject` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnRemoveProject_Click( object sender, EventArgs eventArguments )
	{
		this.RemoveProject();
	}

	/// <summary>
	/// Represents the event handler if the text box of the path has been double clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void tbxPath_DoubleClick( object sender, EventArgs eventArguments )
	{
		this.OpenFolderDialog();
	}

	/// <summary>
	/// Represents the event handler if the `Scan` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnScan_Click( object sender, EventArgs eventArguments )
	{
		this.Scan();
	}

	/// <summary>
	/// Represents the event handler if the `Purge` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnPurge_Click( object sender, EventArgs eventArguments )
	{
		this.Purge();
	}

	/// <summary>
	/// Represents the event handler if the `Flag` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnFlag_Click( object sender, EventArgs eventArguments )
	{
		this.Flag();
	}

	/// <summary>
	/// Represents the event handler if the `Delete` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnDelete_Click( object sender, EventArgs eventArguments )
	{
		this.Delete();
	}

	/// <summary>
	/// Represents the event handler if the `Empty Dirs` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnEmptyDirs_Click( object sender, EventArgs eventArguments )
	{
		this.RemoveEmptyDirs();
	}

	/// <summary>
	/// Represents the event handler if the `Lower Case` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnLowerCase_Click( object sender, EventArgs eventArguments )
	{
		this.LowerCaseExtensions();
	}

	/// <summary>
	/// Represents the event handler if the `ExIf` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnMetaData_Click( object sender, EventArgs eventArguments )
	{
		this.MetaData();
	}

	/// <summary>
	/// Represents the event handler if the `Log` button has been clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void btnLog_Click( object sender, EventArgs eventArguments )
	{
		this.ToggleLog();
	}

	/// <summary>
	/// Represents the event handler if the current item of the list box of MD5 sets will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void lbxMd5Sets_Format( object sender, ListControlConvertEventArgs eventArguments )
	{
		Md5SetInterface md5Set = ( Md5SetInterface ) eventArguments.ListItem;
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

		eventArguments.Value = $"{index} :: {md5Set.Checksum}";
	}

	/// <summary>
	/// Represents the event handler if the current item of the list box of files will be formatted.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void lbxFiles_Format( object sender, ListControlConvertEventArgs eventArguments )
	{
		FileInterface file = ( FileInterface ) eventArguments.ListItem;
		char prefix = false == file.FlagDeletion
			? '+'
			: '-';
		eventArguments.Value = $"{prefix} {file.Path}";
	}

	/// <summary>
	/// Represents the event handler if the list box of files has been double clicked.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The arguments of the event.</param>
	private void lbxFiles_MouseDoubleClick( object sender, MouseEventArgs eventArguments )
	{
		int index = this.lbxFiles.IndexFromPoint( eventArguments.Location );
		if ( index != ListBox.NoMatches )
		{
			this.files[ index ].FlagDeletion = !this.files.Current.FlagDeletion;
		}
	}
}
