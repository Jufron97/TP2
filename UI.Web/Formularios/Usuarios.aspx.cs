using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using UI.Web.Formularios;

namespace UI.Web
{
    public partial class Usuarios : ApplicationForm
    {
        private UsuarioLogic _logic;

        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }


        /// <summary>
        /// Carga todo los datos de los alumnos en 
        /// </summary>
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

        public void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = txtNombre.Text;
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Habilitado = checkHabilitado.Checked;
            usuario.Clave = txtClave.Text;
            usuario.Email = txtEmail.Text;
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtNombre.Text = Entity.Nombre;
            txtApellido.Text = Entity.Apellido;
            txtNombreUsuario.Text = Entity.NombreUsuario;
            txtEmail.Text = Entity.Email;
            checkHabilitado.Checked = Entity.Habilitado;
        }

        private void EnableForm(bool enable)
        {
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtNombreUsuario.Enabled = enable;
            txtEmail.Enabled = enable;
            checkHabilitado.Enabled = enable;
            txtClave.Enabled = enable;
            txtRepetirClave.Enabled = enable;
            lblRepetirClave.Enabled = enable;
            desabilitoValidaciones(false);
        }

        public void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        public void desabilitoValidaciones(bool enable)
        {
            reqNombUsuario.Enabled = enable;
            reqApellido.Enabled = enable;
            reqNombre.Enabled = enable;
            reqClave.Enabled = enable;
            reqRepetirClave.Enabled = enable;
            reqEmail.Enabled = enable;
        }


        private void DeleteEntity(int ID)
        {
            Logic.Delete(ID);
        }

        private void ClearForm()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtNombreUsuario.Text = String.Empty;
            txtEmail.Text = String.Empty;
            checkHabilitado.Checked = false;
            txtClave.Text = String.Empty;
            txtRepetirClave.Text = String.Empty;
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
                    Entity = new Usuario();
                    Entity.ID = selectID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;
                case FormModes.Alta:
                    Entity = new Usuario();
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