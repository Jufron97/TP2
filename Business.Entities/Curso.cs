using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Curso:BusinessEntity
    {
        #region Atributos

        private int m_anioCalendario;
        private int m_cupo;
        private int m_descripcion;
        private int m_IDComision;
        private int m_IDMateria;

        #endregion

        #region Propiedades
        public int AnioCalendario
        {
            get => m_anioCalendario;
            set => m_anioCalendario = value;
        }

        public int Cupo
        {
            get => m_cupo;
            set => m_cupo = value;
        }

        public int Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        public int IDComision
        {
            get => m_IDComision;
            set => m_IDComision = value;
        }

        public int IDMateria
        {
            get => m_IDMateria;
            set => m_IDMateria = value;
        }

        #endregion
    }
}
