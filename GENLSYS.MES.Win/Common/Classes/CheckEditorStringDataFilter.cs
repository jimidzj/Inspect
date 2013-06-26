using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win;
using System.Windows.Forms;
using GENLSYS.MES.Common;

namespace GENLSYS.MES.Win.Common.Classes
{
    public class CheckEditorStringDataFilter : Infragistics.Win.IEditorDataFilter
    {
        object Infragistics.Win.IEditorDataFilter.Convert(Infragistics.Win.EditorDataFilterConvertArgs args)
        {
            switch (args.Direction)
            {
                case ConversionDirection.EditorToOwner:
                    args.Handled = true;
                    CheckState state = (CheckState)args.Value;
                    switch (state)
                    {
                        case CheckState.Checked:
                            return MES_Misc.Y.ToString();
                        case CheckState.Unchecked:
                            return MES_Misc.N.ToString();
                        case CheckState.Indeterminate:
                            return "?";
                    }
                    break;
                case ConversionDirection.OwnerToEditor:
                    args.Handled = true;
                    if (args.Value.ToString() == MES_Misc.Y.ToString())
                        return CheckState.Checked;
                    else if (args.Value.ToString() == MES_Misc.N.ToString())
                        return CheckState.Unchecked;
                    else
                        return CheckState.Indeterminate;
            }
            return args.Value;
        }
    }
}
