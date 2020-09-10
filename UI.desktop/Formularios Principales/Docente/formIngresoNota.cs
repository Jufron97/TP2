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
    public partial class formIngresoNota : Form
    {
        private Inscripcion m_inscripcion;

        public Inscripcion InsActual
        {
            get => m_inscripcion;
            set => m_inscripcion = value;
        }
        
        public formIngresoNota(Inscripcion inscripcion)
        {
            InitializeComponent();
            InsActual = inscripcion;
        }

        public void cargoFormulario()
        {
            txtAlumno.Text = InsActual.ApellidoAlumno + ", " + InsActual.NombreAlumno;
            txtCondicion.Text = InsActual.Condicion;
        }

        public bool validarNota()
        {
            if (Int32.TryParse(txtNota.Text, out int valor))
            {
                return true;                
            }
            else
            {
                MessageBox.Show("El valor ingresado no es valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }         
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validarNota())
            {
                InsActual.Nota = Int32.Parse(txtNota.Text);
                InsActual.Condicion = "Corregido";
                InsActual.State = BusinessEntity.States.Modified;
                new InscripcionLogic().Save(InsActual);
                MessageBox.Show("Nota ingresada con exito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Close();
        }

        private void formIngresoNota_Shown(object sender, EventArgs e)
        {
            cargoFormulario();
        }
    }
}
