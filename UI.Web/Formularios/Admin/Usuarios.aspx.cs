﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Academia.Util;
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

        private void cargoDropDown()
        {
            dwTiposPersonas.DataSource = Persona.DameTusTipos();
            dwTiposPersonas.DataBind();
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
                Master.MuestroMenu();
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearForm();
            selectID = (int)GridView.SelectedValue;
            LoadForm(this.selectID);
        }

        public void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = txtNombre.Text;
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Habilitado = checkHabilitado.Checked;
            usuario.Clave = txtClave.Text;
            usuario.Email = txtEmail.Text;
            //Persona
            usuario.Persona.FechaNacimiento = CalFechaNac.SelectedDate;
            usuario.Persona.Telefono = txtTelefono.Text;
            usuario.Persona.Direccion = txtDireccion.Text;
            usuario.Persona.TipoPersona = (Persona.TiposPersonas)(dwTiposPersonas.SelectedIndex);
        }

        public void LoadForm(int id)
        {
            cargoDropDown();
            Entity = this.Logic.GetOne(id);
            txtNombre.Text = Entity.Nombre;
            txtApellido.Text = Entity.Apellido;
            txtNombreUsuario.Text = Entity.NombreUsuario;
            txtEmail.Text = Entity.Email;
            checkHabilitado.Checked = Entity.Habilitado;
            txtTelefono.Text = Entity.Persona.Telefono;
            txtDireccion.Text = Entity.Persona.Direccion;
            CalFechaNac.SelectedDate = Entity.Persona.FechaNacimiento;
            dwTiposPersonas.SelectedValue = Entity.Persona.TipoPersona.ToString();
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
            txtDireccion.Enabled = enable;
            txtTelefono.Enabled = enable;
            CalFechaNac.Enabled = enable;
            dwTiposPersonas.Enabled = enable;
        }

        public void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqNombUsuario.Enabled = enable;
            reqApellido.Enabled = enable;
            reqNombre.Enabled = enable;
            reqClave.Enabled = enable;
            reqRepetirClave.Enabled = enable;
            reqEmail.Enabled = enable;
            reqDireccion.Enabled = enable;
            reqTelefono.Enabled = enable;                     
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
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            CalFechaNac.SelectedDate = DateTime.Now;
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

        protected void ValidoDatos()
        {
            reqApellido.IsValid = Validaciones.EsCadenaValida(txtApellido.Text);
            reqNombre.IsValid = Validaciones.EsCadenaValida(txtNombre.Text);
            reqDireccion.IsValid = Validaciones.EsCadenaValida(txtDireccion.Text);
            reqTelefono.IsValid = Validaciones.EsCadenaValida(txtTelefono.Text);
            reqNombUsuario.IsValid = Validaciones.EsCadenaValida(txtNombreUsuario.Text);   
            //Se tiene que negar con el signo ! por que si no, devolveria que el email es invalido
            reqEmail.IsValid = !Validaciones.EsCadenaValida(txtEmail.Text);
            reqClave.IsValid = Validaciones.ValidarLongitudClave(txtClave.Text, txtRepetirClave.Text);
            reqRepetirClave.IsValid = Validaciones.ValidarLongitudClave(txtRepetirClave.Text, txtClave.Text);
            if (!String.Equals(txtClave.Text, txtRepetirClave.Text))
            {
                reqClave.ErrorMessage = "Las Claves No Coinciden";
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            ValidoDatos();
            if (Page.IsValid)
            {
            switch (this.FormMode)
                {
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = Logic.GetOne(selectID);
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
                Response.Redirect("~/Formularios/Admin/Usuarios.aspx");

            }          
        }
    }
}