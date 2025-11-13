using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio16_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static float a, c, d;
        static char b;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b1.Text;
            }
            else
                t1.Text = t1.Text + b1.Text;
        }
        protected void b2_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b2.Text;
            }
            else
                t1.Text = t1.Text + b2.Text;
        }
        protected void b3_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b3.Text;
            }
            else
                t1.Text = t1.Text + b3.Text;
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b4.Text;
            }
            else
                t1.Text = t1.Text + b4.Text;
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b5.Text;
            }
            else
                t1.Text = t1.Text + b5.Text;
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b6.Text;
            }
            else
                t1.Text = t1.Text + b6.Text;
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b7.Text;
            }
            else
                t1.Text = t1.Text + b7.Text;
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b8.Text;
            }
            else
                t1.Text = t1.Text + b8.Text;
        }

        protected void b9_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b9.Text;
            }
            else
                t1.Text = t1.Text + b9.Text;
        }

        protected void b0_Click(object sender, EventArgs e)
        {
            if ((t1.Text == "+") || (t1.Text == "-") || (t1.Text == "*") || (t1.Text == "/"))
            {
                t1.Text = "";
                t1.Text = t1.Text + b0.Text;
            }
            else
                t1.Text = t1.Text + b0.Text;
        }

        protected void add_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t1.Text);
            t1.Text = "";
            b = '+';
            t1.Text = t1.Text + b;
        }

        protected void sub_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t1.Text);
            t1.Text = "";
            b = '-';
            t1.Text = t1.Text + b;
        }

        protected void mul_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t1.Text);
            t1.Text = "";
            b = '*';
            t1.Text = t1.Text + b;
        }

        protected void div_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(t1.Text);
            t1.Text = "";
            b = '/';
            t1.Text = t1.Text + b;
        }

        protected void eql_Click(object sender, EventArgs e)
        {
            c = Convert.ToInt32(t1.Text);
            t1.Text = "";
            if (b == '+')
            {
                d = a + c;
                t1.Text += d;
                a = d;
            }
            else if (b == '+')
            {
                d= a + c;
                t1.Text += d;
                a = d;
            }
            else if (b == '-')
            {
                d = a - c;
                t1.Text += d;
                a = d;
            } 
            else if (b == '*')
            {
                d = a * c;
                t1.Text += d;
                a = d;
            }
            else
            {
                d = a / c;
                t1.Text += d;
                a = d;
            }
        }

        protected void clr_Click(object sender, EventArgs e)
        {
            t1.Text = "";
        }

        protected void t1_TextChanged(object sender, EventArgs e)
        {
            
        }



    }
}