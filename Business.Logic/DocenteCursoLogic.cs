﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class DocenteCursoLogic
    {
        private DocenteCursoAdapter m_cursoDocenteAdapter;

        public DocenteCursoAdapter CursoDocenteData
        {
            get => m_cursoDocenteAdapter;
            set => m_cursoDocenteAdapter = value;
        }

        public DocenteCursoLogic()
        {
            CursoDocenteData = new DocenteCursoAdapter();
        }

        /// <summary>
        /// Devuelve todos los cursos y sus docentes 
        /// <returns></returns>
        public List<DocenteCurso> GetAll()
        {
            return CursoDocenteData.GetAll();
        }

        /// <summary>
        /// Devuelve 
        /// </summary>
        /// <returns></returns>
        public List<Persona> GetAll(Curso curso)
        {
            return CursoDocenteData.GetAll(curso);
        }

        public DocenteCurso GetOne(int id)
        {
            return CursoDocenteData.GetOne(id);
        }

        public void Delete(DocenteCurso docCurso)
        {
            CursoDocenteData.Delete(docCurso);
        }

        public void Save(DocenteCurso docCurso)
        {
            CursoDocenteData.Save(docCurso);
        }

        public void Update(DocenteCurso docCurso)
        {
            CursoDocenteData.Update(docCurso);
        }
    }
}
