using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Pagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            miodiv.InnerHtml = HttpContext.Current.Session["miooggetto"] == null ? "NO SESSION" : HttpContext.Current.Session["miooggetto"].ToString();
        }
    }
}