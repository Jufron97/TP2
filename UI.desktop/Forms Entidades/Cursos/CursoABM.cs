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
using Academia.Util;

namespace Academia.UI.Desktop.Forms_Entidades.Cursos
{
    public partial class CursoABM : ApplicationForm
    {
        public Curso m_cursoActual;

        #region Propiedades

        public Curso CursoActual
        {
            get => m_cursoActual;
            set => m_cursoActual = value;
        }

        #endregion

        #region Constructores

        public CursoABM()
        {
            InitializeComponent();
        }
        


        #endregion

        #region Metodos

        public void cargoComboBox()
        {
            //ComboBox Comision
            cbComision.DataSource = new ComisionLogic().GetAll();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
            //ComboBox Materia
            cbMateria.DataSource = new MateriaLogic().GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
        }

        /// <summary>
        /// Crea el formulario especifico segun el tipo especificado
        /// </summary>
        public void IniciarFormulario()
        {
            cargoComboBox();
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        /// <summary>
        /// Se utiliza para pasar los datos del objeto a los TXT correspondientes
        /// </summary>
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.cbMateria.SelectedValue = this.CursoActual.IDMateria;
            this.cbComision.SelectedValue = this.CursoActual.IDComision;
            this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
        }

        /// <summary>
        /// Se utiliza para modificar los datos de un curso especifica o para dar de alta uno nuevo
        /// </summary>
        public void CastearDatosCurso()
        {
            this.CursoActual = new Curso();
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAñoCalendario.Text);
            this.CursoActual.Materia = (Materia)cbMateria.SelectedItem;
            this.CursoActual.Comision = (Comision)cbComision.SelectedItem;          
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
        }

        new public void MapearADatos()
        {
            switch(this.Modo)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosCurso();
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosCurso();
                    this.CursoActual.ID = Convert.ToInt32(this.txtID.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public bool ValidoDatos()
        {
            bool validador = true;
            //Valido el año calendario
            if (Validaciones.EstaVacioCampo(txtAñoCalendario.Text))
            {
                if (!Validaciones.EsNumerico(txtAñoCalendario.Text))
                {
                    errProvider.SetError(txtAñoCalendario, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtAñoCalendario, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido el cupo
            if (Validaciones.EstaVacioCampo(txtCupo.Text))
            {
                if (!Validaciones.EsNumerico(txtCupo.Text))
                {
                    errProvider.SetError(txtCupo, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtCupo, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }

        /// <summary>
        /// Metodo utilizado para validar los datos ingresados al formulario 
        /// </summary>
        /// <returns></returns>
        new public virtual bool Validar()
        {
            if (ValidoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
        }

        /// <summary>
        /// Crea un MessageBox especifico con el mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="botones"></param>
        /// <param name="icono"></param>
        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public void limpioErrores()
        {
            errProvider.Clear();
        }

        #endregion

        #region EventosFormulario

        private void CursoDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            limpioErrores();
            if (this.Modo == ApplicationForm.ModoForm.Alta || this.Modo == ApplicationForm.ModoForm.Modificacion)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            else
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
