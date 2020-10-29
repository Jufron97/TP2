using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academia.Business.Logic;
using Academia.Business.Entities;
using System.Windows.Forms;

namespace UI.Web.Formularios.Alumno
{
    public partial class CursosAlumno : ApplicationForm
    {
        private CursoLogic _curlogic;
        private CursoLogic CurLog
        {
            get
            {
                if (_curlogic == null)
                {
                    _curlogic = new CursoLogic();
                }
                return _curlogic;
            }
        }

        private InscripcionLogic _inslogic;
        private InscripcionLogic InsLog
        {
            get
            {
                if (_inslogic == null)
                {
                    _inslogic = new InscripcionLogic();
                }
                return _inslogic;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
             
                LoadGrid();
                
            }
            
            Entity = (Usuario)HttpContext.Current.Session["usuario"];

        }

        private Usuario Entity
        {
            get;
            set;
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridViewCurso.SelectedValue;
        }

        private void LoadGrid()
        {
            string operacion = Request.QueryString["op"].ToString();

            if (operacion == "Curso")
            {
                this.GridViewInsc.Visible = false;
                this.btnInscribir.Visible = false;
                this.btnInscribir.Enabled = false;
                this.GridViewCurso.DataSource = CurLog.GetAll();
                this.GridViewCurso.DataBind();
            }
            else if (operacion == "Inscripcion") 
            {
                this.GridViewCurso.Visible = false;
                this.GridViewInsc.DataSource = InsLog.GetAll(Entity);
                this.GridViewInsc.DataBind();
            }
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                Inscripcion insAlumno = new Inscripcion();
                //Se pasarian los objetos correspondientes a la inscripcion
                insAlumno.Alumno = Entity.Persona;
                insAlumno.Curso = ((Curso)CurLog.GetOne(selectID));
                insAlumno.Condicion = "En Cursado";
                insAlumno.State = BusinessEntity.States.New;
                //En primera parte se valida que el usuario no este inscripto
                if (!InsLog.validarInscripcion(insAlumno))
                {
                    //Como segunda validacion que el curso al cual se quiera inscribir tenga cupo disponible
                    if (insAlumno.Curso.Cupo > 0)
                    {
                        CurLog.Update(insAlumno.Curso);
                        InsLog.Save(insAlumno);
                        MessageBox.Show("Inscripcion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El curso ingresado no tiene cupos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El alumno ya se encuentra inscripto en el curso","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay items seleccionados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.LoadGrid();
            
        }
    }
}