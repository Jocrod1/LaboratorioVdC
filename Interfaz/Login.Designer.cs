namespace Interfaz
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.cbCedula = new System.Windows.Forms.ComboBox();
            this.mostrar_contraseña = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtcontraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_contraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtusuario);
            this.panel1.Controls.Add(this.cbCedula);
            this.panel1.Controls.Add(this.mostrar_contraseña);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtcontraseña);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 361);
            this.panel1.TabIndex = 0;
            // 
            // txtusuario
            // 
            this.txtusuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtusuario.Font = new System.Drawing.Font("Century Gothic", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(174, 191);
            this.txtusuario.MaxLength = 50;
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(180, 30);
            this.txtusuario.TabIndex = 96;
            // 
            // cbCedula
            // 
            this.cbCedula.BackColor = System.Drawing.SystemColors.Control;
            this.cbCedula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCedula.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cbCedula.FormattingEnabled = true;
            this.cbCedula.Items.AddRange(new object[] {
            "V-",
            "E-"});
            this.cbCedula.Location = new System.Drawing.Point(102, 190);
            this.cbCedula.Name = "cbCedula";
            this.cbCedula.Size = new System.Drawing.Size(64, 29);
            this.cbCedula.TabIndex = 95;
            this.cbCedula.SelectedIndexChanged += new System.EventHandler(this.cbCedula_SelectedIndexChanged);
            // 
            // mostrar_contraseña
            // 
            this.mostrar_contraseña.BackColor = System.Drawing.Color.Transparent;
            this.mostrar_contraseña.BackgroundImage = global::Interfaz.Properties.Resources.view;
            this.mostrar_contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mostrar_contraseña.Location = new System.Drawing.Point(360, 234);
            this.mostrar_contraseña.Name = "mostrar_contraseña";
            this.mostrar_contraseña.Size = new System.Drawing.Size(32, 32);
            this.mostrar_contraseña.TabIndex = 16;
            this.mostrar_contraseña.TabStop = false;
            this.mostrar_contraseña.Visible = false;
            this.mostrar_contraseña.Click += new System.EventHandler(this.mostrar_contraseña_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(54, 234);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(54, 191);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // txtcontraseña
            // 
            this.txtcontraseña.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtcontraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcontraseña.Font = new System.Drawing.Font("Century Gothic", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontraseña.Location = new System.Drawing.Point(99, 236);
            this.txtcontraseña.MaxLength = 50;
            this.txtcontraseña.Name = "txtcontraseña";
            this.txtcontraseña.Size = new System.Drawing.Size(255, 30);
            this.txtcontraseña.TabIndex = 2;
            this.txtcontraseña.Enter += new System.EventHandler(this.txtPassEnter);
            this.txtcontraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontraseña_KeyDown);
            this.txtcontraseña.Leave += new System.EventHandler(this.txtPassLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18.32727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(102, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingreso al Sistema";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOrange;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 124);
            this.panel3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 49);
            this.label2.TabIndex = 7;
            this.label2.Text = "Laboratorio Clínico Especializado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 77);
            this.label1.TabIndex = 6;
            this.label1.Text = "Virgen de Coromoto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(100, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(254, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(196)))), ((int)(((byte)(90)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 361);
            this.panel2.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 361);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_contraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcontraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.PictureBox mostrar_contraseña;
        private System.Windows.Forms.ComboBox cbCedula;
        private System.Windows.Forms.TextBox txtusuario;
    }
}