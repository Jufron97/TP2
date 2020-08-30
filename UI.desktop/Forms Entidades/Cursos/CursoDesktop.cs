using Academia.Business.Entities;
using Academia.Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.UI.Desktop.Forms_Entidades.Cursos
{
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso m_cursoActual;

        #region Propiedades

        public Curso CursoActual
        {
            get => m_cursoActual;
            set => m_cursoActual = value;
        }

        #endregion

        #region Constructores

        public CursoDesktop()
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

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtIDMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtIDComision.Text = this.CursoActual.IDComision.ToString();
            this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
        }

        /// <summary>
        /// Se utiliza para modificar los datos de un curso especifica o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosCurso()
        {
            this.CursoActual = new Curso();
            this.CursoActual.ID = Convert.ToInt32(this.txtID.Text);
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAñoCalendario.Text);
            this.CursoActual.IDComision = Convert.ToInt32(this.txtIDComision.Text);
            this.CursoActual.IDMateria = Convert.ToInt32(this.txtIDMateria.Text);
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
        }

        public void MapearADatos2()
        {
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                this.CursoActual.State = BusinessEntity.States.Deleted;
            }
            else
            {
                CastearDatosCurso();
                if (this.Modo == ApplicationForm.ModoForm.Alta)
                {
                    CursoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    CursoActual.State = BusinessEntity.States.Modified;
                }
            }
        }

        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (this.txtIDMateria.TextLength == 0 || this.txtIDComision.TextLength == 0 || this.txtAñoCalendario.TextLength == 0 || this.txtCupo.TextLength == 0)
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (Int32.TryParse(txtIDMateria.Text, out int valor) == false)
                {
                  Notificar("ID Materia ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return false;
                }
                else if (Int32.TryParse(txtIDComision.Text, out int valor1) == false)
                {
                  Notificar("ID Comision ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return false;
                }
                else if (Int32.TryParse(txtAñoCalendario.Text, out int valor2) == false)
                {
                  Notificar("Año Calendario ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return false;
                }
                else if (Int32.TryParse(txtCupo.Text, out int valor3) == false)
                {
                  Notificar("Cupo ingresado no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return false;
                }
            return true;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
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

        private void CursoDesktop_Shown(object sender, EventArgs e)
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
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region CodigoViejo

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                CursoActual = new CursoLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                CursoActual = new CursoLogic().GetOne(ID); ;
                MapearDeDatos();
            }
        }

        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                CursoActual = new Curso();
                this.CursoActual.IDMateria = Int32.Parse(this.txtIDMateria.Text);
                this.CursoActual.IDComision = Int32.Parse(this.txtIDComision.Text);
                this.CursoActual.AnioCalendario = Int32.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                CursoActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.CursoActual.IDMateria = Int32.Parse(this.txtIDMateria.Text);
                this.CursoActual.IDComision = Int32.Parse(this.txtIDComision.Text);
                this.CursoActual.AnioCalendario = Int32.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                CursoActual.State = BusinessEntity.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                new CursoLogic().Delete(Int32.Parse(this.txtID.Text));

            }
        }

        #endregion

 
    }
}
