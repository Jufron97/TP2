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
    public partial class ListadoMaterias : Form
    {
        public ListadoMaterias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }

        #region Metodos
        /// <summary>
        /// Devuelve si hay alguna fila/item seleccionada
        /// </summary>
        /// <returns></returns>
        private bool itemSeleccionado()
        {
            return (dgvMaterias.SelectedRows.Count > 0);
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

        #endregion

        #region EventosFormulario
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
            MateriaABM formMaterias = new MateriaABM();
            formMaterias.Modo = ApplicationForm.ModoForm.Alta;
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if(itemSeleccionado())
            {
                /*
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMaterias = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMaterias.ShowDialog();
                */
                MateriaABM formMaterias = new MateriaABM();
                formMaterias.Modo = ApplicationForm.ModoForm.Modificacion;
                formMaterias.MateriaActual = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem);
                formMaterias.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay materias seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                /*
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMaterias = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMaterias.ShowDialog();
                */
                MateriaABM formMaterias = new MateriaABM();
                formMaterias.Modo = ApplicationForm.ModoForm.Baja;
                formMaterias.MateriaActual = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem);
                formMaterias.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay materias seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
