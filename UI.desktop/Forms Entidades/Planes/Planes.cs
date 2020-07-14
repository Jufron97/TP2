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

namespace Academia.UI.Desktop.Forms_Entidades.Planes
{
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {/*
            PlanesDesktop formPlanes = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlanes.ShowDialog();
            Listar();*/
        }
 

        private void tsEditar_Click(object sender, EventArgs e)
        {
            /*
            int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanesDesktop formPlanes = new PlanesDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formPlanes.ShowDialog();
            Listar();*/
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {/*
            int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanesDesktop formPlanes = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPlanes.ShowDialog();
            Listar();*/
        }
    }
}
