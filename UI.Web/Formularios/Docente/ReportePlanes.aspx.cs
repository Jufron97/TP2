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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadReport();
            }
        }

        public void LoadReport()
        {
            
            RvPlanes.LocalReport.ReportPath = @"A:\Juan\Facu\NET\Unidad 5\Lab5.6\TP2L05\UI.desktop\Formularios Principales\Docente\ReportePlanes.rdlc";

            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", new PlanLogic().GetAll());

            RvPlanes.LocalReport.DataSources.Add(reportDataSource);

            RvPlanes.LocalReport.Refresh();

        }


    }
}