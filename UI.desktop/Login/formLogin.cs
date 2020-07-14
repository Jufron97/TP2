using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (txtUsuario.Text == "Admin" && txtContraseña.Text == "Admin")
            {
                MessageBox.Show("Usted ah ingresado correctamente al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contrasela invalidos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkOlvidoPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
