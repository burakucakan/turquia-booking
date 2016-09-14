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

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //UctrlImageUpload1.ImageUploaded +=
        //UctImageUpload1.FileUploaded += new userControls_Common_uctImageUpload.FileUploadedDelegate(UctImageUpload1_FileUploaded);
        //UctImageUpload1.FileDeleted +=new userControls_Common_uctImageUpload.FileDeletedDelegate(UctImageUpload1_FileDeleted);

        //if (!IsPostBack)
        //{
        //    UctImageUpload1.BasePath = System.Configuration.ConfigurationManager.AppSettings["TourImagesPath"];
        //    UctImageUpload1.UplType = HOTOMOTO.BUS.Enumerations.UploadType.Tour;
        //    UctImageUpload1.ID1 = "15";
        //    UctImageUpload1.AddImage("001501.jpg", "18", true);
        //    UctImageUpload1.AddImage("001502.jpg", "19", false);
        //    UctImageUpload1.GenerateFileUploads();
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //UctImageUpload1.UploadAll();
    }

    private void UctImageUpload1_FileUploaded(string FileName, bool isDefault)
    {
        //Response.Write("Erich");
    }

    private void UctImageUpload1_FileDeleted(string FileID)
    {
        //Response.Write("Deleted");
    }

}
