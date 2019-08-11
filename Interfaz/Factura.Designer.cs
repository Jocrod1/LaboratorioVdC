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
            this.tabExamenes = new System.Windows.Forms.TabPage();
            this.tabPaciente = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabFinalizar = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvSeleccionados = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvExamenes = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblFaseActual = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabExamenes.SuspendLayout();
            this.tabPaciente.SuspendLayout();
            this.tabFinalizar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabExamenes);
            this.tabControl1.Controls.Add(this.tabPaciente);
            this.tabControl1.Controls.Add(this.tabFinalizar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 514);
            this.tabControl1.TabIndex = 53;
            // 
            // tabExamenes
            // 
            this.tabExamenes.BackColor = System.Drawing.Color.LightGreen;
            this.tabExamenes.Controls.Add(this.panel7);
            this.tabExamenes.Controls.Add(this.panel6);
            this.tabExamenes.Controls.Add(this.panel5);
            this.tabExamenes.Controls.Add(this.panel4);
            this.tabExamenes.Controls.Add(this.panel3);
            this.tabExamenes.Controls.Add(this.panel2);
            this.tabExamenes.Location = new System.Drawing.Point(4, 25);
            this.tabExamenes.Name = "tabExamenes";
            this.tabExamenes.Padding = new System.Windows.Forms.Padding(3);
            this.tabExamenes.Size = new System.Drawing.Size(1057, 485);
            this.tabExamenes.TabIndex = 0;
            this.tabExamenes.Text = "Examenes";
            // 
            // tabPaciente
            // 
            this.tabPaciente.BackColor = System.Drawing.Color.LightGreen;
            this.tabPaciente.Controls.Add(this.label2);
            this.tabPaciente.Location = new System.Drawing.Point(4, 25);
            this.tabPaciente.Name = "tabPaciente";
            this.tabPaciente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaciente.Size = new System.Drawing.Size(1285, 600);
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
            // tabFinalizar
            // 
            this.tabFinalizar.BackColor = System.Drawing.Color.LightGreen;
            this.tabFinalizar.Controls.Add(this.label3);
            this.tabFinalizar.Location = new System.Drawing.Point(4, 25);
            this.tabFinalizar.Name = "tabFinalizar";
            this.tabFinalizar.Size = new System.Drawing.Size(1061, 528);
            this.tabFinalizar.TabIndex = 2;
            this.tabFinalizar.Text = "Finalizar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "aqui review e imprimes";
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetroceder.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRetroceder.Location = new System.Drawing.Point(25, 31);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(120, 35);
            this.btnRetroceder.TabIndex = 51;
            this.btnRetroceder.Text = "← Retroceder";
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnContinuar.Location = new System.Drawing.Point(39, 31);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(120, 35);
            this.btnContinuar.TabIndex = 52;
            this.btnContinuar.Text = "Continuar →";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 100);
            this.panel1.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(976, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 479);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 53);
            this.panel3.TabIndex = 6;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(18, 17);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(973, 93);
            this.panel4.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvSeleccionados);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 215);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 174);
            this.panel5.TabIndex = 8;
            // 
            // dgvSeleccionados
            // 
            this.dgvSeleccionados.AllowUserToAddRows = false;
            this.dgvSeleccionados.AllowUserToDeleteRows = false;
            this.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeleccionados.Location = new System.Drawing.Point(0, 0);
            this.dgvSeleccionados.Name = "dgvSeleccionados";
            this.dgvSeleccionados.ReadOnly = true;
            this.dgvSeleccionados.Size = new System.Drawing.Size(973, 174);
            this.dgvSeleccionados.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 202);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(973, 13);
            this.panel6.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgvExamenes);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 56);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(973, 146);
            this.panel7.TabIndex = 10;
            // 
            // dgvExamenes
            // 
            this.dgvExamenes.AllowUserToAddRows = false;
            this.dgvExamenes.AllowUserToDeleteRows = false;
            this.dgvExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamenes.Location = new System.Drawing.Point(0, 0);
            this.dgvExamenes.Name = "dgvExamenes";
            this.dgvExamenes.Size = new System.Drawing.Size(973, 146);
            this.dgvExamenes.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 386);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(78, 93);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnEliminar);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 212);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(78, 174);
            this.panel9.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(3, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 60);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnAnadir);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(78, 212);
            this.panel10.TabIndex = 2;
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(3, 53);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(70, 60);
            this.btnAnadir.TabIndex = 6;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnRetroceder);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 100);
            this.panel11.TabIndex = 53;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnContinuar);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(873, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(192, 100);
            this.panel12.TabIndex = 54;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(200, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(673, 36);
            this.panel13.TabIndex = 55;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(200, 75);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(673, 25);
            this.panel14.TabIndex = 56;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lblFaseActual);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(200, 36);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(673, 39);
            this.panel15.TabIndex = 57;
            // 
            // lblFaseActual
            // 
            this.lblFaseActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFaseActual.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaseActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.lblFaseActual.Location = new System.Drawing.Point(0, 0);
            this.lblFaseActual.Name = "lblFaseActual";
            this.lblFaseActual.Size = new System.Drawing.Size(673, 39);
            this.lblFaseActual.TabIndex = 51;
            this.lblFaseActual.Text = "Fase Actual";
            this.lblFaseActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tabExamenes.ResumeLayout(false);
            this.tabPaciente.ResumeLayout(false);
            this.tabPaciente.PerformLayout();
            this.tabFinalizar.ResumeLayout(false);
            this.tabFinalizar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExamenes;
        private System.Windows.Forms.TabPage tabPaciente;
        private System.Windows.Forms.TabPage tabFinalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvExamenes;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvSeleccionados;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lblFaseActual;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
    }
}