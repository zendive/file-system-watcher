using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace FSWatch
{
  public partial class UC_Page : UserControl
  {
    public delegate void OnFolderChangedDelegate(TabPage _tabPage, string _sCurrentFolder);
    public event OnFolderChangedDelegate OnFolderChanged;

    private delegate void UpdateTraceDelegate(string text);
    private UpdateTraceDelegate m_UpdateTraceInvokeMethod = null;

    private FileSystemWatcher m_fsw = new FileSystemWatcher();
    private readonly Color m_clrError = Color.LightPink;
    private Regex m_regexFilter;

    private int m_iPathStripWidthRatio;

    public UC_Page()
    {
      InitializeComponent();
      Init();

      m_iPathStripWidthRatio = toolStripMain.Size.Width - cmbPath.Size.Width;
      m_regexFilter = new Regex("", RegexOptions.Compiled);

      m_fsw.Changed += new FileSystemEventHandler(fsw_Changed);
      m_fsw.Created += new FileSystemEventHandler(fsw_Changed);
      m_fsw.Deleted += new FileSystemEventHandler(fsw_Changed);
      m_fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
      m_fsw.Error += new ErrorEventHandler(fsw_Error);
    }

    private void Init()
    {
      cmbPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cmbPath.AutoSize = true;

      btnLaunchSwitch.Tag = null; // launch falg
      btnNF_SubDir.Checked = true;

      btnNF_LastAccess.Checked = true;
      btnNF_LastWrite.Checked = true;
      btnNF_FileName.Checked = true;
      btnNF_DirectoryName.Checked = true;

      m_UpdateTraceInvokeMethod = new UpdateTraceDelegate(UpdateTrace);

      PopulateFolderHistory(global::FSWatch.Properties.Settings.Default.FoldersHistory);
    }

    private void PopulateFolderHistory(string _sFolderHistory)
    {
      string[] asFolders = _sFolderHistory.Split(new char[] { ';' });
      cmbPath.Items.Clear();

      foreach (string sFolder in asFolders)
      {
        if (!string.IsNullOrEmpty(sFolder))
        {
          cmbPath.Items.Add(sFolder);
        }
      }
    }

    private void trace_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Disabling any editing in txtTrace control
      // but allowing to copy selected text
      if (e.KeyChar == 0x0003) // Ctrl+C (Ctrl+Ins is transparent to KeyPress method)
      {
        e.Handled = false;
      }
      else
      {
        // block any else
        e.Handled = true;
      }
    }

    private void btnSelectFolder_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.ShowNewFolderButton = true;
      fbd.Description = "Select Folder to watch for."
        + "It may be System, Temporary or remote machine shared folder.";

      DialogResult dr = fbd.ShowDialog();
      if (dr == DialogResult.OK)
      {
        cmbPath.Text = fbd.SelectedPath;
      }
      else
      {
        cmbPath.Text = "";
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      this.txtTrace.Text = "";
    }

    private void toolStripMain_Resize(object sender, EventArgs e)
    {
      int iWidth = 300;//((ToolStrip)sender).Size.Width - m_iPathStripWidthRatio;
      int iHeight = cmbPath.Size.Height;
      cmbPath.Size = new Size(iWidth, iHeight);
    }

    private bool Path_IsValid(string sPath)
    {
      try
      {
        if (Directory.Exists(sPath))
        {
          return true;
        }
      }
      catch (Exception xcp)
      {
        DEBUG.DUMP_EXCEPTION(xcp);
      }

      return false;
    }

    private string Path_Normalize(string _sPath)
    {
      if (_sPath.EndsWith("\\") || _sPath.EndsWith("/"))
      {
        return _sPath.Substring(0, _sPath.Length - 1);
      }
      else
      {
        return _sPath;
      }
    }

    public void btnLaunchSwitch_Click(object sender, EventArgs e)
    {
      bool bEnableUI = true;

      try
      {
        if (btnLaunchSwitch.Tag == null)
        {
          string sPath = Path_Normalize(cmbPath.Text);
          cmbPath.Text = sPath;

          if (!Path_IsValid(sPath))
          {
            cmbPath.BackColor = m_clrError;
            return;
          }
          else
          {
            cmbPath.BackColor = Color.White;
          }

          if (null != OnFolderChanged)
          {
            OnFolderChanged(this.Parent as TabPage, GetCurrentFolderName(sPath));
          }

          Start(sPath);

          btnLaunchSwitch.Tag = 1;
          btnLaunchSwitch.ToolTipText = "Stop";
          btnLaunchSwitch.Image = global::FSWatch.Properties.Resources.Stop;
          this.Invoke(m_UpdateTraceInvokeMethod, new object[] { "Started...\r\n" });
          bEnableUI = false;
        }
        else
        {
          Stop();

          btnLaunchSwitch.Tag = null;
          btnLaunchSwitch.ToolTipText = "Start";
          btnLaunchSwitch.Image = global::FSWatch.Properties.Resources.Start;
          this.Invoke(m_UpdateTraceInvokeMethod, new object[] { "Stopped...\r\n\r\n" });
          bEnableUI = true;
        }
      }
      catch (Exception xcp)
      {
        DEBUG.DUMP_EXCEPTION(xcp);
        bEnableUI = true;
      }
      finally
      {
        EnableUI(bEnableUI);
      }
    }

    private string GetCurrentFolderName(string _sPath)
    {
      if (Path.GetPathRoot(_sPath) == _sPath)
      {// root paths like `c:\`, `d:\`
        return _sPath;
      }
      else
      {
        return Path.GetFileName(_sPath);
      }
    }

    private string GetTheMoment
    {
      get
      {
        DateTime moment = DateTime.Now;
        return string.Format("{0}.{1:00}.{2:00} {3:00}:{4:00}:{5:00}.{6:000}"
          , moment.Year, moment.Month, moment.Day
          , moment.Hour, moment.Minute, moment.Second, moment.Millisecond);
      }
    }

    private void fsw_Error(object sender, ErrorEventArgs e)
    {
      this.Invoke(m_UpdateTraceInvokeMethod, new object[] { 
        "ERROR> " + e.GetException().Message + "\r\n" }); 
    }

    private void fsw_Renamed(object sender, RenamedEventArgs e)
    {
      string str = string.Format("{0}> {1} \"{2}\" to \"{3}\"\r\n"
        , GetTheMoment, GetChangeMark(e.ChangeType), e.OldFullPath, e.FullPath);

      if (m_regexFilter.IsMatch(str))
      {
        this.Invoke(m_UpdateTraceInvokeMethod, new object[] { str });
      }
    }

    private void fsw_Changed(object sender, FileSystemEventArgs e)
    {
      string str = string.Format("{0}> {1} \"{2}\"\r\n"
        , GetTheMoment, GetChangeMark(e.ChangeType), e.FullPath);

      if (m_regexFilter.IsMatch(str))
      {
        this.Invoke(m_UpdateTraceInvokeMethod, new object[] { str });
      }
    }
    
    private string GetChangeMark(WatcherChangeTypes _wct)
    {
      switch (_wct)
      {
        case WatcherChangeTypes.Changed: return "***";
        case WatcherChangeTypes.Created: return "+++";
        case WatcherChangeTypes.Deleted: return "---";
        case WatcherChangeTypes.Renamed: return "~~~";
        default: return "???";
      }
    }

    public void UpdateFolderHistory(string _sPath)
    {
      string sFolderHistory = global::FSWatch.Properties.Settings.Default.FoldersHistory;
      string[] asFolders = sFolderHistory.Split(new char[] { ';' });

      // abort if already exists
      foreach (string sFolder in asFolders)
      {
        if (sFolder == _sPath)
        {
          return;
        }
      }

      if (asFolders.Length < (int)DEFAULT.MAX_FOLDER_HISTORY)
      { // uppend to the end
        if (string.IsNullOrEmpty(sFolderHistory))
        {
          sFolderHistory = _sPath;
        }
        else
        {
          sFolderHistory = sFolderHistory + ";" + _sPath;
        }
      }
      else
      { // add new, remove oldest
        int iFirstDelimiter = sFolderHistory.IndexOf(';');
        sFolderHistory = sFolderHistory.Substring(iFirstDelimiter + 1) + ";" + _sPath;
      }

      DEBUG.TRACE("- sFolderHistory = {0}", sFolderHistory);
      global::FSWatch.Properties.Settings.Default["FoldersHistory"] = sFolderHistory;
      PopulateFolderHistory(sFolderHistory);
    }

    public void Start(string _sPath)
    {
      UpdateFolderHistory(_sPath);

      m_fsw.Path = _sPath;
      m_fsw.IncludeSubdirectories = btnNF_SubDir.Checked;
      // catch all if filter is empty
      m_fsw.Filter = "";
      m_fsw.NotifyFilter ^= m_fsw.NotifyFilter;

      if (btnNF_LastAccess.Checked) { m_fsw.NotifyFilter |= NotifyFilters.LastAccess; }
      if (btnNF_LastWrite.Checked) { m_fsw.NotifyFilter |= NotifyFilters.LastWrite; }
      if (btnNF_FileName.Checked) { m_fsw.NotifyFilter |= NotifyFilters.FileName; }
      if (btnNF_DirectoryName.Checked) { m_fsw.NotifyFilter |= NotifyFilters.DirectoryName; }

      if (btnNF_CreationTime.Checked) { m_fsw.NotifyFilter |= NotifyFilters.CreationTime; }
      if (btnNF_Attributes.Checked) { m_fsw.NotifyFilter |= NotifyFilters.Attributes; }
      if (btnNF_Security.Checked) { m_fsw.NotifyFilter |= NotifyFilters.Security; }
      if (btnNF_Size.Checked) { m_fsw.NotifyFilter |= NotifyFilters.Size; }

      m_fsw.EnableRaisingEvents = true;
    }

    public void Stop()
    {
      m_fsw.EnableRaisingEvents = false;
    }

    public void UpdateTrace(string _str)
    {
      if (this.txtTrace.InvokeRequired)
      {
        this.Invoke(m_UpdateTraceInvokeMethod, new object[] { _str });
      }
      else
      {
        // Avoid overload memory consumption
        if (txtTrace.Text.Length > 30000)
        { // TODO: replace hardcoded number by some parametriezed value;
          txtTrace.Text.Remove(0, 1000);
          txtTrace.Text.Insert(0, "(skipped)\r\n");
        }

        txtTrace.AppendText(_str);

        // Make visible last data uppended (EXPENSIVE)
        txtTrace.Focus();
        txtTrace.Select(txtTrace.Text.Length, 0);
        txtTrace.ScrollToCaret();
      }
    }

    private void EnableUI(bool _bEnable)
    {
      cmbPath.Enabled = _bEnable;
      btnSelectFolder.Enabled = _bEnable;

      btnNF_SubDir.Enabled = _bEnable;
      btnNF_LastAccess.Enabled = _bEnable;
      btnNF_LastWrite.Enabled = _bEnable;
      btnNF_FileName.Enabled = _bEnable;
      btnNF_DirectoryName.Enabled = _bEnable;
      btnNF_CreationTime.Enabled = _bEnable;
      btnNF_Attributes.Enabled = _bEnable;
      btnNF_Security.Enabled = _bEnable;
      btnNF_Size.Enabled = _bEnable;
    }

    private void btnNF_Clicked(object sender, EventArgs e)
    {
      ToolStripButton btn = sender as ToolStripButton;
      btn.Checked = !btn.Checked;
    }

    private void txtFilter_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        try
        {
          m_regexFilter = new Regex(txtFilter.Text, RegexOptions.Compiled | RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
          txtFilter.BackColor = Color.White;
          txtTrace.Focus();
        }
        catch (ArgumentException)
        { // wrong regex pattern
          txtFilter.BackColor = m_clrError;
          m_regexFilter = new Regex("", RegexOptions.Compiled);
        }
        e.Handled = true;
      }
      else
      {
        e.Handled = false;
      }
    }
  }
}
