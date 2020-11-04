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
    public partial class DocenteCursos : ApplicationForm
    {
        #region Atributos

        private DocenteCursoLogic _logic;

        #endregion

        #region Propiedades

        public DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }

        private DocenteCurso Entity
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
                Master.MuestroMenu();
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
            //DropDown con las Curso
            dwCurso.DataSource = new CursoLogic().GetAll();
            dwCurso.DataValueField = "ID";
            dwCurso.DataTextField = "MateriaComisionCurso";
            dwCurso.DataBind();
            //Curso cursoSeleccionado= dwCurso.SelectedValue
            //DropDown con las Docentes
            dwDocente.DataSource = new DocenteCursoLogic().GetAll(Entity.Curso);
            dwDocente.DataValueField = "ID";
            dwDocente.DataTextField = "NombreApellDocente";
            dwDocente.DataBind();
            //DropDown con las Cargos           
            dwCargo.DataSource = Persona.DameTusTipos();                
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
        /// <param name="curso"></param>
        public void LoadEntity(DocenteCurso docCurso)
        {
            docCurso.Curso = new CursoLogic().GetOne(Int32.Parse(dwCurso.SelectedValue));
            docCurso.Docente = new PersonaLogic().GetOne(Int32.Parse(dwDocente.SelectedValue));
            docCurso.Cargo = (DocenteCurso.TiposCargos)(Int32.Parse(dwCargo.SelectedValue));
        }

        /// <summary>
        /// Se carga el formulario con los datos de la entidad seleccionada
        /// </summary>
        /// <param name="id"></param>
        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            //Se cargan los dropDownList 
            cargoDropDownList();
            //Dependiendo del curso seleccionado se mostrara los valores de las comisiones y la materia a la cual hace referencia
            dwCurso.SelectedValue = Entity.IDCurso.ToString();
            dwDocente.SelectedValue = Entity.IDDocente.ToString();
            dwCargo.SelectedValue = Entity.Docente.TipoPersona.ToString();
        }

        /// <summary>
        /// Se habilitda/deshabilita el formulario ABM
        /// </summary>
        /// <param name="enable"></param>
        private void EnableForm(bool enable)
        {
            dwCurso.Enabled = enable;
            dwDocente.Enabled = enable;
            dwCargo.Enabled = enable;
        }

        /// <summary>
        /// Se invoca para guardar a la entidad
        /// </summary>
        /// <param name="curso"></param>
        public void SaveEntity(DocenteCurso docCurso)
        {
            Logic.Save(docCurso);
        }

        public void HabilitoValidaciones(bool enable)
        {

        }

        /// <summary>
        /// Se invoca para eliminar a la entidad por el ID enviado
        /// </summary>
        /// <param name="curso"></param>
        private void DeleteEntity(DocenteCurso docCurso)
        {
            Logic.Delete(docCurso);
        }

        /// <summary>
        /// Se limpia el formulario ABM
        /// </summary>
        private void ClearForm()
        {/*
            txtAño.Text = String.Empty;
            txtCupo.Text = String.Empty;*/
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
            if (Page.IsValid)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        Entity = Logic.GetOne(selectID);
                        DeleteEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new DocenteCurso();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        Entity = new DocenteCurso();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                Response.Redirect("~/Formularios/Admin/DocenteCursos.aspx");
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
