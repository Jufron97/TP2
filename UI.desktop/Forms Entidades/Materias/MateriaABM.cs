using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Academia.Business.Entities;
using Academia.Business.Logic;

namespace Academia.UI.Desktop.Forms_Entidades.Materias
{
    public partial class MateriaABM : ApplicationForm
    {
        private Materia m_materiaActual;

        #region Propiedades
        public Materia MateriaActual
        {
            get => m_materiaActual;
            set => m_materiaActual = value;
        }

        #endregion

        #region Constructores

        public MateriaABM()
        {
            InitializeComponent();
        }
        
        #endregion

        #region Metodos

        public void cargoComboBox()
        {
            cbPlan.DataSource = new PlanLogic().GetAll();
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
        }
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
                    cbPlan.Enabled = false;
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HsTotales.ToString();
            this.cbPlan.SelectedValue = this.MateriaActual.IdPlan;
        }

        /// <summary>
        /// Metodo Utilizado para modificar los datos de la materia seleccionada o para dar de alta una nuevo
        /// </summary>
        public void CastearDatosMateria()
        {
            this.MateriaActual = new Materia();
            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HsSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            this.MateriaActual.HsTotales = Convert.ToInt32(this.txtHorasTotales.Text);
            this.MateriaActual.Plan = (Plan)cbPlan.SelectedItem;
        }

        /// <summary>
        /// Metodo que se utiliza para pasar los datos de los TXT a un objeto correspindientes
        /// </summary>
        public void MapearADatos2()
        {
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    MateriaActual.State = Usuario.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosMateria();
                    this.MateriaActual.State = Usuario.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosMateria();
                    this.MateriaActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.MateriaActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public bool verificoCamposNulos()
        {
            bool validador = true;
            if(String.IsNullOrEmpty(txtDescripcion.Text))
            {
                validador = false;
                errorProv.SetError(txtDescripcion, "Este campo no puede estar vacio!");
            }
            if (String.IsNullOrEmpty(txtHorasTotales.Text))
            {
                validador = false;
                errorProv.SetError(txtHorasTotales, "Este campo no puede estar vacio!");
            }
            if (String.IsNullOrEmpty(txtHsSemanales.Text))
            {
                validador = false;
                errorProv.SetError(txtHsSemanales, "Este campo no puede estar vacio!");
            }
            return validador;
        }

        public bool verificoValores()
        {
            bool validador = true;
            string mensaje = null;
            if (Int32.TryParse(txtHsSemanales.Text, out int valor) == false)
            {
                mensaje+="HsSemanales ingresadas no validas\n";
                validador = false;
            }
            if (Int32.TryParse(txtHorasTotales.Text, out int valor1) == false)
            {
                mensaje += "HsTotales ingresadas no validas\n";
                validador = false;
            }
            if(!String.IsNullOrEmpty(mensaje))
            {
                Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return validador;
        }
        
        new public virtual bool Validar()
        {
            if (verificoCamposNulos())
            {
                if(verificoValores())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;               
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos2();
            new MateriaLogic().Save(MateriaActual);
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        #endregion

        #region EventosFormulario

        /// <summary>
        /// Verifica los datos ingresados al formulario, devuelve un booleano
        /// </summary>
        /// <returns></returns>
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
                if (MessageBox.Show("Seguro que desea eliminar la materia seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void MateriaDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }

        #endregion
      
    }
}
