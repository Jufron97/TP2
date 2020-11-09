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
            RvPlanes.LocalReport.ReportPath = @"C:\Users\Jeremias\Desktop\Gonza\Facultad\4°\.Net\Laboratorios\Unidad 4\TP 2 - Laboratorio 5\TP2\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc";
            RvPlanes.ProcessingMode = ProcessingMode.Local;
            PlanBindingSource.DataSource = new PlanLogic().GetAll();
            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", PlanBindingSource);
            RvPlanes.LocalReport.DataSources.Add(reportDataSource);
            RvPlanes.LocalReport.Refresh();
            this.RvPlanes.RefreshReport();
           
        }
    }
}
