using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class CursoLogic:BusinessLogic
    {
        private CursoAdapter m_cursoData;

        public CursoAdapter CursoData
        {
            get => m_cursoData;
            set => m_cursoData = value;
        }
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }

        public void Update(Curso curso)
        {
            CursoData.modificoCupoCurso(curso);
        }
    }
}
