using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Comision:BusinessEntity
    {
        #region Atributos

        private int m_anioEspecialidad;
        private string m_descripcion;
        private Plan m_Plan;

        #endregion

        #region Constructores

        public Comision()
        {
            Plan = new Plan();
        }

        #endregion

        #region Propiedades
        public int AnioEspecialidad
        {
            get => m_anioEspecialidad;
            set => m_anioEspecialidad = value;
        }
      
        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        public Plan Plan
        {
            get => m_Plan;
            set => m_Plan = value;
        }

        public int IDPlan
        {
            get => Plan.ID;
        }

        public string DescPlan
        {
            get => Plan.Descripcion;
        }

        #endregion
    }
}
