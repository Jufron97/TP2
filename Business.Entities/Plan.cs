using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Plan:BusinessEntity
    {
        private string m_descripcion;
        private int m_IDEspecialidad;

        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }
        
        public int IDEspecialidad
        {
            get => m_IDEspecialidad;
            set => m_IDEspecialidad = value;
        }

    }
}
