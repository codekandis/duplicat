using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CodeKandis.DupliCat.Data;
using CodeKandis.DupliCat.Io;
using CodeKandis.DupliCat.Serialization.Json;
using SharpKandis.Collections.Generic;
using SharpKandis.Windows.Forms;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Forms
{
	/// <summary>
	/// Represents the main form of the application.
	/// </summary>
	internal partial class Main:
		Form
	{
		/// <summary>
		/// Represents the path of the listing.
		/// </summary>
		private const string ListingPath = @"D:\development\csharp\codekandis\projects\DupliCat\DupliCat\listing.json";

		/// <summary>
		/// Stores the bindable data source of MD5 sets.
		/// </summary>
		private BindableDataSource<Md5SetInterface> md5Sets;

		/// <summary>
		/// Stores the MD5 sets.
		/// </summary>
		private Md5SetListInterface md5SetList = new Md5SetList();

		/// <summary>
		/// Stores the bindable data source of files.
		/// </summary>
		private BindableDataSource<FileInterface> files;

		/// <summary>
		/// Stores the files.
		/// </summary>
		private readonly FileListInterface fileList = new FileList();

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
			this.md5Sets = new BindableDataSource<Md5SetInterface>();
			this.md5Sets.CurrentChanged += this.md5Sets_CurrentChanged;
			this.md5Sets.RefreshWith( this.md5SetList );
			this.lbxMd5Sets.DataSource = this.md5Sets;

			this.files = new BindableDataSource<FileInterface>();
			this.files.RefreshWith( this.fileList );
			this.lbxFiles.DataSource = this.files;

			this.LoadListing();
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
		/// Loads the listing.
		/// </summary>
		private void LoadListing()
		{
			this.md5SetList = new Md5SetListJsonFileDeserializer( Main.ListingPath )
				.Deserialize();

			this.md5Sets.RefreshWith(
				this.md5SetList
			);

			this.lblTotal.Text = this.md5Sets.Count.ToString();
		}

		/// <summary>
		/// Saves the listing.
		/// </summary>
		private void SaveListing()
		{
			new Md5SetListJsonFileSerializer( Main.ListingPath )
				.Serialize( this.md5SetList );
		}

		/// <summary>
		/// Toggles the log visibility.
		/// </summary>
		private void ToggleLog()
		{
			this.pnlLog.Visible = !this.pnlLog.Visible;
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
							this.prbrScanning.Value = 0;
							this.prbrScanning.Show();
						}
					);

					Dictionary<string, FileListInterface> mappedFiles = new Dictionary<string, FileListInterface>();

					FileListInterface scannedFileList = new DirectoryScanner(
							this.tbxPath.Text,
							this.tbxPatterns.Text.Split( ' ' )
						)
						.Scan();

					this.Invoke(
						() =>
						{
							this.prbrScanning.Maximum = scannedFileList.Count;
						}
					);
					this.Log(
						$"Files: {scannedFileList.Count}"
					);

					foreach ( FileInterface file in scannedFileList )
					{
						try
						{
							this.Log( file.Path );

							string determinedMd5Checksum = new Md5FileChecksumDeterminator( file )
								.Determine();
							bool md5ChecksumExists = mappedFiles.ContainsKey( determinedMd5Checksum );

							FileListInterface mappedFileList;
							if ( false == md5ChecksumExists )
							{
								mappedFileList = new FileList();
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
								this.prbrScanning.Value++;
							}
						);
					}

					this.md5SetList = new Md5SetList();
					foreach ( KeyValuePair<string, FileListInterface> keyValuePair in mappedFiles )
					{
						this.md5SetList.Add(
							new Md5Set(
								keyValuePair.Key,
								keyValuePair.Value
							)
						);
					}

					this.md5Sets.Clear();
					this.md5Sets.RefreshWith( this.md5SetList );


					this.Invoke(
						() =>
						{
							this.prbrScanning.Hide();

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
		/// Marks all duplicates for deletion.
		/// </summary>
		private void Mark()
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
		/// Deletes all marked duplicates.
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
			new RecursivelyEmptyDirectoryRemover( this.tbxPath.Text )
				.Remove();
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
		/// Represents the event handler if the current item of the bound data source of MD5 sets has been changed.
		/// </summary>
		/// <param name="sender">The object which raised the event.</param>
		/// <param name="eventArguments">The arguments of the event.</param>
		private void md5Sets_CurrentChanged( object sender, EventArgs eventArguments )
		{
			this.files.RefreshWith( this.md5Sets.Current.Files );
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
		/// Represents the event handler if the `Mark` button has been clicked.
		/// </summary>
		/// <param name="sender">The object which raised the event.</param>
		/// <param name="eventArguments">The arguments of the event.</param>
		private void btnMark_Click( object sender, EventArgs eventArguments )
		{
			this.Mark();
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
		/// Represents the event handler if the `Load` button has been clicked.
		/// </summary>
		/// <param name="sender">The object which raised the event.</param>
		/// <param name="eventArguments">The arguments of the event.</param>
		private void btnLoad_Click( object sender, EventArgs eventArguments )
		{
			this.LoadListing();
		}

		/// <summary>
		/// Represents the event handler if the `Save` button has been clicked.
		/// </summary>
		/// <param name="sender">The object which raised the event.</param>
		/// <param name="eventArguments">The arguments of the event.</param>
		private void btnSave_Click( object sender, EventArgs eventArguments )
		{
			this.SaveListing();
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
		/// Represents the event handler if the text box of the path has been double clicked.
		/// </summary>
		/// <param name="sender">The object which raised the event.</param>
		/// <param name="eventArguments">The arguments of the event.</param>
		private void tbxPath_DoubleClick( object sender, EventArgs eventArguments )
		{
			if ( DialogResult.OK == this.fbdlgPath.ShowDialog( this.Parent ) )
			{
				this.tbxPath.Text = this.fbdlgPath.SelectedPath;
			}
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
		/// Represents the event handler if the current item of the list box of files sets will be formatted.
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
}
