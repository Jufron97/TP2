﻿using System;
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

namespace Academia.UI.Desktop.Formularios_Principales
{
    public partial class FormularioAlumno : Form
    {
        private Usuario m_usuarioActual;

        public Usuario UsuarioActual
        {
            get => m_usuarioActual;
            set => m_usuarioActual = value;
        }
        public FormularioAlumno(Usuario usuActual)
        {
            InitializeComponent();
            UsuarioActual = usuActual;
        }

    }
}
