﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class Especialidad:BusinessEntity
    {
        private string m_descripcion;

        /// <summary>
        /// Devuelve/setea la descripcion de la especialidad
        /// </summary>
        public string Descripcion
        {
            get => m_descripcion;
            set => m_descripcion = value;
        }
    }
}
