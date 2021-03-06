﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Entities;
using Academia.Business.Logic;
using Academia.Util;

namespace UI.Web.Formularios
{
    public partial class Cursos : ApplicationForm
    {
        #region Atributos

        private CursoLogic _logic;

        #endregion

        #region Propiedades

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

        private Curso Entity
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

        /// <summary>
        /// Se carga la grilla con todos los Cursos
        /// </summary>
        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        /// <summary>
        /// Se cargan los DropDownList con los datos correspondientes de todas las materias y comisiones en la BD
        /// </summary>
        public void cargoDropDownList()
        {
            //DropDown con las comisiones
            dwComision.DataSource = new ComisionLogic().GetAll();
            dwComision.DataValueField = "ID";
            dwComision.DataTextField = "Descripcion";
            dwComision.DataBind();
            //DropDown con las materias
            dwMateria.DataSource = new MateriaLogic().GetAll();
            dwMateria.DataValueField = "ID";
            dwMateria.DataTextField = "Descripcion";
            dwMateria.DataBind();
        }
    

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        /// <summary>
        /// Se carga a la entidad con los datos seleccionados en el formulario
        /// </summary>
        /// <param name="curso"></param>
        public void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = Int32.Parse(txtAño.Text);
            curso.Comision = new ComisionLogic().GetOne(Int32.Parse(dwComision.SelectedValue));
            curso.Materia = new MateriaLogic().GetOne(Int32.Parse(dwMateria.SelectedValue));
            curso.Cupo = Int32.Parse(txtCupo.Text);
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtAño.Text = Entity.AnioCalendario.ToString();
            txtCupo.Text = Entity.Cupo.ToString();
            //Se cargan los dropDownList 
            cargoDropDownList();
            //Dependiendo del curso seleccionado se mostrara los valores de las comisiones y la materia a la cual hace referencia
            dwComision.SelectedValue = Entity.IDComision.ToString();
            dwMateria.SelectedValue = Entity.IDMateria.ToString();
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
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
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="curso"></param>
        public void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqAño.Enabled = enable;
            reqCupo.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="curso"></param>
        private void DeleteEntity(int ID)
        {
            Logic.Delete(ID);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {
            txtAño.Text = String.Empty;
            txtCupo.Text = String.Empty;           
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
            cargoDropDownList();
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
                ClearForm();
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(this.selectID);
            }
        }

        protected void ValidoDatos()
        {
            reqAño.IsValid = Validaciones.EsNumerico(txtAño.Text);
            reqCupo.IsValid = Validaciones.EsNumerico(txtCupo.Text);
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
                        Entity = new Curso();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Cursos.aspx");
                    }
                    break;
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = new CursoLogic().GetOne(selectID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Formularios/Admin/Cursos.aspx");
                    }
                    break;
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    Response.Redirect("~/Formularios/Admin/Cursos.aspx");
                    break;
                default:
                    break;
            }           
        }


    }

    #endregion
}