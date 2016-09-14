using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace CARETTA.COM
{
    public class CheckBoxListLoader
    {
        public static void BindCBL(CheckBoxList cblControl, DataTable dt, string DataTextField, string DataValueField)
        {
            cblControl.DataValueField = DataValueField;
            cblControl.DataTextField = DataTextField;
            cblControl.DataSource = dt;
            cblControl.DataBind();
        }
    }
}
