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

        public TiposCargos Cargo
        {
            get => m_cargo;
            set => m_cargo = value;
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

        public Persona Docente
        {
            get => m_docente;
            set => m_docente = value;
        }

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
