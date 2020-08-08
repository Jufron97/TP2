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
using Academia.UI.Desktop.Formularios_Principales;
using Academia.Util;

namespace Academia.UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usuLogic = new UsuarioLogic();
            try
            {                      
                //Cree este metodo para primero, verificar que el usuario exista, luego poder tener los datos menos la clave
                //de ser necesarios en caso que los usemos para mostrarlos en los forms dependiendo de los tipos
                if (usuLogic.verificoLogin(txtUsuario.Text, txtContraseña.Text))
                {
                    Usuario usuarioLogeado = new Usuario();
                    usuarioLogeado = usuLogic.GetOne(txtUsuario.Text, txtContraseña.Text);
                    //Verifico que el usuario este habilitado o no para ingresar
                    if (usuarioLogeado.Habilitado)
                    {
                        MessageBox.Show("Usted ah ingresado correctamente al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        //Aca estan los formularios hay que crearlos y darles una apariencia
                        /* 
                        if(usuarioLogeado.Persona.TipoPersona==Persona.TiposPersonas.Alumno)
                        {
                            new FormularioAlumno().ShowDialog();
                        }
                       if(usuarioLogeado.Persona.TipoPersona == Persona.TiposPersonas.Docente)
                        {
                            new FormularioDocente().ShowDialog();
                        }
                       if(usuarioLogeado.Persona.TipoPersona == Persona.TiposPersonas.Admin)
                        {
                            new FormularioPrincipal().ShowDialog();
                        }*/
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no habilitado al sistema", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña invalidos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void lnkOlvidoPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
