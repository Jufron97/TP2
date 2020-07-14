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

namespace Academia.UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
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
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor utilizado para las Altas
        /// </summary>
        /// <param name="modo"></param>
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.btnAceptar.Text = "Guardar";
        }

        /// <summary>
        /// Constructor utilizado para las Bajas y Modificaciones
        /// </summary>
        /// <param name="modo"></param>
        public UsuarioDesktop(int ID, ModoForm modo) : this()
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

        #region Metodos
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;         
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
            UsuarioActual = new Usuario();
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Email = this.txtEmail.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            UsuarioActual.State = Usuario.States.New;
            }
         else if(this.Modo == ApplicationForm.ModoForm.Modificacion)
                {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.State = Usuario.States.Modified;
                }
                else if(this.Modo ==ApplicationForm.ModoForm.Baja)
                {
                    new UsuarioLogic().Delete(Int32.Parse(this.txtID.Text));
                }
        }

        new public virtual void GuardarCambios() 
        {
            MapearADatos();
            if(this.Modo== ApplicationForm.ModoForm.Modificacion || this.Modo == ApplicationForm.ModoForm.Alta)
            {
                new UsuarioLogic().Save(UsuarioActual);
            }          
        }

        new public virtual bool Validar()
        {
            if (this.txtApellido.TextLength==0 || this.txtNombre.TextLength==0 || this.txtUsuario.TextLength==0 || this.txtEmail.TextLength==0 || this.txtClave.TextLength==0 || this.txtConfirmarClave.TextLength==0)
            {
            Notificar("Algun Campo ingresado estaba vacio",MessageBoxButtons.OK,MessageBoxIcon.Error);         
            return false;
            }
            else
            { 
                if (this.txtClave.Text != this.txtConfirmarClave.Text)
                {
                Notificar("Las claves no coinciden",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                }
                else if(this.txtClave.TextLength < 8)
                    {
                    Notificar("Clave menor a 8 caracteres",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                    }
                else if (this.txtEmail.Text.Contains("@")!= true)
                {
                Notificar("Email ingresado no es correcto",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
