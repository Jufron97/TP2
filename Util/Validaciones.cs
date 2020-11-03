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
        public static Boolean EsEmailValido(string email)
        {
            String expresion;
            expresion = @"\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*";
            return Regex.IsMatch(email, expresion);
        }

        public static bool EsUsuarioValido(string usu)
        {
            string patron = "[^ \\w_.-]";
            string espaciosBlancos = "[ \\s]";
            return !(Regex.IsMatch(usu, patron) || Regex.IsMatch(usu, espaciosBlancos));
        }

        public static bool ValidarLongitudClave(string clave,string claveRep)
        {
            if (String.Equals(clave, claveRep))
            {
                if (clave != null)
                {
                    return clave.Length < 8;
                }
                else return false;
            }
            else return false;
        }

        public static bool EsNombreValido(string nombre)
        {
            string patron = "[^ a-zA-Z]";
            return Regex.IsMatch(nombre, patron);
        }

        public static bool EsDescripcionValida(string descripcion)
        {
            string patron = "[\\w]";
            return Regex.IsMatch(descripcion, patron);
        }

        public static bool EsLegajoValido(string legajo)
        {
            string patron = @"(\d){5}";
            return Regex.IsMatch(legajo, patron);
        }

        public static bool EsTelefonoValido(string telefono)
        {
            string patron = @"(\d){7,}";
            return Regex.IsMatch(telefono, patron);
        }

        public static bool EsDireccionValida(string direccion)
        {
            string patron = @"(\w|\s)+ \d{1,5} ((b|B)(i|I)(s|S))?";
            return Regex.IsMatch(direccion, patron);
        }

    }
}
