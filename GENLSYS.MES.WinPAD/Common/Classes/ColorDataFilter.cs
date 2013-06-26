using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win;
using System.Drawing;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    public class ColorDataFilter : Infragistics.Win.IEditorDataFilter
    {
        object Infragistics.Win.IEditorDataFilter.Convert(Infragistics.Win.EditorDataFilterConvertArgs args)
        {
            switch (args.Direction)
            {
                case ConversionDirection.EditorToOwner:
                    args.Handled = true;
                    return ColorTranslator.ToHtml((Color)args.Value);
                case ConversionDirection.OwnerToEditor:
                    args.Handled = true;
                    return ColorTranslator.FromHtml(args.Value.ToString());
            }
            return args.Value;
        }
    }
}
