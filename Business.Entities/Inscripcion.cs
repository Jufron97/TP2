using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Inscripcion:BusinessEntity
    {
        #region Atributos

        private int m_nota;
        private Persona m_alumno;
        private Curso m_curso;
        private string m_condicion;

        #endregion

        #region Constructores

        public Inscripcion()
        {
            Alumno = new Persona();
            Curso = new Curso();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve/Setea la condicion en la cual se encuentra la Inscripcion del alumno
        /// </summary>
        public string Condicion
        {
            get => m_condicion;
            set => m_condicion = value;
        }

        /// <summary>
        /// Devuelve/Setea la nota a la Inscripcion del alumno
        /// </summary>
        public int Nota
        {
            get => m_nota;
            set => m_nota = value;
        }

        /// <summary>
        /// Devuelve/Setea el objeto Alumno en el cual se basa la inscripcion
        /// </summary>
        public Persona Alumno
        {
            get => m_alumno;
            set => m_alumno = value;
        }

        /// <summary>
        /// Devuelve el ID del alumno al que hace referencia la inscripcion
        /// </summary>
        public int IDAlumno
        {
            get => Alumno.ID;
        }

        /// <summary>
        /// Devuelve el nombre del alumno al que hace referencia la inscripcion
        /// </summary>
        public string NombreAlumno
        {
            get => Alumno.Nombre;
        }

        /// <summary>
        /// Devuelve el apellido del alumno al que hace referencia la inscripcion
        /// </summary>
        public string ApellidoAlumno
        {
            get => Alumno.Apellido;
        }

        /// <summary>
        /// Devuelve/Setea el objeto Curso en el cual se basa la inscripcion
        /// </summary>
        public Curso Curso
        {
            get => m_curso;
            set => m_curso = value;
        }

        /// <summary>
        /// Devuelve el ID del curso      
        /// /// </summary>
        public int IDCurso
        {
            get => Curso.ID;
        }

        /// <summary>
        /// Devuelve la descripcion de la materia a la que hace referencia el curso
        /// </summary>
        public string DescMateria
        {
            get => Curso.DescMateria;
        }

        /// <summary>
        /// Devuelve la descripcion de la comision a la que hace referencia el curso
        /// </summary>
        public string DescComision
        {
            get => Curso.DescComision;
        }

        #endregion
    }
}
