using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Academia.Util;

namespace UI.Web.Formularios
{
    public partial class Comisiones : ApplicationForm
    {
        #region Atributos

        private ComisionLogic _logic;

        #endregion

        #region Propiedades

        public ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Comision Entity
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

        public void cargoDropDownList()
        {
            dwPlan.DataSource = new PlanLogic().GetAll();
            dwPlan.DataValueField = "ID";
            dwPlan.DataTextField = "Descripcion";
            dwPlan.DataBind();
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
        /// <param name="comision"></param>
        public void LoadEntity(Comision comision)
        {
            comision.Descripcion = txtDescripcion.Text;
            comision.AnioEspecialidad = Int32.Parse(txtAño.Text);
            comision.Plan = new PlanLogic().GetOne(Int32.Parse(dwPlan.SelectedValue));
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
            txtAño.Text = Entity.AnioEspecialidad.ToString();
            cargoDropDownList();
            dwPlan.SelectedValue = Entity.IDPlan.ToString();
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtAño.Enabled = enable;
            dwPlan.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="comision"></param>
        public void SaveEntity(Comision comision)
        {
            Logic.Save(comision);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqAño.Enabled = enable;
            reqDescripcion.Enabled = enable;
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
            txtAño.Text = String.Empty;
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
            cargoDropDownList();
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
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

        protected void ValidoDatos()
        {
            reqAño.IsValid = Validaciones.EsNumerico(txtAño.Text);
            reqDescripcion.IsValid = Validaciones.EsCadenaValida(txtDescripcion.Text);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.HabilitoValidaciones(true);
            this.ValidoDatos();
            switch(this.FormMode)
            {
                case FormModes.Alta:
                    if(Page.IsValid)
                    {
                        Entity = new Comision();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Comisiones.aspx");
                    }
                    break;
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = new ComisionLogic().GetOne(selectID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Comisiones.aspx");
                    }
                    break;
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    Response.Redirect("~/Formularios/Admin/Comisiones.aspx");
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