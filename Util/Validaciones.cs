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
        public static Boolean emailBienEscrito(String email)
        {
            String expresion;
            expresion = @"\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Boolean usuarioLogeado(Usuario usu)
        {
            if (usu.Nombre!=null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

    }
}
