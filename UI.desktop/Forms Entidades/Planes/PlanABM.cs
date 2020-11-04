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
using Academia.Util;

namespace Academia.UI.Desktop.Forms_Entidades.Planes
{
    public partial class PlanABM : ApplicationForm
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
        public PlanABM()
        {
            InitializeComponent();
        }

        #endregion

        public void cargoComboBox()
        {
            this.cbEspecialidad.DataSource = new EspecialidadLogic().GetAll();
            this.cbEspecialidad.ValueMember = "ID";
            this.cbEspecialidad.DisplayMember = "Descripcion";
        }

        #region Metodos
        /// <summary>
        /// Crea el formulario especifico segun el tipo especificado
        /// </summary>
        public void IniciarFormulario()
        {
            cargoComboBox();
            switch (this.Modo)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.cbEspecialidad.Enabled = false;
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.cbEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
            //this.txtIDEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();          
        }

        /// <summary>
        /// Se utiliza para modificar los datos de una especialidad especifica o para dar de alta una nueva
        /// </summary>
        public void CastearDatosPlan()
        {
            this.PlanActual = new Plan();
            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            this.PlanActual.Especialidad = (Especialidad)cbEspecialidad.SelectedItem;
        }

        public void limpioErrores()
        {
            errProvider.Clear();
        }

        new public virtual void MapearADatos()
        {
            switch (this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosPlan();
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosPlan();
                    PlanActual.ID = Convert.ToInt32(this.txtID.Text);
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new PlanLogic().Save(PlanActual);
        }

        public bool validoDatos()
        {
            bool validador = true;
            if (Validaciones.EstaVacioCampo(txtDescripcion.Text))
            {
                if (!Validaciones.VerificoLongitudCampo(txtDescripcion.Text))
                {
                    errProvider.SetError(txtDescripcion, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtDescripcion, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }

        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (validoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
            limpioErrores();
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
                if (MessageBox.Show("Seguro que desea eliminar el plan seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
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
     
    }
}
