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
                    LoadReport();
                }
            }
        }

        public void LoadReport()
        {
            RvPlanes.LocalReport.ReportPath = @"C:\Users\Jeremias\Desktop\Gonza\Facultad\4°\.Net\Laboratorios\Unidad 4\TP 2 - Laboratorio 5\TP2\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc";
            
            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", new PlanLogic().GetAll());

            RvPlanes.LocalReport.DataSources.Add(reportDataSource);
            RvPlanes.DataBind();
            RvPlanes.LocalReport.Refresh();

        }


    }
}