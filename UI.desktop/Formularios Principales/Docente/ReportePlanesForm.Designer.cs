namespace Academia.UI.Desktop.Formularios_Principales.Docente
{
    partial class ReportePlanesForm
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
            this.PlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RvPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PlanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanBindingSource
            // 
            this.PlanBindingSource.DataSource = typeof(Academia.Business.Entities.Plan);
            // 
            // RvPlanes
            // 
            this.RvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsPlanes";
            reportDataSource1.Value = this.PlanBindingSource;
            this.RvPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.RvPlanes.LocalReport.ReportEmbeddedResource = "Academia.UI.Desktop.Formularios Principales.Docente.ReportePlanes.rdlc";
            this.RvPlanes.Location = new System.Drawing.Point(0, 0);
            this.RvPlanes.Name = "RvPlanes";
            this.RvPlanes.Size = new System.Drawing.Size(1044, 615);
            this.RvPlanes.TabIndex = 0;
            // 
            // ReportePlanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 615);
            this.Controls.Add(this.RvPlanes);
            this.Name = "ReportePlanesForm";
            this.Text = "ReportePlanesForm";
            this.Load += new System.EventHandler(this.ReportePlanesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvPlanes;
        private System.Windows.Forms.BindingSource PlanBindingSource;
    }
}