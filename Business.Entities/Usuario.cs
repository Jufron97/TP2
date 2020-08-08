using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Usuario:BusinessEntity
    {
        #region Atributos

        private string m_nombreUsuario;
        private string m_clave;
        private bool m_habilitado;
        private Persona m_persona;

        #endregion

        #region Propiedades
        public string NombreUsuario
        {
            get => m_nombreUsuario;
            set => m_nombreUsuario = value;
        }

        public string Clave
        {
            get => m_clave;
            set => m_clave = value;
        }

        public bool Habilitado
        {
            get => m_habilitado;
            set => m_habilitado = value;
        }
        public  Persona Persona
        {
            get => m_persona;
            set => m_persona = value;
        }

        #endregion
    }
}
