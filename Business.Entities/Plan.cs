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

        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }
        
        public Especialidad Especialidad
        {
            get => m_especialdidad;
            set => m_especialdidad = value;
        }

        public int IDEspecialidad
        {
            get => Especialidad.ID;
        }

        public string DescEspecialidad
        {
            get => Especialidad.Descripcion;
        }

        #endregion

    }
}
