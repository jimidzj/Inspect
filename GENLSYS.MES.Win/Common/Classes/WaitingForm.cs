using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GENLSYS.MES.Win.Common.Forms;
using System.Windows.Forms;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class WaitingForm
    {
        public static void CreateWaitForm()
        {
            WaitingForm.Instance.CreateForm();
        }

        public static void CloseWaitForm()
        {
            WaitingForm.Instance.CloseForm();
        }

        public static void SetWaitMessage(string msg)
        {
            WaitingForm.Instance.SetMessage(msg);
        }

        private static WaitingForm _instance;
        private static readonly Object syncLock = new Object();

        public static WaitingForm Instance
        {
            get
            {
                if (WaitingForm._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitingForm._instance == null)
                        {
                            WaitingForm._instance = new WaitingForm();
                        }
                    }
                }
                return WaitingForm._instance;
            }
        }

        private WaitingForm()
        {
        }

        private Thread waitThread;
        private frmWaiting frmWaiting;

        public void CreateForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }

            waitThread = new Thread(new ThreadStart(delegate()
            {
                frmWaiting = new frmWaiting();
                frmWaiting.ShowDialog();
                //Application.Run(frmWaiting);
            }));
            waitThread.Start();
        }

        public void CloseForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitThread.Abort();
                }
                catch (Exception)
                {
                }
            }
        }

        public void SetMessage(string msg)
        {
            if (frmWaiting != null)
            {
                try
                {
                    frmWaiting.SetMessage(msg);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
