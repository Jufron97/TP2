using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    class Comision:BusinessEntity
    {
        #region Atributos

        private int m_anioEspecialidad;
        private string m_descripcion;
        private int m_IDPlan;

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
    
        public int IDPlan
        {
            get => m_IDPlan;
            set => m_IDPlan = value;
        }

        #endregion
    }
}
