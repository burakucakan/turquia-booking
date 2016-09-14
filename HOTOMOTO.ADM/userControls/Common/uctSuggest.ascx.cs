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

public partial class userControls_Common_uctSuggest : System.Web.UI.UserControl
{

    public object DataSource
    {
        set { lb.DataSource = value; }
    }

    public string DataTextField
    {
        set { lb.DataTextField = value; }
    }

    public string DataValueField
    {
        set { lb.DataValueField = value; }
    }

    public string SelectedValue
    {
        get { return lb.SelectedIndex > -1 ? lb.SelectedValue : "0" ; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void DataBindLb()
    {
        lb.DataBind();
        lb.Items.Insert(0,new ListItem("Tümü","0"));
        tb.Text = "";
    }


    private void BringUP(string textToSearch)
    {
        int LastAddedIndex = 0;
        string tempText = "";
        string tempValue = "";
        textToSearch = textToSearch.ToLower();
        for (int i = 0; i < lb.Items.Count; i++)
        {
            if (lb.Items[i].Text.ToLower().IndexOf(textToSearch) > -1)
            {
                tempText = lb.Items[i].Text;
                tempValue = lb.Items[i].Value;
                lb.Items[i].Text = lb.Items[LastAddedIndex].Text;
                lb.Items[i].Value = lb.Items[LastAddedIndex].Value;
                lb.Items[LastAddedIndex].Text = tempText;
                lb.Items[LastAddedIndex].Value = tempValue;
                LastAddedIndex += 1;
            }
        }
        lb.SelectedIndex = -1;
    }



    protected void btnS_Click(object sender, EventArgs e)
    {
        if (tb.Text == "")
        {
            BringUP("Tümü");
        }
        else
        {
            BringUP(tb.Text);
        }
    }
}
