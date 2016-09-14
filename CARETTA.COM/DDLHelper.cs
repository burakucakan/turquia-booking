using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CARETTA.COM
{
    public class DDLHelper
    {


        /// <summary>
        /// DropDown Bound Baþlangýç Item YOK
        /// </summary>
        /// <param name="ddlControl">Dropdownlist</param>
        /// <param name="dt">Datasource Datatable</param>
        /// <param name="DataTextField">Görüntülenecek Hücre</param>
        /// <param name="DataValueField">Value Hücre</param>
        /// <param name="SelectedValue">Seçili Hücre</param>
        public static void BindDDL(ref System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue)
        {
            BindDDL(ref ddlControl, dt, DataTextField, DataValueField, SelectedValue, "", "");
        }

        /// <summary>
        /// DropDown Bound Baþlangýç Item VAR
        /// </summary>
        /// <param name="ddlControl">Dropdownlist</param>
        /// <param name="dt">Datasource Datatable</param>
        /// <param name="DataTextField">Görüntülenecek Hücre</param>
        /// <param name="DataValueField">Value Hücre</param>
        /// <param name="SelectedValue">Seçili Hücre</param>
        /// <param name="InitialValueText">Baþlangýç Item Text</param>
        /// <param name="InitialValue">Baþlangýç item value</param>
        public static void BindDDL(ref System.Web.UI.WebControls.DropDownList ddlControl, DataTable dt, string DataTextField, string DataValueField, string SelectedValue, string InitialValueText, string InitialValue)
        {
            ddlControl.Items.Clear();
            ddlControl.DataTextField = DataTextField;
            ddlControl.DataValueField = DataValueField;
            ddlControl.DataSource = dt;
            ddlControl.DataBind();
            if (InitialValueText != "")
            {
                ddlControl.Items.Insert(0, new System.Web.UI.WebControls.ListItem(InitialValueText, InitialValue));
            }
            if (SelectedValue != "")
            {
                ddlControl.SelectedValue = SelectedValue;
            }
        }

        /// <summary>
        /// DROPDOWNLIST I VALUE ÝLE TEXT AYNI OLACAK ÞEKÝLDE RAKAM ÝLE DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="count">Kaça kadar?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int count) {
            ddl.Items.Clear();
            LoadNumberDDL(ref ddl, count, 1, 1, false);
        }

        /// <summary>
        /// DROPDOWNLIST I VALUE ÝLE TEXT AYNI OLACAK ÞEKÝLDE RAKAM ÝLE DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="count">Kaça kadar?</param>
        /// <param name="count">Tek Hanelilerin Soluna '0' eklensin mi?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int count, bool PadLeft)
        {
            ddl.Items.Clear();
            LoadNumberDDL(ref ddl, count, 1, 1, PadLeft);
        }

        /// <summary>
        /// DROPDOWNLIST I VALUE ÝLE TEXT AYNI OLACAK ÞEKÝLDE RAKAM ÝLE ÝSTENEN SAYIDA ARTARAK DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="Count">Kaça kadar?</param>
        /// <param name="Step">Kaç Kaç Artsýn?</param>
        /// <param name="StartNumber">Kaçtan Baþlasýn?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int Count, int Step, int StartNumber) {
            ddl.Items.Clear();
            LoadNumberDDL(ref ddl, Count, Step, StartNumber, false);
        }        

        /// <summary>
        /// DROPDOWNLIST I VALUE ÝLE TEXT AYNI OLACAK ÞEKÝLDE RAKAM ÝLE ÝSTENEN SAYIDA ARTARAK DOLDURUR.
        /// </summary>
        /// <param name="ddl">DropDownlList Ref Parametre</param>
        /// <param name="Count">Kaça kadar?</param>
        /// <param name="Step">Kaç Kaç Artsýn?</param>
        /// <param name="StartNumber">Kaçtan Baþlasýn?</param>
        /// <param name="count">Tek Hanelilerin Soluna '0' eklensin mi?</param>
        public static void LoadNumberDDL(ref System.Web.UI.WebControls.DropDownList ddl, int Count, int Step, int StartNumber, bool PadLeft) {
            ddl.Items.Clear();
            for (int i = StartNumber; i <= Count; i += Step) {
                if (!PadLeft) {
                    ddl.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                }
                else {
                    ddl.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0')));
                }
            }
        }

    }
}
