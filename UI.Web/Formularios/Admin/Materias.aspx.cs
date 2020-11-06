using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Academia.Util;
using System.Windows.Forms;

namespace UI.Web.Formularios
{
    public partial class Materias : ApplicationForm
    {
        #region Atributos

        private MateriaLogic _logic;

        #endregion

        #region Propiedades

        public MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private Materia Entity
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
            if(UsuarioActual.Persona.TipoPersona==Persona.TiposPersonas.Admin)
            {
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                    Master.MuestroMenu();
                }
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
        /// Se cargan los DropDownList con los datos correspondientes de todas los planes en la BD
        /// </summary>
        public void cargoDropDownList()
        {
            //DropDown con las comisiones
            dwPlanes.DataSource = new PlanLogic().GetAll();
            dwPlanes.DataValueField = "ID";
            dwPlanes.DataTextField = "Descripcion";
            dwPlanes.DataBind();
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
        /// <param name="materia"></param>
        public void LoadEntity(Materia materia)
        {
            materia.Descripcion = txtDescripcion.Text;
            materia.HsSemanales = Int32.Parse(txtHsSemanales.Text);
            materia.HsTotales = Int32.Parse(txtHsTotales.Text);
            materia.Plan = new PlanLogic().GetOne(Int32.Parse(dwPlanes.SelectedValue));
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
            txtHsSemanales.Text = Entity.HsSemanales.ToString();
            txtHsTotales.Text = Entity.HsTotales.ToString();
            cargoDropDownList();
            //Dependiendo del curso seleccionado se mostrara los valores del plan al cual hace referencia
            dwPlanes.SelectedValue = Entity.IdPlan.ToString();
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
            dwPlanes.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="materia"></param>
        public void SaveEntity(Materia materia)
        {
            Logic.Save(materia);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqDescripcion.Enabled = enable;
            reqHsSemanales.Enabled = enable;
            reqHsTotales.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="ID"></param>
        private void DeleteEntity(int ID)
        {
            Entity = Logic.GetOne(ID);
            Logic.Delete(Entity);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
            txtHsSemanales.Text = String.Empty;
            txtHsTotales.Text = String.Empty;
        }

        protected void ValidoDatos()
        {
            reqDescripcion.IsValid = Validaciones.EsCadenaValida(txtDescripcion.Text);
            reqHsSemanales.IsValid = Validaciones.EsNumerico(txtHsSemanales.Text);
            reqHsTotales.IsValid = Validaciones.EsNumerico(txtHsTotales.Text);
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
            ClearForm();
            cargoDropDownList();
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
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
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                      Entity = new MateriaLogic().GetOne(selectID);
                      Entity.State = BusinessEntity.States.Modified;
                      LoadEntity(Entity);
                      SaveEntity(Entity);
                      LoadGrid();
                    }
                    break;
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        Entity = new Materia();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                    }
                    break;
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Formularios/Admin/Materias.aspx");
        }
    }

    #endregion
}