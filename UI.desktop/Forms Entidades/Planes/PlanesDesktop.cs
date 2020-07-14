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
    public partial class PlanesDesktop : ApplicationForm
    {
        private Plan m_planActual;

        public Plan PlanActual
        {
            get => m_planActual;
            set => m_planActual = value;
        }

        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo):this()
        {
            Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public PlanesDesktop(int ID, ModoForm modo):this()
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

        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.txtIDEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
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
                new PlanLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            if (this.Modo == ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                new PlanLogic().Save(PlanActual);
            }
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
