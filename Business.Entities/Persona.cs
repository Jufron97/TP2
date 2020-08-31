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
       
        public Plan Plan
        {
            get => m_plan;
            set => m_plan = value;
        }

        public int IDPlan
        {
            get =>Plan.ID;
        }

        public int Legajo
        {
            get => m_legajo;
            set => m_legajo = value;
        }
     
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
        #endregion
    }
}
