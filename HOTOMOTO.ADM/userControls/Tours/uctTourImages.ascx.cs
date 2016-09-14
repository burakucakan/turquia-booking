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

public partial class userControls_Tours_uctTourImages : BaseUserControl
{
    public int TourID
    {
        get {
            if (Request.QueryString["tourid"] != null)
            {
                ViewState.Add("TIDA", Convert.ToInt32(Request.QueryString["tourid"]));
            }
            return ViewState["TIDA"] == null ? 0 : Convert.ToInt32(ViewState["TIDA"]); 
        }
        set { ViewState.Add("TIDA", value); }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        UctImageUpload1.FileUploaded += new userControls_Common_uctImageUpload.FileUploadedDelegate(UctImageUpload1_FileUploaded);
        UctImageUpload1.FileDeleted += new userControls_Common_uctImageUpload.FileDeletedDelegate(UctImageUpload1_FileDeleted);

        UctImageUpload1.BasePath = System.Configuration.ConfigurationManager.AppSettings["TourImagesPath"];
        LoadAll();
        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //UctImageUpload1.FileUploaded += new userControls_Common_uctImageUpload.FileUploadedDelegate(UctImageUpload1_FileUploaded);
        //UctImageUpload1.FileDeleted += new userControls_Common_uctImageUpload.FileDeletedDelegate(UctImageUpload1_FileDeleted);


    }

    public void LoadAll()
    {
        if (this.TourID != 0)
        {
            UctImageUpload1.ClearImages();
            UctImageUpload1.BasePath = System.Configuration.ConfigurationManager.AppSettings["TourImagesPath"];
            UctImageUpload1.UplType = HOTOMOTO.BUS.Enumerations.UploadType.Tour;
            UctImageUpload1.ID1 = this.TourID.ToString();

            foreach (DataRow drTourImage in HOTOMOTO.BUS.Tour.GetTourImages(this.TourID).Rows)
            {
                UctImageUpload1.AddImage(drTourImage["FileName"].ToString(), drTourImage["TourImageID"].ToString(), Convert.ToBoolean(drTourImage["isDefault"]));
            }
        }
        UctImageUpload1.GenerateFileUploads();
    }

    public void UploadAll()
    {
        UctImageUpload1.ID1 = this.TourID.ToString();
        UctImageUpload1.UploadAll();
        LoadAll();
    }

    private void UctImageUpload1_FileUploaded(string FileName, bool isDefault)
    {
        //Response.Write("Erich");
        HOTOMOTO.APEX.TourImages objTourImages = new HOTOMOTO.APEX.TourImages();
        objTourImages.Filename = FileName;
        objTourImages.isDefault = isDefault;
        objTourImages.TourID = this.TourID;
        objTourImages.Save();
    }

    private void UctImageUpload1_FileDeleted(string FileID)
    {
        HOTOMOTO.APEX.TourImages objTourImages = new HOTOMOTO.APEX.TourImages();
        objTourImages.TourImageID = Convert.ToInt32(FileID);
        objTourImages.Delete();
        LoadAll();
    }

}
