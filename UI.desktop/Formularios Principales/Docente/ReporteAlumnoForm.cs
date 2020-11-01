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
    public partial class ReporteAlumnoForm : Form
    {
        Usuario Usuario { get; set; }
        public ReporteAlumnoForm(Usuario usu)
        {
            InitializeComponent();
            Usuario = usu;
        }

        private void ReporteAlumnoForm_Load(object sender, EventArgs e)
        {
            RvInscripciones.LocalReport.ReportPath = @"A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReporteAlumnos.rdlc";
            RvInscripciones.ProcessingMode = ProcessingMode.Local;

            InscripcionBindingSource.DataSource = new InscripcionLogic().GetAll(Usuario);

            ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", InscripcionBindingSource);

            RvInscripciones.LocalReport.DataSources.Add(reportDataSource);

            RvInscripciones.LocalReport.Refresh();
            this.RvInscripciones.RefreshReport();
           
        }
    }
}
