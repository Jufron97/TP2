﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
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

        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HsTotales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.IdPlan.ToString();
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
            this.MateriaActual.Plan.ID = Convert.ToInt32(this.txtIDPlan.Text);
        }

        /// <summary>
        /// Metodo que se utiliza para pasar los datos de los TXT a un objeto correspindientes
        /// </summary>
        public void MapearADatos2()
        {
            //Dependiendo del tipo de formulario, se le asigna el tipo al usuario
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                MateriaActual.State = Usuario.States.Deleted;
            }
            else
            {
                CastearDatosMateria();
                //Se asigna el tipo de operacion al usuarios para posteriormente poder dejarlo en la BD
                if (this.Modo == ApplicationForm.ModoForm.Alta)
                {
                    this.MateriaActual.State = Usuario.States.New;
                }
                else
                {
                    this.MateriaActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.MateriaActual.State = Usuario.States.Modified;
                }
            }
        }
        
        new public virtual bool Validar()
        {
            if (this.txtDescripcion.TextLength == 0 || this.txtHsSemanales.TextLength == 0 || this.txtHorasTotales.TextLength == 0 || this.txtIDPlan.TextLength == 0)
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Int32.TryParse(txtHsSemanales.Text, out int valor) == false)
                {
                    Notificar("HsSemanales ingresadas no validas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if(Int32.TryParse(txtHorasTotales.Text, out int valor1) == false)
                    {
                        Notificar("HsTotales ingresadas no validas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if(Int32.TryParse(txtIDPlan.Text, out int valor2) == false)
                    {
                        Notificar("ID Plan ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
            return true;  
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
                GuardarCambios();
                this.Close();
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

        #region CodigoViejo

        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                MateriaActual = new Materia();
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = Int32.Parse(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = Int32.Parse(this.txtHorasTotales.Text);
                this.MateriaActual.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                MateriaActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = Int32.Parse(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = Int32.Parse(this.txtHorasTotales.Text);
                this.MateriaActual.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                MateriaActual.State = BusinessEntity.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                //new MateriaLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        public MateriaABM(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        public MateriaABM(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                MateriaActual = new MateriaLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                MateriaActual = new MateriaLogic().GetOne(ID);
                MapearDeDatos();
            }
        }

        #endregion


    }
}
