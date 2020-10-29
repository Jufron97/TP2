using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeButton.ServerClick += new System.EventHandler(this.HomeButton_Click);
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                Usuario usu = (Usuario)Session["usuario"];


                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/HomeAdmin",false);
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Formularios/Alumno/HomeAlumno", false);
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Formularios/Docente/HomeDocente", false);
                        break;
                    default:
                        break;
                }
            }
            else { Response.Redirect("~/Login.aspx",false); }
        }

      
    }
}