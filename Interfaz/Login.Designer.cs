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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtboxContrasena);
            this.panel1.Controls.Add(this.txtboxUsuario);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 355);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(147, 306);
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
            this.txtboxContrasena.LineFocusedColor = System.Drawing.SystemColors.HotTrack;
            this.txtboxContrasena.LineIdleColor = System.Drawing.Color.Gray;
            this.txtboxContrasena.LineMouseHoverColor = System.Drawing.SystemColors.HotTrack;
            this.txtboxContrasena.LineThickness = 3;
            this.txtboxContrasena.Location = new System.Drawing.Point(43, 238);
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
            this.txtboxUsuario.LineFocusedColor = System.Drawing.SystemColors.HotTrack;
            this.txtboxUsuario.LineIdleColor = System.Drawing.Color.Gray;
            this.txtboxUsuario.LineMouseHoverColor = System.Drawing.SystemColors.HotTrack;
            this.txtboxUsuario.LineThickness = 3;
            this.txtboxUsuario.Location = new System.Drawing.Point(43, 177);
            this.txtboxUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxUsuario.Name = "txtboxUsuario";
            this.txtboxUsuario.Size = new System.Drawing.Size(370, 44);
            this.txtboxUsuario.TabIndex = 1;
            this.txtboxUsuario.Text = "Nombre de usuario";
            this.txtboxUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtboxUsuario.Enter += new System.EventHandler(this.txtUserEnter);
            this.txtboxUsuario.Leave += new System.EventHandler(this.txtUserLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 361);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(449, 124);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(9, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 111);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 69);
            this.label1.TabIndex = 6;
            this.label1.Text = "Virgen de Coromoto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(97, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 41);
            this.label2.TabIndex = 7;
            this.label2.Text = "Laboratorio Clinico Especializado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(128, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 59);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingreso al Sistema";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 361);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtboxContrasena;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtboxUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}