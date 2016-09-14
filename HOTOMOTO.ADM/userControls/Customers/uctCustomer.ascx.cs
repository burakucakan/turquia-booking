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

public partial class userControls_Customers_uctCustomer : BaseUserControl 
{

   

    public int CustomerID
    {
        get {
            if (Request.QueryString["customerid"] != null)
            {
                return Convert.ToInt32(Request.QueryString["customerid"]);
            }
            else if (ViewState["cid"] == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ViewState["cid"]);
            }

        }
        set { ViewState.Add("cid",value); }
    }
	

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["customerid"] != null)
        {
            pnlAddress.Visible = true;
            UctCustomerAddresses1.CustomerID = Convert.ToInt32(Request.QueryString["customerid"]);
            UctCustomerAccessOptions1.CustomerID = Convert.ToInt32(Request.QueryString["customerid"]);
        }
        else
        {
            pnlAddress.Visible = false;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            


            CARETTA.COM.DDLHelper.BindDDL(ref ddlCT, HOTOMOTO.APEX.CustomerTypes.GetAllCustomerTypesDataSet(this.SessRoot.LanguageID).Tables[0], "Type", "CustomerTypeID", "0", "Müþteri tipi seçiniz...", "0");

            CARETTA.COM.DDLHelper.BindDDL(ref ddlCurT, HOTOMOTO.APEX.Currencies.GetAllCurrenciesDataSet().Tables[0], "Code", "CurrencyID", "0", "Döviz Tipi Seçiniz...", "0");

            LoadAll();

        }
    }

    private void LoadAll()
    {
        HOTOMOTO.APEX.Customers objCustomer;
        DataTable dtCustomerCredibility;

        if (this.CustomerID != 0)
        {
            objCustomer = new HOTOMOTO.APEX.Customers();
            objCustomer.Load(this.CustomerID);
            txtCC.Text = objCustomer.CustomerCode.ToString();
            txtCL.Text = "0";
            dtCustomerCredibility = HOTOMOTO.APEX.Custom.SPExec_Payment.GetCredibilityByCustomerID(this.CustomerID);
            if (dtCustomerCredibility.Rows.Count > 0)
            {
                txtCL.Text = dtCustomerCredibility.Rows[0]["CreditLimit"].ToString();
                lblCCID.Text = dtCustomerCredibility.Rows[0]["CustomerCredibilityID"].ToString();
            }
            else
            {
                lblCCID.Text = "0";
            }
            txtCN.Text = objCustomer.CustomerName;
            txtEmA.Text  = objCustomer.EmailAddress;
            txtFN.Text = objCustomer.CompanyName;
            txtWS.Text = objCustomer.Website;
            ddlCT.SelectedValue = objCustomer.CustomerTypeID.ToString();
            ddlCurT.SelectedValue = objCustomer.CurrencyID.ToString();
            cbIsActive.Checked = objCustomer.isActive;
        }
    }

    private void SaveAll()
    {
        HOTOMOTO.APEX.Customers objCustomer;
        HOTOMOTO.APEX.CustomerCredibilities objCustomerCredibilities;
        int intCustomerID = 0;

        objCustomer = new HOTOMOTO.APEX.Customers();
        if (this.CustomerID != 0)
        {
            objCustomer.Load(this.CustomerID);
        }
        else
        {
            objCustomer.CreateDate = DateTime.Now;
            objCustomer.CreatedBy = this.SessRoot.UserID;
        }
        objCustomer.CompanyName = txtFN.Text;
        objCustomer.CurrencyID = Convert.ToInt32(ddlCurT.SelectedValue);
        objCustomer.CustomerCode = txtCC.Text;
        objCustomer.CustomerName = txtCN.Text;
        objCustomer.CustomerTypeID = Convert.ToInt32(ddlCT.SelectedValue);
        objCustomer.EmailAddress = txtEmA.Text;
        objCustomer.isActive = cbIsActive.Checked;
        objCustomer.Website = txtWS.Text;
        if (this.CustomerID == 0)
        {
            intCustomerID = objCustomer.Save();
        }
        else
        {
            objCustomer.Save();
            intCustomerID = this.CustomerID;
        }
        
        objCustomerCredibilities = new HOTOMOTO.APEX.CustomerCredibilities();
        if (this.CustomerID != 0)
        {
            objCustomerCredibilities.Load(Convert.ToInt32(lblCCID.Text));
            if (objCustomerCredibilities.CustomerCredibilityID == 0)
            {
                objCustomerCredibilities.CreateDate = DateTime.Now;
                objCustomerCredibilities.CreatedBy = this.SessRoot.UserID;
            }
        }
        else
        {
            objCustomerCredibilities.CreateDate = DateTime.Now;
            objCustomerCredibilities.CreatedBy = this.SessRoot.UserID;
        }
        objCustomerCredibilities.CustomerID = intCustomerID;
        objCustomerCredibilities.CreditLimit = Convert.ToInt32(txtCL.Text);
        objCustomerCredibilities.ModifiedBy = this.SessRoot.UserID;
        objCustomerCredibilities.ModifyDate = DateTime.Now;
        objCustomerCredibilities.Save();

    }

    protected void btnPublish_Click(object sender, ImageClickEventArgs e)
    {
        
        SaveAll();
        pnlAddress.Visible = true;

    }
}
