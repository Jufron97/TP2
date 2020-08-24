using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace Academia.UI.Desktop
{
    public partial class FormularioDocente : Form
    {
        private Usuario m_usuarioActual;

        public Usuario UsuarioActual
        {
            get => m_usuarioActual;
            set => m_usuarioActual = value;
        }

        public FormularioDocente(Usuario usuActual)
        {
            InitializeComponent();
            UsuarioActual = usuActual;
            lblNombreyApellido.Text = UsuarioActual.Persona.Apellido + ", " + UsuarioActual.Persona.Nombre;
            lblLegajo.Text = UsuarioActual.Persona.Legajo.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
