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
using Academia.Util;

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
            switch(this.Modo)
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

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.cbPlan.SelectedValue = this.ComisionActual.IDPlan;
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
        }

        new public virtual void MapearADatos()
        {
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosComision();
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosComision();
                    this.ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new ComisionLogic().Save(ComisionActual);
        }

        public bool ValidoDatos()
        {
            bool validador = true;
            //Valido la descripcion
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
            //Valido el año
            if (Validaciones.EstaVacioCampo(txtAnioEspecialidad.Text))
            {
                if (!Validaciones.EsNumerico(txtAnioEspecialidad.Text))
                {
                    errProvider.SetError(txtAnioEspecialidad, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtAnioEspecialidad, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }

        new public virtual bool Validar()
        {
            if (ValidoDatos())
            {
                return true;
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

        public void limpioErrores()
        {
            errProvider.Clear();
        }

        #endregion

        #region  EventosFormulario

        private void ComisionDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }


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
    }
}
