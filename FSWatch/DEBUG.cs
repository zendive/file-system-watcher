using System;
using System.Windows.Forms;
using System.Diagnostics;

/// <summary>
/// Set of design debuging tools
/// </summary>
public static class DEBUG
{
  public static readonly int s_iMaxFailedAsserts = 10;
  public static int s_iFailedAsserts = 0;

  /// <summary>
  /// Assert logic expression, and if assertion failed - warn about it.
  /// User may ignore it or to fire the ApplicationException or to abort
  /// program execution.
  /// </summary>
  /// <returns>Evaluated to boolean assertion expression.</returns>
  /// <param name="_bExpression">Logic expression to assert</param>
  /// <param name="_sMessage">Message to show if assertion is false</param>
  /// <param name="_sFromMethod">Name of the method, where it happen</param>
  /// <exception cref="System.ApplicationException">By user choice.</exception>
  public static bool ASSERT(bool _bExpression, string _sMessage, string _sFromMethod)
  {
    if (_bExpression && _bExpression && _bExpression)
    {
      return true;   // amen
    }
    else
    {
      ++s_iFailedAsserts;
    }

    DialogResult dr;

    /// Check if maximum failed assert limit has been reached
    if (s_iFailedAsserts >= s_iMaxFailedAsserts)
    {
      /// If reached the maximum, so display warning message with
      /// default choice to interrupt the program
      dr = MessageBox.Show("Maximum number of failed asserts has reached the limit ("
        + s_iMaxFailedAsserts.ToString() + ")." + Environment.NewLine
        + "Do You wish to continue common program execution?",
        Application.ProductName + " - Assertion Control",
        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

      switch (dr)
      {
        case DialogResult.Yes:  // continue normal execution
          break;

        case DialogResult.No: goto default;
        default:                // abort the program
          Application.Exit();
          return false;
      }
    }

    string sMessage = String.Format("{0}\nAT: {1}"
      , _sMessage, _sFromMethod);

    dr = MessageBox.Show(null
      , sMessage
      + "\n\n___________________"
      + "\n[Yes]\t- Ignore"
      + "\n[No]\t- Throw ApplicationException"
      + "\n[Cancel]\t- Abort Application"
      , Application.ProductName + " - Assertion Failed!"
      , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);

    switch (dr)
    {
      case DialogResult.Yes:    // ignore
        break;

      case DialogResult.No:     // throw wxception
        throw new System.ApplicationException(sMessage);

      case DialogResult.Cancel:
        Application.Exit();
        return false;
    }

    return false;
  }

  [Conditional("DEBUG")]
  public static void DUMP_EXCEPTION(Exception _xcp)
  {
    DumpExceptionForm dumpForm = new DumpExceptionForm(_xcp);
    dumpForm.ShowDialog();
  }

  [Conditional("DEBUG")]
  public static void TRACE(string _str, params object[] _params)
  {
    Console.WriteLine(_str, _params);
  }

};
