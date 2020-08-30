using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace Academia.UI.Desktop.Forms_Entidades.Planes
{
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan m_planActual;

        #region Propiedades
        public Plan PlanActual
        {
            get => m_planActual;
            set => m_planActual = value;
        }

        #endregion

        #region Constructores
        public PlanDesktop()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Crea el formulario especifico segun el tipo especificado
        /// </summary>
        public void IniciarFormulario()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
                {
                    this.btnAceptar.Text = "Eliminar";
                    MapearDeDatos();
                }
                else
                {
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                }
        }

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.txtIDEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();          
        }

        /// <summary>
        /// Se utiliza para modificar los datos de una especialidad especifica o para dar de alta una nueva
        /// </summary>
        public void CastearDatosPlan()
        {
            this.PlanActual = new Plan();
            this.PlanActual.ID = Convert.ToInt32(this.txtID.Text);
            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            this.PlanActual.IDEspecialidad = Convert.ToInt32(this.txtIDEspecialidad.Text);
        }

        public void MapearADatos2()
        {
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                this.PlanActual.State = BusinessEntity.States.Deleted;
            }
            else
            {
                CastearDatosPlan();
                if (this.Modo==ApplicationForm.ModoForm.Alta)
                {
                    PlanActual.State = BusinessEntity.States.New;
                }
                else
                {
                    PlanActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos2();
            new PlanLogic().Save(PlanActual);
        }

        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (this.txtDescripcion.TextLength == 0 || this.txtIDEspecialidad.TextLength == 0)
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Int32.TryParse(txtIDEspecialidad.Text,out int valor) == false)
                {
                    Notificar("ID ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }              
                else
                    return true;
            }
        }

        /// <summary>
        /// Crea un MessageBox especifico con el mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="botones"></param>
        /// <param name="icono"></param>
        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion

        #region EventosFormulario
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            else
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PlanDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }

        #endregion

        #region CodigoViejo

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                PlanActual = new PlanLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                PlanActual = new PlanLogic().GetOne(ID);
                MapearDeDatos();
            }
        }

        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                PlanActual = new Plan();
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = Int32.Parse(this.txtIDEspecialidad.Text);
                PlanActual.State = Especialidad.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = Int32.Parse(this.txtIDEspecialidad.Text);
                PlanActual.State = Usuario.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                //new PlanLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        #endregion
    }
}
