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

       
        private void btnVisualizarCursos_Click(object sender, EventArgs e)
        {
            //Aca se mostraria los cursos a los cuales se inscribio el alumno
            InscripcionAlumno formInscripcion = new InscripcionAlumno(UsuarioActual);
            formInscripcion.TipoOperacion = InscripcionAlumno.Operacion.VisualizarCursos;
            formInscripcion.ShowDialog();
        }

        private void btnInscripcionCursos_Click(object sender, EventArgs e)
        {
            //Se crea el formulario correspondiente
            InscripcionAlumno formInscripcion = new InscripcionAlumno(UsuarioActual);
            formInscripcion.TipoOperacion = InscripcionAlumno.Operacion.InscripcionCurso;
            formInscripcion.ShowDialog();
        }

        #endregion
    }
}
