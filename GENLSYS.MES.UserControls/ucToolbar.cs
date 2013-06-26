using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.UserControls
{
    public partial class ucToolbar : UserControl
    {
        public delegate void ucToolbarNewEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarDeleteEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarEditEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarExportEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarExitEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarQueryEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarSaveEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarReleaseEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarDispatchEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarVerUpdateEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarCopyEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarPrintEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarViewEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarTerminateEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarSyncEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarPrintLabelEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarExportFileEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarScatterEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarRepackEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarToRepairEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarRepairEventHandler(Object sender, EventArgs e);
        public delegate void ucToolbarAdjustEventHandler(Object sender, EventArgs e);

        public event ucToolbarNewEventHandler NewEventHandler;
        public event ucToolbarDeleteEventHandler DeleteEventHandler;
        public event ucToolbarEditEventHandler EditEventHandler;
        public event ucToolbarExportEventHandler ExportEventHandler;
        public event ucToolbarExitEventHandler ExitEventHandler;
        public event ucToolbarQueryEventHandler QueryEventHandler;
        public event ucToolbarSaveEventHandler SaveEventHandler;
        public event ucToolbarReleaseEventHandler ReleaseEventHandler;
        public event ucToolbarDispatchEventHandler DispatchEventHandler;
        public event ucToolbarVerUpdateEventHandler VerUpdateEventHandler;
        public event ucToolbarCopyEventHandler CopyEventHandler;
        public event ucToolbarPrintEventHandler PrintEventHandler;
        public event ucToolbarViewEventHandler ViewEventHandler;
        public event ucToolbarTerminateEventHandler TerminateEventHandler;
        public event ucToolbarSyncEventHandler SyncEventHandler;
        public event ucToolbarPrintLabelEventHandler PrintLabelEventHandler;
        public event ucToolbarExportFileEventHandler ExportFileEventHandler;
        public event ucToolbarScatterEventHandler ScatterEventHandler;
        public event ucToolbarRepackEventHandler RepackEventHandler;
        public event ucToolbarToRepairEventHandler ToRepairEventHandler;
        public event ucToolbarRepairEventHandler RepairEventHandler;
        public event ucToolbarAdjustEventHandler AdjustEventHandler;

        public ucToolbar()
        {
            InitializeComponent();

            SetDelegate();
        }

        public void SetDelegate()
        {
            btnNew.Click += delegate(object sender, EventArgs e)
            {
                if (NewEventHandler != null)
                {
                    NewEventHandler(sender, e);
                }
            };

            btnDelete.Click += delegate(object sender, EventArgs e)
            {
                if (DeleteEventHandler != null)
                {
                    DeleteEventHandler(sender, e);
                }
            };

            btnEdit.Click += delegate(object sender, EventArgs e)
            {
                if (EditEventHandler != null)
                {
                    EditEventHandler(sender, e);
                }
            };

            btnExport.Click += delegate(object sender, EventArgs e)
            {
                if (ExportEventHandler != null)
                {
                    ExportEventHandler(sender, e);
                }
            };

            btnQuery.Click += delegate(object sender, EventArgs e)
            {
                if (QueryEventHandler != null)
                {
                    QueryEventHandler(sender, e);
                }
            };

            btnSave.Click += delegate(object sender, EventArgs e)
            {
                if (SaveEventHandler != null)
                {
                    SaveEventHandler(sender, e);
                }
            };

            btnExit.Click += delegate(object sender, EventArgs e)
            {
                if (ExitEventHandler != null)
                {
                    ExitEventHandler(sender, e);
                }
            };

            btnRelease.Click += delegate(object sender, EventArgs e)
            {
                if (ReleaseEventHandler != null)
                {
                    ReleaseEventHandler(sender, e);
                }
            };

            btnDispatch.Click += delegate(object sender, EventArgs e)
            {
                if (DispatchEventHandler != null)
                {
                    DispatchEventHandler(sender, e);
                }
            };
            btnVerUpdate.Click += delegate(object sender, EventArgs e)
            {
                if (VerUpdateEventHandler != null)
                {
                    VerUpdateEventHandler(sender, e);
                }
            };
            btnCopy.Click += delegate(object sender, EventArgs e)
            {
                if (CopyEventHandler != null)
                {
                    CopyEventHandler(sender, e);
                }
            };
            btnPrint.Click += delegate(object sender, EventArgs e)
            {
                if (PrintEventHandler != null)
                {
                    PrintEventHandler(sender, e);
                }
            };
            btnView.Click += delegate(object sender, EventArgs e)
            {
                if (ViewEventHandler != null)
                {
                    ViewEventHandler(sender, e);
                }
            };
            btnTerminate.Click += delegate(object sender, EventArgs e)
            {
                if (TerminateEventHandler != null)
                {
                    TerminateEventHandler(sender, e);
                }
            };
            btnSync.Click += delegate(object sender, EventArgs e)
            {
                if (SyncEventHandler != null)
                {
                    SyncEventHandler(sender, e);
                }
            };
            btnPrintLabel.Click += delegate(object sender, EventArgs e)
            {
                if (PrintLabelEventHandler != null)
                {
                    PrintLabelEventHandler(sender, e);
                }
            };
            btnExportFile.Click += delegate(object sender, EventArgs e)
            {
                if (ExportFileEventHandler != null)
                {
                    ExportFileEventHandler(sender, e);
                }
            };
            btnScatter.Click += delegate(object sender, EventArgs e)
            {
                if (ScatterEventHandler != null)
                {
                    ScatterEventHandler(sender, e);
                }
            };
            btnRepack.Click += delegate(object sender, EventArgs e)
            {
                if (RepackEventHandler != null)
                {
                    RepackEventHandler(sender, e);
                }
            };
            btnToRepair.Click += delegate(object sender, EventArgs e)
            {
                if (ToRepairEventHandler != null)
                {
                    ToRepairEventHandler(sender, e);
                }
            };
            btnRepair.Click += delegate(object sender, EventArgs e)
            {
                if (RepairEventHandler != null)
                {
                    RepairEventHandler(sender, e);
                }
            };
            btnAdjust.Click += delegate(object sender, EventArgs e)
            {
                if (AdjustEventHandler != null)
                {
                    AdjustEventHandler(sender, e);
                }
            };
        }

        public void SetNewVisible(bool visible)
        {
            btnNew.Visible = visible;
            toolStripSeparatorNew.Visible = visible;
        }

        public void SetEditVisible(bool visible)
        {
            btnEdit.Visible = visible;
            toolStripSeparatorEdit.Visible = visible;
        }

        public void SetDeleteVisible(bool visible)
        {
            btnDelete.Visible = visible;
            toolStripSeparatorDelete.Visible = visible;
        }

        public void SetExportVisible(bool visible)
        {
            btnExport.Visible = visible;
            toolStripSeparatorExport.Visible = visible;
        }

        public void SetQueryVisible(bool visible)
        {
            btnQuery.Visible = visible;
            toolStripSeparatorQuery.Visible = visible;
        }

        public void SetSaveVisible(bool visible)
        {
            btnSave.Visible = visible;
            toolStripSeparatorSave.Visible = visible;
        }

        public void SetReleaseVisible(bool visible)
        {
            btnRelease.Visible = visible;
            toolStripSeparatorRelease.Visible = visible;
        }

        public void SetDispatchVisible(bool visible)
        {
            btnDispatch.Visible = visible;
            toolStripSeparatorDispatch.Visible = visible;
        }

        public void SetVerUpdateVisible(bool visible)
        {
            btnVerUpdate.Visible = visible;
            toolStripSeparatorVerUpdate.Visible = visible;
        }
        public void SetCopyVisible(bool visible)
        {
            btnCopy.Visible = visible;
            toolStripSeparatorCopy.Visible = visible;
        }
        public void SetPrintVisible(bool visible)
        {
            btnPrint.Visible = visible;
            toolStripSeparatorPrint.Visible = visible;
        }
        public void SetViewVisible(bool visible)
        {
            btnView.Visible = visible;
            toolStripSeparatorView.Visible = visible;
        }
        public void SetTerminateVisible(bool visible)
        {
            btnTerminate.Visible = visible;
            toolStripSeparatorTerminate.Visible = visible;
        }

        public void SetSyncVisible(bool visible)
        {
            btnSync.Visible = visible;
            toolStripSeparatorSync.Visible = visible;
        }

        public void SetPrintLabelVisible(bool visible)
        {
            btnPrintLabel.Visible = visible;
            toolStripSeparatorPrintLabel.Visible = visible;
        }

        public void SetExportFileVisible(bool visible)
        {
            btnExportFile.Visible = visible;
            toolStripSeparatorExportFile.Visible = visible;
        }

        public void SetScatterVisible(bool visible)
        {
            btnScatter.Visible = visible;
            toolStripSeparatorScatter.Visible = visible;
        }
        public void SetRepackVisible(bool visible)
        {
            btnRepack.Visible = visible;
            toolStripSeparatorRepack.Visible = visible;
        }

        public void SetToRepairVisible(bool visible)
        {
            btnToRepair.Visible = visible;
            toolStripSeparatorToRepair.Visible = visible;
        }

        public void SetRepairVisible(bool visible)
        {
            btnRepair.Visible = visible;
            toolStripSeparatorRepair.Visible = visible;
        }

        public void SetAdjustVisible(bool visible)
        {
            btnAdjust.Visible = visible;
            toolStripSeparatorAdjust.Visible = visible;
        }

        public void DoPrivilege(string formName)
        {
            foreach (ToolStripItem item in this.toolStrip1.Items)
            {
                if (item is System.Windows.Forms.ToolStripButton)
                {
                    string funcurl = formName + Parameter.FUNC_SEPARATOR + item.Name.ToLower() ;
                    string selectStr="funcurl='" + funcurl + "'";
                    if (Parameter.ALL_FUNCTIONS.Select(selectStr).Count() > 0)
                    {
                        if (Parameter.USER_FUNCTIONS.Select(selectStr).Count() == 0)
                        {
                            SetButtonVisible(item.Name,false);
                        }
                    }
                }
            }
        }

        private void SetButtonVisible(string btnName, bool visible)
        {
            if (btnName.Equals("btnNew"))
            {
                SetNewVisible(visible);
            }
            else if (btnName.Equals("btnDelete"))
            {
                SetDeleteVisible(visible);
            }
            else if (btnName.Equals("btnEdit"))
            {
                SetEditVisible(visible);
            }
            else if (btnName.Equals("btnCopy"))
            {
                SetCopyVisible(visible);
            }
            else if (btnName.Equals("btnQuery"))
            {
                SetQueryVisible(visible);
            }
            else if (btnName.Equals("btnSave"))
            {
                SetSaveVisible(visible);
            }
            else if (btnName.Equals("btnExport"))
            {
                SetExportVisible(visible);
            }
            else if (btnName.Equals("btnRelease"))
            {
                SetReleaseVisible(visible);
            }
            else if (btnName.Equals("btnDispatch"))
            {
                SetDispatchVisible(visible);
            }
            else if (btnName.Equals("btnVerUpdate"))
            {
                SetVerUpdateVisible(visible);
            }
            else if (btnName.Equals("btnPrint"))
            {
                SetPrintVisible(visible);
            }
            else if (btnName.Equals("btnView"))
            {
                SetViewVisible(visible);
            }
            else if (btnName.Equals("btnTerminate"))
            {
                SetTerminateVisible(visible);
            }
            else if (btnName.Equals("btnSync"))
            {
                SetSyncVisible(visible);
            }
            else if (btnName.Equals("btnPrintLabel"))
            {
                SetPrintLabelVisible(visible);
            }
            else if (btnName.Equals("btnExportFile"))
            {
                SetExportFileVisible(visible);
            }
            else if (btnName.Equals("btnScatter"))
            {
                SetScatterVisible(visible);
            }
            else if (btnName.Equals("btnRepack"))
            {
                SetRepackVisible(visible);
            }
            else if (btnName.Equals("btnToRepair"))
            {
                SetToRepairVisible(visible);
            }
            else if (btnName.Equals("btnRepair"))
            {
                SetRepairVisible(visible);
            }
            else if (btnName.Equals("btnAdjust"))
            {
                SetAdjustVisible(visible);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.btnEdit.Enabled = true;
            //this.btnNew.Enabled = false;
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    this.btnEdit.Enabled = false;
        //    this.btnNew.Enabled = true;
        //}

        public void SetToolbarWithSelection()
        {
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnPrint.Enabled = true;
            this.btnView.Enabled = true;
            this.btnTerminate.Enabled = true;
            this.btnPrintLabel.Enabled = true;
            this.btnExportFile.Enabled = true;
            this.btnRepair.Enabled = true;
            this.btnAdjust.Enabled = true;
        }

        public void SetToolbarWithoutSelection()
        {
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = false; 
            this.btnView.Enabled = false;
            this.btnTerminate.Enabled = false;
            this.btnPrintLabel.Enabled = false;
            this.btnExportFile.Enabled = false;
            this.btnRepair.Enabled = false;
            this.btnAdjust.Enabled = false;
        }

        public void SetToolbarWithRows()
        {
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = true;
            this.btnRepair.Enabled = true;
        }

        public void SetToolbarWithoutRows()
        {
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnRepair.Enabled = false;
        }

    }
}
