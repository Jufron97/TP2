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

namespace Academia.UI.Desktop.Forms_Entidades.Especialidades
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                dgvEspecialidades.DataSource = el.GetAll();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop formEspecialiad = new EspecialidadesDesktop(ID,ApplicationForm.ModoForm.Baja);
            formEspecialiad.ShowDialog();
            this.Listar();
        }
    }
}
