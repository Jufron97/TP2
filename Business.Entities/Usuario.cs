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

        public Usuario()
        {
            Persona = new Persona();
        }

        #region Propiedades

        /// <summary>
        /// Devuelve/Setea el nombre del Usuario
        /// </summary>
        public string NombreUsuario
        {
            get => m_nombreUsuario;
            set => m_nombreUsuario = value;
        }

        /// <summary>
        /// Devuelve/Setea la clave del Usuario
        /// </summary>
        public string Clave
        {
            get => m_clave;
            set => m_clave = value;
        }

        /// <summary>
        /// Devuelve/Setea el estado del Usuario
        /// </summary>
        public bool Habilitado
        {
            get => m_habilitado;
            set => m_habilitado = value;
        }

        /// <summary>
        /// Devuelve/Setea la Persona al cual hace referencia el Usuario
        /// </summary>
        public Persona Persona
        {
            get => m_persona;
            set => m_persona = value;
        }

        /// <summary>
        /// Devuelve/Setea el nombre de la Persona a la cual hace referencia el Usuario
        /// </summary>
        public string Nombre
        {
            get => Persona.Nombre;
            set => Persona.Nombre = value;
        }

        /// <summary>
        /// Devuelve/Setea el apellido de la Persona a la cual hace referencia el Usuario
        /// </summary>
        public string Apellido
        {
            get => Persona.Apellido;
            set => Persona.Apellido = value;
        }

        /// <summary>
        /// Devuelve/Setea el email de la Persona a la cual hace referencia el Usuario
        /// </summary>
        public string Email
        {
            get => Persona.Email;
            set => Persona.Email = value;
        }

        /// <summary>
        /// Devuelve/Setea el Legajo de la Persona a la cual hace referencia el Usuario
        /// </summary>
        public int Legajo
        {
            get => Persona.Legajo;
            set => Persona.Legajo = value;
        }

        #endregion
    }
}
