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

namespace Academia.UI.Desktop
{
    public partial class formCursosDocente : Form
    {
        private Usuario m_docente;
        private Operacion m_operacion;
       
        public enum Operacion
        {
            RegistroNotas,
            VisualizacionReporteCurso
        }

        public formCursosDocente(Usuario usuario)
        {
            InitializeComponent();
            Docente = usuario;
            dgvAlumnosCursos.AutoGenerateColumns = false;
        }

        #region Propiedades

        public Usuario Docente
        {
            get => m_docente;
            set => m_docente = value;
        }

        public Operacion TipoOperacion
        {
            get => m_operacion;
            set => m_operacion = value;
        }

        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos
        /// <summary>
        /// Metodo que visualiza todos los cursos
        /// </summary>
        public void Listar()
        {
            try
            {
                InscripcionLogic inscripciones = new InscripcionLogic();
                //Aca voy a tener que crear otro metodo para traer las inscripciones del docente curso
                dgvAlumnosCursos.DataSource = inscripciones.GetAll();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Devuelve si hay alguna fila/item seleccionada
        /// </summary>
        /// <returns></returns>
        private bool itemSeleccionado()
        {
            return (this.dgvAlumnosCursos.SelectedRows.Count > 0);
        }

        #endregion

        #region EventosFormulario

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(itemSeleccionado())
            {
                //Se crea el formulario con la inscripcion seleccionada
                new formIngresoNota((Inscripcion)this.dgvAlumnosCursos.SelectedRows[0].DataBoundItem).ShowDialog();      
            }
            Listar();
        }

        private void formCursosDocente_Shown(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion
    }
}
