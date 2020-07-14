using Academia.UI.Desktop.Forms_Entidades.Especialidades;
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
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new formLogin().ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Usuarios().ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Especialidades().ShowDialog();
        }
    }
}
