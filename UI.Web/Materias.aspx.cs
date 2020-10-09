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
    public partial class Materias : System.Web.UI.Page
    {

        private MateriaLogic _logic;

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
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

        private Materia Entity
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

        public void LoadEntity(Materia materia)
        {
            materia.HsSemanales = Int32.Parse(txtHsSemanales.Text);
            materia.HsTotales = Int32.Parse(txtHsTotales.Text);
            materia.Descripcion = txtDescripcion.Text;
            PlanLogic planlog = new PlanLogic();
            materia.Plan = planlog.GetOne(Int32.Parse(dropPlan.SelectedValue));

        }


        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtHsSemanales.Text = Entity.HsSemanales.ToString();
            txtHsTotales.Text = Entity.HsTotales.ToString();
            txtDescripcion.Text = Entity.Descripcion;
            dropPlan.DataSource = Entity.IdPlan;
            
        }

        private void EnableForm(bool enable)
        {
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
            txtDescripcion.Enabled = enable;
            dropPlan.Enabled = enable;
            desabilitoValidaciones(false);
        }

        public void SaveEntity(Materia materia)
        {
            Logic.Save(materia);
        }

        public void desabilitoValidaciones(bool enable)
        {
            reqHsSemanales.Enabled = enable;
            reqHsTotales.Enabled = enable;
            reqDescripcion.Enabled = enable;
        }


        private void DeleteEntity(Materia mat)
        {
            Logic.Delete(mat);
        }


        private void ClearForm()
        {
            txtHsSemanales.Text = String.Empty;
            txtHsTotales.Text = String.Empty;
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
                        Materia mat = new Materia();
                        mat = Logic.GetOne(selectID);
                        DeleteEntity(mat);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Materia();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Materia();
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
