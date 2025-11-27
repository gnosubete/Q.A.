namespace Clinica.Saludable.Vistas
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        

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
            button1 = new Button();
            button2 = new Button();
            txtRut = new TextBox();
            txtPassword = new TextBox();
            groupBox1.SuspendLayout();
            //SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtRut);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(513, 330);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 55);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 0;
            label1.Text = "Rut:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 106);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // button1
            // 
            button1.Location = new Point(168, 172);
            button1.Name = "button1";
            button1.Size = new Size(133, 46);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(207, 255);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            //button2.Click += button2_Click;
            // 
            // txtRut
            // 
            txtRut.Location = new Point(130, 55);
            txtRut.Name = "txtRut";
            txtRut.Size = new Size(223, 27);
            txtRut.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(130, 106);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(233, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            //AutoScaleDimensions = new SizeF(8F, 20F);
            //AutoScaleMode = AutoScaleMode.Font;
            //ClientSize = new Size(537, 354);
            //Controls.Add(groupBox1);
            //Name = "FormLogin";
            //Text = "FormLogin";
            //groupBox1.ResumeLayout(false);
            //groupBox1.PerformLayout();
            //ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtRut;
    }
}