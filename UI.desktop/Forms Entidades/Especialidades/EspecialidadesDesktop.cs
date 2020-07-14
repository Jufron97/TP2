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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        private Especialidad m_especialidadActual;

        public Especialidad EspecialidadActual
        {
            get => m_especialidadActual;
            set => m_especialidadActual= value;
        }
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadesDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        public EspecialidadesDesktop(int ID, ModoForm modo):this()
        {
            Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                EspecialidadActual = new EspecialidadLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                EspecialidadActual = new EspecialidadLogic().GetOne(ID);
                MapearDeDatos();
            }
        }

        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
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
                EspecialidadActual = new Especialidad();
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = Especialidad.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = Usuario.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                new EspecialidadLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            if (this.Modo == ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                new EspecialidadLogic().Save(EspecialidadActual);
            }
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }
    }
}
