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

public partial class userControls_uctRoomImages : BaseUserControl
{
    // Variables
    int max = 2;
    // Page Load
    public int HotelID
    {
        get { return ViewState["DHID"] == null ? 0 : Convert.ToInt32(ViewState["DHID"]); }
        set { ViewState.Add("DHID", value); }
    }

    public int RoomID
    {
        get { return ViewState["DRID"] == null ? 0 : Convert.ToInt32(ViewState["DRID"]); }
        set { ViewState.Add("DRID", value); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessRoot.ParentID == 0)
        {
        }
            //btnRemoveImage1.Visible = false;
    }
    // Page Init

    private string ImagePath(int HotelID, int RoomID, int NrPicture)
    {
        return Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + RoomID.ToString().PadLeft(4, '0') + NrPicture.ToString().PadLeft(2, '0') + ".jpg");
    }

    private string ImageFileName(int HotelID, int RoomID, int NrPicture)
    {
        return HotelID.ToString().PadLeft(4, '0') + RoomID.ToString().PadLeft(4, '0') + NrPicture.ToString().PadLeft(2, '0') + ".jpg";
    }

    void Page_Init(object sender, EventArgs e)
    {
        GenerateFileUploads();
    }

    private void GenerateFileUploads()
    {
        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
        {
            // RadioButton'larý doldurma            
            TableRow htrRoomImage = new TableRow();
            htrRoomImage.Height = Unit.Pixel(70);
            TableCell htcRoomImage = new TableCell();

            //Radio Button Ayarlanýyor
            RadioButton rb = new RadioButton();
            rb.ID = "rbRoomImage" + ImageIndex.ToString();
            rb.AutoPostBack = true;
            rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
            htcRoomImage.Controls.Add(rb);
            htrRoomImage.Cells.Add(htcRoomImage);
            tblRadioButtons.Rows.Add(htrRoomImage);


            //Boþ imagelarý doldurma
            htcRoomImage = new TableCell();
            htrRoomImage = new TableRow(); htrRoomImage.Height = Unit.Pixel(70);
            Image imgRoomImage = new Image();
            imgRoomImage.ID = "imgRoomImage" + ImageIndex.ToString();
            imgRoomImage.ImageUrl = "~/HotelImages/NoPicture.jpg";
            imgRoomImage.Width = 90;
            imgRoomImage.Height = 60;
            imgRoomImage.BorderStyle = BorderStyle.Solid;
            imgRoomImage.BorderWidth = 2;
            htcRoomImage.Controls.Add(imgRoomImage);
            htrRoomImage.Cells.Add(htcRoomImage);
            tblImages.Rows.Add(htrRoomImage);
            
            // FileUpload'larý doldurma
            htrRoomImage = new TableRow(); htrRoomImage.Height = Unit.Pixel(70);
            htcRoomImage = new TableCell();
            FileUpload fu = new FileUpload();
            fu.ID = "fuRoomImage" + ImageIndex.ToString();
            htcRoomImage.Controls.Add(fu);
            htrRoomImage.Cells.Add(htcRoomImage);

            // ResimKaldýr butonlarýný doldurma
            //if (SessRoot.ChildID > 0)
            //{
            //    // Buton'lar
            Button btnRemoveImage = new Button();
            btnRemoveImage.Click += new EventHandler(btnRemoveImage_Click);
            btnRemoveImage.Text = "Kaldýr";
            btnRemoveImage.ID = "btnRemoveImage" + ImageIndex.ToString();
            btnRemoveImage.Width = 90;
            htcRoomImage.Controls.Add(btnRemoveImage);
            htrRoomImage.Cells.Add(htcRoomImage);
            //}
            tblFileUploads.Rows.Add(htrRoomImage);
        }
        //if (SessRoot.ChildID != -1)
        //    LoadRoomImages();
        LoadRoomImages(this.HotelID, this.RoomID);
    }

    // Sonradan eklenen butonlara basýldýðýnda
    protected void btnRemoveImage_Click(object sender, EventArgs e)
    {


        int ImageIndex = 0;
        if (max <= 9)
            ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 1));
        else
        {
            ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 2));
        }

        if (this.FindControl("rbRoomImage" + ImageIndex.ToString()) != null)
        {
            if (!(((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked))
            {
                FileInfo fi = new FileInfo(Server.MapPath(((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl));
                if (fi.Exists)
                {
                    fi.Delete();
                    string[] strButtonID = new string[2];
                    strButtonID = ((Button)sender).ID.Split('_');
                    int RoomImageID = 0;
                    if (max <= 9)
                        RoomImageID = Convert.ToInt32(strButtonID[1]);
                    else
                        RoomImageID = Convert.ToInt32(strButtonID[1]);
                    HOTOMOTO.BUS.Rooms.RemoveRoomImage(RoomImageID);
                    LoadRoomImages(this.HotelID, this.RoomID);
                }
            }
        }

        //if (this.FindControl("rbRoomImage" + ImageIndex.ToString()) != null)
        //    if (!(((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked))
        //        if (SessRoot.ChildID > 0)
        //        {
        
        //        }
    }
    // Sonradan eklenen RadioButtonlar'a basýldýðýnda
    void rb_CheckedChanged(object sender, EventArgs e)
    {
        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
            ((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked = false;
        ((RadioButton)sender).Checked = true;
    }
    // Resimleri kaydetme
    public void SaveRoomImages(int HotelID, int RoomID)
    {
        //int FormerRoomIndex = 0;
        //while (true)
        //{
        //    FileInfo fi = new FileInfo(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + FormerRoomIndex.ToString().PadLeft(2, '0') + "01" + ".jpg"));
        //    if (fi.Exists)
        //        FormerRoomIndex++;
        //    else
        //        break;
        //}


        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
        {
            if (this.FindControl("fuRoomImage" + ImageIndex.ToString()) != null)
                if (((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).HasFile)
                {
                    FileInfo fi = new FileInfo(ImagePath(HotelID, RoomID, ImageIndex));
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    ((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).SaveAs(ImagePath(HotelID, RoomID, ImageIndex));
                    HOTOMOTO.APEX.RoomImages RoomImage = new HOTOMOTO.APEX.RoomImages();
                    RoomImage.Filename = ImageFileName(HotelID, RoomID, ImageIndex);
                    RoomImage.RoomID = RoomID;
                    if (((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked)
                        RoomImage.isDefault = true;
                    else
                        RoomImage.isDefault = false;
                    RoomImage.Save();

                }
        }
        LoadRoomImages(HotelID, RoomID);
    }
    // 1.RadioButton'a basýldýðýnda
    protected void rbHotelImage1_CheckedChanged(object sender, EventArgs e)
    {
        //if (!(((FileUpload)this.FindControl("fuHotelImage1")).HasFile))
        //    ((RadioButton)sender).Checked = false;
        //else
        //{
        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
            ((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked = false;
        //rbRoomImage1.Checked = true;
        //}

    }
    // Varsayýlan resimi seçmiþ mi?
    public bool isDefaultImageChosen(bool ForUpdate)
    {
        if (ForUpdate)          // güncelleme
        {
            for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
            {
                if (this.FindControl("rbRoomImage" + ImageIndex.ToString()) != null)
                    if (((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked)
                        if (((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg") && !((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).HasFile)
                            return false;
            }
            return true;
        }
        else                    // insert etme
        {
            for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
            {
                if (this.FindControl("rbRoomImage" + ImageIndex.ToString()) != null)
                    if (((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked)
                        if (!(((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).HasFile))
                            return false;
            }
            return true;
        }
    }
    // Oda resimlerinin dolmasý
    public void LoadRoomImages(int HotelID, int RoomID)
    {
        this.RoomID = RoomID;
        this.HotelID = HotelID;

        if ((this.RoomID != 0) && (this.HotelID != 0))
            return;

        try
        {
           
            DataTable dtRoomImages = new DataTable();
            dtRoomImages = HOTOMOTO.BUS.Rooms.GetRoomImages(RoomID);
            for (int ImageIndex = 1; ImageIndex <= dtRoomImages.Rows.Count; ImageIndex++)
            {

                ((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked = false;
                if (Convert.ToBoolean(dtRoomImages.Rows[ImageIndex - 1]["isDefault"]))
                    ((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked = true;

                FileInfo fi = new FileInfo(ImagePath(HotelID, RoomID, ImageIndex));
                if (fi.Exists)
                    ((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl = "~/HotelImages/" + dtRoomImages.Rows[ImageIndex - 1]["Filename"].ToString();
                if (((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())) != null)
                {
                    ((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).Visible = true;
                    ((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).ID += "_" + dtRoomImages.Rows[ImageIndex - 1]["RoomImageID"];
                }
            }
            for (int ImageIndex = dtRoomImages.Rows.Count + 1; ImageIndex <= max; ImageIndex++)
            {
                ((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl = "~/HotelImages/NoPicture.jpg";
                ((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked = false;
                ((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).Visible = false;
            }
            upImages.Update();
            upRadioButtons.Update();
            upFileUploads.Update();
        }
        catch (Exception)
        { }
    }
    // Resimleri güncelleme (roomid zaten sessroot'taki itemid)
    //public void UpdateRoomImages(int HotelID, int RoomID)
    //{
    //    DataTable dtRoomImages = new DataTable();
    //    dtRoomImages = HOTOMOTO.BUS.Rooms.GetRoomImages(RoomID);
    //    if (dtRoomImages.Rows.Count > 0)        // önceden eklenmiþ oda ise; güncelle
    //    {
    //        int FormerRoomIndex = Convert.ToInt32(dtRoomImages.Rows[0]["Filename"].ToString().Substring(4, 2));
    //        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
    //        {
    //            if (this.FindControl("fuRoomImage" + ImageIndex.ToString()) != null)
    //            {
    //                if (((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).HasFile)
    //                {
    //                    int PhotoIndex = 1;
    //                    if (!(((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg")))
    //                    {
    //                        string[] strImageUrl = new string[3];
    //                        strImageUrl = ((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl.Split('/');
    //                        PhotoIndex = Convert.ToInt32(strImageUrl[2].Substring(6, 2).PadLeft(2, '0'));
    //                    }
    //                    else
    //                    {
    //                        while (true)
    //                        {
    //                            FileInfo fiFormerImage = new FileInfo(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + FormerRoomIndex.ToString().PadLeft(2, '0') + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg"));
    //                            if (!fiFormerImage.Exists)
    //                                break;
    //                            else
    //                                PhotoIndex++;
    //                            if (PhotoIndex > max)
    //                            {
    //                                PhotoIndex--;
    //                                break;
    //                            }
    //                        }
    //                    }
    //                    FileInfo fi = new FileInfo(Server.MapPath(((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl));
    //                    ((FileUpload)this.FindControl("fuRoomImage" + ImageIndex.ToString())).SaveAs(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + FormerRoomIndex.ToString().PadLeft(2, '0') + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg"));
    //                    if (((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg"))
    //                    {
    //                        HOTOMOTO.APEX.RoomImages RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                        RoomImage.RoomID = RoomID;
    //                        RoomImage.Filename = HotelID.ToString().PadLeft(4, '0') + FormerRoomIndex.ToString().PadLeft(2, '0') + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg";
    //                        if (((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked)
    //                            RoomImage.isDefault = true;
    //                        else
    //                            RoomImage.isDefault = false;
    //                        RoomImage.Save();
    //                    }
    //                }
    //                if (((RadioButton)this.FindControl("rbRoomImage" + ImageIndex.ToString())).Checked)
    //                {
    //                    int RoomImageID = 0;
    //                    HOTOMOTO.APEX.RoomImages RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                    DataTable dtNewRoomImages = HOTOMOTO.BUS.Rooms.GetRoomImages(RoomID);
    //                    string[] strImageUrl = new string[3];
    //                    strImageUrl = ((Image)this.FindControl("imgRoomImage" + ImageIndex.ToString())).ImageUrl.Split('/');
    //                    if (!(strImageUrl[2].Equals("NoPicture.jpg")))
    //                    {
    //                        foreach (DataRow drRoomImage in dtNewRoomImages.Rows)
    //                        {

    //                            if (drRoomImage["Filename"].ToString().Equals(strImageUrl[2]))
    //                                RoomImageID = Convert.ToInt32(drRoomImage["RoomImageID"]);
    //                            if (Convert.ToBoolean(drRoomImage["isDefault"]))
    //                            {
    //                                RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                                RoomImage.Load(Convert.ToInt32(drRoomImage["RoomImageID"]));
    //                                RoomImage.isDefault = false;
    //                                RoomImage.Save();
    //                            }
    //                        }
    //                        RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                        RoomImage.Load(RoomImageID);
    //                        RoomImage.isDefault = true;
    //                        RoomImage.Save();
    //                    }
    //                    else
    //                    {
    //                        foreach (DataRow drRoomImage in dtNewRoomImages.Rows)
    //                            if (Convert.ToBoolean(drRoomImage["isDefault"]))
    //                            {
    //                                RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                                RoomImage.Load(Convert.ToInt32(drRoomImage["RoomImageID"]));
    //                                RoomImage.isDefault = false;
    //                                RoomImage.Save();
    //                            }
    //                        RoomImage = new HOTOMOTO.APEX.RoomImages();
    //                        RoomImage.Load(Convert.ToInt32(dtNewRoomImages.Rows[ImageIndex - 1]["RoomImageID"]));
    //                        RoomImage.isDefault = true;
    //                        RoomImage.Save();  
    //                    }
    //                }
    //            }
    //        }
    //        //LoadRoomImages();
    //    }
    //    else
    //        SaveRoomImages(HotelID, RoomID);
    //}
}
