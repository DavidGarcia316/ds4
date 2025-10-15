using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnSemiPerimetro_Click(object sender, EventArgs e)
        {
            int ladoA = int.Parse(txtLadoA.Text);
            int ladoB = int.Parse(txtLadoB.Text);
            int ladoc = int.Parse(txtLadoC.Text);

            int semi = (ladoA + ladoB + ladoc) / 2;


            txtResultaSemi.Text = semi.ToString();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            double ladoA = double.Parse(txtLadoA.Text);
            double ladoB = double.Parse(txtLadoB.Text);
            double ladoC = double.Parse(txtLadoC.Text);

            double semi = (ladoA + ladoB + ladoC) / 2;

            double semiSuma = (semi - ladoA) * (semi - ladoB) * (semi - ladoC);
            double resulSemi = semi * semiSuma;

            double area = Math.Round(Math.Sqrt(resulSemi), 2);

            txtResultaArea.Text = area.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtLadoA.Text = "";
            txtLadoB.Text = "";
            txtLadoC.Text = "";
            txtResultaArea.Text = "";
            txtResultaSemi.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}