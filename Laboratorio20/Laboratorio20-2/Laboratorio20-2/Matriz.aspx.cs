using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int n;
            // Verificamos si es un número válido y mayor a 0
            if (int.TryParse(txtDimension.Text, out n) && n > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<table class='tabla-matriz'>");

                for (int fila = 0; fila < n; fila++)
                {
                    sb.Append("<tr>");
                    for (int col = 0; col < n; col++)
                    {
                        // Lógica diagonal inversa: fila + columna == N - 1
                        if (fila + col == n - 1)
                        {
                            sb.Append("<td class='uno'>1</td>");
                        }
                        else
                        {
                            sb.Append("<td>0</td>");
                        }
                    }
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                litMatriz.Text = sb.ToString();
                }
            }
        }
}