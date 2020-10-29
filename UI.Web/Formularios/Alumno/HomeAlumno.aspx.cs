using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;

namespace UI.Web.Formularios.Alumno
{
    public partial class FormularioAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Usuario usu = (Usuario)Session["usuario"];
                lblNombreUsuario.Text = usu.NombreUsuario;
                lblLegajo.Text = usu.Legajo.ToString();
            }
            
        }
    }
}