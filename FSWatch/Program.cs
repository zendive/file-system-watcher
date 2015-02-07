using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

namespace FSWatch
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    static void Main()
    {
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(true);

        using (Form form = new MainForm())
        {
          Application.Run(form);
        }
      }
      catch (Exception xcp)
      {
        DEBUG.DUMP_EXCEPTION(xcp);
      }
    }
  };
}