using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace UI.Web
{
    public partial class Comisiones : System.Web.UI.Page
    {
        private ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get => (FormModes)ViewState["FormMode"];
            set => ViewState["FormMode"] = value;
        }

        private Comision Entity
        {
            get;
            set;
        }

        private int selectID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set => ViewState["SelectedID"] = value;
        }

        private bool isEntititySelected
        {
            get => selectID != 0;
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        public void LoadEntity(Comision com)
        {
            com.AnioEspecialidad = Int32.Parse(txtAnioEspecialidad.Text);
            com.Descripcion = txtDescripcion.Text;
            PlanLogic planlog = new PlanLogic();
            com.Plan = planlog.GetOne(Int32.Parse(dropPlan.SelectedValue));

        }


        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtAnioEspecialidad.Text = Entity.AnioEspecialidad.ToString();
            txtDescripcion.Text = Entity.Descripcion;
            dropPlan.DataSource = Entity.IDPlan;

        }

        private void EnableForm(bool enable)
        {
            txtAnioEspecialidad.Enabled = enable;
            txtDescripcion.Enabled = enable;
            dropPlan.Enabled = enable;
            desabilitoValidaciones(false);
        }

        public void SaveEntity(Comision com)
        {
            Logic.Save(com);
        }

        public void desabilitoValidaciones(bool enable)
        {
            reqAnioEspecialidad.Enabled = enable;
            reqDescripcion.Enabled = enable;
        }


        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }


        private void ClearForm()
        {
            txtAnioEspecialidad.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            dropPlan.DataSource = null;
            dropPlan.DataBind();
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
                        DeleteEntity(selectID);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Comision();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Comision();
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