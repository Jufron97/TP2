using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace UI.Web.Formularios.Docente
{
    public partial class RegistroNotas : ApplicationForm
    {
        #region Atributos

        private InscripcionLogic _logic;

        #endregion

        #region Propiedades

        public InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new InscripcionLogic();
                }
                return _logic;
            }
        }

        private Inscripcion Entity
        {
            get;
            set;
        }

        #endregion

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        /// <summary>
        /// Se carga la grilla con todas las comisiones
        /// </summary>
        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        /// <summary>
        /// Se carga a la entidad con los datos seleccionados en el formulario
        /// </summary>
        /// <param name="inscripcion"></param>
        public void LoadEntity(Inscripcion inscripcion)
        {
            inscripcion.Alumno = Entity.Alumno;
            inscripcion.Curso = Entity.Curso;
            inscripcion.Condicion = "Corregido";
            inscripcion.Nota = Int32.Parse(txtNota.Text);
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtNombre.Text = Entity.NombreAlumno;
            txtApellido.Text = Entity.ApellidoAlumno;           
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtNota.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="comision"></param>
        public void SaveEntity(Inscripcion inscripcion)
        {
            Logic.Save(inscripcion);
        }

        public void desabilitoValidaciones(bool enable)
        {

        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="ID"></param>
        private void DeleteEntity(Inscripcion inscripcion)
        {
            Logic.Delete(inscripcion);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtNota.Text = String.Empty;
        }

        #endregion

        #region Eventosormulario

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            desabilitoValidaciones(true);
            if (Page.IsValid)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        DeleteEntity(selectID);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Inscripcion();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Inscripcion();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                formPanel.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }
    }
    #endregion
}
