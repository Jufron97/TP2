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
            get => _logic;set => _logic = value;
            }
        protected void IngresarButton_Click(object sender, EventArgs e) 
        {
            UsuarioLogic Usuariologic = new UsuarioLogic();

            if (Usuariologic.verificoLogin(txtUsuario.Value, txtContraseña.Value))
            {
                Usuario usu = Usuariologic.GetOne(txtUsuario.Value, txtContraseña.Value);

                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/Formularios/HomeAdmin");
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Formularios/HomeAlumno");
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Formularios/HomeDocente");
                        break;
                }
                HttpContext.Current.Session["usuario"] = usu;
            }
            else 
            {
                MessageBox.Show("Soy Juan Frontons y la tengo re clara");
            }

            

        }




    }
}