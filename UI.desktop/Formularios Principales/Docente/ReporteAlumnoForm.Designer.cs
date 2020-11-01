namespace Academia.UI.Desktop.Formularios_Principales.Docente
{
    partial class ReporteAlumnoForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InscripcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RvInscripciones = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InscripcionBindingSource
            // 
            this.InscripcionBindingSource.DataSource = typeof(Academia.Business.Entities.Inscripcion);
            // 
            // RvInscripciones
            // 
            this.RvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsInscripciones";
            reportDataSource1.Value = this.InscripcionBindingSource;
            this.RvInscripciones.LocalReport.DataSources.Add(reportDataSource1);
            this.RvInscripciones.LocalReport.ReportEmbeddedResource = "Academia.UI.Desktop.Formularios Principales.Docente.ReporteAlumnos.rdlc";
            this.RvInscripciones.Location = new System.Drawing.Point(0, 0);
            this.RvInscripciones.Name = "RvInscripciones";
            this.RvInscripciones.Size = new System.Drawing.Size(1029, 631);
            this.RvInscripciones.TabIndex = 0;
            // 
            // ReporteAlumnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 631);
            this.Controls.Add(this.RvInscripciones);
            this.Name = "ReporteAlumnoForm";
            this.Text = "ReporteAlumnoForm";
            this.Load += new System.EventHandler(this.ReporteAlumnoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource InscripcionBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer RvInscripciones;
    }
}