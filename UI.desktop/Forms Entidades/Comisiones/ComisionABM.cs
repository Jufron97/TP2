﻿using System;
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

namespace Academia.UI.Desktop.Forms_Entidades.Comisiones
{
    public partial class ComisionABM : ApplicationForm
    {
        private Comision m_comisionActual;

        #region Propiedades
        public Comision ComisionActual
        {
            get => m_comisionActual;
            set => m_comisionActual = value;
        }
        #endregion

        #region Constructores

        public ComisionABM()
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

        /// <summary>
        /// Crea el formulario especifico segun el tipo especificado
        /// </summary>
        public void IniciarFormulario()
        {
            cargoComboBox();
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ApplicationForm.ModoForm.Baja)
                {
                    this.btnAceptar.Text = "Eliminar";
                    cbPlan.Enabled = false;
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
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.cbPlan.SelectedValue = this.ComisionActual.IDPlan;
            //this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
        }

        /// <summary>
        /// Se utiliza para modificar los datos de un curso especifica o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosComision()
        {
            this.ComisionActual = new Comision();
            this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.Plan = (Plan)cbPlan.SelectedItem;
            //this.ComisionActual.Plan.ID = Convert.ToInt32(this.txtIDPlan.Text);
        }

        public void MapearADatos2()
        {
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                this.ComisionActual.State = BusinessEntity.States.Deleted;
            }
            else
            {
                CastearDatosComision();
                if (this.Modo == ApplicationForm.ModoForm.Alta)
                {
                    ComisionActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
                    ComisionActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos2();
            new ComisionLogic().Save(ComisionActual);
        }

        /// <summary>
        /// Se verifica si existen campos nulos
        /// </summary>
        /// <returns></returns>
        public bool verificoCamposNulos()
        {
            bool validador = true;
            if(String.IsNullOrEmpty(txtAnioEspecialidad.Text))
            {
                validador = false;
                errorProv.SetError(txtAnioEspecialidad, "Este campo no puede estar vacio!");
            }
            if(String.IsNullOrEmpty(txtDescripcion.Text))
            {
                validador = false;
                errorProv.SetError(txtDescripcion, "Este campo no puede estar vacio!");
            }
            return validador;
        }

        /// <summary>
        /// Se verifica que los campos ingresados correspondan a los valores predeterminados
        /// </summary>
        /// <returns></returns>
        public bool verificoValores()
        {
            bool validador = true;
            string mensaje = null;
            if (Int32.TryParse(this.txtAnioEspecialidad.Text, out int valor) == false)
            {
                mensaje += "El año ingresado no es valido";
                validador = false;
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
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error); //concatenar mensajes y llamar a notificar una sola vez al final
                return false;               
            }
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        #endregion

        #region  EventosFormulario

        private void ComisionDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
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
                if (MessageBox.Show("Seguro que desea eliminar la comision seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        #endregion

        #region CodigoViejo


        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                ComisionActual = new Comision();
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                //this.ComisionActual.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                ComisionActual.State = Comision.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                //this.ComisionActual.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                ComisionActual.State = Comision.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                ComisionActual.State = Comision.States.Deleted;               
            }
        }

        public ComisionABM(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        public ComisionABM(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {

                ComisionActual = new ComisionLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                ComisionActual = new ComisionLogic().GetOne(ID);
                MapearDeDatos();
            }
        }


        #endregion


    }
}