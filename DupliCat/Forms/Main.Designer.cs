﻿namespace CodeKandis.DupliCat.Forms
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
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			this.btnScan          = new System.Windows.Forms.Button();
			this.lbxFiles         = new System.Windows.Forms.ListBox();
			this.btnSave          = new System.Windows.Forms.Button();
			this.lbxMd5Sets       = new System.Windows.Forms.ListBox();
			this.tbxPath          = new SharpKandis.Windows.Forms.TextBoxPlaceholder();
			this.pnlLog           = new System.Windows.Forms.Panel();
			this.tbxLog           = new System.Windows.Forms.TextBox();
			this.btnLog           = new System.Windows.Forms.Button();
			this.btnPurge         = new System.Windows.Forms.Button();
			this.prbrProgress     = new System.Windows.Forms.ProgressBar();
			this.lblTotal         = new System.Windows.Forms.Label();
			this.btnFlag          = new System.Windows.Forms.Button();
			this.btnDelete        = new System.Windows.Forms.Button();
			this.btnLoad          = new System.Windows.Forms.Button();
			this.tbxPatterns      = new SharpKandis.Windows.Forms.TextBoxPlaceholder();
			this.fbdlgPath        = new System.Windows.Forms.FolderBrowserDialog();
			this.btnEmptyDirs     = new System.Windows.Forms.Button();
			this.cbxProjects      = new System.Windows.Forms.ComboBox();
			this.btnAddProject    = new System.Windows.Forms.Button();
			this.btnRemoveProject = new System.Windows.Forms.Button();
			this.tbxNotes         = new SharpKandis.Windows.Forms.TextBoxPlaceholder();
			this.btnLowerCase     = new System.Windows.Forms.Button();
			this.btnMetaData      = new System.Windows.Forms.Button();
			this.pnlErrorLog      = new System.Windows.Forms.Panel();
			this.tbxErrorLog      = new System.Windows.Forms.TextBox();
			label1                = new System.Windows.Forms.Label();
			label2                = new System.Windows.Forms.Label();
			label3                = new System.Windows.Forms.Label();
			this.pnlLog.SuspendLayout();
			this.pnlErrorLog.SuspendLayout();
			this.SuspendLayout();

			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point( 12, 38 );
			label1.Name     = "label1";
			label1.Size     = new System.Drawing.Size( 34, 13 );
			label1.TabIndex = 14;
			label1.Text     = "Total:";

			// 
			// btnScan
			// 
			this.btnScan.Location =  new System.Drawing.Point( 1381, 11 );
			this.btnScan.Name     =  "btnScan";
			this.btnScan.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnScan.TabIndex =  8;
			this.btnScan.Text     =  "Scan";
			this.btnScan.Click    += new System.EventHandler( this.btnScan_Click );

			// 
			// lbxFiles
			// 
			this.lbxFiles.Font              =  new System.Drawing.Font( "Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
			this.lbxFiles.FormattingEnabled =  true;
			this.lbxFiles.IntegralHeight    =  false;
			this.lbxFiles.Location          =  new System.Drawing.Point( 1000, 55 );
			this.lbxFiles.Name              =  "lbxFiles";
			this.lbxFiles.Size              =  new System.Drawing.Size( 982, 904 );
			this.lbxFiles.TabIndex          =  16;
			this.lbxFiles.Format            += new System.Windows.Forms.ListControlConvertEventHandler( this.lbxFiles_Format );
			this.lbxFiles.MouseDoubleClick  += new System.Windows.Forms.MouseEventHandler( this.lbxFiles_MouseDoubleClick );

			// 
			// btnSave
			// 
			this.btnSave.Location =  new System.Drawing.Point( 32, 11 );
			this.btnSave.Name     =  "btnSave";
			this.btnSave.Size     =  new System.Drawing.Size( 22, 22 );
			this.btnSave.TabIndex =  5;
			this.btnSave.Text     =  "📥";
			this.btnSave.Click    += new System.EventHandler( this.btnSave_Click );

			// 
			// lbxMd5Sets
			// 
			this.lbxMd5Sets.Font              =  new System.Drawing.Font( "Fira Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 0 ) ) );
			this.lbxMd5Sets.FormattingEnabled =  true;
			this.lbxMd5Sets.IntegralHeight    =  false;
			this.lbxMd5Sets.Location          =  new System.Drawing.Point( 12, 55 );
			this.lbxMd5Sets.Name              =  "lbxMd5Sets";
			this.lbxMd5Sets.Size              =  new System.Drawing.Size( 982, 904 );
			this.lbxMd5Sets.TabIndex          =  15;
			this.lbxMd5Sets.Format            += new System.Windows.Forms.ListControlConvertEventHandler( this.lbxMd5Sets_Format );

			// 
			// tbxPath
			// 
			this.tbxPath.Location        =  new System.Drawing.Point( 566, 12 );
			this.tbxPath.Name            =  "tbxPath";
			this.tbxPath.PlaceholderText =  "Path";
			this.tbxPath.Size            =  new System.Drawing.Size( 614, 20 );
			this.tbxPath.TabIndex        =  6;
			this.tbxPath.DoubleClick     += new System.EventHandler( this.tbxPath_DoubleClick );

			// 
			// pnlLog
			// 
			this.pnlLog.BackColor   = System.Drawing.SystemColors.ControlLight;
			this.pnlLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLog.Controls.Add( label2 );
			this.pnlLog.Controls.Add( this.tbxLog );
			this.pnlLog.Location = new System.Drawing.Point( 62, 105 );
			this.pnlLog.Name     = "pnlLog";
			this.pnlLog.Size     = new System.Drawing.Size( 882, 804 );
			this.pnlLog.TabIndex = 11;
			this.pnlLog.Visible  = false;

			// 
			// tbxLog
			// 
			this.tbxLog.Location   = new System.Drawing.Point( -1, 19 );
			this.tbxLog.Multiline  = true;
			this.tbxLog.Name       = "tbxLog";
			this.tbxLog.ReadOnly   = true;
			this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbxLog.Size       = new System.Drawing.Size( 882, 784 );
			this.tbxLog.TabIndex   = 17;

			// 
			// btnLog
			// 
			this.btnLog.Location =  new System.Drawing.Point( 1907, 11 );
			this.btnLog.Name     =  "btnLog";
			this.btnLog.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnLog.TabIndex =  14;
			this.btnLog.Text     =  "Log";
			this.btnLog.Click    += new System.EventHandler( this.btnLog_Click );

			// 
			// btnPurge
			// 
			this.btnPurge.Location =  new System.Drawing.Point( 1456, 11 );
			this.btnPurge.Name     =  "btnPurge";
			this.btnPurge.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnPurge.TabIndex =  9;
			this.btnPurge.Text     =  "Purge";
			this.btnPurge.Click    += new System.EventHandler( this.btnPurge_Click );

			// 
			// prbrProgress
			// 
			this.prbrProgress.Location = new System.Drawing.Point( 12, 52 );
			this.prbrProgress.Name     = "prbrProgress";
			this.prbrProgress.Size     = new System.Drawing.Size( 982, 10 );
			this.prbrProgress.Step     = 1;
			this.prbrProgress.Style    = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.prbrProgress.TabIndex = 10;
			this.prbrProgress.Visible  = false;

			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point( 42, 38 );
			this.lblTotal.Name     = "lblTotal";
			this.lblTotal.Size     = new System.Drawing.Size( 13, 13 );
			this.lblTotal.TabIndex = 15;
			this.lblTotal.Text     = "0";

			// 
			// btnFlag
			// 
			this.btnFlag.Location =  new System.Drawing.Point( 1531, 11 );
			this.btnFlag.Name     =  "btnFlag";
			this.btnFlag.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnFlag.TabIndex =  10;
			this.btnFlag.Text     =  "Flag";
			this.btnFlag.Click    += new System.EventHandler( this.btnFlag_Click );

			// 
			// btnDelete
			// 
			this.btnDelete.Location =  new System.Drawing.Point( 1606, 11 );
			this.btnDelete.Name     =  "btnDelete";
			this.btnDelete.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnDelete.TabIndex =  11;
			this.btnDelete.Text     =  "Delete";
			this.btnDelete.Click    += new System.EventHandler( this.btnDelete_Click );

			// 
			// btnLoad
			// 
			this.btnLoad.Location =  new System.Drawing.Point( 11, 11 );
			this.btnLoad.Name     =  "btnLoad";
			this.btnLoad.Size     =  new System.Drawing.Size( 22, 22 );
			this.btnLoad.TabIndex =  4;
			this.btnLoad.Text     =  "📤";
			this.btnLoad.Click    += new System.EventHandler( this.btnLoad_Click );

			// 
			// tbxPatterns
			// 
			this.tbxPatterns.Location        = new System.Drawing.Point( 1181, 12 );
			this.tbxPatterns.Name            = "tbxPatterns";
			this.tbxPatterns.PlaceholderText = "Patterns";
			this.tbxPatterns.Size            = new System.Drawing.Size( 200, 20 );
			this.tbxPatterns.TabIndex        = 7;

			// 
			// fbdlgPath
			// 
			this.fbdlgPath.RootFolder          = System.Environment.SpecialFolder.MyComputer;
			this.fbdlgPath.ShowNewFolderButton = false;

			// 
			// btnEmptyDirs
			// 
			this.btnEmptyDirs.Location =  new System.Drawing.Point( 1681, 11 );
			this.btnEmptyDirs.Name     =  "btnEmptyDirs";
			this.btnEmptyDirs.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnEmptyDirs.TabIndex =  12;
			this.btnEmptyDirs.Text     =  "Empty Dirs";
			this.btnEmptyDirs.Click    += new System.EventHandler( this.btnEmptyDirs_Click );

			// 
			// cbxProjects
			// 
			this.cbxProjects.DropDownStyle     =  System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxProjects.FormattingEnabled =  true;
			this.cbxProjects.Location          =  new System.Drawing.Point( 54, 12 );
			this.cbxProjects.Name              =  "cbxProjects";
			this.cbxProjects.Size              =  new System.Drawing.Size( 268, 21 );
			this.cbxProjects.TabIndex          =  0;
			this.cbxProjects.Format            += new System.Windows.Forms.ListControlConvertEventHandler( this.cbxProjects_Format );

			// 
			// btnAddProject
			// 
			this.btnAddProject.Location =  new System.Drawing.Point( 523, 11 );
			this.btnAddProject.Name     =  "btnAddProject";
			this.btnAddProject.Size     =  new System.Drawing.Size( 22, 22 );
			this.btnAddProject.TabIndex =  2;
			this.btnAddProject.Text     =  "+";
			this.btnAddProject.Click    += new System.EventHandler( this.btnAddProject_Click );

			// 
			// btnRemoveProject
			// 
			this.btnRemoveProject.Location =  new System.Drawing.Point( 544, 11 );
			this.btnRemoveProject.Name     =  "btnRemoveProject";
			this.btnRemoveProject.Size     =  new System.Drawing.Size( 22, 22 );
			this.btnRemoveProject.TabIndex =  3;
			this.btnRemoveProject.Text     =  "-";
			this.btnRemoveProject.Click    += new System.EventHandler( this.btnRemoveProject_Click );

			// 
			// tbxNotes
			// 
			this.tbxNotes.Location        = new System.Drawing.Point( 323, 12 );
			this.tbxNotes.Name            = "tbxNotes";
			this.tbxNotes.PlaceholderText = "Notes";
			this.tbxNotes.Size            = new System.Drawing.Size( 200, 20 );
			this.tbxNotes.TabIndex        = 1;

			// 
			// btnLowerCase
			// 
			this.btnLowerCase.Location =  new System.Drawing.Point( 1757, 11 );
			this.btnLowerCase.Name     =  "btnLowerCase";
			this.btnLowerCase.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnLowerCase.TabIndex =  13;
			this.btnLowerCase.Text     =  "Lower Case";
			this.btnLowerCase.Click    += new System.EventHandler( this.btnLowerCase_Click );

			// 
			// btnMetaData
			// 
			this.btnMetaData.Location =  new System.Drawing.Point( 1832, 11 );
			this.btnMetaData.Name     =  "btnMetaData";
			this.btnMetaData.Size     =  new System.Drawing.Size( 76, 22 );
			this.btnMetaData.TabIndex =  17;
			this.btnMetaData.Text     =  "MetaData";
			this.btnMetaData.Click    += new System.EventHandler( this.btnMetaData_Click );

			// 
			// pnlErrorLog
			// 
			this.pnlErrorLog.BackColor   = System.Drawing.SystemColors.ControlLight;
			this.pnlErrorLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlErrorLog.Controls.Add( label3 );
			this.pnlErrorLog.Controls.Add( this.tbxErrorLog );
			this.pnlErrorLog.Location = new System.Drawing.Point( 1050, 105 );
			this.pnlErrorLog.Name     = "pnlErrorLog";
			this.pnlErrorLog.Size     = new System.Drawing.Size( 882, 804 );
			this.pnlErrorLog.TabIndex = 18;
			this.pnlErrorLog.Visible  = false;

			// 
			// tbxErrorLog
			// 
			this.tbxErrorLog.Location   = new System.Drawing.Point( -1, 20 );
			this.tbxErrorLog.Multiline  = true;
			this.tbxErrorLog.Name       = "tbxErrorLog";
			this.tbxErrorLog.ReadOnly   = true;
			this.tbxErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbxErrorLog.Size       = new System.Drawing.Size( 882, 783 );
			this.tbxErrorLog.TabIndex   = 17;

			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point( 3, 3 );
			label2.Name     = "label2";
			label2.Size     = new System.Drawing.Size( 48, 13 );
			label2.TabIndex = 19;
			label2.Text     = "Progress";

			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point( 3, 3 );
			label3.Name     = "label3";
			label3.Size     = new System.Drawing.Size( 34, 13 );
			label3.TabIndex = 20;
			label3.Text     = "Errors";

			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize          = new System.Drawing.Size( 1994, 971 );
			this.Controls.Add( this.pnlErrorLog );
			this.Controls.Add( this.btnMetaData );
			this.Controls.Add( this.btnLowerCase );
			this.Controls.Add( this.tbxNotes );
			this.Controls.Add( this.btnRemoveProject );
			this.Controls.Add( this.btnAddProject );
			this.Controls.Add( this.cbxProjects );
			this.Controls.Add( this.btnEmptyDirs );
			this.Controls.Add( this.tbxPatterns );
			this.Controls.Add( this.btnLoad );
			this.Controls.Add( this.btnDelete );
			this.Controls.Add( this.btnFlag );
			this.Controls.Add( this.lblTotal );
			this.Controls.Add( label1 );
			this.Controls.Add( this.btnPurge );
			this.Controls.Add( this.btnLog );
			this.Controls.Add( this.pnlLog );
			this.Controls.Add( this.tbxPath );
			this.Controls.Add( this.lbxMd5Sets );
			this.Controls.Add( this.prbrProgress );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.lbxFiles );
			this.Controls.Add( this.btnScan );
			this.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name            =  "Main";
			this.StartPosition   =  System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text            =  "Main";
			this.Load            += new System.EventHandler( this.this_Load );
			this.pnlLog.ResumeLayout( false );
			this.pnlLog.PerformLayout();
			this.pnlErrorLog.ResumeLayout( false );
			this.pnlErrorLog.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();
		}

		private System.Windows.Forms.Panel pnlErrorLog;

		private System.Windows.Forms.TextBox tbxErrorLog;

		private System.Windows.Forms.Button btnMetaData;

		private System.Windows.Forms.Button btnLowerCase;

		private SharpKandis.Windows.Forms.TextBoxPlaceholder tbxNotes;

		private System.Windows.Forms.Button btnAddProject;

		private System.Windows.Forms.Button btnRemoveProject;

		private System.Windows.Forms.ComboBox cbxProjects;

		private System.Windows.Forms.Button btnEmptyDirs;

		private System.Windows.Forms.FolderBrowserDialog fbdlgPath;

		private SharpKandis.Windows.Forms.TextBoxPlaceholder tbxPatterns;

		private System.Windows.Forms.Button btnDelete;

		private System.Windows.Forms.Button btnLoad;

		private System.Windows.Forms.Button btnFlag;

		private System.Windows.Forms.Label lblTotal;

		private System.Windows.Forms.Button btnPurge;

		private System.Windows.Forms.Button btnLog;

		private System.Windows.Forms.TextBox tbxLog;

		private System.Windows.Forms.Panel pnlLog;

		private System.Windows.Forms.ProgressBar prbrProgress;

		private System.Windows.Forms.Button btnSave;

		private System.Windows.Forms.ListBox lbxFiles;

		private System.Windows.Forms.ListBox lbxMd5Sets;

		private System.Windows.Forms.Button btnScan;

		private SharpKandis.Windows.Forms.TextBoxPlaceholder tbxPath;

		#endregion
	}
}