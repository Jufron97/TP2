using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.UI.Desktop.Formularios_Principales.Alumno
{
    public partial class InscripcionAlumno : Form
    {
        private Usuario m_usuario;

        public Usuario UsuarioActual
        {
            get => m_usuario;
            set => m_usuario = value;
        }

        public InscripcionAlumno(Usuario usuario)
        {
            InitializeComponent();
            UsuarioActual = usuario;
        }

    }
}
