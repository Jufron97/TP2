using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Materia:BusinessEntity
    {
        #region Atributos

        private int m_hsSemanales;
        private int m_hsTotales;
        private int m_idPlan;
        private string m_descripcion;

        #endregion

        #region Propiedades
        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        public int HsSemanales
        {
            get => m_hsSemanales;
            set => m_hsSemanales = value;
        }

        public int HsTotales
        {
            get => m_hsTotales;
            set => m_hsTotales = value;
        }

        public int IdPlan
        {
            get => m_idPlan;
            set => m_idPlan = value;
        }

        #endregion
    }
}
