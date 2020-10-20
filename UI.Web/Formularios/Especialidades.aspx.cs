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

        #endregion

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
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

        public void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = txtDescripcion.Text;
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
        }

        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
        }

        public void SaveEntity(Especialidad especialidad)
        {
            Logic.Save(especialidad);
        }
     
        public void desabilitoValidaciones(bool enable)
        {
            reqDescripcion.Enabled = enable;
        }
      
        private void DeleteEntity(int ID)
        {
            Logic.Delete(ID);
        }


        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
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
                        Entity = new Especialidad();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new Especialidad();
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