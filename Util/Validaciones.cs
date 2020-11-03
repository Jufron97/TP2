using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academia.Util
{
    public class Validaciones
    {
        private static string patron = @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$";

        /// <summary>
        /// Se verifica que la cadena sea menor o igual a 50 caracteres y que no sea vacia
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool VerificoLongitudYVacio(string cadena)
        {
            return cadena.Length < 50 && !String.IsNullOrEmpty(cadena);
        }

        /// <summary>
        /// Devuelve true si es un cadena valida, caso contrario false
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        public static bool EsCadenaValida(string cadena)
        {
            if (VerificoLongitudYVacio(cadena))
            {
                return !Regex.IsMatch(cadena,patron);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve true si es un valor numerico, caso contrario false
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool EsNumerico(string cadena)
        {
            return Int32.TryParse(cadena, out int resultado);
        }

        /// <summary>
        /// Devuelve true si es un nombre valido, caso contrario false
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        public static bool ValidarLongitudClave(string clave,string claveRep)
        {
            if (String.Equals(clave, claveRep))
            {
                if (!String.IsNullOrEmpty(clave))
                {
                    return clave.Length > 8;
                }
                else 
                    return false;
            }
            else return false;
        }
    }
}
