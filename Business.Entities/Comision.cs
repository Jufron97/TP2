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

        /// <summary>
        /// Devuelve/Setea el año de la especialidad
        /// </summary>
        public int AnioEspecialidad
        {
            get => m_anioEspecialidad;
            set => m_anioEspecialidad = value;
        }

        /// <summary>
        /// Devuelve/Setea la descripcion inscripcion de la especialidad
        /// </summary>
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

        /// <summary>
        /// Devuelve el ID del plan al que hace referencia la especialidad
        /// </summary>
        public int IDPlan
        {
            get => Plan.ID;
        }

        /// <summary>
        /// Devuelve la descripcion del plan al que hace referencia la especialidad
        /// </summary>
        public string DescPlan
        {
            get => Plan.Descripcion;
        }

        #endregion
    }
}
