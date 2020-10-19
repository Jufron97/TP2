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

        /// <summary>
        /// Se carga la grilla con todos los Cursos
        /// </summary>
        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        /// <summary>
        /// Se cargan los DropDownList con los datos correspondientes datos en la BD
        /// </summary>
        public void cargoDropDownList()
        {
            dwComision.DataSource = new ComisionLogic().GetAll();
            dwComision.DataValueField = "ID";
            dwComision.DataValueField = "Descripcion";
            dwComision.DataBind();
            dwMateria.DataSource = new MateriaLogic().GetAll();
            dwMateria.DataValueField = "ID";
            dwMateria.DataTextField = "Descripcion";
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

        /// <summary>
        /// Se carga el formulario con el respectivo Curso seleccionado
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id); 
            //Se cargan los dropDownList 
            cargoDropDownList();
            //Dependiendo del curso seleccionado se mostrara los valores de las comisiones y la materia a la cual hace referencia
            dwComision.SelectedValue = Entity.IDComision.ToString();
            dwMateria.SelectedValue = Entity.IDMateria.ToString();
        }

        /// <summary>
        /// Metodo que deshabilita/habilita los controles del formulario
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            dwMateria.Enabled = enable;
            dwComision.Enabled = enable;
            txtAño.Enabled = enable;
            txtCupo.Enabled = enable;
        }

        /// <summary>
        /// Metodo 
        /// </summary>
        /// <param name="curso"></param>
        public void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
        }

        public void desabilitoValidaciones(bool enable)
        {
        }

        /// <summary>
        /// Metodo que sirve para eliminar la entidad
        /// </summary>
        /// <param name="curso"></param>
        private void DeleteEntity(Curso curso)
        {
            Logic.Delete(curso.ID);
        }

        /// <summary>
        /// Metodo que sirve para limpiar el formulario
        /// </summary>
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