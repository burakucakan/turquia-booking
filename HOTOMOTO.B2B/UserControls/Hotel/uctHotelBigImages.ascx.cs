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
using System.Text;

public partial class UserControls_Hotel_uctHotelBigImages :BaseUserControl {

    private int m_HotelID;

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            if (CARETTA.COM.Util.IsNumeric(Request.QueryString["HotelID"])) {
                this.m_HotelID = int.Parse(Request.QueryString["HotelID"]);
            }
            else { Response.Redirect("Default.aspx"); }

        }

        DataTable dtImages = HOTOMOTO.BUS.Hotels.GetHotelImages(m_HotelID);
        GenerateHTML(dtImages);
    }

    private void GenerateHTML(DataTable dtImages) {

        StringBuilder sbImages = new StringBuilder();

        sbImages.Append("<table align=center cellpadding=2>");

        for (int i = 0; i < dtImages.Rows.Count; i++) {
            sbImages.Append("<tr>");
            for (int j = 1; j <= 3; j++) {
                if (dtImages.Rows.Count - 1 < i) {
                    sbImages.Append("<td colspan=2>");
                    break;
                }
                else {
                    sbImages.Append("<td>");
                    sbImages.Append("<img width=236 height=178 src='Images/HotelImages/Big/");
                    sbImages.Append(dtImages.Rows[i]["FileName"].ToString());
                    sbImages.Append("'> </td>");
                    sbImages.Append("<td width='10px'></td>");
                    i++;
                }
            }
            sbImages.Append("</tr>");
            i--;
        }

        sbImages.Append("</table>");
        dvImages.InnerHtml = sbImages.ToString();
    }

}
