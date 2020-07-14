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
    public class UsuariosConsola
    {

        private UsuarioLogic m_usuarioNegocio;

        #region Propiedades
        public UsuarioLogic UsuarioNegocio
        {
            get => m_usuarioNegocio;
            set => m_usuarioNegocio = value;
        }
        #endregion

        public UsuariosConsola()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        #region Metodos
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usu in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usu);
            }
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
        }
        
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada  debe ser un valor entero");
            }
            catch(Exception e)
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
            Usuario usu = new Usuario();

            Console.WriteLine("Ingrese nombre");
            usu.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            usu.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario");
            usu.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave");
            usu.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese Email");
            usu.Email = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion de usuario 1-Si /2-No");
            usu.Habilitado = (Console.ReadLine() == "1");
            usu.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usu);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usu.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.WriteLine("Ingrese ID  del usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usu = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre");
                usu.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido");
                usu.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario");
                usu.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave");
                usu.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email");
                usu.Email = Console.ReadLine();
                Console.WriteLine("Ingrese habilitacion de usuario 1-Si /2-No");
                usu.Habilitado = (Console.ReadLine() == "1");
                usu.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usu);
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
                Console.WriteLine("Ingrese ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
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

        public void MostrarDatos(Usuario usu)
        {
            Console.WriteLine("Usuario: {0}", usu.ID);
            Console.WriteLine("\t\tNombre: {0}", usu.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usu.Apellido);
            Console.WriteLine("\t\tNombre Usuario: {0}", usu.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usu.Clave);
            Console.WriteLine("\t\tEmail: {0}", usu.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usu.Habilitado);
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
