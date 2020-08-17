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
            new Usuarios().ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Especialidades().ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Planes().ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Materias().ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Comisiones().ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Cursos().ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new UsuarioDesktop().ShowDialog();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new EspecialidadDesktop().ShowDialog();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PlanDesktop().ShowDialog();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new MateriaDesktop().ShowDialog();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ComisionDesktop().ShowDialog();
        }

        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CursoDesktop().ShowDialog();
        }

        /*private void uusariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BajaUsuario().ShowDialog();
        }

        private void especialidadesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BajaEspecialidad().ShowDialog();
        }

        private void planesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BajaPlan().ShowDialog();
        }

        private void materiasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BajaMateria().ShowDialog();
        }

        private void comisionesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BajaComision().ShowDialog();
        }

        private void cursosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BajaCurso().ShowDialog();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ModUsuario().ShowDialog();
        }

        private void especialidadesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new ModEspecialidad().ShowDialog();
        }

        private void planesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new ModPlan().ShowDialog();
        }

        private void materiasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new ModMateria().ShowDialog();
        }

        private void comisionesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new ModComision().ShowDialog();
        }

        private void cursosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new ModCurso().ShowDialog();
        }*/
    }
}
