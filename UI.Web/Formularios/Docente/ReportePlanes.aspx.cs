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
    public partial class ReportePlanes : System.Web.UI.Page
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
                    Master.MuestroMenu();
                    LoadReport();
                }
            }
        }

        public void LoadReport()
        {
            RvPlanes.LocalReport.ReportPath = @"C:\Users\User\source\repos\TP2\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc";            
            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", new PlanLogic().GetAll());
            RvPlanes.LocalReport.DataSources.Add(reportDataSource);         
            RvPlanes.LocalReport.Refresh();
        }
    }
}