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

namespace Academia.UI.Desktop.Forms_Entidades.Comisiones
{
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision m_comisionActual;

        #region Propiedades
        public Comision ComisionActual
        {
            get => m_comisionActual;
            set => m_comisionActual = value;
        }
        #endregion


        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
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


        #region Metodos
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
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
                ComisionActual = new Comision();
                this.ComisionActual.AnioEspecialidad= Int32.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.IDPlan = Int32.Parse(this.txtIDPlan.Text);
                ComisionActual.State = Comision.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.IDPlan = Int32.Parse(this.txtIDPlan.Text);
                ComisionActual.State = Comision.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                new ComisionLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            if (this.Modo == ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                new ComisionLogic().Save(ComisionActual);
            }
        }

        new public virtual bool Validar()
        {
            if (this.txtAnioEspecialidad.TextLength == 0 || this.txtDescripcion.TextLength == 0 || this.txtIDPlan.TextLength == 0)
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Int32.TryParse(this.txtAnioEspecialidad.Text,out int valor) == false)
                {
                    Notificar("El año ingresado no es valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Int32.TryParse(this.txtIDPlan.Text, out int valor1) == false)
                {
                    Notificar("El ID de plan ingresado no es valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    return true;
            }
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }



        #endregion

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
    }
}
