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
using System.IO;

public partial class userControls_Common_uctImageUpload : System.Web.UI.UserControl
{

    public int NrImages
    {
        get { return ViewState["NU"] == null ? 9 : Convert.ToInt32(ViewState["NU"]); }
        set { ViewState.Add("NU",value); }
    }

    public string BasePath
    {
        get { return ViewState["BP"] == null ? "" : Convert.ToString(ViewState["BP"]); }
        set { ViewState.Add("BP", value); }
    }

    public string ID1
    {
        get { return ViewState["ID1"] == null ? "" : Convert.ToString(ViewState["ID1"]); }
        set { ViewState.Add("ID1", value); }
    }

    public string ID2
    {
        get { return ViewState["ID2"] == null ? "" : Convert.ToString(ViewState["ID2"]); }
        set { ViewState.Add("ID2", value); }
    }

    private string ImageString
    {
        get { return ViewState["IS"] == null ? "" : Convert.ToString(ViewState["IS"]); }
        set { ViewState.Add("IS", value); }
    }

    public HOTOMOTO.BUS.Enumerations.UploadType UplType
    {
        get { return ViewState["UT"] == null ? HOTOMOTO.BUS.Enumerations.UploadType.Tour : (HOTOMOTO.BUS.Enumerations.UploadType)ViewState["UT"]; }
        set { ViewState.Add("UT", value); }
    }

    public void AddImage(string strFileName, string strID, bool isDefault)
    {
        this.ImageString += "#" + strFileName + "?" + strID + "?" + (isDefault == true ? "True" : "False");
    }

    public void ClearImages()
    {
        this.ImageString = "";
    }

    private ArrayList FileNames()
    {
        if (this.ImageString == "")
        {
            return new ArrayList();
        }


        string strFileNames = "";
        string[] arrFileNames;
        ArrayList alFileNames = new ArrayList();

        strFileNames = this.ImageString.Substring(1);
        arrFileNames = strFileNames.Split('#');
        for (int i = 0; i < arrFileNames.Length; i++)
        {
            alFileNames.Add(arrFileNames[i].ToString().Split('?')[0]);
        }
        return alFileNames;
    }

    private ArrayList FileIDs()
    {
        if (this.ImageString == "")
        {
            return new ArrayList();
        }

        string strFileIDs = "";
        string[] arrFileIDs;
        ArrayList alFileIDs = new ArrayList();
   
        strFileIDs = this.ImageString.Substring(1);
        arrFileIDs = strFileIDs.Split('#');
        for (int i = 0; i < arrFileIDs.Length; i++)
        {
            alFileIDs.Add(arrFileIDs[i].ToString().Split('?')[1]);
        }
        return alFileIDs;
    }

    private ArrayList FileIsDefaults()
    {
        if (this.ImageString == "")
        {
            return new ArrayList();
        }

        string strFileIDs = "";
        string[] arrFileIDs;
        ArrayList alFileIDs = new ArrayList();
     
        strFileIDs = this.ImageString.Substring(1);
        arrFileIDs = strFileIDs.Split('#');
        for (int i = 0; i < arrFileIDs.Length; i++)
        {
            alFileIDs.Add(arrFileIDs[i].ToString().Split('?')[2]);
        }
        return alFileIDs;
    }

    public delegate void FileUploadedDelegate(string FileName, bool isDefault);
    public delegate void FileDeletedDelegate(string FileID);

    public event FileUploadedDelegate FileUploaded;
    public event FileDeletedDelegate FileDeleted;

    protected void Page_Init(object sender, EventArgs e)
    {
        GenerateFileUploads();
    }

    public void GenerateFileUploads()
    {
        tblRadioButtons.Rows.Clear();
        tblImages.Rows.Clear();
        tblFileUploads.Rows.Clear();


        for (int ImageIndex = 1; ImageIndex <= this.NrImages ; ImageIndex++)
        {
            // RadioButton'larý doldurma          
            
            TableRow htrImage = new TableRow();
            htrImage.Height = Unit.Pixel(70);
            TableCell htcImage = new TableCell();

            //Radio Button Ayarlanýyor
            RadioButton rb = new RadioButton();
            rb.ID = "rbImage" + ImageIndex.ToString();
            rb.AutoPostBack = true;
            rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
            htcImage.Controls.Add(rb);
            htrImage.Cells.Add(htcImage);
            tblRadioButtons.Rows.Add(htrImage);


            //Boþ imagelarý doldurma
            
            htcImage = new TableCell();
            htrImage = new TableRow(); 
            htrImage.Height = Unit.Pixel(70);
            Image imgImage = new Image();
            imgImage.ID = "imgImage" + ImageIndex.ToString();
            imgImage.ImageUrl = this.BasePath + "/NoPicture.jpg";
            imgImage.Width = 90;
            imgImage.Height = 60;
            imgImage.BorderStyle = BorderStyle.Solid;
            imgImage.BorderWidth = 2;
            htcImage.Controls.Add(imgImage);
            htrImage.Cells.Add(htcImage);
            tblImages.Rows.Add(htrImage);

            // FileUpload'larý doldurma
            
            htrImage = new TableRow(); 
            htrImage.Height = Unit.Pixel(70);
            htcImage = new TableCell();
            FileUpload fu = new FileUpload();
            fu.ID = "fuImage" + ImageIndex.ToString();
            htcImage.Controls.Add(fu);
            htrImage.Cells.Add(htcImage);

            //Kaldýr Butonu
            Button btnRemoveImage = new Button();
            btnRemoveImage.Click += new EventHandler(btnRemoveImage_Click);
            btnRemoveImage.Text = "Kaldýr";
            btnRemoveImage.ID = "btnRemoveImage" + ImageIndex.ToString();
            btnRemoveImage.Width = 90;
            htcImage.Controls.Add(btnRemoveImage);
            htrImage.Cells.Add(htcImage);
            tblFileUploads.Rows.Add(htrImage);

        }

        LoadImages();
    }

    void rb_CheckedChanged(object sender, EventArgs e)
    {
        for (int ImageIndex = 1; ImageIndex <= this.NrImages ; ImageIndex++)
            ((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked = false;
        ((RadioButton)sender).Checked = true;
    }

    protected void btnRemoveImage_Click(object sender, EventArgs e)
    {


        int ImageIndex = 0;
        if (this.NrImages  <= 9)
            ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 1));
        else
        {
            ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 2));
        }

        if (this.FindControl("rbImage" + ImageIndex.ToString()) != null)
        {
            //if (!(((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked))
            //{
            try
            {
                FileInfo fi = new FileInfo(Server.MapPath(((Image)this.FindControl("imgImage" + ImageIndex.ToString())).ImageUrl));
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
            catch { }
                FileDeleted(Convert.ToString(this.FileIDs()[ImageIndex - 1]));
          //}
        }
    }

    public void UploadAll()
    {

        for (int ImageIndex = 1; ImageIndex <= this.NrImages; ImageIndex++)
        {
            if (this.FindControl("fuImage" + ImageIndex.ToString()) != null)
            {
                if (((FileUpload)this.FindControl("fuImage" + ImageIndex.ToString())).HasFile)
                {
                    FileInfo fi = new FileInfo(ImagePath(ImageIndex));
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    ((FileUpload)this.FindControl("fuImage" + ImageIndex.ToString())).SaveAs(ImagePath(ImageIndex));

                    if (((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked)
                    {
                        FileUploaded(System.IO.Path.GetFileName(ImagePath(ImageIndex)), true);
                    }
                    else
                    {
                        FileUploaded(System.IO.Path.GetFileName(ImagePath(ImageIndex)), false);
                    }
                }
            }
        }
    }

    private string ImagePath(int NrPicture)
    {
        if (this.UplType == HOTOMOTO.BUS.Enumerations.UploadType.Tour)
        {
            return Server.MapPath(this.BasePath + "/" + this.ID1.PadLeft(4, '0') + NrPicture.ToString().PadLeft(2, '0') + ".jpg");
        }
        return "";
        
    }

    public void LoadImages()
    {
        for (int ImageIndex = 1; ImageIndex <= this.FileNames().Count; ImageIndex++)
        {

            ((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked = false;
            if (this.FileIsDefaults()[ImageIndex -1].ToString() == "True")
                ((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked = true;

            FileInfo fi = new FileInfo(ImagePath(ImageIndex));
            if (fi.Exists)
                ((Image)this.FindControl("imgImage" + ImageIndex.ToString())).ImageUrl = this.BasePath + "/" + this.FileNames()[ImageIndex-1].ToString();
            if (((Button)this.FindControl("btnImage" + ImageIndex.ToString())) != null)
            {
                ((Button)this.FindControl("btnImage" + ImageIndex.ToString())).Visible = true;
            }
        }
        for (int ImageIndex = this.FileNames().Count + 1; ImageIndex <= this.NrImages; ImageIndex++)
        {
            ((Image)this.FindControl("imgImage" + ImageIndex.ToString())).ImageUrl = this.BasePath + "/NoPicture.jpg";
            ((RadioButton)this.FindControl("rbImage" + ImageIndex.ToString())).Checked = false;
            ((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).Visible = false;
        }
        upImages.Update();
        upRadioButtons.Update();
        upFileUploads.Update();
    }


}
