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
                    CursoLogic curLogic = new CursoLogic();
                    dgvInscripcionAlumno.DataSource = curLogic.GetAll();
                    
                }
                else 
                {
                    this.Nota.Visible = true;
                    AlumnoInscripcionLogic alInsLogic = new AlumnoInscripcionLogic();
                    dgvInscripcionAlumno.DataSource = alInsLogic.GetAll(UsuarioActual);                 
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public void ocultoColumnas()
        {

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
                AlumnoInscripcion insAlumno = new AlumnoInscripcion();
                AlumnoInscripcionLogic insAlLogic = new AlumnoInscripcionLogic();
                //Se pasarian los objetos correspondientes ala inscripcion
                insAlumno.Alumno = UsuarioActual;
                insAlumno.Curso = ((Curso)this.dgvInscripcionAlumno.SelectedRows[0].DataBoundItem);
                insAlumno.Condicion = "Por corregir";
                insAlumno.State = BusinessEntity.States.New;                
                if (!insAlLogic.validarInscripcion(insAlumno))               
                {
                    new AlumnoInscripcionLogic().Save(insAlumno);
                    MessageBox.Show("Inscripcion exitosa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
                else
                {
                    MessageBox.Show("El alumno ya se encuentra inscripto en el curso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                new PlanLogic().GetOne(UsuarioActual.Persona.IDPlan);
            }
        }

        private void InscripcionAlumno_Shown(object sender, EventArgs e)
        {
            Listar();
        }

        #endregion
    }
}
