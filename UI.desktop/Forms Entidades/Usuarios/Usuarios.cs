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
using Academia.UI.Desktop;

namespace Academia.UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
        }

        #region EventosFormulario
        private void Usuarios_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop();
            formUsuario.Modo = ApplicationForm.ModoForm.Alta;
            formUsuario.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {/*
                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                Aca implemente otra forma de invocar alformulario de alumno
                */
                //Se crea el formulario
                UsuarioDesktop formUsuario = new UsuarioDesktop();
                //Se asigna el tipo de formulario
                formUsuario.Modo = ApplicationForm.ModoForm.Modificacion;
                //Se selecciona al usuario
                formUsuario.UsuarioActual=((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem);
                //Se muestra al usuario en el formulario con los datos cargados
                formUsuario.ShowDialog();

                Listar();
            }
            else
            {
                MessageBox.Show("No hay Usuarios seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            /*
            int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID,ApplicationForm.ModoForm.Baja);
            */
            if(itemSeleccionado())
            {
                UsuarioDesktop formUsuario = new UsuarioDesktop();
                formUsuario.Modo = ApplicationForm.ModoForm.Baja;
                formUsuario.UsuarioActual = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem);
                formUsuario.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay Usuarios seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// Devuelve si hay alguna fila/item seleccionada
        /// </summary>
        /// <returns></returns>
        private bool itemSeleccionado()
        {
            return (dgvUsuarios.SelectedRows.Count > 0);
        }
    }
}
