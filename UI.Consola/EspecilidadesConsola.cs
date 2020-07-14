using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Logic;
using Academia.Business.Entities;
using System.Linq.Expressions;

namespace Academia.UI.Consola
{
    public class EspecilidadesConsola
    {
        private EspecialidadLogic m_especialidadNegocio;

        #region Propiedades
        public EspecialidadLogic EspecialidadNegocio
        {
            get => m_especialidadNegocio;
            set => m_especialidadNegocio = value;
        }
        #endregion

        public EspecilidadesConsola()
        {
            EspecialidadNegocio = new EspecialidadLogic();
        }

        #region Metodos
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Especialidad esp in EspecialidadNegocio.GetAll())
            {
                MostrarDatos(esp);
            }
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID de la especialidad a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(EspecialidadNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada  debe ser un valor entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Especialidad esp = new Especialidad();

            Console.WriteLine("Ingrese Descripcion de la especialidad a agregar");
            esp.Descripcion = Console.ReadLine();
            EspecialidadNegocio.Save(esp);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", esp.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.WriteLine("Ingrese ID  de la especialidad a modificar");
                int ID = int.Parse(Console.ReadLine());
                Especialidad esp = EspecialidadNegocio.GetOne(ID);
                Console.WriteLine("Ingrese descripcion");
                esp.Descripcion = Console.ReadLine();
                EspecialidadNegocio.Save(esp);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada  debe ser un valor entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID de la especialidad a eliminar");
                int ID = int.Parse(Console.ReadLine());
                EspecialidadNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada  debe ser un valor entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void MostrarDatos(Especialidad esp)
        {
            Console.WriteLine("Especialidad: {0}", esp.ID);
            Console.WriteLine("\t\tDescripcion: {0}", esp.Descripcion);       
        }

        public void Menu()
        {
            ConsoleKeyInfo opcionMenu;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese opcion");
                Console.WriteLine("1  - Listado General");
                Console.WriteLine("2  - Consulta");
                Console.WriteLine("3  - Agregar");
                Console.WriteLine("4  - Modificar");
                Console.WriteLine("5  - Eliminar");
                Console.WriteLine("6  - Salir");
                opcionMenu = Console.ReadKey();
                Console.WriteLine("\n");
                switch (opcionMenu.Key)
                {
                    case ConsoleKey.NumPad1:
                        ListadoGeneral();
                        break;
                    case ConsoleKey.NumPad2:
                        Consultar();
                        break;
                    case ConsoleKey.NumPad3:
                        Agregar();
                        break;
                    case ConsoleKey.NumPad4:
                        Modificar();
                        break;
                    case ConsoleKey.NumPad5:
                        Eliminar();
                        break;
                    default:
                        break;
                }
            } while (opcionMenu.Key != ConsoleKey.NumPad6);
        }
        #endregion
    }
}
