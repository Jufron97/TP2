using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Logic;
using Academia.Business.Entities;
using UI.Web.Formularios;
using Academia.Util;

namespace UI.Web
{
    public partial class Especialidades : ApplicationForm
    {

        #region Atributos

        private EspecialidadLogic _logic;

        #endregion

        #region Propiedades

        public EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }

        private Especialidad Entity
        {
            get;
            set;
        }

        public Usuario UsuarioActual
        {
            get;
            set;
        }

        #endregion

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["usuario"];
            if (UsuarioActual.Persona.TipoPersona == Persona.TiposPersonas.Admin)
            {
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                    Master.MuestroMenu();
                }
            }
        }

        /// <summary>
        /// Se carga la grilla con todas las especialidades
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
        /// <param name="especialidad"></param>
        public void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = txtDescripcion.Text;
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="especialidad"></param>
        public void SaveEntity(Especialidad especialidad)
        {
            Logic.Save(especialidad);
        }
     
        public void HabilitoValidaciones(bool enable)
        {
            //reqDescripcion.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="ID"></param>
        private void DeleteEntity(int ID)
        {
            Logic.Delete(ID);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
        }
        protected void ValidoDatos() { 

            reqDescripcion.IsValid = Validaciones.EsCadenaValida(txtDescripcion.Text);
        }

    #endregion

    #region Eventosormulario

    protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(selectID);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }



        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                ClearForm();
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(this.selectID);
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            switch(this.FormMode)
            {
                case FormModes.Alta:
                    if(Page.IsValid)
                    {                     
                        Entity = new Especialidad();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Especialidades.aspx");
                    }
                    break;
                case FormModes.Modificacion:
                    if(Page.IsValid)
                    {
                        Entity = new EspecialidadLogic().GetOne(selectID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Especialidades.aspx");
                    }
                    break;
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    Response.Redirect("~/Formularios/Admin/Especialidades.aspx");
                    break;
                default:
                    break;
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