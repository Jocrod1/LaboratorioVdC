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
            this.tabFinalizar = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFaseActual = new System.Windows.Forms.Label();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExamenes = new System.Windows.Forms.DataGridView();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvSeleccionados = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabExamenes.SuspendLayout();
            this.tabPaciente.SuspendLayout();
            this.tabFinalizar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1069, 557);
            this.tabControl1.TabIndex = 53;
            // 
            // tabExamenes
            // 
            this.tabExamenes.BackColor = System.Drawing.Color.LightGreen;
            this.tabExamenes.Controls.Add(this.txtBuscar);
            this.tabExamenes.Controls.Add(this.dgvSeleccionados);
            this.tabExamenes.Controls.Add(this.btnEliminar);
            this.tabExamenes.Controls.Add(this.btnAnadir);
            this.tabExamenes.Controls.Add(this.dgvExamenes);
            this.tabExamenes.Location = new System.Drawing.Point(4, 25);
            this.tabExamenes.Name = "tabExamenes";
            this.tabExamenes.Padding = new System.Windows.Forms.Padding(3);
            this.tabExamenes.Size = new System.Drawing.Size(1061, 528);
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
            this.tabPaciente.Size = new System.Drawing.Size(1061, 528);
            this.tabPaciente.TabIndex = 1;
            this.tabPaciente.Text = "Paciente";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "aqui registras al paciente";
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
            // lblFaseActual
            // 
            this.lblFaseActual.AutoSize = true;
            this.lblFaseActual.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaseActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.lblFaseActual.Location = new System.Drawing.Point(514, 26);
            this.lblFaseActual.Name = "lblFaseActual";
            this.lblFaseActual.Size = new System.Drawing.Size(144, 37);
            this.lblFaseActual.TabIndex = 50;
            this.lblFaseActual.Text = "Fase Actual";
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetroceder.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRetroceder.Location = new System.Drawing.Point(388, 31);
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
            this.btnContinuar.Location = new System.Drawing.Point(664, 31);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(120, 35);
            this.btnContinuar.TabIndex = 52;
            this.btnContinuar.Text = "Continuar →";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRetroceder);
            this.panel1.Controls.Add(this.btnContinuar);
            this.panel1.Controls.Add(this.lblFaseActual);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 100);
            this.panel1.TabIndex = 54;
            // 
            // dgvExamenes
            // 
            this.dgvExamenes.AllowUserToAddRows = false;
            this.dgvExamenes.AllowUserToDeleteRows = false;
            this.dgvExamenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamenes.Location = new System.Drawing.Point(8, 62);
            this.dgvExamenes.Name = "dgvExamenes";
            this.dgvExamenes.Size = new System.Drawing.Size(969, 149);
            this.dgvExamenes.TabIndex = 0;
            // 
            // btnAnadir
            // 
            this.btnAnadir.Location = new System.Drawing.Point(983, 62);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(70, 60);
            this.btnAnadir.TabIndex = 1;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = true;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(983, 240);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 60);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvSeleccionados
            // 
            this.dgvSeleccionados.AllowUserToAddRows = false;
            this.dgvSeleccionados.AllowUserToDeleteRows = false;
            this.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeleccionados.Location = new System.Drawing.Point(8, 240);
            this.dgvSeleccionados.Name = "dgvSeleccionados";
            this.dgvSeleccionados.ReadOnly = true;
            this.dgvSeleccionados.Size = new System.Drawing.Size(969, 149);
            this.dgvSeleccionados.TabIndex = 3;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(8, 36);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 20);
            this.txtBuscar.TabIndex = 4;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Factura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabExamenes.ResumeLayout(false);
            this.tabExamenes.PerformLayout();
            this.tabPaciente.ResumeLayout(false);
            this.tabPaciente.PerformLayout();
            this.tabFinalizar.ResumeLayout(false);
            this.tabFinalizar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabExamenes;
        private System.Windows.Forms.TabPage tabPaciente;
        private System.Windows.Forms.TabPage tabFinalizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFaseActual;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.DataGridView dgvExamenes;
        private System.Windows.Forms.DataGridView dgvSeleccionados;
        private System.Windows.Forms.TextBox txtBuscar;

    }
}