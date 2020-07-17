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

namespace Academia.UI.Desktop.Forms_Entidades.Materias
{
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }


        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                dgvMaterias.DataSource = ml.GetAll();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMaterias = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMaterias = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMaterias = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
            formMaterias.ShowDialog();
            this.Listar();
        }
    }
}
