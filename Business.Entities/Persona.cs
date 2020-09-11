using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Persona:BusinessEntity
    {
        #region Atributos

        private string m_apellido;
        private string m_nombre;
        private string m_telefono;
        private string m_direccion;
        private string m_email;
        private DateTime m_fechaNacimiento;
        private Plan m_plan;
        private TiposPersonas m_tipoPersona;
        private int m_legajo;

        #endregion

        #region Constructores

        public Persona()
        {
            Plan = new Plan();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve/Setea el apellido de la Persona
        /// </summary>
        public string Apellido
        {
            get => m_apellido;
            set => m_apellido = value;
        }

        /// <summary>
        /// Devuelve/Setea el nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get => m_nombre;
            set => m_nombre = value;
        }

        /// <summary>
        /// Devuelve/Setea el telefono de la Persona
        /// </summary>
        public string Telefono
        {
            get => m_telefono;
            set => m_telefono = value;
        }

        /// <summary>
        /// Devuelve/Setea la direccion de la Persona
        /// </summary>
        public string Direccion
        {
            get => m_direccion;
            set => m_direccion = value;
        }

        /// <summary>
        /// Devuelve/Setea el email de la Persona
        /// </summary>
        public string Email
        {
            get => m_email;
            set => m_email = value;
        }

        /// <summary>
        /// Devuelve/Setea la fecha de nacimiento de la Persona
        /// </summary>
        public DateTime FechaNacimiento
        {
            get => m_fechaNacimiento;
            set => m_fechaNacimiento = value;
        }

        /// <summary>
        /// Devuelve/Setea el legajo de la Persona
        /// </summary>
        public int Legajo
        {
            get => m_legajo;
            set => m_legajo = value;
        }

        /// <summary>
        /// Devuelve/Setea el rol de la Persona
        /// </summary>
        public TiposPersonas TipoPersona 
        {
            get => m_tipoPersona;
            set => m_tipoPersona=value;
        }
        
        public enum TiposPersonas 
        {
            Admin,
            Alumno,
            Docente       
        }

        /// <summary>
        /// Devuelve/Setea el Plan al cual hace referencia la Persona
        /// </summary>
        public Plan Plan
        {
            get => m_plan;
            set => m_plan = value;
        }

        /// <summary>
        /// Devuelve el ID del Plan al cual hace referencia
        /// </summary>
        public int IDPlan
        {
            get => Plan.ID;
        }

        #endregion
    }
}
