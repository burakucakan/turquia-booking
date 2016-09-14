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

public partial class userControls_uctHotelImages : BaseUserControl {
	int max = 6;
    int imageMinIndex = 2;

    private int hotelID
    {
        get { return ((ViewState["HID"] == null) ? 0 : (int)ViewState["HID"]); }
        set { ViewState.Add("HID", value); }
    }

	protected void Page_Load(object sender, EventArgs e) {
		
	}

	void Page_Init(object sender, EventArgs e) {

        if (Request.QueryString["hotelid"] != null)
            hotelID = int.Parse(Request.QueryString["hotelid"]);

        if (hotelID == 0)
            btnRemoveImage1.Visible = false;

        for (int ImageIndex = imageMinIndex; ImageIndex <= max; ImageIndex++)
        {
			// RadioButton'larý doldurma            
			HtmlTableRow htrHotelImage = new HtmlTableRow(); htrHotelImage.Height = "70";
			HtmlTableCell htcHotelImage = new HtmlTableCell();
			RadioButton rb = new RadioButton();
			rb.ID = "rbHotelImage" + ImageIndex.ToString();
			rb.AutoPostBack = true;
			rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
			htcHotelImage.Controls.Add(rb);
			htrHotelImage.Cells.Add(htcHotelImage);
			tblRadioButtons.Rows.Add(htrHotelImage);

			// Image'leri doldurma
			imgHotelImage1.Visible = true;
			htcHotelImage = new HtmlTableCell();
			htrHotelImage = new HtmlTableRow(); htrHotelImage.Height = "70";
			Image imgHotelImage = new Image();
			imgHotelImage.ID = "imgHotelImage" + ImageIndex.ToString();
            if (hotelID == 0)
            {
                imgHotelImage.ImageUrl = "~/HotelImages/NoPicture.jpg";
            }
			imgHotelImage.Width = 90;
			imgHotelImage.Height = 60;
			imgHotelImage.BorderStyle = BorderStyle.Solid;
			imgHotelImage.BorderWidth = 2;
			htcHotelImage.Controls.Add(imgHotelImage);
			htrHotelImage.Cells.Add(htcHotelImage);
			tblImages.Rows.Add(htrHotelImage);
			

			// FileUpload'larý doldurma
			htrHotelImage = new HtmlTableRow(); htrHotelImage.Height = "70";
			htcHotelImage = new HtmlTableCell();
			FileUpload fu = new FileUpload();
			fu.ID = "fuHotelImage" + ImageIndex.ToString();
			htcHotelImage.Controls.Add(fu);
			htrHotelImage.Cells.Add(htcHotelImage);

			// ResimKaldýr butonlarýný doldurma
			if(hotelID > 0) {
				// Buton'lar
				Button btnRemoveImage = new Button();
				btnRemoveImage.Click += new EventHandler(btnRemoveImage_Click);
				btnRemoveImage.Text = "Kaldýr";
				btnRemoveImage.ID = "btnRemoveImage" + ImageIndex.ToString();
				btnRemoveImage.Width = 90;
				htcHotelImage.Controls.Add(btnRemoveImage);
				htrHotelImage.Cells.Add(htcHotelImage);
			}
			tblFileUploads.Rows.Add(htrHotelImage);
		}
		if(hotelID > 0)
			LoadHotelImages();
	}
	// Sonradan eklenen butonlara basýldýðýnda
	protected void btnRemoveImage_Click(object sender, EventArgs e) {
		int ImageIndex = 0;
		if(max <= 9)
			ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 1));
		else {
			ImageIndex = Convert.ToInt32(((Button)sender).ID.Substring(14, 2));
		}

		if(this.FindControl("rbHotelImage" + ImageIndex.ToString()) != null)
			if(!(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked))
				if(!(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.Equals("~/HotelImages/NoPicture.jpg")))
					if(hotelID > 0) {
						FileInfo fi = new FileInfo(Server.MapPath(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl));
						if(fi.Exists) {
							fi.Delete();
							string[] strButtonID = new string[2];
							strButtonID = ((Button)sender).ID.Split('_');
							int HotelImageID = 0;
							if(max <= 9)
								HotelImageID = Convert.ToInt32(strButtonID[1]);
							else
								HotelImageID = Convert.ToInt32(strButtonID[1]);
							HOTOMOTO.BUS.Hotels.RemoveHotelImage(HotelImageID);
							LoadHotelImages();
						}
					}
	}
	// Sonradan eklenen RadioButtonlar'a basýldýðýnda
	void rb_CheckedChanged(object sender, EventArgs e) {
        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
			((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked = false;
		((RadioButton)sender).Checked = true;
	}
	// Resimlerimi kaydetme
	public void SaveHotelImages(int HotelID) {
        for (int ImageIndex = 1; ImageIndex <= max; ImageIndex++)
        {
			if(this.FindControl("fuHotelImage" + ImageIndex.ToString()) != null)
				if(((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).HasFile) {
					int FormerImageIndex = 1;
					while(true) {
						FileInfo fi = new FileInfo(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + "00" + FormerImageIndex.ToString().PadLeft(2, '0') + ".jpg"));
						if(fi.Exists)
							FormerImageIndex++;
						else {
							((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).SaveAs(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + "00" + FormerImageIndex.ToString().PadLeft(2, '0') + ".jpg"));
							HOTOMOTO.APEX.HotelImages HotelImage = new HOTOMOTO.APEX.HotelImages();
							HotelImage.HotelID = HotelID;
							HotelImage.Filename = HotelID.ToString().PadLeft(4, '0') + "00" + FormerImageIndex.ToString().PadLeft(2, '0') + ".jpg";
							if(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked)
								HotelImage.isDefault = true;
							else
								HotelImage.isDefault = false;
							HotelImage.Save();
							break;
						}
					}
				}
		}
	}
	// 1.RadioButton'a basýldýðýnda
	protected void rbHotelImage1_CheckedChanged(object sender, EventArgs e) {
		//if (!(((FileUpload)this.FindControl("fuHotelImage1")).HasFile))
		//    ((RadioButton)sender).Checked = false;
		//else
		//{
        for (int ImageIndex = imageMinIndex; ImageIndex <= max; ImageIndex++)
			((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked = false;
		rbHotelImage1.Checked = true;
		//}

	}
	// Varsayýlan resimi seçmiþ mi?
	public bool isDefaultImageChosen(bool ForUpdate) {
		if(ForUpdate) {
            for (int ImageIndex = imageMinIndex; ImageIndex <= max; ImageIndex++)
            {
				if(this.FindControl("rbHotelImage" + ImageIndex.ToString()) != null)
					if(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked)
						if(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg") && !((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).HasFile)
							return false;
			}
			return true;
		} else {
            for (int ImageIndex = imageMinIndex; ImageIndex <= max; ImageIndex++)
            {
				if(this.FindControl("rbHotelImage" + ImageIndex.ToString()) != null)
					if(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked)
						if(!(((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).HasFile))
							return false;
			}
			return true;
		}
	}
	// Otel resimlerinin dolmasý
	public void LoadHotelImages() {
		DataTable dtHotelImages = new DataTable();
		dtHotelImages = HOTOMOTO.BUS.Hotels.GetHotelImages(hotelID);
        for (int ImageIndex = 1; ImageIndex <= dtHotelImages.Rows.Count; ImageIndex++)
        {
			((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked = false;
			if(Convert.ToBoolean(dtHotelImages.Rows[ImageIndex - 1]["isDefault"]))
				((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked = true;
			FileInfo fi = new FileInfo(Server.MapPath("~/HotelImages/" + dtHotelImages.Rows[ImageIndex - 1]["Filename"].ToString()));
			if(fi.Exists)
				((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl = "~/HotelImages/" + dtHotelImages.Rows[ImageIndex - 1]["Filename"].ToString();
			if(((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())) != null) {
				((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).Visible = true;
				((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).ID += "_" + dtHotelImages.Rows[ImageIndex - 1]["HotelImageID"];
			}
		}
		for(int ImageIndex = dtHotelImages.Rows.Count + 1; ImageIndex <= max; ImageIndex++) {
			((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl = "~/HotelImages/NoPicture.jpg";
			((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked = false;
			if(((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())) != null)
				((Button)this.FindControl("btnRemoveImage" + ImageIndex.ToString())).Visible = false;
		}
		upImages.Update();
		upRadioButtons.Update();
		upFileUploads.Update();
	}

	// Resimleri güncelleme (hotelid zaten sessroot'taki itemid)
	public void UpdateHotelImages(int HotelID) {
		DataTable dtHotelImages = new DataTable();
		dtHotelImages = HOTOMOTO.BUS.Hotels.GetHotelImages(HotelID);
		if(dtHotelImages.Rows.Count > 0)        // önceden eklenmiþ otel ise; güncelle
        {
            //Hotelin Id' si
			int FormerHotelIndex = Convert.ToInt32(dtHotelImages.Rows[0]["Filename"].ToString().Substring(0, 4));
            for (int ImageIndex = imageMinIndex; ImageIndex <= max; ImageIndex++)
            {
				if(this.FindControl("fuHotelImage" + ImageIndex.ToString()) != null) {
					if(((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).HasFile) {
						int PhotoIndex = 1;
						if(!(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg"))) {
							string[] strImageUrl = new string[3];
							strImageUrl = ((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.Split('/');
							PhotoIndex = Convert.ToInt32(strImageUrl[2].Substring(6, 2).PadLeft(2, '0'));
						} else {
							while(true) {
								FileInfo fiFormerImage = new FileInfo(Server.MapPath("~/HotelImages/" + HotelID.ToString().PadLeft(4, '0') + "00" + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg"));
								if(!fiFormerImage.Exists)
									break;
								else
									PhotoIndex++;
								if(PhotoIndex > max) {
									PhotoIndex--;
									break;
								}
							}
						}

						FileInfo fi = new FileInfo(Server.MapPath(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl));
						((FileUpload)this.FindControl("fuHotelImage" + ImageIndex.ToString())).SaveAs(Server.MapPath("~/HotelImages/" + FormerHotelIndex.ToString().PadLeft(4, '0') + "00" + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg"));
						if(((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.ToString().Equals("~/HotelImages/NoPicture.jpg")) {
							HOTOMOTO.APEX.HotelImages HotelImage = new HOTOMOTO.APEX.HotelImages();
							HotelImage.HotelID = HotelID;
							HotelImage.Filename = FormerHotelIndex.ToString().PadLeft(4, '0') + "00" + PhotoIndex.ToString().PadLeft(2, '0') + ".jpg";
							if(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked)
								HotelImage.isDefault = true;
							else
								HotelImage.isDefault = false;
							HotelImage.Save();
						}
					}
					if(((RadioButton)this.FindControl("rbHotelImage" + ImageIndex.ToString())).Checked) {
						int HotelImageID = 0;
						HOTOMOTO.APEX.HotelImages HotelImage = new HOTOMOTO.APEX.HotelImages();
						DataTable dtNewHotelImages = HOTOMOTO.BUS.Hotels.GetHotelImages(HotelID);
						string[] strImageUrl = new string[3];
						strImageUrl = ((Image)this.FindControl("imgHotelImage" + ImageIndex.ToString())).ImageUrl.Split('/');
						if(!(strImageUrl[2].Equals("NoPicture.jpg"))) {
							foreach(DataRow drHotelImage in dtNewHotelImages.Rows) {
								if(drHotelImage["Filename"].ToString().Equals(strImageUrl[2]) || strImageUrl[2].Equals("NoPicture.jpg"))
									HotelImageID = Convert.ToInt32(drHotelImage["HotelImageID"]);
								if(Convert.ToBoolean(drHotelImage["isDefault"])) {
									HotelImage = new HOTOMOTO.APEX.HotelImages();
									HotelImage.Load(Convert.ToInt32(drHotelImage["HotelImageID"]));
									HotelImage.isDefault = false;
									HotelImage.Save();
								}
							}
							HotelImage = new HOTOMOTO.APEX.HotelImages();
							HotelImage.Load(HotelImageID);
							HotelImage.isDefault = true;
							HotelImage.Save();
						} else {
							foreach(DataRow drHotelImage in dtNewHotelImages.Rows)
								if(Convert.ToBoolean(drHotelImage["isDefault"])) {
									HotelImage = new HOTOMOTO.APEX.HotelImages();
									HotelImage.Load(Convert.ToInt32(drHotelImage["HotelImageID"]));
									HotelImage.isDefault = false;
									HotelImage.Save();
								}
							HotelImage = new HOTOMOTO.APEX.HotelImages();
							HotelImage.Load(Convert.ToInt32(dtNewHotelImages.Rows[ImageIndex - 1]["HotelImageID"]));
							HotelImage.isDefault = true;
							HotelImage.Save();
						}
					}
				}
			}
			LoadHotelImages();
		} else
			SaveHotelImages(HotelID);
	}
}