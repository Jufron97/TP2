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
    public partial class InscripcionAlumno : Form
    {
        private Usuario m_usuario;
        private Operacion m_operacion;

        public enum Operacion
        {
            VisualizarCursos,
            InscripcionCurso
        }

        #region Propiedades

        public Usuario UsuarioActual
        {
            get => m_usuario;
            set => m_usuario = value;
        }

        public Operacion TipoOperacion
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
            this.dgvInscripcionAlumno.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que visualiza todos los cursos
        /// </summary>
        public void Listar()
        {
            try
            {
                if (this.TipoOperacion == InscripcionAlumno.Operacion.InscripcionCurso)
                {
                    this.Nota.Visible = false;
                    this.Condicion.Visible = false;
                    CursoLogic curLogic = new CursoLogic();
                    dgvInscripcionAlumno.DataSource = curLogic.GetAll();
                }
                else 
                {
                    this.btnSeleccionar.Visible = false;
                    //Dado que tengo que se muestra otra propiedad, hay que cambiarle eel DataPropertyName
                    this.Materia.DataPropertyName = "DescCursoMateria";
                    this.Comision.DataPropertyName = "DescCursoComision";
                    InscripcionLogic alInsLogic = new InscripcionLogic();
                    dgvInscripcionAlumno.DataSource = alInsLogic.GetAll(UsuarioActual);                 
                }
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
            return (this.dgvInscripcionAlumno.SelectedRows.Count > 0);
        }

        #endregion

        #region EventosFormulario

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                Inscripcion inscripcion = new Inscripcion();
                InscripcionLogic insLogic = new InscripcionLogic();
                //Se pasarian los objetos correspondientes a la inscripcion
                inscripcion.Alumno = ((Inscripcion)this.dgvInscripcionAlumno.SelectedRows[0].DataBoundItem).Alumno;
                inscripcion.Curso = ((Inscripcion)this.dgvInscripcionAlumno.SelectedRows[0].DataBoundItem).Curso;
                inscripcion.Condicion = "Corregido";
                inscripcion.State = BusinessEntity.States.Modified;
                insLogic.Save(inscripcion);
            }
            else
            {
                MessageBox.Show("No hay items seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InscripcionAlumno_Shown(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion
    }
}
