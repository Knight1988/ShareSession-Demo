using System;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSetSession_OnClick(object sender, EventArgs e)
        {
            Session["WebApplication2"] = "I'm Session from WebApplication2";
            Response.Redirect("http://test1.pec.it/CheckSession.aspx");
        }
    }
}