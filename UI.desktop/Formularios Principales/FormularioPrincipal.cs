using Academia.UI.Desktop.Forms_Entidades.Comisiones;
using Academia.UI.Desktop.Forms_Entidades.Cursos;
using Academia.UI.Desktop.Forms_Entidades.Especialidades;
using Academia.UI.Desktop.Forms_Entidades.Materias;
using Academia.UI.Desktop.Forms_Entidades.Planes;
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
    public partial class FormularioPrincipal : Form
    {
        private Usuario m_usuarioActual;

        public Usuario UsuarioActual
        {
            get => m_usuarioActual;
            set => m_usuarioActual = value;
        }

        public FormularioPrincipal(Usuario usuActual)
        {
            InitializeComponent();
            UsuarioActual = usuActual;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new ListadoUsuarios().ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListadoEspecialidades().ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListadoPlanes().ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListadoMaterias().ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListadoComisiones().ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ListadoCursos().ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new UsuarioABM().ShowDialog();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new EspecialidadABM().ShowDialog();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PlanABM().ShowDialog();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new MateriaABM().ShowDialog();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ComisionABM().ShowDialog();
        }

        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CursoABM().ShowDialog();
        }

        private void imgNet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ERA POR ABAJO PALACIOS",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
