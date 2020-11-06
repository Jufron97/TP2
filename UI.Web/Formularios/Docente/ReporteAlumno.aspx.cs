using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace UI.Web.Formularios.Docente
{
    public partial class ReporteAlumno : System.Web.UI.Page
    {

        Usuario Usuario 
        { 
            get; 
            set; 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario.Persona.TipoPersona == Persona.TiposPersonas.Docente)
            {
                if (!Page.IsPostBack)
                {
                    LoadReport();
                }
            }          
        }

        public void LoadReport()
        {
            RvInscripciones.ProcessingMode = ProcessingMode.Local;
            RvInscripciones.LocalReport.ReportPath = @"A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReporteAlumnos.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones",new InscripcionLogic().GetAll(Usuario));

            RvInscripciones.LocalReport.DataSources.Add(reportDataSource);

            RvInscripciones.LocalReport.Refresh();
            
        }


    }
}