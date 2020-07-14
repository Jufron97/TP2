using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class ModuloUsuario:BusinessEntity
    {
        #region Atributos

        private bool m_permiteAlta;
        private bool m_permiteBaja;
        private bool m_permiteModificacion;
        private bool m_permiteConsulta;
        private int m_idUsuario;
        private int m_idModulo;

        #endregion

        #region Propiedades 

        public bool PermiteAlta
        {
            get => m_permiteAlta;
            set => m_permiteAlta = value;
        }
        public bool PermiteBaja
        {
            get => m_permiteBaja;
            set => m_permiteBaja = value;
        }
        public bool PermiteModificacion
        {
            get => m_permiteModificacion;
            set => m_permiteModificacion = value;
        }
        public bool PermiteConsulta
        {
            get => m_permiteConsulta;
            set => m_permiteConsulta = value;
        }
        public int IdUsuario
        {
            get => m_idUsuario;
            set => m_idUsuario = value;
        }
        public int IdModulo
        {
            get => m_idModulo;
            set => m_idModulo = value;
        }

        #endregion
    }
}
