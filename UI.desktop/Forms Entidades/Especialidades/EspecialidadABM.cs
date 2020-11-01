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

namespace Academia.UI.Desktop.Forms_Entidades.Especialidades
{
    public partial class EspecialidadABM : ApplicationForm
    {
        private Especialidad m_especialidadActual;
        
        #region Propiedades

        public Especialidad EspecialidadActual
        {
            get => m_especialidadActual;
            set => m_especialidadActual = value;
        }

        #endregion

        #region Constructores

        public EspecialidadABM()
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
            switch (this.Modo)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        /// <summary>
        /// Se utiliza para modificar los datos de un plan especifico o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosEspecialidad()
        {
            this.EspecialidadActual = new Especialidad();
            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }

        public void MapearADatos2()
        {
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosEspecialidad();
                    this.EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosEspecialidad();
                    this.EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;

            }
        }

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();           
        }

        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (this.txtDescripcion.TextLength == 0)
            {
                Notificar("El campo Descripcion esta vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new EspecialidadLogic().Save(EspecialidadActual);
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

        #region EventosFormularios

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                if (MessageBox.Show("Seguro que desea eliminar la especialidad seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
        }

        private void EspecialidadDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }

        #endregion

        

    }
}
