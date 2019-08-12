namespace Interfaz
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPaciente = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabExamenes = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtBuscarExamen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvExamenes = new System.Windows.Forms.DataGridView();
            this.dgvSeleccionados = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabFinalizar = new System.Windows.Forms.TabPage();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvResumenExamenes = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.lblFaseActual = new System.Windows.Forms.Label();
            this.txtBuscarSeleccionados = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPaciente.SuspendLayout();
            this.tabExamenes.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).BeginInit();
            this.tabFinalizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenExamenes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPaciente);
            this.tabControl1.Controls.Add(this.tabExamenes);
            this.tabControl1.Controls.Add(this.tabFinalizar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 514);
            this.tabControl1.TabIndex = 53;
            // 
            // tabPaciente
            // 
            this.tabPaciente.BackColor = System.Drawing.Color.LightGreen;
            this.tabPaciente.Controls.Add(this.label2);
            this.tabPaciente.Location = new System.Drawing.Point(4, 25);
            this.tabPaciente.Name = "tabPaciente";
            this.tabPaciente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaciente.Size = new System.Drawing.Size(1057, 485);
            this.tabPaciente.TabIndex = 1;
            this.tabPaciente.Text = "Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "aqui registras al paciente";
            // 
            // tabExamenes
            // 
            this.tabExamenes.BackColor = System.Drawing.Color.LightGreen;
            this.tabExamenes.Controls.Add(this.panel7);
            this.tabExamenes.Controls.Add(this.panel4);
            this.tabExamenes.Location = new System.Drawing.Point(4, 25);
            this.tabExamenes.Name = "tabExamenes";
            this.tabExamenes.Padding = new System.Windows.Forms.Padding(3);
            this.tabExamenes.Size = new System.Drawing.Size(1057, 485);
            this.tabExamenes.TabIndex = 0;
            this.tabExamenes.Text = "Examenes";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.txtBuscarSeleccionados);
            this.panel7.Controls.Add(this.txtBuscarExamen);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.btnAnadir);
            this.panel7.Controls.Add(this.btnEliminar);
            this.panel7.Controls.Add(this.dgvExamenes);
            this.panel7.Controls.Add(this.dgvSeleccionados);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1051, 386);
            this.panel7.TabIndex = 10;
            // 
            // txtBuscarExamen
            // 
            this.txtBuscarExamen.Location = new System.Drawing.Point(26, 66);
            this.txtBuscarExamen.Name = "txtBuscarExamen";
            this.txtBuscarExamen.Size = new System.Drawing.Size(248, 20);
            this.txtBuscarExamen.TabIndex = 10;
            this.txtBuscarExamen.TextChanged += new System.EventHandler(this.txtBuscarExamen_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Examenes a realizar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Todos los examenes:";
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(380, 346);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(50, 26);
            this.btnAnadir.TabIndex = 7;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(890, 346);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(50, 26);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Quitar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvExamenes
            // 
            this.dgvExamenes.AllowUserToAddRows = false;
            this.dgvExamenes.AllowUserToDeleteRows = false;
            this.dgvExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamenes.Location = new System.Drawing.Point(26, 92);
            this.dgvExamenes.Name = "dgvExamenes";
            this.dgvExamenes.ReadOnly = true;
            this.dgvExamenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamenes.Size = new System.Drawing.Size(405, 242);
            this.dgvExamenes.TabIndex = 1;
            // 
            // dgvSeleccionados
            // 
            this.dgvSeleccionados.AllowUserToAddRows = false;
            this.dgvSeleccionados.AllowUserToDeleteRows = false;
            this.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionados.Location = new System.Drawing.Point(535, 92);
            this.dgvSeleccionados.Name = "dgvSeleccionados";
            this.dgvSeleccionados.ReadOnly = true;
            this.dgvSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionados.Size = new System.Drawing.Size(405, 242);
            this.dgvSeleccionados.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1051, 93);
            this.panel4.TabIndex = 7;
            // 
            // tabFinalizar
            // 
            this.tabFinalizar.BackColor = System.Drawing.Color.LightGreen;
            this.tabFinalizar.Controls.Add(this.btnImprimir);
            this.tabFinalizar.Controls.Add(this.lblPrecioTotal);
            this.tabFinalizar.Controls.Add(this.label8);
            this.tabFinalizar.Controls.Add(this.dgvResumenExamenes);
            this.tabFinalizar.Controls.Add(this.label7);
            this.tabFinalizar.Controls.Add(this.label5);
            this.tabFinalizar.Controls.Add(this.label6);
            this.tabFinalizar.Controls.Add(this.lblNombre);
            this.tabFinalizar.Controls.Add(this.label3);
            this.tabFinalizar.Location = new System.Drawing.Point(4, 25);
            this.tabFinalizar.Name = "tabFinalizar";
            this.tabFinalizar.Size = new System.Drawing.Size(1057, 485);
            this.tabFinalizar.TabIndex = 2;
            this.tabFinalizar.Text = "Finalizar";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(843, 75);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(140, 23);
            this.btnImprimir.TabIndex = 38;
            this.btnImprimir.Text = "Imprimir Factura";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPrecioTotal.Location = new System.Drawing.Point(784, 327);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(98, 25);
            this.lblPrecioTotal.TabIndex = 37;
            this.lblPrecioTotal.Text = "preciototal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(784, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 25);
            this.label8.TabIndex = 36;
            this.label8.Text = "Precio Total:";
            // 
            // dgvResumenExamenes
            // 
            this.dgvResumenExamenes.AllowUserToAddRows = false;
            this.dgvResumenExamenes.AllowUserToDeleteRows = false;
            this.dgvResumenExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenExamenes.Location = new System.Drawing.Point(344, 75);
            this.dgvResumenExamenes.Name = "dgvResumenExamenes";
            this.dgvResumenExamenes.ReadOnly = true;
            this.dgvResumenExamenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumenExamenes.Size = new System.Drawing.Size(388, 277);
            this.dgvResumenExamenes.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(339, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 25);
            this.label7.TabIndex = 34;
            this.label7.Text = "Exámenes a realizar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(154, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 33;
            this.label5.Text = "nombrepac";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(65, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 32;
            this.label6.Text = "Nombre:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblNombre.Location = new System.Drawing.Point(154, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 25);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "cipac";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(74, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "Cédula:";
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetroceder.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRetroceder.Location = new System.Drawing.Point(115, 37);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(120, 35);
            this.btnRetroceder.TabIndex = 51;
            this.btnRetroceder.Text = "← Retroceder";
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 100);
            this.panel1.TabIndex = 54;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btnRetroceder);
            this.panel15.Controls.Add(this.btnContinuar);
            this.panel15.Controls.Add(this.lblFaseActual);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1065, 100);
            this.panel15.TabIndex = 57;
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnContinuar.Location = new System.Drawing.Point(775, 37);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(120, 35);
            this.btnContinuar.TabIndex = 52;
            this.btnContinuar.Text = "Continuar →";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblFaseActual
            // 
            this.lblFaseActual.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaseActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.lblFaseActual.Location = new System.Drawing.Point(147, 37);
            this.lblFaseActual.Name = "lblFaseActual";
            this.lblFaseActual.Size = new System.Drawing.Size(673, 39);
            this.lblFaseActual.TabIndex = 51;
            this.lblFaseActual.Text = "Fase Actual";
            this.lblFaseActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBuscarSeleccionados
            // 
            this.txtBuscarSeleccionados.Location = new System.Drawing.Point(535, 66);
            this.txtBuscarSeleccionados.Name = "txtBuscarSeleccionados";
            this.txtBuscarSeleccionados.Size = new System.Drawing.Size(248, 20);
            this.txtBuscarSeleccionados.TabIndex = 11;
            this.txtBuscarSeleccionados.TextChanged += new System.EventHandler(this.txtBuscarSeleccionados_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(280, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 20);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(789, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 20);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Factura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPaciente.ResumeLayout(false);
            this.tabPaciente.PerformLayout();
            this.tabExamenes.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).EndInit();
            this.tabFinalizar.ResumeLayout(false);
            this.tabFinalizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenExamenes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExamenes;
        private System.Windows.Forms.TabPage tabPaciente;
        private System.Windows.Forms.TabPage tabFinalizar;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvExamenes;
        private System.Windows.Forms.DataGridView dgvSeleccionados;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label lblFaseActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvResumenExamenes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtBuscarExamen;
        private System.Windows.Forms.TextBox txtBuscarSeleccionados;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}