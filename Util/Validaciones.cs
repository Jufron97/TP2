using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.Util
{
    public class Validaciones
    {
        private static string patron = @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$\s";

        /// <summary>
        /// Se verifica si el campo excede los 50 caracteres
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool VerificoLongitudCampo(string cadena)
        {
            return cadena.Length < 50;
        }

        /// <summary>
        ///Se verifica si el campo esta vacio
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool EstaVacioCampo(string cadena)
        {
           return !String.IsNullOrEmpty(cadena);
        }

        /// <summary>
        /// Se verifica si el campo ingresado es valido
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool EsCampoValido(string cadena)
        {
            return !Regex.IsMatch(cadena, patron);
        }
        
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
        /// Devuelve true si es un cadena valida, caso contrario false
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        public static ErrorProvider EsTxtValido(TextBox txt, ErrorProvider errorProvider)
        {
            if(EstaVacioCampo(txt.Text))
            {
                if (VerificoLongitudCampo(txt.Text))
                {
                    if (Validaciones.EsCampoValido(txt.Text))
                    {
                        errorProvider.SetError(txt, "El campo ingresado no es valido");
                        return errorProvider;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    errorProvider.SetError(txt, "El campo debe contener menos de 50 caracteres");
                    return errorProvider;
                }
            }
            else
            {
                errorProvider.SetError(txt, "El campo ingresado no puede ser vacio");
                return errorProvider;
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
            else 
                return false;
        }

        //Se verifica si las claves son iguales
        public static bool ClavesIguales(string cadena1,string cadena2)
        {
            return String.Equals(cadena1, cadena2);
        }
    }
}
