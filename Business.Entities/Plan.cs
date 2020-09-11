using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Plan:BusinessEntity
    {
        #region Atributos

        private string m_descripcion;
        private Especialidad m_especialdidad;

        #endregion

        #region Constructores

        public Plan()
        {
            Especialidad = new Especialidad();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve/Setea la descripcion del Plan
        /// </summary>
        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        /// <summary>
        /// Devuelve/Setea la especialidad al cual hace referencia el Plan
        /// </summary>
        public Especialidad Especialidad
        {
            get => m_especialdidad;
            set => m_especialdidad = value;
        }

        /// <summary>
        /// Devuelve el ID de la especialidad al cual hace referencia el Plan
        /// </summary>
        public int IDEspecialidad
        {
            get => Especialidad.ID;
        }

        /// <summary>
        /// Devuelve la descripcion de la especialidad al cual hace referencia el Plan
        /// </summary>
        public string DescEspecialidad
        {
            get => Especialidad.Descripcion;
        }

        #endregion

    }
}
