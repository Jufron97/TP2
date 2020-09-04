using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Business.Logic;

namespace Academia.UI.Desktop.Formularios_Principales.Alumno
{
    public partial class InscripcionAlumno : Form
    {
        private Usuario m_usuario;
        private Operacion m_operacion;

        #region Propiedades

        public Usuario UsuarioActual
        {
            get => m_usuario;
            set => m_usuario = value;
        }

        public Operacion TipoFormulario
        {
            get => m_operacion;
            set => m_operacion = value;
        }

        #endregion

        #region Constructores

        public InscripcionAlumno(Usuario usuario)
        {
            UsuarioActual = usuario;
            InitializeComponent();
        }

        #endregion

        #region Metodos

        public void Listar()
        {
            AlumnoInscripcionLogic InsLogic = new AlumnoInscripcionLogic();
            try
            {
                if (this.TipoFormulario== InscripcionAlumno.Operacion.ListadoCursos)
                {                   
                    dgvInscripcionAlumno.DataSource = InsLogic.GetAll();
                }
                else
                {
                    dgvInscripcionAlumno.DataSource = InsLogic.GetAll(UsuarioActual);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        public enum Operacion
        {
            ListadoCursos,
            VisualizarCursos
        }
    }
}
