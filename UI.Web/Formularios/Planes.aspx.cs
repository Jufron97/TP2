using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Logic;
using Academia.Business.Entities;
using UI.Web.Formularios;

namespace UI.Web
{
    public partial class Planes : ApplicationForm
    {
        private PlanLogic _logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

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

        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        public void cargoDropDownList()
        {
            dwEspecialidades.DataSource = new EspecialidadLogic().GetAll();
            dwEspecialidades.DataTextField = "Descripcion";
            dwEspecialidades.DataValueField = "ID";
            dwEspecialidades.DataBind();
        }

        private Plan Entity
        {
            get;
            set;
        }


        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        public void LoadEntity(Plan plan)
        {
            plan.Descripcion = txtDescripcion.Text;
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
            cargoDropDownList();
            dwEspecialidades.SelectedValue = Entity.ID.ToString();
        }

        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
        }

        public void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
        }

        public void desabilitoValidaciones(bool enable)
        {

        }

        private void DeleteEntity(Plan plan)
        {
            Logic.Delete(plan);
        }


        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
        }

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

        protected void LinkButton1_Click(object sender, EventArgs e)
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
            desabilitoValidaciones(true);
            if (Page.IsValid)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        Entity = new PlanLogic().GetOne(selectID);                       
                        DeleteEntity(Entity);
                        LoadGrid();
                        break;
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
                formPanel.Visible = false;
            }
        }
    }
}