namespace Academia.UI.Desktop.Formularios_Principales.Alumno
{
    partial class InscripcionAlumno
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
            this.dgvInscripcionAlumno = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcionAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInscripcionAlumno
            // 
            this.dgvInscripcionAlumno.AllowUserToAddRows = false;
            this.dgvInscripcionAlumno.AllowUserToDeleteRows = false;
            this.dgvInscripcionAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripcionAlumno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDMateria,
            this.IDComision});
            this.dgvInscripcionAlumno.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvInscripcionAlumno.Location = new System.Drawing.Point(0, 0);
            this.dgvInscripcionAlumno.MultiSelect = false;
            this.dgvInscripcionAlumno.Name = "dgvInscripcionAlumno";
            this.dgvInscripcionAlumno.ReadOnly = true;
            this.dgvInscripcionAlumno.RowHeadersVisible = false;
            this.dgvInscripcionAlumno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripcionAlumno.Size = new System.Drawing.Size(413, 209);
            this.dgvInscripcionAlumno.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // IDMateria
            // 
            this.IDMateria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDMateria.DataPropertyName = "DescMateria";
            this.IDMateria.FillWeight = 30F;
            this.IDMateria.HeaderText = "Materia";
            this.IDMateria.Name = "IDMateria";
            this.IDMateria.ReadOnly = true;
            // 
            // IDComision
            // 
            this.IDComision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDComision.DataPropertyName = "DescComision";
            this.IDComision.FillWeight = 30F;
            this.IDComision.HeaderText = "Comision";
            this.IDComision.Name = "IDComision";
            this.IDComision.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(242, 221);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(326, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // InscripcionAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 256);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dgvInscripcionAlumno);
            this.Name = "InscripcionAlumno";
            this.Text = "InscripcionAlumno";
            this.Shown += new System.EventHandler(this.InscripcionAlumno_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcionAlumno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInscripcionAlumno;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDComision;
    }
}