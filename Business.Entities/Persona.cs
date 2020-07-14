using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Persona
    {
        #region Atributos

        private string m_apellido;
        private string m_nombre;
        private string m_telefono;
        private string m_direccion;
        private string m_email;
        private DateTime m_fechaNacimiento;
        private int m_IDPlan;
        //private TiposPersonas m_tipoPersona;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get => m_apellido;
            set => m_apellido = value;
        }

        
        public string Nombre
        {
            get => m_nombre;
            set => m_nombre = value;
        }
       
        public string Telefono
        {
            get => m_telefono;
            set => m_telefono = value;
        }
        
        public string Direccion
        {
            get => m_direccion;
            set => m_direccion = value;
        }
      
        public string Email
        {
            get => m_email;
            set => m_email = value;
        }
        
        public DateTime FechaNacimiento
        {
            get => m_fechaNacimiento;
            set => m_fechaNacimiento = value;
        }
        
        public int IDPlan
        {
            get => m_IDPlan;
            set => m_IDPlan = value;
        }

        private int m_legajo;
        public int Legajo
        {
            get => m_legajo;
            set => m_legajo = value;
        }

        /*
        public int TipoPersona 
        {
            get => m_tipoPersona;
            set => m_tipoPersona=value;
        }
        */
        #endregion
    }
}
