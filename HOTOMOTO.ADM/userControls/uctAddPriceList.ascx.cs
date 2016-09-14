using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

public partial class userControls_uctAddPriceList : BaseUserControl
{
    string strValidationGroup = "vgPriceListInsertion";
    string TxtCssClass = "textBox";
    string LblCssClass = "label";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void Page_Init(object sender, EventArgs e)
    {
        btnPublish.ValidationGroup = strValidationGroup;
        reqfvBookingEndDate.ValidationGroup = strValidationGroup;
        reqfvBookingStartDate.ValidationGroup = strValidationGroup;
        reqfvReservationEndDate.ValidationGroup = strValidationGroup;
        reqfvReservationStartDate.ValidationGroup = strValidationGroup;
        Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
        int TabIndex = 0;
        foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
        {
            if (Language.isActive == true)
            {
                TabPanel tab = new TabPanel();
                tab.ID = TabIndex.ToString();
                tab.HeaderText = Language.Language;

                Table tbl = new Table();
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                Label lbl = new Label();
                lbl.CssClass = LblCssClass;
                TextBox txt = new TextBox();
                txt.CssClass = TxtCssClass;
                txt.TextMode = TextBoxMode.MultiLine;
                RequiredFieldValidator reqfv = new RequiredFieldValidator();
                reqfv.ErrorMessage = "*";
                reqfv.ValidationGroup = strValidationGroup;
                reqfv.SetFocusOnError = true;

                #region Fiyat Listesi Adý

                lbl.Text = "Fiyat Listesi Adý : ";
                lbl.ID = "lblPriceListName" + Language.LanguageID.ToString();
                tc.Controls.Add(lbl);
                tr.Cells.Add(tc);

                txt.ID = "txtPriceListName" + Language.LanguageID.ToString();
                txt.TextMode = TextBoxMode.MultiLine;
                tc = new TableCell();
                tc.Controls.Add(txt);
                tr.Cells.Add(tc);

                reqfv.ControlToValidate = txt.ID;
                reqfv.ID = "reqfvPriceListName" + Language.LanguageID.ToString();
                tc = new TableCell();
                tc.Controls.Add(reqfv);
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);

                #endregion

                #region Fiyat Listesi Tanýmý

                tr = new TableRow();
                lbl = new Label();
                lbl.CssClass = LblCssClass;
                lbl.Text = "Fiyat Listesi Tanýmý : ";
                lbl.ID = "lblPriceListDescription" + Language.LanguageID.ToString();
                tc = new TableCell();
                tc.Controls.Add(lbl);
                tr.Cells.Add(tc);

                txt = new TextBox();
                txt.ID = "txtPriceListDescription" + Language.LanguageID.ToString();
                txt.CssClass = TxtCssClass;
                txt.TextMode = TextBoxMode.MultiLine;
                tc = new TableCell();
                tc.Controls.Add(txt);
                tr.Cells.Add(tc);

                reqfv = new RequiredFieldValidator();
                reqfv.SetFocusOnError = true;
                reqfv.ErrorMessage = "*";
                reqfv.ValidationGroup = strValidationGroup;
                reqfv.ControlToValidate = txt.ID;
                reqfv.ID = "reqfvPriceListDescription" + Language.LanguageID.ToString();
                tc = new TableCell();
                tc.Controls.Add(reqfv);
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);

                #endregion

                tab.Controls.Add(tbl);
                tabLanguages.Tabs.Add(tab);
                TabIndex++;
            }
            if (tabLanguages.Tabs.Count > 0)
                tabLanguages.ActiveTabIndex = 0;
        }
    }
    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
		//HOTOMOTO.APEX.RoomPriceLists RoomPriceList = new HOTOMOTO.APEX.RoomPriceLists();
		//RoomPriceList.ReservationStartDate = Convert.ToDateTime(txtReservationStartDate.Text);
		//RoomPriceList.ReservationEndDate = Convert.ToDateTime(txtReservationEndDate.Text);
		//RoomPriceList.BookingStartDate = Convert.ToDateTime(txtBookingStartDate.Text);
		//RoomPriceList.BookingEndDate = Convert.ToDateTime(txtBookingEndDate.Text);
		//// Dile göre deðiþen deðiþkenler
		//Hashtable htLanguages = HOTOMOTO.APEX.Languages.GetAllLanguages();
		//int TabIndex = 0;
		//foreach (HOTOMOTO.APEX.Languages Language in htLanguages.Values)
		//{
		//    RoomPriceList.Description = ((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtPriceListDescription" + Language.LanguageID.ToString())).Text;
		//    RoomPriceList.PriceListTitle = ((TextBox)tabLanguages.Tabs[TabIndex].FindControl("txtPriceListName" + Language.LanguageID.ToString())).Text;
		//    TabIndex++;
		//    break;
		//}
		////RoomPriceList.Description = 
		////int RoomPriceListID = 0;
		//RoomPriceList.Save();

    }
}
