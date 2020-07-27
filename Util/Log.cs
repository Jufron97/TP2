using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace Academia.Util
{
    public class Log
    {
        private string m_ruta;

        public string Ruta
        {
            get => m_ruta;
            set => m_ruta = value;
        }

        public Log(string error)
        {
            string cadena = "";
            string nombre = nombreDirectorio();
            //Aca tendria que ir el directorio de la carpeta Util automaticamente, cosa que no puedo encontrar como hacerlo
            Ruta = @"A:\Juan\Facu\NET\Unidad 4\TP2L05\TP2L05\Util"; // buscar elmah-log4net
            crearDirectorio();
            nombre = nombreDirectorio();
            cadena +=DateTime.Now + " - " + error + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Ruta+"/"+nombre, true);
            sw.Write(cadena);
            sw.Close();
        }

        public string nombreDirectorio()
        {
            return "Log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";
        }

        public void crearDirectorio()
        {
            try
            {
                if (!Directory.Exists(Ruta))
                {
                    Directory.CreateDirectory(Ruta);
                }
            }
            catch(DirectoryNotFoundException exDirecNoEncontrado)
            {
                throw new Exception(exDirecNoEncontrado.Message);
            }
        }
    }
}
