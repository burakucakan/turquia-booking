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

public partial class userControls_uctMessage : BaseUserControl {

    private MessageType m_MessageType;
    private MessageBlockCss m_MessageBlockCss; 
    
    protected void Page_Load(object sender, EventArgs e) {
        if(!Page.IsPostBack) {
            ltrLinks.Text = string.Empty;
            this.Css = MessageBlockCss.b710;
        }
    }

    public void AddLink(string Link, string Title) {
        ltrLinks.Text += "<div class\"hotlinks\"><a href=\"" + Link + "\">" + Title + "</a></div>";
    }

    public string Message {
        get { return this.lblMessage.Text; }
        set { this.lblMessage.Text = value; }
    }

    public MessageType Type {
        get { return this.m_MessageType; }
        set {
            this.m_MessageType = value;

            if(this.m_MessageType == MessageType.Information)
                this.lblMessage.CssClass = "information";
            else if(this.m_MessageType == MessageType.Warning)
                this.lblMessage.CssClass = "warning";
            else if(this.m_MessageType == MessageType.Error)
                this.lblMessage.CssClass = "error";
        }
    }

    public MessageBlockCss Css {
        get { return this.m_MessageBlockCss; }
        set {
            this.m_MessageBlockCss = value;

            if(this.m_MessageBlockCss == MessageBlockCss.b230)
                this.pnlMessage.CssClass = "b230";
            else if(this.m_MessageBlockCss == MessageBlockCss.b470)
                this.pnlMessage.CssClass = "b470";
            else if(this.m_MessageBlockCss == MessageBlockCss.b710)
                this.pnlMessage.CssClass = "b710";
        }
    }
}