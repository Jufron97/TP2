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
        private string m_descripcion;
        private Comision m_comision;
        private Materia m_materia;

        #endregion

        #region Constructores

        public Curso()
        {
            Comision = new Comision();
            Materia = new Materia();
        }

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

        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }

        public Comision Comision
        {
            get => m_comision;
            set => m_comision = value;
        }

        public int IDComision
        {
            get => Comision.ID;
        }

        public Materia Materia
        {
            get => m_materia;
            set => m_materia = value;
        }

        public int IDMateria
        {
            get => Materia.ID;
        }

        #endregion
    }
}
