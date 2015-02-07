using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public partial class DumpExceptionForm : Form
{
  private Exception m_exception;

  public DumpExceptionForm(Exception _xcp)
  {
    m_exception = _xcp;

    InitializeComponent();
  }

  private void DumpExceptionForm_Load(object sender, EventArgs e)
  {
    this.Text = Application.ProductName + " - " + this.Text;
    txtType.Text = m_exception.GetType().ToString();
    txtMessage.Text = m_exception.Message;
    txtStackTrace.Text = m_exception.StackTrace;
  }

  private void btnContinue_Click(object sender, EventArgs e)
  {
    this.Close();
  }

  private void btnThrowException_Click(object sender, EventArgs e)
  {
    throw new ApplicationException(
      "User choosed to throw ApplicationException from DumpExceptionForm"
      + " that rised with {" + m_exception.Message + "} exception."
      , m_exception);
  }

  private void btnExitAplication_Click(object sender, EventArgs e)
  {
    Application.Exit();
  }

};
