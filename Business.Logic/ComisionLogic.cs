using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class ComisionLogic:BusinessLogic
    {
        private ComisionAdapter m_comisionData;

        public ComisionAdapter ComisionData
        {
            get => m_comisionData;
            set => m_comisionData = value;
        }
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }

    }
}
