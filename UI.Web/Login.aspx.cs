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
using Academia.Util;

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
            if (Usuariologic.verificoLogin(txtUsuario.Value, txtContraseña.Value))
            {
                this.cvContraseña.IsValid = true;             
                Usuario usu = Usuariologic.GetOne(txtUsuario.Value, txtContraseña.Value);
                //Se asgina el usuario a la sesion para no perderlo
                Session["usuario"] = usu;
                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/HomeAdmin.aspx",false);
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Formularios/Alumno/HomeAlumno.aspx",false);
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Formularios/Docente/HomeDocente.aspx",false);
                        break;

                    default: Response.Redirect("~/Login.aspx",false);
                        break;
                }
                
            }
            else
            {
                this.cvContraseña.IsValid = false;
                Response.Write("<script>window.open('Mensaje.aspx','popup','width=800,height=500') </script>");
            }
            return;
        }
    }
}