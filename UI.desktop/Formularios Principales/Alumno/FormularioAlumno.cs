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
using Academia.UI.Desktop.Forms_Entidades.Cursos;
using Academia.UI.Desktop.Formularios_Principales.Alumno;

namespace Academia.UI.Desktop
{
    public partial class FormularioAlumno : Form
    {
        private Usuario m_usuarioActual;

        #region Propiedades

        public Usuario UsuarioActual
        {
            get => m_usuarioActual;
            set => m_usuarioActual = value;
        }

        #endregion

        #region Constructores

        public FormularioAlumno(Usuario usuActual)
        {
            InitializeComponent();
            UsuarioActual = usuActual;
            lblNombreyApellido.Text = UsuarioActual.Persona.Apellido+", "+UsuarioActual.Persona.Nombre;
            lblLegajo.Text = UsuarioActual.Persona.Legajo.ToString();
        }

        #endregion


        #region EventosFormulario

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnVisualizarCursos_Click(object sender, EventArgs e)
        {
            //Aca se mostraria los cursos a los cuales se inscribio el alumno
        }

        private void btnInscripcionCursos_Click(object sender, EventArgs e)
        {
            //Se crea el formulario correspondiente
            new InscripcionAlumno(UsuarioActual).ShowDialog();
        }
    }
}
