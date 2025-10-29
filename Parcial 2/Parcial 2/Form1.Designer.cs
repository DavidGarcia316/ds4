namespace Parcial2
{
    public class Form1 : Form
    {
        private TextBox txtEntrada;
        private ComboBox cmbConversion;
        private Label lblResultado;
        private ListBox listBoxHistorial;
        private Button btnConvertir;
        private List<string> historial = new List<string>();

        public Form1()
        {
            // No llamamos a InitializeComponent
            InicializarControles();
        }

        private void InicializarControles()
        {
            this.Text = "Conversor Numérico";
            this.Size = new System.Drawing.Size(440, 300);

            txtEntrada = new TextBox() { Location = new System.Drawing.Point(20, 30), Width = 200 };
            cmbConversion = new ComboBox() { Location = new System.Drawing.Point(230, 30), Width = 180 };
            cmbConversion.Items.AddRange(new string[] {
                "Hexadecimal a Decimal",
                "Decimal a Hexadecimal",
                "Octal a Decimal",
                "Decimal a Octal"
            });
            cmbConversion.SelectedIndex = 0;
            lblResultado = new Label() { Location = new System.Drawing.Point(20, 70), Width = 390, Height = 25 };
            btnConvertir = new Button() { Text = "Convertir", Location = new System.Drawing.Point(20, 110), Width = 120 };
            btnConvertir.Click += BtnConvertir_Click;
            listBoxHistorial = new ListBox() { Location = new System.Drawing.Point(20, 150), Width = 390, Height = 100 };

            this.Controls.Add(txtEntrada);
            this.Controls.Add(cmbConversion);
            this.Controls.Add(lblResultado);
            this.Controls.Add(btnConvertir);
            this.Controls.Add(listBoxHistorial);
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                string entrada = txtEntrada.Text;
                string conversion = cmbConversion.SelectedItem.ToString();
                string resultado = "";

                if (conversion == "Hexadecimal a Decimal")
                    resultado = Convert.ToInt32(entrada, 16).ToString();
                else if (conversion == "Decimal a Hexadecimal")
                    resultado = int.Parse(entrada).ToString("X");
                else if (conversion == "Octal a Decimal")
                    resultado = Convert.ToInt32(entrada, 8).ToString();
                else if (conversion == "Decimal a Octal")
                    resultado = Convert.ToString(int.Parse(entrada), 8);

                lblResultado.Text = $"Resultado: {resultado}";
                historial.Add($"{entrada} ({conversion}) = {resultado}");
                listBoxHistorial.DataSource = null;
                listBoxHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conversión: " + ex.Message);
            }
        }
    }
}