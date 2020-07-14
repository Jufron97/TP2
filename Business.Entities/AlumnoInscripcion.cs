using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        private int m_nota;
        private int m_IDAlumno;
        private int m_IDCurso;
        private string m_condicion;

        public int IDAlumno
        {
            get => m_IDAlumno;
            set => m_IDAlumno = value;

        }

        public int IDCurso
        {
            get => m_IDCurso;
            set => m_IDCurso = value;
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
    }
}
