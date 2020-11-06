using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;

namespace UI.Web
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        public Usuario Usuario
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if(Usuario.Persona.TipoPersona==Persona.TiposPersonas.Admin)
            {
                Master.MuestroMenu();
            }          
        }
    }
}