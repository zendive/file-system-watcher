using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//---
using System.IO;
using System.Text.RegularExpressions;

namespace FSWatch
{
  public enum DEFAULT:int
  {
    MAX_FOLDER_HISTORY = 32
  }

  public partial class MainForm: Form
  {
    private Regex regexProductVersion = new Regex(@"(\d+\.\d+.\d+).*", RegexOptions.Compiled);
    private string m_sAppTitle = "";

    public MainForm()
    {
      InitializeComponent();

      m_sAppTitle = Application.ProductName + " v"
         + regexProductVersion.Replace(Application.ProductVersion, "$1");
    }
    
    private void MainForm_Load(object sender, EventArgs e)
    {
      UpdateFormTitle("");
      Page_AddNew();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      // ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.en/cpref4/html/M_System_Configuration_ApplicationSettingsBase_Save.htm
      global::FSWatch.Properties.Settings.Default.Save();
    }

    #region UI Events

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
      // My favorite feature implementation
      if (e.KeyCode == Keys.F11)
      {
        e.Handled = true;
        if (this.Opacity < 0.11d) { return; }
        this.Opacity -= 0.1d;
      }
      else if (e.KeyCode == Keys.F12)
      {
        e.Handled = true;
        this.Opacity += 0.1d;
      }
      // exit
      else if (e.KeyCode == Keys.Escape)
      {
        e.Handled = true;
        #if DEBUG
        Application.Exit();
        #endif
      }
      // about
      else if (e.KeyCode == Keys.F1)
      {
        e.Handled = true;
        string link = "http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx";

        DialogResult dlgResult = MessageBox.Show(
          "More information available online at: \""+ link +"\"\nDo you want to Proceed?"
          , Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dlgResult == DialogResult.Yes)
        {
          System.Diagnostics.Process proc = new System.Diagnostics.Process();
          proc.StartInfo.FileName = link;
          proc.StartInfo.UseShellExecute = true;

          proc.Start();
        }
      }
      else if (e.KeyCode == Keys.F5)
      {
        TabPage tab = tabSet.SelectedTab;
        if (null != tab && null != tab.Tag)
        {
          UC_Page page = tab.Tag as UC_Page;
          if (null != page)
          {
            page.btnLaunchSwitch_Click(sender, e);
          }
        }
        e.Handled = true;
      }
      else if (e.Control && e.KeyCode == Keys.T)
      {
        e.Handled = true;
        Page_AddNew();
      }
      else if (e.Control && e.KeyCode == Keys.W)
      {
        e.Handled = true;
        Page_Remove(tabSet.SelectedTab);
      }
    }

    private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Page_AddNew();
      }
    }

    void tabSet_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Middle)
      {
        TabPage tab = GetTabPageAtLocation(tabSet, e.Location);
        if (null != tab)
        {
          Page_Remove(tab);
        }
      }
    }

    #endregion UI Events

    #region UI Compound

    private TabPage GetTabPageAtLocation(TabControl _tabControl, Point _point)
    {
      for (int c = 0; c < _tabControl.TabPages.Count; c++)
      {
        if (_tabControl.GetTabRect(c).Contains(_point))
        {
          return _tabControl.TabPages[c];
        }
      }
      return null;
    }

    public void UpdateFormTitle(string _sTargetFolder)
    {
      this.Text = _sTargetFolder +" - "+ m_sAppTitle;
    }

    private void Page_AddNew()
    {
      TabPage tab = new TabPage("(*)");
      UC_Page page = new UC_Page();

      page.OnFolderChanged += new UC_Page.OnFolderChangedDelegate(page_OnFolderChanged);
      page.Dock = DockStyle.Fill;

      tab.Controls.Add(page);
      tab.Tag = page; // associate `tab.Tag` with hosted Page class, note that `page.Parent == tab`
      
      tabSet.Controls.Add(tab);
      tabSet.SelectedTab = tab;

      UpdateFormTitle(tab.Text);
    }

    void tab_MouseHover(object sender, EventArgs e)
    {
      DEBUG.TRACE("- MouseHover - {{{0}}}", sender.ToString());
    }

    void page_OnFolderChanged(TabPage _tabPage, string _sCurrentFolder)
    {
      _tabPage.Text = _sCurrentFolder;
      this.UpdateFormTitle(_sCurrentFolder);
    }
    
    private void Page_Selected(object sender, TabControlEventArgs e)
    {
      this.UpdateFormTitle(e.TabPage.Text);
    }

    private void Page_Remove(TabPage _tab)
    {
      if (tabSet.TabPages.Count > 1)
      {
        UC_Page page = _tab.Tag as UC_Page;
        page.Stop();
        // page.Finallyze();
        page = null;
        
        int iCurPos = tabSet.TabPages.IndexOf(_tab);
        int iLastPos = tabSet.TabPages.Count - 1;
        if (iCurPos == iLastPos)
        {
          tabSet.SelectTab(iCurPos - 1);
          tabSet.TabPages.RemoveAt(iCurPos);
        }
        else if (iCurPos < iLastPos)
        {
          tabSet.TabPages.RemoveAt(iCurPos);
          tabSet.SelectTab(iCurPos);
        }

        UpdateFormTitle(tabSet.SelectedTab.Text);
      }
    }
    
    #endregion UI Compound

    

  };
}