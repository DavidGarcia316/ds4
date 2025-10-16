namespace Laboratorio13
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            lista = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(290, 33);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(262, 85);
            button1.TabIndex = 0;
            button1.Text = "Conectar y desconectar de sql server";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lista
            // 
            lista.FormattingEnabled = true;
            lista.Location = new Point(159, 174);
            lista.Margin = new Padding(2, 2, 2, 2);
            lista.Name = "lista";
            lista.Size = new Size(263, 144);
            lista.TabIndex = 1;
            lista.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 360);
            Controls.Add(lista);
            Controls.Add(button1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListBox lista;
    }
}
