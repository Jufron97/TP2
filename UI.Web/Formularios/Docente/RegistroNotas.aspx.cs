using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Academia.Util;

namespace UI.Web.Formularios.Docente
{
    public partial class RegistroNotas : ApplicationForm
    {
        #region Atributos

        private InscripcionLogic _logic;
        private Usuario m_docente;

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

        private Usuario EntityDoc
        {
            get => m_docente;
            set => m_docente = value;
        }

        private Inscripcion EntityIns
        {
            get;
            set;
        }

        #endregion

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            EntityDoc = (Usuario)Session["usuario"];
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
            this.ClearForm();
            selectID = (int)GridView.SelectedValue;
            LoadForm(this.selectID);
        }

        /// <summary>
        /// Se carga a la entidad con los datos seleccionados en el formulario
        /// </summary>
        /// <param name="inscripcion"></param>
        public void LoadEntity(Inscripcion inscripcion)
        {
            inscripcion.Alumno = EntityIns.Alumno;
            inscripcion.Curso = EntityIns.Curso;
            inscripcion.Condicion = "Corregido";
            inscripcion.Nota = Int32.Parse(txtNota.Text);
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            EntityIns = this.Logic.GetOne(id);
            txtNombre.Text = EntityIns.NombreAlumno;
            txtApellido.Text = EntityIns.ApellidoAlumno;           
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

        public void HabilitoValidaciones(bool enable)
        {
            reqNota.Enabled = enable;
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
        protected void ValidoDatos()
        {
            reqNota.IsValid = Validaciones.EsNumerico(txtNota.Text);
        }
        #endregion

        #region Eventosormulario

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            if (Page.IsValid)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        DeleteEntity(EntityIns);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        EntityIns = new Inscripcion();
                        EntityIns.ID = selectID;
                        EntityIns.State = BusinessEntity.States.Modified;
                        LoadEntity(EntityIns);
                        SaveEntity(EntityIns);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        EntityIns = new Inscripcion();
                        LoadEntity(EntityIns);
                        SaveEntity(EntityIns);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                Response.Redirect("~/Formularios/Docente/RegistroNotas.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void btnCorregir_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                formPanel.Visible = true;
                LoadForm(selectID);
            }          
        }
        
    }
    #endregion
}
