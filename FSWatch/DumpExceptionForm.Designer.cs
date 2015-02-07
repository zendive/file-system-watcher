partial class DumpExceptionForm
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

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    this.txtType = new System.Windows.Forms.TextBox();
    this.txtMessage = new System.Windows.Forms.TextBox();
    this.txtStackTrace = new System.Windows.Forms.TextBox();
    this.btnContinue = new System.Windows.Forms.Button();
    this.btnThrowException = new System.Windows.Forms.Button();
    this.btnExitAplication = new System.Windows.Forms.Button();
    this.groupBox1 = new System.Windows.Forms.GroupBox();
    this.groupBox2 = new System.Windows.Forms.GroupBox();
    this.groupBox3 = new System.Windows.Forms.GroupBox();
    this.lblNote = new System.Windows.Forms.Label();
    this.panel1 = new System.Windows.Forms.Panel();
    this.groupBox1.SuspendLayout();
    this.groupBox2.SuspendLayout();
    this.groupBox3.SuspendLayout();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    // 
    // txtType
    // 
    this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
    this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.txtType.Location = new System.Drawing.Point(3, 16);
    this.txtType.Name = "txtType";
    this.txtType.ReadOnly = true;
    this.txtType.Size = new System.Drawing.Size(468, 13);
    this.txtType.TabIndex = 4;
    // 
    // txtMessage
    // 
    this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
    this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.txtMessage.Location = new System.Drawing.Point(3, 16);
    this.txtMessage.Multiline = true;
    this.txtMessage.Name = "txtMessage";
    this.txtMessage.ReadOnly = true;
    this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
    this.txtMessage.Size = new System.Drawing.Size(468, 59);
    this.txtMessage.TabIndex = 6;
    // 
    // txtStackTrace
    // 
    this.txtStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
    this.txtStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
    this.txtStackTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.txtStackTrace.Location = new System.Drawing.Point(3, 16);
    this.txtStackTrace.Multiline = true;
    this.txtStackTrace.Name = "txtStackTrace";
    this.txtStackTrace.ReadOnly = true;
    this.txtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
    this.txtStackTrace.Size = new System.Drawing.Size(468, 139);
    this.txtStackTrace.TabIndex = 8;
    // 
    // btnContinue
    // 
    this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
    this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.btnContinue.Location = new System.Drawing.Point(24, 362);
    this.btnContinue.Name = "btnContinue";
    this.btnContinue.Size = new System.Drawing.Size(75, 23);
    this.btnContinue.TabIndex = 0;
    this.btnContinue.Text = "&Ignore";
    this.btnContinue.UseVisualStyleBackColor = true;
    this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
    // 
    // btnThrowException
    // 
    this.btnThrowException.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
    this.btnThrowException.Location = new System.Drawing.Point(128, 362);
    this.btnThrowException.Name = "btnThrowException";
    this.btnThrowException.Size = new System.Drawing.Size(210, 23);
    this.btnThrowException.TabIndex = 1;
    this.btnThrowException.Text = "&throw new ApplicationException";
    this.btnThrowException.UseVisualStyleBackColor = true;
    this.btnThrowException.Click += new System.EventHandler(this.btnThrowException_Click);
    // 
    // btnExitAplication
    // 
    this.btnExitAplication.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
    this.btnExitAplication.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    this.btnExitAplication.Location = new System.Drawing.Point(367, 362);
    this.btnExitAplication.Name = "btnExitAplication";
    this.btnExitAplication.Size = new System.Drawing.Size(107, 23);
    this.btnExitAplication.TabIndex = 2;
    this.btnExitAplication.Text = "&Application.Exit";
    this.btnExitAplication.UseVisualStyleBackColor = true;
    this.btnExitAplication.Click += new System.EventHandler(this.btnExitAplication_Click);
    // 
    // groupBox1
    // 
    this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.groupBox1.Controls.Add(this.txtStackTrace);
    this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.groupBox1.Location = new System.Drawing.Point(12, 181);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new System.Drawing.Size(474, 158);
    this.groupBox1.TabIndex = 9;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Stack Trace";
    // 
    // groupBox2
    // 
    this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.groupBox2.Controls.Add(this.txtMessage);
    this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.groupBox2.Location = new System.Drawing.Point(12, 93);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new System.Drawing.Size(474, 78);
    this.groupBox2.TabIndex = 10;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Message";
    // 
    // groupBox3
    // 
    this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.groupBox3.Controls.Add(this.txtType);
    this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.groupBox3.Location = new System.Drawing.Point(12, 48);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Size = new System.Drawing.Size(474, 39);
    this.groupBox3.TabIndex = 11;
    this.groupBox3.TabStop = false;
    this.groupBox3.Text = "Type";
    // 
    // lblNote
    // 
    this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.lblNote.BackColor = System.Drawing.Color.Transparent;
    this.lblNote.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
    this.lblNote.Location = new System.Drawing.Point(1, 9);
    this.lblNote.Name = "lblNote";
    this.lblNote.Size = new System.Drawing.Size(491, 20);
    this.lblNote.TabIndex = 12;
    this.lblNote.Text = "Unhandled runtime behaviour";
    this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
    // 
    // panel1
    // 
    this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
    this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.panel1.Controls.Add(this.lblNote);
    this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
    this.panel1.Location = new System.Drawing.Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new System.Drawing.Size(498, 42);
    this.panel1.TabIndex = 12;
    // 
    // DumpExceptionForm
    // 
    this.AcceptButton = this.btnContinue;
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
    this.CancelButton = this.btnExitAplication;
    this.CausesValidation = false;
    this.ClientSize = new System.Drawing.Size(498, 412);
    this.ControlBox = false;
    this.Controls.Add(this.panel1);
    this.Controls.Add(this.groupBox3);
    this.Controls.Add(this.groupBox2);
    this.Controls.Add(this.groupBox1);
    this.Controls.Add(this.btnExitAplication);
    this.Controls.Add(this.btnThrowException);
    this.Controls.Add(this.btnContinue);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.MinimumSize = new System.Drawing.Size(488, 414);
    this.Name = "DumpExceptionForm";
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = ".::{ Exception Dump }::.";
    this.TopMost = true;
    this.Load += new System.EventHandler(this.DumpExceptionForm_Load);
    this.groupBox1.ResumeLayout(false);
    this.groupBox1.PerformLayout();
    this.groupBox2.ResumeLayout(false);
    this.groupBox2.PerformLayout();
    this.groupBox3.ResumeLayout(false);
    this.groupBox3.PerformLayout();
    this.panel1.ResumeLayout(false);
    this.ResumeLayout(false);

  }

  #endregion

  private System.Windows.Forms.TextBox txtType;
  private System.Windows.Forms.TextBox txtMessage;
  private System.Windows.Forms.TextBox txtStackTrace;
  private System.Windows.Forms.Button btnContinue;
  private System.Windows.Forms.Button btnThrowException;
  private System.Windows.Forms.Button btnExitAplication;
  private System.Windows.Forms.GroupBox groupBox1;
  private System.Windows.Forms.GroupBox groupBox2;
  private System.Windows.Forms.GroupBox groupBox3;
  private System.Windows.Forms.Label lblNote;
  private System.Windows.Forms.Panel panel1;
}
