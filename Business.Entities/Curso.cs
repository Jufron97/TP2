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

        /// <summary>
        /// Devuelve/Setea el valor del año del curso
        /// </summary>
        public int AnioCalendario
        {
            get => m_anioCalendario;
            set => m_anioCalendario = value;
        }

        /// <summary>
        /// Devuelve/Setea el valor del cupo del curso
        /// </summary>
        public int Cupo
        {
            get => m_cupo;
            set => m_cupo = value;
        }

        /// <summary>
        /// Devuelve/Setea el objeto Comision al cual hace referencia el curso
        /// </summary>
        public Comision Comision
        {
            get => m_comision;
            set => m_comision = value;
        }

        /// <summary>
        /// Devuelve el valor del ID de la Comision al cual hace referencia el curso
        /// </summary>
        public int IDComision
        {
            get => Comision.ID;
        }

        public string DescComision
        {
            get => Comision.Descripcion;
        }

        /// <summary>
        /// Devuelve/Setea el objeto Materia al cual hace referencia el curso
        /// </summary>
        public Materia Materia
        {
            get => m_materia;
            set => m_materia = value;
        }

        /// <summary>
        /// Devuelve el valor del ID de la Materia al cual hace referencia el curso
        /// </summary>
        public int IDMateria
        {
            get => Materia.ID;
        }

        /// <summary>
        /// Devuelve el valor de la descripcion de la Comision al cual hace referencia el curso
        /// </summary>
        public string DescMateria
        {
            get => Materia.Descripcion; 
        }

        #endregion
    }
}
