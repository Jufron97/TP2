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

        /// <summary>
        /// Devuelve/setea la descripcion de la Materia
        /// </summary>
        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        /// <summary>
        /// Devuelve/Setea las horas semanalaes de la Matera
        /// </summary>
        public int HsSemanales
        {
            get => m_hsSemanales;
            set => m_hsSemanales = value;
        }

        /// <summary>
        /// Devuelve/Setea las horas totales de la Matera
        /// </summary>
        public int HsTotales
        {
            get => m_hsTotales;
            set => m_hsTotales = value;
        }


        /// <summary>
        /// Devuelve/Setea el Plan al cual hace referencia la Materia
        /// </summary>
        public Plan Plan
        {
            get => m_Plan;
            set => m_Plan = value;
        }

        /// <summary>
        /// Devuelve el ID del Plan al cual hace referencia la Materia
        /// </summary>
        public int IdPlan
        {
            get => Plan.ID;
        }

        /// <summary>
        /// Devuevle la descripcion del cual hace referencia la Materia
        /// </summary>
        public string DescPlan
        {
            get => Plan.Descripcion;
        }

        #endregion
    }
}
