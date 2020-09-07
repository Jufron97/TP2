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
    public partial class ListadoPlanes : Form
    {
        public ListadoPlanes()
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

        /// <summary>
        /// Devuelve si hay alguna fila/item seleccionada
        /// </summary>
        /// <returns></returns>
        private bool itemSeleccionado()
        {
            return (dgvPlanes.SelectedRows.Count > 0);
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            PlanABM formPlanes = new PlanABM();
            formPlanes.Modo = ApplicationForm.ModoForm.Alta;
            formPlanes.ShowDialog();
            this.Listar();
        }
 

        private void tsEditar_Click(object sender, EventArgs e)
        {
            /*
            int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlanes = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlanes.ShowDialog();
            */
            if (itemSeleccionado())
            {
                PlanABM formUsuario = new PlanABM();
                formUsuario.Modo = ApplicationForm.ModoForm.Modificacion;
                formUsuario.PlanActual = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem);
                formUsuario.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay planes seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {       
            /*
             int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlanes = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPlanes.ShowDialog();
            */
            if (itemSeleccionado())
            {
                PlanABM formUsuario = new PlanABM();
                formUsuario.Modo = ApplicationForm.ModoForm.Baja;
                formUsuario.PlanActual = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem);
                formUsuario.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay planes seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
