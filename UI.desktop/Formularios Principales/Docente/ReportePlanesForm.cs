using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Microsoft.Reporting.WinForms;

namespace Academia.UI.Desktop.Formularios_Principales.Docente
{
    public partial class ReportePlanesForm : Form
    {
        public ReportePlanesForm()
        {
            InitializeComponent();
        }

        private void ReportePlanesForm_Load(object sender, EventArgs e)
        {
            RvPlanes.LocalReport.ReportPath = @"A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc";
            RvPlanes.ProcessingMode = ProcessingMode.Local;
            PlanBindingSource.DataSource = new PlanLogic().GetAll();
            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", PlanBindingSource);
            RvPlanes.LocalReport.DataSources.Add(reportDataSource);
            RvPlanes.LocalReport.Refresh();
            this.RvPlanes.RefreshReport();
           
        }
    }
}
