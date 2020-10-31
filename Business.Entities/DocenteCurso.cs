using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {
        #region Atributos 
        private TiposCargos m_cargo;
        private Curso m_curso;
        private Persona m_docente;

        #endregion

        #region Constructores

        public DocenteCurso()
        {
            Curso = new Curso();
            Docente = new Persona();
        }

        #endregion

        #region Propiedades  

        /// <summary>
        /// Devuelve/setea el cargo del Docente
        /// </summary>
        public TiposCargos Cargo
        {
            get => m_cargo;
            set => m_cargo = value;
        }

        /// <summary>
        /// Devuelve/setea el Curso al cual hace referencia
        /// </summary>
        public Curso Curso
        {
            get => m_curso;
            set => m_curso = value;
        }

        /// <summary>
        /// Devuevle la descripcion de la comision a la cual hace referencia el curso
        /// </summary>
        public string DescComisionCurso
        {
            get => Curso.DescComision;
        }

        /// <summary>
        /// Devuevle la descripcion de la materia a la cual hace referencia el curso
        /// </summary>
        public string DescMateriaCurso
        {
            get => Curso.DescMateria;
        }

        /// <summary>
        /// Devuelve el ID del Curso
        /// </summary>
        public int IDCurso
        {
            get => Curso.ID;
        }

        /// <summary>
        /// Devuelve/setea el Docente al cual hace referencia
        /// </summary>
        public Persona Docente
        {
            get => m_docente;
            set => m_docente = value;
        }

        /// <summary>
        /// Devuelve el ID del Docente 
        /// </summary>
        public int IDDocente
        {
            get => Docente.ID;
        }

        #endregion

        public enum TiposCargos
        {
            Profesor,
            JefeDeCatedra,
            Auxiliar,
        }
    }
}
