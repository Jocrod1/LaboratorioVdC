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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtboxContrasena = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtboxUsuario = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtboxContrasena);
            this.panel1.Controls.Add(this.txtboxUsuario);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(108, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 378);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(257, 306);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(154, 39);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtboxContrasena
            // 
            this.txtboxContrasena.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxContrasena.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtboxContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtboxContrasena.HintForeColor = System.Drawing.Color.Empty;
            this.txtboxContrasena.HintText = "";
            this.txtboxContrasena.isPassword = true;
            this.txtboxContrasena.LineFocusedColor = System.Drawing.Color.RoyalBlue;
            this.txtboxContrasena.LineIdleColor = System.Drawing.Color.Gray;
            this.txtboxContrasena.LineMouseHoverColor = System.Drawing.Color.RoyalBlue;
            this.txtboxContrasena.LineThickness = 3;
            this.txtboxContrasena.Location = new System.Drawing.Point(154, 223);
            this.txtboxContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxContrasena.Name = "txtboxContrasena";
            this.txtboxContrasena.Size = new System.Drawing.Size(370, 44);
            this.txtboxContrasena.TabIndex = 2;
            this.txtboxContrasena.Text = "Contrasena";
            this.txtboxContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtboxContrasena.Enter += new System.EventHandler(this.txtPassEnter);
            this.txtboxContrasena.Leave += new System.EventHandler(this.txtPassLeave);
            // 
            // txtboxUsuario
            // 
            this.txtboxUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtboxUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtboxUsuario.HintForeColor = System.Drawing.Color.Empty;
            this.txtboxUsuario.HintText = "";
            this.txtboxUsuario.isPassword = false;
            this.txtboxUsuario.LineFocusedColor = System.Drawing.Color.RoyalBlue;
            this.txtboxUsuario.LineIdleColor = System.Drawing.Color.Gray;
            this.txtboxUsuario.LineMouseHoverColor = System.Drawing.Color.RoyalBlue;
            this.txtboxUsuario.LineThickness = 3;
            this.txtboxUsuario.Location = new System.Drawing.Point(154, 162);
            this.txtboxUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxUsuario.Name = "txtboxUsuario";
            this.txtboxUsuario.Size = new System.Drawing.Size(370, 44);
            this.txtboxUsuario.TabIndex = 1;
            this.txtboxUsuario.Text = "Nombre de usuario";
            this.txtboxUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtboxUsuario.Enter += new System.EventHandler(this.txtUserEnter);
            this.txtboxUsuario.Leave += new System.EventHandler(this.txtUserLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(257, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Location = new System.Drawing.Point(-5, -6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 161);
            this.panel2.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtboxContrasena;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtboxUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}