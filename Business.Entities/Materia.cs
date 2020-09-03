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
        private Plan m_Plan;
        private string m_descripcion;

        #endregion

        #region Constructores

        public Materia()
        {
            Plan = new Plan();
        }

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

        public Plan Plan
        {
            get => m_Plan;
            set => m_Plan = value;
        }

        public int IdPlan
        {
            get => Plan.ID;
        }

        public string DescripcionPlan
        {
            get => Plan.Descripcion;
        }

        #endregion
    }
}
