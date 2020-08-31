﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        #region Atributos

        private int m_nota;
        private Persona m_alumno;
        private Curso m_curso;
        private string m_condicion;

        #endregion

        #region Constructores

        public AlumnoInscripcion()
        {
            Alumno = new Persona();
            Curso = new Curso();
        }

        #endregion

        #region Propiedades

        public Persona Alumno
        {
            get => m_alumno;
            set => m_alumno = value;
        }

        public int IDAlumno
        {
            get => Alumno.ID;
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

        #endregion
    }
}
