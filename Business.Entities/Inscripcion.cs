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

        public string Condicion
        {
            get => m_condicion;
            set => m_condicion = value;
        }

        public int Nota
        {
            get => m_nota;
            set => m_nota = value;
        }

        public Persona Alumno
        {
            get => m_alumno;
            set => m_alumno = value;
        }

        public int IDAlumno
        {
            get => Alumno.ID;
        }

        public string NombreAlumno
        {
            get => Alumno.Nombre;
        }

        public string ApellidoAlumno
        {
            get => Alumno.Apellido;
        }

        public Curso Curso
        {
            get => m_curso;
            set => m_curso = value;
        }

        public int IDCurso
        {
            get => Curso.ID;
        }

        public string DescMateria
        {
            get => Curso.DescMateria;
        }

        public string DescComision
        {
            get => Curso.DescComision;
        }


        #endregion
    }
}
