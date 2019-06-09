namespace Interfaz
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.Barra = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Menu_Vertical = new System.Windows.Forms.Panel();
            this.panel_compras = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_reporte_compra = new System.Windows.Forms.Button();
            this.btn_listado_compra = new System.Windows.Forms.Button();
            this.btnregistrar_compra = new System.Windows.Forms.Button();
            this.panel_final = new System.Windows.Forms.Panel();
            this.btncompras = new System.Windows.Forms.Button();
            this.btnventas = new System.Windows.Forms.Button();
            this.btnarticulos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.lblhora = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.tiempo_continuo = new System.Windows.Forms.Timer(this.components);
            this.Barra.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.Menu_Vertical.SuspendLayout();
            this.panel_compras.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // Barra
            // 
            this.Barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.Barra.Controls.Add(this.pictureBox1);
            this.Barra.Controls.Add(this.panel4);
            this.Barra.Controls.Add(this.label1);
            this.Barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.Barra.Location = new System.Drawing.Point(0, 0);
            this.Barra.Name = "Barra";
            this.Barra.Size = new System.Drawing.Size(1038, 95);
            this.Barra.TabIndex = 1;
            this.Barra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Barra_MouseDown);
            this.Barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Barra_MouseMove);
            this.Barra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Barra_MouseUp);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(81, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 92);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Salir
            // 
            this.Salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Salir.BackgroundImage")));
            this.Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Salir.FlatAppearance.BorderSize = 0;
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salir.Location = new System.Drawing.Point(182, 2);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(92, 92);
            this.Salir.TabIndex = 4;
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trajan Pro", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 91);
            this.label1.TabIndex = 3;
            this.label1.Text = "Laboratorio Clínico Especializado Virgen de Coromoto, C.A.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel3.Controls.Add(this.Menu_Vertical);
            this.panel3.Controls.Add(this.panel_compras);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1038, 680);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(7, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 86);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.Salir);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(762, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(276, 95);
            this.panel4.TabIndex = 7;
            // 
            // Menu_Vertical
            // 
            this.Menu_Vertical.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Menu_Vertical.Controls.Add(this.panel2);
            this.Menu_Vertical.Controls.Add(this.panel_login);
            this.Menu_Vertical.Controls.Add(this.panel_final);
            this.Menu_Vertical.Controls.Add(this.btncompras);
            this.Menu_Vertical.Controls.Add(this.btnventas);
            this.Menu_Vertical.Controls.Add(this.btnarticulos);
            this.Menu_Vertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu_Vertical.Location = new System.Drawing.Point(0, 0);
            this.Menu_Vertical.Name = "Menu_Vertical";
            this.Menu_Vertical.Size = new System.Drawing.Size(358, 680);
            this.Menu_Vertical.TabIndex = 1;
            // 
            // panel_compras
            // 
            this.panel_compras.Controls.Add(this.panel5);
            this.panel_compras.Controls.Add(this.btn_reporte_compra);
            this.panel_compras.Controls.Add(this.btn_listado_compra);
            this.panel_compras.Controls.Add(this.btnregistrar_compra);
            this.panel_compras.Location = new System.Drawing.Point(650, 201);
            this.panel_compras.Name = "panel_compras";
            this.panel_compras.Size = new System.Drawing.Size(358, 140);
            this.panel_compras.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.panel5.Location = new System.Drawing.Point(0, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 144);
            this.panel5.TabIndex = 15;
            // 
            // btn_reporte_compra
            // 
            this.btn_reporte_compra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.btn_reporte_compra.FlatAppearance.BorderSize = 0;
            this.btn_reporte_compra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btn_reporte_compra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reporte_compra.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reporte_compra.ForeColor = System.Drawing.Color.White;
            this.btn_reporte_compra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reporte_compra.Location = new System.Drawing.Point(6, 95);
            this.btn_reporte_compra.Name = "btn_reporte_compra";
            this.btn_reporte_compra.Size = new System.Drawing.Size(352, 48);
            this.btn_reporte_compra.TabIndex = 14;
            this.btn_reporte_compra.Text = "Reporte";
            this.btn_reporte_compra.UseVisualStyleBackColor = false;
            // 
            // btn_listado_compra
            // 
            this.btn_listado_compra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.btn_listado_compra.FlatAppearance.BorderSize = 0;
            this.btn_listado_compra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btn_listado_compra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_listado_compra.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listado_compra.ForeColor = System.Drawing.Color.White;
            this.btn_listado_compra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_listado_compra.Location = new System.Drawing.Point(6, 47);
            this.btn_listado_compra.Name = "btn_listado_compra";
            this.btn_listado_compra.Size = new System.Drawing.Size(352, 48);
            this.btn_listado_compra.TabIndex = 12;
            this.btn_listado_compra.Text = "Listado";
            this.btn_listado_compra.UseVisualStyleBackColor = false;
            // 
            // btnregistrar_compra
            // 
            this.btnregistrar_compra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(149)))), ((int)(((byte)(255)))));
            this.btnregistrar_compra.FlatAppearance.BorderSize = 0;
            this.btnregistrar_compra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btnregistrar_compra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregistrar_compra.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistrar_compra.ForeColor = System.Drawing.Color.White;
            this.btnregistrar_compra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnregistrar_compra.Location = new System.Drawing.Point(6, -1);
            this.btnregistrar_compra.Name = "btnregistrar_compra";
            this.btnregistrar_compra.Size = new System.Drawing.Size(352, 48);
            this.btnregistrar_compra.TabIndex = 10;
            this.btnregistrar_compra.Text = "Registrar";
            this.btnregistrar_compra.UseVisualStyleBackColor = false;
            // 
            // panel_final
            // 
            this.panel_final.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.panel_final.Location = new System.Drawing.Point(4, 173);
            this.panel_final.Name = "panel_final";
            this.panel_final.Size = new System.Drawing.Size(351, 2);
            this.panel_final.TabIndex = 16;
            // 
            // btncompras
            // 
            this.btncompras.FlatAppearance.BorderSize = 0;
            this.btncompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btncompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncompras.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncompras.ForeColor = System.Drawing.Color.White;
            this.btncompras.Image = ((System.Drawing.Image)(resources.GetObject("btncompras.Image")));
            this.btncompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncompras.Location = new System.Drawing.Point(2, 123);
            this.btncompras.Name = "btncompras";
            this.btncompras.Size = new System.Drawing.Size(355, 50);
            this.btncompras.TabIndex = 3;
            this.btncompras.Text = "Exámenes";
            this.btncompras.UseVisualStyleBackColor = true;
            // 
            // btnventas
            // 
            this.btnventas.FlatAppearance.BorderSize = 0;
            this.btnventas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btnventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnventas.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnventas.ForeColor = System.Drawing.Color.White;
            this.btnventas.Image = ((System.Drawing.Image)(resources.GetObject("btnventas.Image")));
            this.btnventas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnventas.Location = new System.Drawing.Point(2, 63);
            this.btnventas.Name = "btnventas";
            this.btnventas.Size = new System.Drawing.Size(355, 50);
            this.btnventas.TabIndex = 2;
            this.btnventas.Text = "Trabajadores";
            this.btnventas.UseVisualStyleBackColor = true;
            // 
            // btnarticulos
            // 
            this.btnarticulos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnarticulos.FlatAppearance.BorderSize = 0;
            this.btnarticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.btnarticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnarticulos.Font = new System.Drawing.Font("Trajan Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnarticulos.ForeColor = System.Drawing.Color.White;
            this.btnarticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnarticulos.Image")));
            this.btnarticulos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnarticulos.Location = new System.Drawing.Point(2, 3);
            this.btnarticulos.Name = "btnarticulos";
            this.btnarticulos.Size = new System.Drawing.Size(355, 50);
            this.btnarticulos.TabIndex = 1;
            this.btnarticulos.Text = "Clientes";
            this.btnarticulos.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel20);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 141);
            this.panel2.TabIndex = 20;
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.panel_login.Location = new System.Drawing.Point(2, 543);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(313, 0);
            this.panel_login.TabIndex = 19;
            // 
            // lblhora
            // 
            this.lblhora.Font = new System.Drawing.Font("Britannic Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.Color.White;
            this.lblhora.Location = new System.Drawing.Point(3, 4);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(351, 65);
            this.lblhora.TabIndex = 22;
            this.lblhora.Text = "label8";
            this.lblhora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblfecha
            // 
            this.lblfecha.Font = new System.Drawing.Font("Britannic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.Silver;
            this.lblfecha.Location = new System.Drawing.Point(-1, 70);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblfecha.Size = new System.Drawing.Size(356, 37);
            this.lblfecha.TabIndex = 23;
            this.lblfecha.Text = "label9";
            this.lblfecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(76)))), ((int)(((byte)(162)))));
            this.panel20.Controls.Add(this.lblfecha);
            this.panel20.Controls.Add(this.lblhora);
            this.panel20.Location = new System.Drawing.Point(0, 32);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(358, 110);
            this.panel20.TabIndex = 18;
            // 
            // tiempo_continuo
            // 
            this.tiempo_continuo.Enabled = true;
            this.tiempo_continuo.Interval = 1;
            this.tiempo_continuo.Tick += new System.EventHandler(this.tiempo_continuo_Tick);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1038, 775);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.Barra.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.Menu_Vertical.ResumeLayout(false);
            this.panel_compras.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Barra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel Menu_Vertical;
        private System.Windows.Forms.Panel panel_compras;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_reporte_compra;
        private System.Windows.Forms.Button btn_listado_compra;
        private System.Windows.Forms.Button btnregistrar_compra;
        private System.Windows.Forms.Panel panel_final;
        private System.Windows.Forms.Button btncompras;
        private System.Windows.Forms.Button btnventas;
        private System.Windows.Forms.Button btnarticulos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Timer tiempo_continuo;
    }
}