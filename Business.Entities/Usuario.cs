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
        private string m_nombre;
        private string m_apellido;
        private string m_clave;
        private string m_email;
        private bool m_habilitado;

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

        public string Apellido
        {
            get => m_apellido;
            set => m_apellido = value;
        }

        public string Email
        {
            get => m_email;
            set => m_email = value;
        }

        public bool Habilitado
        {
            get => m_habilitado;
            set => m_habilitado = value;
        }

        public string Nombre
        {
            get => m_nombre;
            set => m_nombre = value;
        }
        #endregion
    }
}
