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


namespace Academia.UI.Desktop.Forms_Entidades.Cursos
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            try
            {
                dgvCursos.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #region Eventos
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop formComision = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            Listar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop formUsuario = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            Listar();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }
        #endregion
    }
}
