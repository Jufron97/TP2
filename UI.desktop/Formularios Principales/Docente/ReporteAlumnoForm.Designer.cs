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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InscripcionBindingSource
            // 
            this.InscripcionBindingSource.DataSource = typeof(Academia.Business.Entities.Inscripcion);
            // 
            // RvInscripciones
            // 
            reportDataSource1.Name = "DsInscripciones";
            reportDataSource1.Value = this.InscripcionBindingSource;
            this.RvInscripciones.LocalReport.DataSources.Add(reportDataSource1);
            this.RvInscripciones.LocalReport.ReportEmbeddedResource = "Academia.UI.Desktop.Formularios Principales.Docente.ReporteAlumnos.rdlc";
            this.RvInscripciones.Location = new System.Drawing.Point(3, 3);
            this.RvInscripciones.Name = "RvInscripciones";
            this.RvInscripciones.Size = new System.Drawing.Size(797, 447);
            this.RvInscripciones.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.RvInscripciones);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ReporteAlumnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ReporteAlumnoForm";
            this.Text = "ReporteAlumnoForm";
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource InscripcionBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer RvInscripciones;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}