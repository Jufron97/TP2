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
    public partial class ListadoEspecialidades : Form
    {
        #region Constructores

        public ListadoEspecialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        #endregion

        #region Metodos

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

        /// <summary>
        /// Devuelve si hay alguna fila/item seleccionada
        /// </summary>
        /// <returns></returns>
        private bool itemSeleccionado()
        {
            return (dgvEspecialidades.SelectedRows.Count > 0);
        }

        #endregion

        #region EventosFormulario

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
            EspecialidadABM formEspecialidad = new EspecialidadABM();
            formEspecialidad.Modo = ApplicationForm.ModoForm.Alta;
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                /*
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID,ApplicationForm.ModoForm.Modificacion);
                formEspecialidad.ShowDialog();
                this.Listar();
                */
                EspecialidadABM formEspecialidad = new EspecialidadABM();
                formEspecialidad.Modo = ApplicationForm.ModoForm.Modificacion;
                formEspecialidad.EspecialidadActual = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
                formEspecialidad.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay especialidades seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                /*
                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID,ApplicationForm.ModoForm.Baja);
                formEspecialidad.ShowDialog();
                this.Listar();
                */
                EspecialidadABM formEspecialidad = new EspecialidadABM();
                formEspecialidad.Modo = ApplicationForm.ModoForm.Baja;
                formEspecialidad.EspecialidadActual =((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay especialidades seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
