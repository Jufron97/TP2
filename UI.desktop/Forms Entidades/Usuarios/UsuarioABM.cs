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
using Academia.Util;

namespace Academia.UI.Desktop
{
    public partial class UsuarioABM : ApplicationForm
    {

        private Usuario m_usuarioActual;

        #region Propiedades
        public Usuario UsuarioActual
        {
            get => m_usuarioActual;
            set => m_usuarioActual = value;
        }
        #endregion

        #region Constructores
        public UsuarioABM()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos

        public void cargoComboBox()
        {
            cbPlanes.DataSource = new PlanLogic().GetAll();
            cbPlanes.ValueMember = "ID";
            cbPlanes.DisplayMember = "Descripcion";           
        }

        /// <summary>
        /// Crea el formulario especificado segun el tipo de Operacion a realizar
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
                this.lblConfirmarClave.Visible = false;
                this.txtConfirmarClave.Visible = false;
                this.cbPlanes.Enabled = false;
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
            //Usuario
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            //Persona 
            this.txtNombre.Text = this.UsuarioActual.Persona.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Persona.Apellido;
            //Asi se identifica el plan seleccionado pero el ID que este tenga, no hay otra forma de hacerlo si no
            this.cbPlanes.SelectedValue = this.UsuarioActual.Persona.IDPlan;
            dtpFechaNac.Value = UsuarioActual.Persona.FechaNacimiento;

            if (this.UsuarioActual.Persona.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.rdbAlumno.Checked = true;
            }
            else if (this.UsuarioActual.Persona.TipoPersona == Persona.TiposPersonas.Docente)
                {
                    this.rdbDocente.Checked = true;
                }
                   
            
            /*
             * ACA IRIAN TODOS LOS DATOS QUE FALTAN DEL FORMULARIO
             */
        }

        /// <summary>
        /// Metodo Utilizado para modificar los datos del usuario seleccionado o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosUsuario()
        {
            UsuarioActual = new Usuario();
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Persona.FechaNacimiento = this.dtpFechaNac.Value;
            //this.UsuarioActual.Persona.Plan.ID = Convert.ToInt32(this.txtIDPlan.Text);
            //Se castea a el objeto Plan que se selecciono, ya que el DataSource del ComboBox son objetos
            this.UsuarioActual.Persona.Plan = (Plan)this.cbPlanes.SelectedItem;
            //Se verifica el tipo de persona seleccionada
            if (rdbAlumno.Checked)
            {
                this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Alumno;
            }
            else if (rdbDocente.Checked)
                {
                this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Docente;
                }
        }

        /// <summary>
        /// Metodo que se utiliza para pasar los datos de los TXT a un objeto correspindientes
        /// </summary>
        public void MapearADatos2()
        {
            //Dependiendo del tipo de formulario, se le asigna el tipo al usuario
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                UsuarioActual.State = Usuario.States.Deleted;
            }
            else
            {
                CastearDatosUsuario();
                //Se asigna el tipo de operacion al usuarios para posteriormente poder dejarlo en la BD
                if (this.Modo == ApplicationForm.ModoForm.Alta)
                {
                    this.UsuarioActual.State = Usuario.States.New;
                }
                else
                {
                    //Esto no se puede hacer en el metodo de castear usuario, ya que cuando se quiere crear un nuevo usuario
                    //El txtID esta en nulo
                    this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.UsuarioActual.State = Usuario.States.Modified;
                }
            }
        }

        new public virtual void GuardarCambios() 
        {
            MapearADatos2();
            new UsuarioLogic().Save(UsuarioActual);
        }

        /// <summary>
        /// Verifica los datos ingresados al formulario, devuelve un booleano
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (existenCamposVacios())
            {
                if (verificoCampos())
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

        public bool existenCamposVacios()
        {
            bool validador = true;
            if(String.IsNullOrEmpty(txtNombre.Text))
            {
                errProvider.SetError(txtNombre, "El campo no puede estar vacio!");
                validador = false;
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                errProvider.SetError(txtApellido, "El campo no puede estar vacio!");
                validador = false;
            }
            if (String.IsNullOrEmpty(txtClave.Text))
            {
                errProvider.SetError(txtClave, "El campo no puede estar vacio!");
                validador = false;
            }
            if (String.IsNullOrEmpty(txtConfirmarClave.Text))
            {
                errProvider.SetError(txtClave, "El campo no puede estar vacio!");
                validador = false;
            }
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                errProvider.SetError(txtUsuario, "El campo no puede estar vacio!");
                validador = false;
            }
            if(!rdbAlumno.Checked && !rdbDocente.Checked)
            {
                errProvider.SetError(gpbTipoPersona, "Seleccione un tipo");
                validador = false;
            }
            return validador;
        }

        public bool verificoCampos()
        {
            bool validador = true;
            string mensaje = null;
            if(txtClave.TextLength <8)
            {
                mensaje += "La contraseña debe ser mayor a 8 caracteres\n";               
                validador = false;
            }
            if(txtClave.Text != txtConfirmarClave.Text)
            {
                mensaje += "Las claves no coinciden\n";
                validador = false;
            }/*
            if(!Validaciones.emailBienEscrito(txtEmail.Text))
            {
                mensaje += "El mail ingresado no es valido\n";
                validador = false;
            }*/
            if (!String.IsNullOrEmpty(mensaje))
            {
                Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return validador;

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
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("Seguro que desea eliminar el usuario seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void UsuarioDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }

        #endregion

        #region CodigoViejo


        new public virtual void MapearADatos()
        {
            if (this.Modo == ApplicationForm.ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Persona.FechaNacimiento = this.dtpFechaNac.Value;
                //this.UsuarioActual.Persona.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                //Se verifica el tipo de persona seleccionada
                if (rdbAlumno.Checked)
                {
                    this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Alumno;
                }
                else if (rdbDocente.Checked)
                {
                    this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Docente;
                }
                UsuarioActual.State = Usuario.States.New;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Persona.FechaNacimiento = this.dtpFechaNac.Value;
                //this.UsuarioActual.Persona.Plan.ID = Int32.Parse(this.txtIDPlan.Text);
                //Se verifica el tipo de persona seleccionada
                if (rdbAlumno.Checked)
                {
                    this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Alumno;
                }
                else if (rdbDocente.Checked)
                {
                    this.UsuarioActual.Persona.TipoPersona = Persona.TiposPersonas.Docente;
                }
                UsuarioActual.State = Usuario.States.Modified;
            }
            else if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                new UsuarioLogic().Delete(Int32.Parse(this.txtID.Text));
            }
        }

        /// <summary>
        /// Constructor utilizado para las Altas
        /// </summary>
        /// <param name="modo"></param>
        public UsuarioABM(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        /// <summary>
        /// Constructor utilizado para las Bajas y Modificaciones
        /// </summary>
        /// <param name="modo"></param>
        public UsuarioABM(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            if (this.Modo == ApplicationForm.ModoForm.Baja)
            {
                this.lblConfirmarClave.Visible = false;
                this.txtConfirmarClave.Visible = false;
                UsuarioActual = new UsuarioLogic().GetOne(ID);
                MapearDeDatos();
            }
            if (this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                UsuarioActual = new UsuarioLogic().GetOne(ID);
                MapearDeDatos();
            }
        }

        #endregion


    }
}
