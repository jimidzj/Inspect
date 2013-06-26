using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENLSYS.MES.Win.Common.Forms;
using GENLSYS.MES.Common;
using System.Windows.Forms;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class MESMsgBox
    {
        public static void ShowInformation(string message)
        {
            frmMessage f = new frmMessage();
            f.ShowInformation(message);
            f.ShowDialog();
        }

        public static void ShowInformation(string message,string title)
        {
            frmMessage f = new frmMessage();
            f.ShowInformation(message, title);
            f.ShowDialog();
        }

        public static void ShowError(string message)
        {
            frmMessage f = new frmMessage();
            f.ShowError(message);
            f.ShowDialog();
        }

        public static void ShowError(string message, string title)
        {
            frmMessage f = new frmMessage();
            f.ShowError(message, title);
            f.ShowDialog();
        }

        public static void ShowMessage(string msgHeader, string msgContext, 
            Public_MessageBox msgBox, MessageBoxButtons msgButtons)
        {
            frmMessage f = new frmMessage();
            f.ShowMessage(msgHeader, msgContext, msgBox, msgButtons);
            f.ShowDialog();
        }

        public static DialogResult ShowQuestion(string msgHeader, string msgContext,
            Public_MessageBox msgBox, MessageBoxButtons msgButtons)
        {
            frmMessage f = new frmMessage();
            f.ShowMessage(msgHeader, msgContext, msgBox, msgButtons);
            f.ShowDialog();

            return f.ReturnDialogResult;
        }

    }
}
