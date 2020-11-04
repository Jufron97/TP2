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
            cbTiposPersonas.DataSource = Persona.DameTusTipos();
        }

        /// <summary>
        /// Crea el formulario especificado segun el tipo de Operacion a realizar
        /// </summary>
        public void IniciarFormulario()
        {
            cargoComboBox();
            switch (this.Modo)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.lblConfirmarClave.Visible = false;
                    this.txtConfirmarClave.Visible = false;
                    this.cbPlanes.Enabled = false;
                    this.btnAceptar.Text = "Eliminar";
                    MapearDeDatos();
                    break;
                default:
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
            //Usuario
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombreUsuario.Text = this.UsuarioActual.NombreUsuario;
            //Persona 
            this.txtNombrePersona.Text = this.UsuarioActual.Persona.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Persona.Apellido;
            this.txtLegajo.Text = this.UsuarioActual.Persona.Legajo.ToString();
            this.txtDireccion.Text = this.UsuarioActual.Persona.Direccion;
            this.txtEmail.Text = this.UsuarioActual.Persona.Email;
            this.txtTelefono.Text = this.UsuarioActual.Persona.Telefono;
            this.cbPlanes.SelectedValue = this.UsuarioActual.Persona.IDPlan;
            this.dtpFechaNac.Value = this.UsuarioActual.Persona.FechaNacimiento;
            //Para ver que tipo de persona es
            this.cbTiposPersonas.SelectedItem = this.UsuarioActual.Persona.TipoPersona;
        }

        /// <summary>
        /// Metodo Utilizado para modificar los datos del usuario seleccionado o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosUsuario()
        {
            //Datos Usuario
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.NombreUsuario = this.txtNombreUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            //Datos Persona
            this.UsuarioActual.Persona.Nombre = this.txtNombrePersona.Text;
            this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Persona.FechaNacimiento = this.dtpFechaNac.Value;
            this.UsuarioActual.Persona.Direccion = this.txtDireccion.Text;
            this.UsuarioActual.Persona.Telefono = this.txtTelefono.Text;
            this.UsuarioActual.Persona.Email = this.txtEmail.Text;
            this.UsuarioActual.Persona.Legajo = Int32.Parse(this.txtLegajo.Text);
            //Se castea a el objeto Plan que se selecciono, ya que el DataSource del ComboBox son objetos
            this.UsuarioActual.Persona.Plan = (Plan)this.cbPlanes.SelectedItem;
            //Se verifica el tipo de persona seleccionada
            this.UsuarioActual.Persona.TipoPersona = (Persona.TiposPersonas)cbTiposPersonas.SelectedItem;
        }

        /// <summary>
        /// Metodo que se utiliza para pasar los datos de los TXT a un objeto correspindientes
        /// </summary>
        new public virtual void MapearADatos()
        {
            //Dependiendo del tipo de formulario, se le asigna el tipo al usuario
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    UsuarioActual.State = Usuario.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    this.UsuarioActual = new Usuario();
                    CastearDatosUsuario();
                    this.UsuarioActual.State = Usuario.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosUsuario();                    
                    this.UsuarioActual.State = Usuario.States.Modified;
                    break;
                default: 
                    break;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);
        }

        /// <summary>
        /// Verifica los datos ingresados al formulario, devuelve un booleano
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (validoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos erroneos, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool validoDatos()
        {
            bool validador = true;
            //Se valida el nombre de la persona
            if (Validaciones.EstaVacioCampo(txtNombrePersona.Text))
            {
                if(Validaciones.VerificoLongitudCampo(txtNombrePersona.Text))
                { 
                    if(!Validaciones.EsCampoValido(txtNombrePersona.Text))
                    {
                        errProvider.SetError(txtNombrePersona, "El nombre ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtNombrePersona, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtNombrePersona, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido Apellido
            if (Validaciones.EstaVacioCampo(txtApellido.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtApellido.Text))
                {
                    if (!Validaciones.EsCampoValido(txtApellido.Text))
                    {
                        errProvider.SetError(txtApellido, "El Apellido ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtApellido, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtApellido, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido Clave
            if (Validaciones.EstaVacioCampo(txtClave.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtClave.Text))
                {
                    if (!Validaciones.EsCampoValido(txtClave.Text))
                    {
                        errProvider.SetError(txtClave, "Clave ingresada no es valida");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtClave, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtClave, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido RepetirClave
            if (Validaciones.EstaVacioCampo(txtConfirmarClave.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtConfirmarClave.Text))
                {
                    if (!Validaciones.EsCampoValido(txtConfirmarClave.Text))
                    {
                        errProvider.SetError(txtConfirmarClave, "Clave ingresada no es valida");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtConfirmarClave, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtConfirmarClave, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido NombreUsuario
            if (Validaciones.EstaVacioCampo(txtNombreUsuario.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtNombreUsuario.Text))
                {
                    if (!Validaciones.EsCampoValido(txtNombreUsuario.Text))
                    {
                        errProvider.SetError(txtNombreUsuario, "Nombre de usuario ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtNombreUsuario, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtNombreUsuario, "Este campo no puede estar vacio");
                validador = false;
            }
            if(!Validaciones.ClavesIguales(txtClave.Text,txtConfirmarClave.Text))
            {
                errProvider.SetError(txtClave, "Las claves no coinciden");
                errProvider.SetError(txtConfirmarClave, "Las claves no coinciden");
                validador = false;
            }
            return validador;
        }
     
        public void limpioErrores()
        {
            errProvider.Clear();
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        #endregion

        #region EventosFormulario

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
    }      
}
