namespace Academia.UI.Desktop
{
    partial class FormularioDocente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioDocente));
            this.btnRegistroNotas = new System.Windows.Forms.Button();
            this.btnReporteCursos = new System.Windows.Forms.Button();
            this.btnReportePlanes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombreyApellido = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.pnlAlumno = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlAlumno.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistroNotas
            // 
            this.btnRegistroNotas.Location = new System.Drawing.Point(302, 97);
            this.btnRegistroNotas.Name = "btnRegistroNotas";
            this.btnRegistroNotas.Size = new System.Drawing.Size(237, 33);
            this.btnRegistroNotas.TabIndex = 2;
            this.btnRegistroNotas.Text = "Registro de Notas";
            this.btnRegistroNotas.UseVisualStyleBackColor = true;
            this.btnRegistroNotas.Click += new System.EventHandler(this.btnRegistroNotas_Click);
            // 
            // btnReporteCursos
            // 
            this.btnReporteCursos.Location = new System.Drawing.Point(302, 161);
            this.btnReporteCursos.Name = "btnReporteCursos";
            this.btnReporteCursos.Size = new System.Drawing.Size(237, 33);
            this.btnReporteCursos.TabIndex = 3;
            this.btnReporteCursos.Text = "Reporte de Cursos";
            this.btnReporteCursos.UseVisualStyleBackColor = true;
            this.btnReporteCursos.Click += new System.EventHandler(this.btnReporteCursos_Click);
            // 
            // btnReportePlanes
            // 
            this.btnReportePlanes.Location = new System.Drawing.Point(302, 228);
            this.btnReportePlanes.Name = "btnReportePlanes";
            this.btnReportePlanes.Size = new System.Drawing.Size(237, 33);
            this.btnReportePlanes.TabIndex = 5;
            this.btnReportePlanes.Text = "Reporte de Planes";
            this.btnReportePlanes.UseVisualStyleBackColor = true;
            this.btnReportePlanes.Click += new System.EventHandler(this.btnReportePlanes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblNombreyApellido);
            this.panel1.Controls.Add(this.lblLegajo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombreyApellido
            // 
            this.lblNombreyApellido.AutoSize = true;
            this.lblNombreyApellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombreyApellido.Location = new System.Drawing.Point(94, 23);
            this.lblNombreyApellido.Name = "lblNombreyApellido";
            this.lblNombreyApellido.Size = new System.Drawing.Size(86, 13);
            this.lblNombreyApellido.TabIndex = 3;
            this.lblNombreyApellido.Text = "nombreYApellido";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLegajo.Location = new System.Drawing.Point(104, 56);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(35, 13);
            this.lblLegajo.TabIndex = 4;
            this.lblLegajo.Text = "legajo";
            // 
            // pnlAlumno
            // 
            this.pnlAlumno.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlAlumno.Controls.Add(this.panel1);
            this.pnlAlumno.Controls.Add(this.btnCerrarSesion);
            this.pnlAlumno.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAlumno.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.pnlAlumno.Location = new System.Drawing.Point(0, 0);
            this.pnlAlumno.Name = "pnlAlumno";
            this.pnlAlumno.Size = new System.Drawing.Size(200, 364);
            this.pnlAlumno.TabIndex = 6;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 329);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(95, 23);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormularioDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.pnlAlumno);
            this.Controls.Add(this.btnReportePlanes);
            this.Controls.Add(this.btnReporteCursos);
            this.Controls.Add(this.btnRegistroNotas);
            this.Name = "FormularioDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioDocente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlAlumno.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegistroNotas;
        private System.Windows.Forms.Button btnReporteCursos;
        private System.Windows.Forms.Button btnReportePlanes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombreyApellido;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Panel pnlAlumno;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}