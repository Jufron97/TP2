using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Data.Database;

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

        public List<Usuario> GetAll()
        {
           return UsuarioData.GetAll();
        }

        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
