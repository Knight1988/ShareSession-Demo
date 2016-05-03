using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["test"] = "il mio test";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["miooggetto"] = "ciao a tutti";
            //Server.Transfer("Pagina.aspx", true);
            Response.Redirect("http://test2.pec.it/Pagina.aspx");
            //Response.Redirect("Pagina.aspx");
        }
    }
}