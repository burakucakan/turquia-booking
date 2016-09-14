using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CARETTA.COM
{
    public class CBLHelper
    {

        public static void BindCBL(ref System.Web.UI.WebControls.CheckBoxList cblControl, DataTable dt, string DataTextField, string DataValueField)
        {
            cblControl.Items.Clear();
            cblControl.DataTextField = DataTextField;
            cblControl.DataValueField = DataValueField;
            cblControl.DataSource = dt;
            cblControl.DataBind();
        }

    }

   

}
