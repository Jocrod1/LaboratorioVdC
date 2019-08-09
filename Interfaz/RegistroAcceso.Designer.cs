namespace Interfaz
{
    partial class RegistroAcceso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroAcceso));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbTop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.txtCedulaTurno = new System.Windows.Forms.TextBox();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_cedula = new System.Windows.Forms.Panel();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.panel_fechas = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_turno = new System.Windows.Forms.Panel();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_cedula.SuspendLayout();
            this.panel_fechas.SuspendLayout();
            this.panel_turno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_fechas);
            this.panel1.Controls.Add(this.panel_turno);
            this.panel1.Controls.Add(this.panel_cedula);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.cbBuscar);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 122);
            this.panel1.TabIndex = 0;
            // 
            // cbBuscar
            // 
            this.cbBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.cbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBuscar.FormattingEnabled = true;
            this.cbBuscar.Items.AddRange(new object[] {
            "Cedula",
            "Turno",
            "Fechas"});
            this.cbBuscar.Location = new System.Drawing.Point(17, 40);
            this.cbBuscar.Name = "cbBuscar";
            this.cbBuscar.Size = new System.Drawing.Size(117, 31);
            this.cbBuscar.TabIndex = 1;
            this.cbBuscar.SelectedIndexChanged += new System.EventHandler(this.cbBuscar_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbTop);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(988, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(152, 122);
            this.panel4.TabIndex = 69;
            // 
            // cbTop
            // 
            this.cbTop.BackColor = System.Drawing.SystemColors.Control;
            this.cbTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTop.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTop.FormattingEnabled = true;
            this.cbTop.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.cbTop.Location = new System.Drawing.Point(18, 40);
            this.cbTop.Name = "cbTop";
            this.cbTop.Size = new System.Drawing.Size(122, 31);
            this.cbTop.TabIndex = 7;
            this.cbTop.SelectedIndexChanged += new System.EventHandler(this.cbTop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 68;
            this.label1.Text = "Top:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 62;
            this.label3.Text = "Buscar por:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.lblTotal.Location = new System.Drawing.Point(180, 77);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 17);
            this.lblTotal.TabIndex = 61;
            this.lblTotal.Text = "label5";
            // 
            // dtHasta
            // 
            this.dtHasta.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtHasta.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(390, 4);
            this.dtHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(230, 33);
            this.dtHasta.TabIndex = 6;
            this.dtHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // dtDesde
            // 
            this.dtDesde.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtDesde.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(88, 4);
            this.dtDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(230, 33);
            this.dtDesde.TabIndex = 5;
            this.dtDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // txtCedulaTurno
            // 
            this.txtCedulaTurno.BackColor = System.Drawing.SystemColors.Control;
            this.txtCedulaTurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedulaTurno.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedulaTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCedulaTurno.Location = new System.Drawing.Point(361, 3);
            this.txtCedulaTurno.Name = "txtCedulaTurno";
            this.txtCedulaTurno.Size = new System.Drawing.Size(269, 33);
            this.txtCedulaTurno.TabIndex = 4;
            this.txtCedulaTurno.TextChanged += new System.EventHandler(this.txtCedulaTurno_TextChanged);
            // 
            // cbTurno
            // 
            this.cbTurno.BackColor = System.Drawing.SystemColors.Control;
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Items.AddRange(new object[] {
            "Cedula",
            "Nombre"});
            this.cbTurno.Location = new System.Drawing.Point(17, 5);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(260, 31);
            this.cbTurno.TabIndex = 3;
            this.cbTurno.SelectedIndexChanged += new System.EventHandler(this.cbTurno_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 511);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1140, 57);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 122);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(48, 389);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1086, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(54, 389);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataListado);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(48, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1038, 389);
            this.panel3.TabIndex = 4;
            // 
            // panel_cedula
            // 
            this.panel_cedula.Controls.Add(this.txtCedula);
            this.panel_cedula.Location = new System.Drawing.Point(143, 34);
            this.panel_cedula.Name = "panel_cedula";
            this.panel_cedula.Size = new System.Drawing.Size(299, 44);
            this.panel_cedula.TabIndex = 67;
            this.panel_cedula.Visible = false;
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.SystemColors.Control;
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCedula.Location = new System.Drawing.Point(13, 7);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(269, 33);
            this.txtCedula.TabIndex = 2;
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            // 
            // panel_fechas
            // 
            this.panel_fechas.Controls.Add(this.label4);
            this.panel_fechas.Controls.Add(this.label2);
            this.panel_fechas.Controls.Add(this.dtDesde);
            this.panel_fechas.Controls.Add(this.dtHasta);
            this.panel_fechas.Location = new System.Drawing.Point(142, 36);
            this.panel_fechas.Name = "panel_fechas";
            this.panel_fechas.Size = new System.Drawing.Size(645, 41);
            this.panel_fechas.TabIndex = 66;
            this.panel_fechas.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.label4.Location = new System.Drawing.Point(324, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 71;
            this.label4.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "Desde:";
            // 
            // panel_turno
            // 
            this.panel_turno.Controls.Add(this.label5);
            this.panel_turno.Controls.Add(this.cbTurno);
            this.panel_turno.Controls.Add(this.txtCedulaTurno);
            this.panel_turno.Location = new System.Drawing.Point(144, 38);
            this.panel_turno.Name = "panel_turno";
            this.panel_turno.Size = new System.Drawing.Size(643, 41);
            this.panel_turno.TabIndex = 3;
            this.panel_turno.Visible = false;
            // 
            // dataListado
            // 
            this.dataListado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataListado.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListado.Location = new System.Drawing.Point(0, 0);
            this.dataListado.Name = "dataListado";
            this.dataListado.RowHeadersWidth = 51;
            this.dataListado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(1038, 389);
            this.dataListado.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(12, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(25, 25);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.label5.Location = new System.Drawing.Point(283, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 25);
            this.label5.TabIndex = 69;
            this.label5.Text = "Cedula:";
            // 
            // RegistroAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 568);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "RegistroAcceso";
            this.Text = "RegistroAcceso";
            this.Load += new System.EventHandler(this.RegistroAcceso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel_cedula.ResumeLayout(false);
            this.panel_cedula.PerformLayout();
            this.panel_fechas.ResumeLayout(false);
            this.panel_fechas.PerformLayout();
            this.panel_turno.ResumeLayout(false);
            this.panel_turno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.TextBox txtCedulaTurno;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.Panel panel_turno;
        private System.Windows.Forms.Panel panel_cedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Panel panel_fechas;
        private System.Windows.Forms.ComboBox cbTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
    }
}