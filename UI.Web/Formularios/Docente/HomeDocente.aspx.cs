using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;

namespace UI.Web.Formularios.Docente
{
    public partial class FormularioDocente : System.Web.UI.Page
    {
        Usuario Usu { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usu = (Usuario)Session["usuario"];
            lblNombreUsuario.Text = Usu.NombreUsuario;
            Master.MuestroMenu();           
        }

    }
}