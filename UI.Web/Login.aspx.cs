using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using System.Windows.Forms;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IngresarButton.ServerClick += new System.EventHandler(this.IngresarButton_Click);
        }

        private UsuarioLogic _logic;

        public UsuarioLogic Usuariologic
        {
            get => _logic;
            set => _logic = value;
        }

        protected void IngresarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ENTRE LA CONCHA DE TU MADRE"+ String.Format("{0}", Request.Form["txtUsu"]));
            UsuarioLogic Usuariologic = new UsuarioLogic();

            if (Usuariologic.verificoLogin("Zalo","zalito123"))
            {
                Usuario usu = Usuariologic.GetOne("Zalo", "zalito123");
                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/HomeAdmin.aspx");
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Formularios/Alumno/HomeAlumno.aspx");
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Formularios/Docente/HomeDocente.aspx");
                        break;
                }
                HttpContext.Current.Session["usuario"] = usu;
            }
            else
            {
                Response.Write("<script>window.open('Mensaje.aspx','popup','width=800,height=500') </script>");
            }
        }
    }
}