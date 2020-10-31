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

namespace Academia.UI.Desktop.Formularios_Principales.Docente
{
    public partial class ReportePlanesForm : Form
    {
        public ReportePlanesForm()
        {
            InitializeComponent();
        }

        private void ReportePlanesForm_Load(object sender, EventArgs e)
        {

            PlanBindingSource.DataSource = new PlanLogic().GetAll();

            this.RvPlanes.RefreshReport();
           
        }
    }
}
