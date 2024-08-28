﻿using System;
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
	internal partial class Main: Form
	{
		private const string ListingPath = @"D:\development\csharp\codekandis\projects\DupliCat\DupliCat\listing.json";

		private BindableDataSource<Md5SetInterface> md5Sets;

		private Md5SetListInterface md5SetList = new Md5SetList();

		private BindableDataSource<FileInterface> files;

		private readonly FileListInterface fileList = new FileList();

		public Main()
		{
			this.InitializeComponent();
		}

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

		private void Log( string message )
		{
			this.tbxLog.AppendText( message );
			this.tbxLog.AppendText( Environment.NewLine );
			this.Refresh();
		}

		private void LoadListing()
		{
			this.md5SetList = new Md5SetListJsonFileDeserializer( Main.ListingPath )
				.Deserialize();

			this.md5Sets.RefreshWith(
				this.md5SetList
			);

			this.lblTotal.Text = this.md5Sets.Count.ToString();
		}

		private void SaveListing()
		{
			new Md5SetListJsonFileSerializer( Main.ListingPath )
				.Serialize( this.md5SetList );
		}

		private void ToggleLog()
		{
			this.pnlLog.Visible = !this.pnlLog.Visible;
		}

		private void Scan()
		{
			Thread thread = new Thread(
				() =>
				{
					this.tbxLog.Clear();
					this.prbrScanning.Value = 0;
					this.prbrScanning.Show();
					this.Refresh();

					Dictionary<string, FileListInterface> mappedFiles = new Dictionary<string, FileListInterface>();

					FileListInterface scannedFileList = new DirectoryScanner( this.tbxPath.Text )
						.Scan();

					this.prbrScanning.Maximum = scannedFileList.Count;
					this.Log(
						$"Files: {scannedFileList.Count}"
					);

					scannedFileList.ForEach( file =>
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

							this.prbrScanning.Value++;
							this.Refresh();
						}
					);

					this.md5SetList = new Md5SetList();
					mappedFiles.ForEach( keyValuePair =>
						{
							this.md5SetList.Add(
								new Md5Set(
									keyValuePair.Key,
									keyValuePair.Value
								)
							);
						}
					);

					this.md5Sets.Clear();
					this.md5Sets.RefreshWith( this.md5SetList );

					this.prbrScanning.Hide();

					this.lblTotal.Text = this.md5Sets.Count.ToString();
				}
			);
			thread.Start();
		}

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

		private void Mark()
		{
			this.md5SetList.ForEach(
				( Md5SetInterface md5Set ) =>
				{
					for ( int n = 1; n < md5Set.Files.Count; n++ )
					{
						md5Set.Files[ n ].FlagDeletion = true;
					}
				}
			);

			this.md5Sets.DataSource.ResetBindings();
		}

		private void Delete()
		{
			this.md5SetList.ForEach(
				( Md5SetInterface md5Set ) =>
				{
					md5Set
						.Files
						.Where(
							( FileInterface file ) =>
							{
								return true == file.FlagDeletion;
							}
						)
						.Reverse()
						.ForEach(
							( FileInterface file ) =>
							{
								if ( true == File.Exists( file.Path ) )
								{
									File.Delete( file.Path );
								}

								md5Set.Files.Remove( file );
							}
						);
				}
			);

			this.md5Sets.DataSource.ResetBindings();
		}

		private void this_Load( object sender, EventArgs eventArguments )
		{
			this.Initialize();
		}

		private void md5Sets_CurrentChanged( object sender, EventArgs eventArguments )
		{
			this.files.RefreshWith( this.md5Sets.Current.Files );
		}

		private void btnScan_Click( object sender, EventArgs eventArguments )
		{
			this.Scan();
		}

		private void btnPurge_Click( object sender, EventArgs eventArguments )
		{
			this.Purge();
		}

		private void btnMark_Click( object sender, EventArgs eventArguments )
		{
			this.Mark();
		}

		private void btnDelete_Click( object sender, EventArgs e )
		{
			this.Delete();
		}

		private void btnLoad_Click( object sender, EventArgs e )
		{
			this.LoadListing();
		}

		private void btnSave_Click( object sender, EventArgs eventArguments )
		{
			this.SaveListing();
		}

		private void btnLog_Click( object sender, EventArgs eventArguments )
		{
			this.ToggleLog();
		}

		private void lbxFiles_Format( object sender, ListControlConvertEventArgs eventArguments )
		{
			FileInterface file = ( FileInterface ) eventArguments.ListItem;
			char prefix = false == file.FlagDeletion
				? '+'
				: '-';
			eventArguments.Value = $"{prefix} {file.Path}";
		}
	}
}
