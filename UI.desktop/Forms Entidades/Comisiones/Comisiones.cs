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

namespace Academia.UI.Desktop.Forms_Entidades.Comisiones
{
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            try
            {
                dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #region
        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formUsuario = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            Listar();
        }

        #endregion

    }
}
