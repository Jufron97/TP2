using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        private UsuarioAdapter m_usuarioData;

        public UsuarioAdapter UsuarioData
        {
            get => m_usuarioData;
            set => m_usuarioData = value;
        }
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        /// <summary>
        /// Listado de todos los usuarios en la base de datos
        /// </summary>
        /// <param name="nombUsu"></param>
        /// <param name="claveUsu"></param>
        /// <returns></returns>
        public List<Usuario> GetAll()
        {
           return UsuarioData.GetAll();
        }

        /// <summary>
        /// Recibe el ID de un usuario, devuelve un objeto Usuario persistido en la base de datos
        /// </summary>
        /// <returns></returns>
        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        /// <summary>
        /// Recibe el nombre y la clave del usuario, devuelve un objeto Usuario persistido en la base de datos
        /// </summary>
        /// <param name="nombUsu"></param>
        /// <param name="claveUsu"></param>
        /// <returns></returns>
        public Usuario GetOne(string nombUsu,string claveUsu)
        {
            return UsuarioData.GetOne(nombUsu, claveUsu);
        }

        /// <summary>
        /// Recibe el nombre y clave del usuario para verificar que el mismo existe, devuelve un booleano
        /// </summary>
        /// <param name="nombUsu"></param>
        /// <param name="claveUsu"></param>
        /// <returns></returns>
        public bool verificoLogin(string nombUsu, string claveUsu)
        {
            //Si se encontro un usuario, va atener un nombre distinto del nulo, no pense en otra forma de como verificar
            if (UsuarioData.GetOne(nombUsu, claveUsu).NombreUsuario!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina a un usuario persistido con el ID especificado de la base de datos
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Delete(Usuario Usu)
        {
            UsuarioData.Delete(Usu);
        }

        /// <summary>
        /// Guarda al objeto usuario en la base de datos para poder ser persistido
        /// </summary>
        /// <param name="usuario"></param>
        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

    }
}
