using System;

namespace WebApplication1
{
    public partial class CheckSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["WebApplication2"] == null ? "NO SESSION" : Session["WebApplication2"].ToString());
        }
    }
}