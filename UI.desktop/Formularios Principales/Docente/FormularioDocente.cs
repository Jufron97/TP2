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
using Academia.UI.Desktop;
using Academia.UI.Desktop.Formularios_Principales.Docente;

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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistroNotas_Click(object sender, EventArgs e)
        {
            //Aca se mostraria los cursos a los cuales se inscribio el alumno
            formCursosDocente formInscripcion = new formCursosDocente(UsuarioActual);
            formInscripcion.TipoOperacion = formCursosDocente.Operacion.RegistroNotas;
            formInscripcion.ShowDialog();
        }

        private void btnReportePlanes_Click(object sender, EventArgs e)
        {
            new ReportePlanesForm().ShowDialog();
        }

        private void btnReporteCursos_Click(object sender, EventArgs e)
        {
            new ReporteAlumnoForm(UsuarioActual).ShowDialog();
        }
    }
}
