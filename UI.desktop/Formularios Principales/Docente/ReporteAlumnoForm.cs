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

namespace Academia.UI.Desktop.Formularios_Principales.Docente
{
    public partial class ReporteAlumnoForm : Form
    {
        public ReporteAlumnoForm(Usuario usu)
        {
            InitializeComponent();
            CargarReporte(usu);
        }

        

        public void CargarReporte(Usuario usu) 
        {

            InscripcionBindingSource.DataSource = new InscripcionLogic().GetAll(usu);

            this.RvInscripciones.RefreshReport();

        }

       
    }
}