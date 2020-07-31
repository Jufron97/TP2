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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usuLogic = new UsuarioLogic();
            Usuario usuarioLogeado = new Usuario();
            try
            {
                usuarioLogeado = usuLogic.GetOne(txtUsuario.Text, txtContraseña.Text);
                //Esto sirve para saber si devuelve el objeto de la base de datos, solo modifico el txtUsuario con el Apellido          
                //Tendria que ir un metodo usuarioLogeado en validaciones, no se batialgo asi

                if (Validaciones.usuarioLogeado(usuarioLogeado))
                {
                    //Aca iria lo del formulario que se despliega con el usuario, pero no se como seguirlo
                    MessageBox.Show("Usted ah ingresado correctamente al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario y/o contrasela invalidos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
