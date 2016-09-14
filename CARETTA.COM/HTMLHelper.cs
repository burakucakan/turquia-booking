using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace CARETTA.COM {
    public class HTMLHelper {

        //Ýçinde Literal Olan Cell Döndürür
        public static TableCell GetTdLiteral(string Text, string Align) {
            return GetTdLiteral(Text, Align, "");
        }

        //Ýçinde Literal Olan Cell Döndürür
        public static TableCell GetTdLiteral(string Text) {
            return GetTdLiteral(Text, "", "");
        }

        //Ýçinde Literal Olan Cell Döndürür
        public static TableCell GetTdLiteral(string Text, string Align, string Width) {
            TableCell gCell = new TableCell();
            Literal ltl = new Literal();
            ltl.Text = Text;

            if (Align != "") {
                gCell.Style.Add("text-align", Align);
            }

            if (Width != "") {
                gCell.Style.Add("width", Width);
            }

            gCell.Controls.Add(ltl);
            return gCell;
        }

    }
}
