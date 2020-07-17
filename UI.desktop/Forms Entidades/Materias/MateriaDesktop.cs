using System;
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
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia m_materiaActual;

        public Materia MateriaActual
        {
            get => m_materiaActual;
            set => m_materiaActual = value;
        }

        #region Constructores
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        
        public MateriaDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        public MateriaDesktop(int ID, ModoForm modo):this()
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

        #region Metodos
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsSemanales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HsSemanales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.HsSemanales.ToString();
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                MateriaActual = new Materia();
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = Int32.Parse(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = Int32.Parse(this.txtHorasTotales.Text);
                this.MateriaActual.IdPlan = Int32.Parse(this.txtIDPlan.Text);
                MateriaActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = Int32.Parse(this.txtHsSemanales.Text);
                this.MateriaActual.HsTotales = Int32.Parse(this.txtHorasTotales.Text);
                this.MateriaActual.IdPlan = Int32.Parse(this.txtIDPlan.Text);
                MateriaActual.State = BusinessEntity.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                new MateriaLogic().Delete(Int32.Parse(this.txtID.Text));
                
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
            MapearADatos();
            if (this.Modo == ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                new MateriaLogic().Save(MateriaActual);
            }
        }

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
                if (Validar() == true)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        #endregion

    }
}
