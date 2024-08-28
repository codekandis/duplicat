namespace CodeKandis.DupliCat.Forms
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label label1;
			this.btnScan = new System.Windows.Forms.Button();
			this.lbxFiles = new System.Windows.Forms.ListBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.lbxMd5Sets = new System.Windows.Forms.ListBox();
			this.tbxPath = new SharpKandis.Windows.Forms.TextBoxPlaceholder();
			this.pnlLog = new System.Windows.Forms.Panel();
			this.tbxLog = new System.Windows.Forms.TextBox();
			this.btnLog = new System.Windows.Forms.Button();
			this.btnPurge = new System.Windows.Forms.Button();
			this.prbrScanning = new System.Windows.Forms.ProgressBar();
			this.lblTotal = new System.Windows.Forms.Label();
			this.btnMark = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.tbxPatterns = new SharpKandis.Windows.Forms.TextBoxPlaceholder();
			this.fbdlgPath = new System.Windows.Forms.FolderBrowserDialog();
			label1 = new System.Windows.Forms.Label();
			this.pnlLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point( 12, 38 );
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size( 34, 13 );
			label1.TabIndex = 14;
			label1.Text = "Total:";
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point( 1457, 11 );
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size( 76, 22 );
			this.btnScan.TabIndex = 2;
			this.btnScan.Text = "Scan";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler( this.btnScan_Click );
			// 
			// lbxFiles
			// 
			this.lbxFiles.Font = new System.Drawing.Font( "Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
			this.lbxFiles.FormattingEnabled = true;
			this.lbxFiles.IntegralHeight = false;
			this.lbxFiles.Location = new System.Drawing.Point( 1000, 54 );
			this.lbxFiles.Name = "lbxFiles";
			this.lbxFiles.Size = new System.Drawing.Size( 982, 905 );
			this.lbxFiles.TabIndex = 4;
			this.lbxFiles.Format += new System.Windows.Forms.ListControlConvertEventHandler( this.lbxFiles_Format );
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point( 1832, 11 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 76, 22 );
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// lbxMd5Sets
			// 
			this.lbxMd5Sets.DisplayMember = "Checksum";
			this.lbxMd5Sets.Font = new System.Drawing.Font( "Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
			this.lbxMd5Sets.FormattingEnabled = true;
			this.lbxMd5Sets.IntegralHeight = false;
			this.lbxMd5Sets.Location = new System.Drawing.Point( 12, 54 );
			this.lbxMd5Sets.Name = "lbxMd5Sets";
			this.lbxMd5Sets.Size = new System.Drawing.Size( 982, 905 );
			this.lbxMd5Sets.TabIndex = 7;
			// 
			// tbxPath
			// 
			this.tbxPath.Location = new System.Drawing.Point( 12, 12 );
			this.tbxPath.Name = "tbxPath";
			this.tbxPath.PlaceholderText = "Path";
			this.tbxPath.Size = new System.Drawing.Size( 1144, 20 );
			this.tbxPath.TabIndex = 8;
			this.tbxPath.DoubleClick += new System.EventHandler( this.tbxPath_DoubleClick );
			// 
			// pnlLog
			// 
			this.pnlLog.Controls.Add( this.tbxLog );
			this.pnlLog.Location = new System.Drawing.Point( 62, 104 );
			this.pnlLog.Name = "pnlLog";
			this.pnlLog.Size = new System.Drawing.Size( 882, 805 );
			this.pnlLog.TabIndex = 11;
			this.pnlLog.Visible = false;
			// 
			// tbxLog
			// 
			this.tbxLog.Location = new System.Drawing.Point( 3, 3 );
			this.tbxLog.Multiline = true;
			this.tbxLog.Name = "tbxLog";
			this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbxLog.Size = new System.Drawing.Size( 876, 799 );
			this.tbxLog.TabIndex = 0;
			this.tbxLog.WordWrap = false;
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point( 1907, 11 );
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size( 76, 22 );
			this.btnLog.TabIndex = 12;
			this.btnLog.Text = "Log";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler( this.btnLog_Click );
			// 
			// btnPurge
			// 
			this.btnPurge.Location = new System.Drawing.Point( 1532, 11 );
			this.btnPurge.Name = "btnPurge";
			this.btnPurge.Size = new System.Drawing.Size( 76, 22 );
			this.btnPurge.TabIndex = 13;
			this.btnPurge.Text = "Purge";
			this.btnPurge.UseVisualStyleBackColor = true;
			this.btnPurge.Click += new System.EventHandler( this.btnPurge_Click );
			// 
			// prbrScanning
			// 
			this.prbrScanning.Location = new System.Drawing.Point( 12, 25 );
			this.prbrScanning.Name = "prbrScanning";
			this.prbrScanning.Size = new System.Drawing.Size( 1144, 10 );
			this.prbrScanning.Step = 1;
			this.prbrScanning.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.prbrScanning.TabIndex = 10;
			this.prbrScanning.Visible = false;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point( 42, 38 );
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size( 13, 13 );
			this.lblTotal.TabIndex = 15;
			this.lblTotal.Text = "0";
			// 
			// btnMark
			// 
			this.btnMark.Location = new System.Drawing.Point( 1607, 11 );
			this.btnMark.Name = "btnMark";
			this.btnMark.Size = new System.Drawing.Size( 76, 22 );
			this.btnMark.TabIndex = 16;
			this.btnMark.Text = "Mark";
			this.btnMark.UseVisualStyleBackColor = true;
			this.btnMark.Click += new System.EventHandler( this.btnMark_Click );
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point( 1682, 11 );
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size( 76, 22 );
			this.btnDelete.TabIndex = 17;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point( 1757, 11 );
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size( 76, 22 );
			this.btnLoad.TabIndex = 18;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler( this.btnLoad_Click );
			// 
			// tbxPatterns
			// 
			this.tbxPatterns.Location = new System.Drawing.Point( 1157, 12 );
			this.tbxPatterns.Name = "tbxPatterns";
			this.tbxPatterns.PlaceholderText = "Patterns";
			this.tbxPatterns.Size = new System.Drawing.Size( 300, 20 );
			this.tbxPatterns.TabIndex = 19;
			// 
			// fbdlgPath
			// 
			this.fbdlgPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.fbdlgPath.ShowNewFolderButton = false;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 1994, 971 );
			this.Controls.Add( this.tbxPatterns );
			this.Controls.Add( this.btnLoad );
			this.Controls.Add( this.btnDelete );
			this.Controls.Add( this.btnMark );
			this.Controls.Add( this.lblTotal );
			this.Controls.Add( label1 );
			this.Controls.Add( this.btnPurge );
			this.Controls.Add( this.btnLog );
			this.Controls.Add( this.pnlLog );
			this.Controls.Add( this.tbxPath );
			this.Controls.Add( this.lbxMd5Sets );
			this.Controls.Add( this.prbrScanning );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.lbxFiles );
			this.Controls.Add( this.btnScan );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.Load += new System.EventHandler( this.this_Load );
			this.pnlLog.ResumeLayout( false );
			this.pnlLog.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();
		}

		private System.Windows.Forms.FolderBrowserDialog fbdlgPath;

		private SharpKandis.Windows.Forms.TextBoxPlaceholder tbxPatterns;

		private System.Windows.Forms.Button btnDelete;

		private System.Windows.Forms.Button btnLoad;

		private System.Windows.Forms.Button btnMark;

		private System.Windows.Forms.Label lblTotal;

		private System.Windows.Forms.Button btnPurge;

		private System.Windows.Forms.Button btnLog;

		private System.Windows.Forms.TextBox tbxLog;

		private System.Windows.Forms.Panel pnlLog;

		private System.Windows.Forms.ProgressBar prbrScanning;

		private System.Windows.Forms.Button btnSave;

		private System.Windows.Forms.ListBox lbxFiles;

		private System.Windows.Forms.ListBox lbxMd5Sets;

		private System.Windows.Forms.Button btnScan;

		private SharpKandis.Windows.Forms.TextBoxPlaceholder tbxPath;

		#endregion
	}
}