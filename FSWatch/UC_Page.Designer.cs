namespace FSWatch
{
  partial class UC_Page
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Page));
      this.toolStripMain = new System.Windows.Forms.ToolStrip();
      this.btnSelectFolder = new System.Windows.Forms.ToolStripButton();
      this.lblPath = new System.Windows.Forms.ToolStripLabel();
      this.cmbPath = new System.Windows.Forms.ToolStripComboBox();
      this.btnLaunchSwitch = new System.Windows.Forms.ToolStripButton();
      this.btnRefresh = new System.Windows.Forms.ToolStripButton();
      this.lblFilter = new System.Windows.Forms.ToolStripLabel();
      this.txtFilter = new System.Windows.Forms.ToolStripTextBox();
      this.toolStripNF = new System.Windows.Forms.ToolStrip();
      this.btnNF_SubDir = new System.Windows.Forms.ToolStripButton();
      this.btnNF_LastWrite = new System.Windows.Forms.ToolStripButton();
      this.btnNF_LastAccess = new System.Windows.Forms.ToolStripButton();
      this.btnNF_FileName = new System.Windows.Forms.ToolStripButton();
      this.btnNF_DirectoryName = new System.Windows.Forms.ToolStripButton();
      this.btnNF_CreationTime = new System.Windows.Forms.ToolStripButton();
      this.btnNF_Attributes = new System.Windows.Forms.ToolStripButton();
      this.btnNF_Security = new System.Windows.Forms.ToolStripButton();
      this.btnNF_Size = new System.Windows.Forms.ToolStripButton();
      this.txtTrace = new System.Windows.Forms.RichTextBox();
      this.toolStripMain.SuspendLayout();
      this.toolStripNF.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripMain
      // 
      this.toolStripMain.AutoSize = false;
      this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectFolder,
            this.lblPath,
            this.cmbPath,
            this.btnLaunchSwitch,
            this.btnRefresh,
            this.lblFilter,
            this.txtFilter});
      this.toolStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
      this.toolStripMain.Location = new System.Drawing.Point(0, 0);
      this.toolStripMain.Name = "toolStripMain";
      this.toolStripMain.Size = new System.Drawing.Size(573, 23);
      this.toolStripMain.TabIndex = 0;
      this.toolStripMain.Text = "toolStrip1";
      this.toolStripMain.Resize += new System.EventHandler(this.toolStripMain_Resize);
      // 
      // btnSelectFolder
      // 
      this.btnSelectFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSelectFolder.Image = global::FSWatch.Properties.Resources.folder;
      this.btnSelectFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSelectFolder.Name = "btnSelectFolder";
      this.btnSelectFolder.Size = new System.Drawing.Size(23, 20);
      this.btnSelectFolder.Text = "toolStripButton1";
      this.btnSelectFolder.ToolTipText = "Select Folder";
      this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
      // 
      // lblPath
      // 
      this.lblPath.Name = "lblPath";
      this.lblPath.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
      this.lblPath.Size = new System.Drawing.Size(33, 17);
      this.lblPath.Text = "&Path:";
      // 
      // cmbPath
      // 
      this.cmbPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.cmbPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cmbPath.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.cmbPath.MaxDropDownItems = 16;
      this.cmbPath.Name = "cmbPath";
      this.cmbPath.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.cmbPath.Size = new System.Drawing.Size(300, 23);
      // 
      // btnLaunchSwitch
      // 
      this.btnLaunchSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnLaunchSwitch.Image = global::FSWatch.Properties.Resources.Start;
      this.btnLaunchSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnLaunchSwitch.Name = "btnLaunchSwitch";
      this.btnLaunchSwitch.Size = new System.Drawing.Size(23, 20);
      this.btnLaunchSwitch.Text = "toolStripButton1";
      this.btnLaunchSwitch.ToolTipText = "Start/Stop (F5)";
      this.btnLaunchSwitch.Click += new System.EventHandler(this.btnLaunchSwitch_Click);
      // 
      // btnRefresh
      // 
      this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRefresh.Image = global::FSWatch.Properties.Resources.Refresh;
      this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(23, 20);
      this.btnRefresh.Text = "toolStripButton2";
      this.btnRefresh.ToolTipText = "Clean";
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // lblFilter
      // 
      this.lblFilter.Name = "lblFilter";
      this.lblFilter.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
      this.lblFilter.Size = new System.Drawing.Size(69, 17);
      this.lblFilter.Text = "Regex &Filter:";
      // 
      // txtFilter
      // 
      this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
      this.txtFilter.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
      this.txtFilter.Size = new System.Drawing.Size(80, 23);
      this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
      // 
      // toolStripNF
      // 
      this.toolStripNF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNF_SubDir,
            this.btnNF_LastWrite,
            this.btnNF_LastAccess,
            this.btnNF_FileName,
            this.btnNF_DirectoryName,
            this.btnNF_CreationTime,
            this.btnNF_Attributes,
            this.btnNF_Security,
            this.btnNF_Size});
      this.toolStripNF.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
      this.toolStripNF.Location = new System.Drawing.Point(0, 23);
      this.toolStripNF.Name = "toolStripNF";
      this.toolStripNF.Size = new System.Drawing.Size(573, 20);
      this.toolStripNF.TabIndex = 1;
      this.toolStripNF.Text = "toolStrip2";
      // 
      // btnNF_SubDir
      // 
      this.btnNF_SubDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_SubDir.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_SubDir.Image")));
      this.btnNF_SubDir.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_SubDir.Name = "btnNF_SubDir";
      this.btnNF_SubDir.Size = new System.Drawing.Size(42, 17);
      this.btnNF_SubDir.Text = "SubDir";
      this.btnNF_SubDir.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_LastWrite
      // 
      this.btnNF_LastWrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_LastWrite.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_LastWrite.Image")));
      this.btnNF_LastWrite.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_LastWrite.Name = "btnNF_LastWrite";
      this.btnNF_LastWrite.Size = new System.Drawing.Size(57, 17);
      this.btnNF_LastWrite.Text = "LastWrite";
      this.btnNF_LastWrite.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_LastAccess
      // 
      this.btnNF_LastAccess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_LastAccess.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_LastAccess.Image")));
      this.btnNF_LastAccess.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_LastAccess.Name = "btnNF_LastAccess";
      this.btnNF_LastAccess.Size = new System.Drawing.Size(64, 17);
      this.btnNF_LastAccess.Text = "LastAccess";
      this.btnNF_LastAccess.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_FileName
      // 
      this.btnNF_FileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_FileName.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_FileName.Image")));
      this.btnNF_FileName.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_FileName.Name = "btnNF_FileName";
      this.btnNF_FileName.Size = new System.Drawing.Size(54, 17);
      this.btnNF_FileName.Text = "FileName";
      this.btnNF_FileName.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_DirectoryName
      // 
      this.btnNF_DirectoryName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_DirectoryName.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_DirectoryName.Image")));
      this.btnNF_DirectoryName.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_DirectoryName.Name = "btnNF_DirectoryName";
      this.btnNF_DirectoryName.Size = new System.Drawing.Size(82, 17);
      this.btnNF_DirectoryName.Text = "DirectoryName";
      this.btnNF_DirectoryName.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_CreationTime
      // 
      this.btnNF_CreationTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_CreationTime.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_CreationTime.Image")));
      this.btnNF_CreationTime.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_CreationTime.Name = "btnNF_CreationTime";
      this.btnNF_CreationTime.Size = new System.Drawing.Size(74, 17);
      this.btnNF_CreationTime.Text = "CreationTime";
      this.btnNF_CreationTime.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_Attributes
      // 
      this.btnNF_Attributes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_Attributes.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_Attributes.Image")));
      this.btnNF_Attributes.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_Attributes.Name = "btnNF_Attributes";
      this.btnNF_Attributes.Size = new System.Drawing.Size(59, 17);
      this.btnNF_Attributes.Text = "Attributes";
      this.btnNF_Attributes.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_Security
      // 
      this.btnNF_Security.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_Security.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_Security.Image")));
      this.btnNF_Security.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_Security.Name = "btnNF_Security";
      this.btnNF_Security.Size = new System.Drawing.Size(50, 17);
      this.btnNF_Security.Text = "Security";
      this.btnNF_Security.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // btnNF_Size
      // 
      this.btnNF_Size.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.btnNF_Size.Image = ((System.Drawing.Image)(resources.GetObject("btnNF_Size.Image")));
      this.btnNF_Size.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnNF_Size.Name = "btnNF_Size";
      this.btnNF_Size.Size = new System.Drawing.Size(30, 17);
      this.btnNF_Size.Text = "Size";
      this.btnNF_Size.Click += new System.EventHandler(this.btnNF_Clicked);
      // 
      // txtTrace
      // 
      this.txtTrace.CausesValidation = false;
      this.txtTrace.DetectUrls = false;
      this.txtTrace.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtTrace.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtTrace.Location = new System.Drawing.Point(0, 43);
      this.txtTrace.Name = "txtTrace";
      this.txtTrace.Size = new System.Drawing.Size(573, 187);
      this.txtTrace.TabIndex = 2;
      this.txtTrace.Text = "";
      this.txtTrace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trace_KeyPress);
      // 
      // UC_Page
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CausesValidation = false;
      this.Controls.Add(this.txtTrace);
      this.Controls.Add(this.toolStripNF);
      this.Controls.Add(this.toolStripMain);
      this.Name = "UC_Page";
      this.Size = new System.Drawing.Size(573, 230);
      this.toolStripMain.ResumeLayout(false);
      this.toolStripMain.PerformLayout();
      this.toolStripNF.ResumeLayout(false);
      this.toolStripNF.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStripMain;
    private System.Windows.Forms.ToolStripLabel lblPath;
    private System.Windows.Forms.ToolStripComboBox cmbPath;
    private System.Windows.Forms.ToolStripButton btnLaunchSwitch;
    private System.Windows.Forms.ToolStripLabel lblFilter;
    private System.Windows.Forms.ToolStripTextBox txtFilter;
    private System.Windows.Forms.ToolStripButton btnRefresh;
    private System.Windows.Forms.ToolStrip toolStripNF;
    private System.Windows.Forms.ToolStripButton btnNF_LastAccess;
    private System.Windows.Forms.ToolStripButton btnNF_LastWrite;
    private System.Windows.Forms.ToolStripButton btnNF_FileName;
    private System.Windows.Forms.ToolStripButton btnNF_DirectoryName;
    private System.Windows.Forms.ToolStripButton btnNF_CreationTime;
    private System.Windows.Forms.ToolStripButton btnNF_Attributes;
    private System.Windows.Forms.ToolStripButton btnNF_Security;
    private System.Windows.Forms.ToolStripButton btnNF_Size;
    private System.Windows.Forms.ToolStripButton btnNF_SubDir;
    private System.Windows.Forms.ToolStripButton btnSelectFolder;
    private System.Windows.Forms.RichTextBox txtTrace;
  }
}
