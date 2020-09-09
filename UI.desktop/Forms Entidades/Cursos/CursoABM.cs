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
    public partial class CursoABM : ApplicationForm
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

        public CursoABM()
        {
            InitializeComponent();
        }
        


        #endregion

        #region Metodos

        public void cargoComboBox()
        {
            //ComboBox Comision
            cbComision.DataSource = new ComisionLogic().GetAll();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
            //ComboBox Materia
            cbMateria.DataSource = new MateriaLogic().GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
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
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
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
            this.cbMateria.SelectedValue = this.CursoActual.IDMateria;
            this.cbComision.SelectedValue = this.CursoActual.IDComision;
            //this.txtIDMateria.Text = this.CursoActual.IDMateria.ToString();
            //this.txtIDComision.Text = this.CursoActual.IDComision.ToString();
            this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
        }

        /// <summary>
        /// Se utiliza para modificar los datos de un curso especifica o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosCurso()
        {
            this.CursoActual = new Curso();
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAñoCalendario.Text);
            this.CursoActual.Materia = (Materia)cbMateria.SelectedItem;
            this.CursoActual.Comision = (Comision)cbComision.SelectedItem;          
            //this.CursoActual.Comision.ID = Convert.ToInt32(this.txtIDComision.Text);
            //this.CursoActual.Materia.ID = Convert.ToInt32(this.txtIDMateria.Text);
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
                    this.CursoActual.ID = Convert.ToInt32(this.txtID.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                }
            }
        }


        public bool validoCamposNulos()
        {
            bool validador = true;
            if(String.IsNullOrEmpty(txtAñoCalendario.Text))
            {
                validador = false;
                errorProv.SetError(txtAñoCalendario, "Este campo no puede estar vacio!");
            }
            if(String.IsNullOrEmpty(txtCupo.Text))
            {
                validador = false;
                errorProv.SetError(txtCupo, "Este campo no puede estar vacio!");
            }
            return validador;
        }

        public bool validoValores()
        {
            bool validador = true;
            string mensaje = null;
            if(Int32.TryParse(txtAñoCalendario.Text, out int valor2) == false)
            {
                mensaje += "Año Calendario ingresado no valido\n";
                validador = false;
            }           
            if (Int32.TryParse(txtCupo.Text, out int valor3) == false)
            {
                mensaje += "Cupo ingresado no valido\n";
                validador = false;
            }
            return validador;
        }
        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (validoCamposNulos())
            {
                if(validoValores())
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
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos2();
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

        public CursoABM(ModoForm modo) : this()
        {
            this.Modo = modo;
            btnAceptar.Text = "Guardar";
        }

        public CursoABM(int ID, ModoForm modo) : this()
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
                //this.CursoActual.Materia.ID = Int32.Parse(this.txtIDMateria.Text);
                //this.CursoActual.Comision.ID = Int32.Parse(this.txtIDComision.Text);
                this.CursoActual.AnioCalendario = Int32.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                CursoActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                //this.CursoActual.Materia.ID = Int32.Parse(this.txtIDMateria.Text);
                //this.CursoActual.Comision.ID = Int32.Parse(this.txtIDComision.Text);
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
