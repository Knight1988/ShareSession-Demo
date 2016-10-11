using System;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetSession_OnClick(object sender, EventArgs e)
        {
            Session["WebApplication1"] = "I'm Session from WebApplication1";
            Response.Redirect("http://test2.pec.it/CheckSession.aspx");
        }
    }
}