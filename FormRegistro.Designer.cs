namespace Clinica.Saludable.Vistas
{
    partial class FormRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            textBox2 = new TextBox();
            txtRut = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRut);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(579, 307);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 63);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 0;
            label1.Text = "Rut:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 100);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 133);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha de nacimiento:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(185, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(213, 27);
            txtNombre.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(185, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 27);
            textBox2.TabIndex = 4;
            //textBox2.TextChanged += textBox2_TextChanged;
            // 
            // txtRut
            // 
            txtRut.Location = new Point(185, 100);
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(213, 27);
            txtRut.TabIndex = 5;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 331);
            Controls.Add(groupBox1);
            Name = "FormRegistro";
            Text = "FormRegistro";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtRut;
        private TextBox textBox2;
        private TextBox txtNombre;
    }
}