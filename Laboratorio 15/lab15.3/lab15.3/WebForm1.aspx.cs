using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab15._3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            String texto = TextBox1.Text;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "MessageBox", "window.alert('Hola:" + texto + "');", true);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}