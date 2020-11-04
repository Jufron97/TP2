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
    public partial class Planes : ApplicationForm
    {
        #region Atributos

        private PlanLogic _logic;

        #endregion

        #region Propiedades

        public PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new PlanLogic();
                }
                return _logic;
            }
        }

        private Plan Entity
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
                Master.MuestroMenu();
            }
        }

        /// <summary>
        /// Se carga la grilla con todos los Planes
        /// </summary>
        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        /// <summary>
        /// Se carga el DropDownList con los datos correspondientes de todas las especialidades en la BD
        /// </summary>
        public void cargoDropDownList()
        {
            dwEspecialidades.DataSource = new EspecialidadLogic().GetAll();
            dwEspecialidades.DataValueField = "ID";
            dwEspecialidades.DataTextField = "Descripcion";
            dwEspecialidades.DataBind();
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
        /// <param name="plan"></param>
        public void LoadEntity(Plan plan)
        {
            plan.Descripcion = txtDescripcion.Text;
            plan.Especialidad = new EspecialidadLogic().GetOne(Int32.Parse(dwEspecialidades.SelectedValue));
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
            cargoDropDownList();
            dwEspecialidades.SelectedValue = Entity.ID.ToString();
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
        /// <param name="plan"></param>
        public void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqDescripcion.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="plan"></param>
        private void DeleteEntity(Plan plan)
        {
            Logic.Delete(plan);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
        }

        protected void ValidoDatos()
        {
            reqDescripcion.IsValid = Validaciones.EsCadenaValida(txtDescripcion.Text);
        }

        #endregion

        #region EventosFormulario

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
            cargoDropDownList();
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(this.selectID);
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            if (Page.IsValid && this.FormMode != FormModes.Baja)
            {
                switch (this.FormMode)
                {
                    case FormModes.Modificacion:
                        Entity = new Plan();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Plan();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                Response.Redirect("~/Formularios/Admin/Planes.aspx");
            }
            else if (this.FormMode == FormModes.Baja)
            {
                Entity = new PlanLogic().GetOne(selectID);
                DeleteEntity(Entity);
                LoadGrid();
                Response.Redirect("~/Formularios/Admin/Planes.aspx");
            }
        }


    }

    #endregion
}