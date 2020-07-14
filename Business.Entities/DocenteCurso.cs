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

        //private TiposCargos m_cargo;
        private int m_IDCurso;
        private int m_IDDocente;

        #endregion

        #region Propiedades

        /*
        public TiposCargos Cargo
        {
            get => m_cargo;
            set
            {
                m_cargo = value;
            }
        }
        */
        public int IDCurso
        {
            get => m_IDCurso;
            set => m_IDCurso = value;
        }
        public int IDDocente
        {
            get => m_IDDocente;
            set => m_IDDocente = value;
        }

        #endregion
    }
}
