using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace UI.Web.Formularios
{
    public partial class Cursos : System.Web.UI.Page
    {
        private CursoLogic _logic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }

        public CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new CursoLogic();
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
            dwComision.DataSource = new ComisionLogic().GetAll();
            dwComision.DataValueField = "Descripcion";
            dwComision.DataBind();
            dwMateria.DataSource = new MateriaLogic().GetAll();
            dwMateria.DataValueField = "Descripcion";
            dwMateria.DataBind();
        }

        private bool isEntititySelected
        {
            get => selectID != 0;
        }

        private Curso Entity
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

        public FormModes FormMode
        {
            get => (FormModes)ViewState["FormMode"];
            set => ViewState["FormMode"] = value;
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        public void LoadEntity(Curso curso)
        {
            
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);            
            cargoDropDownList();
            /* ACA IRIA EL OBJETO EN EL DROPDOWN
            * 
           */
        }

        private void EnableForm(bool enable)
        {
            dwMateria.Enabled = enable;
            dwComision.Enabled = enable;
            txtAño.Enabled = enable;
            txtCupo.Enabled = enable;
        }

        public void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
        }

        public void desabilitoValidaciones(bool enable)
        {
        }

        private void DeleteEntity(Curso curso)
        {
            Logic.Delete(curso.ID);
        }

        private void ClearForm()
        {
            txtAño.Text = String.Empty;
            txtCupo.Text = String.Empty;           
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
                        Entity = new CursoLogic().GetOne(selectID);
                        DeleteEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new Curso();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Curso();
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