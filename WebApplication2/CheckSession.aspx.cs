using System;

namespace WebApplication2
{
    public partial class CheckSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["WebApplication1"] == null ? "NO SESSION" : Session["WebApplication1"].ToString());
        }
    }
}