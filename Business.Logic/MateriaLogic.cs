using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class MateriaLogic:BusinessLogic
    {
        private MateriaAdapter m_materiaData;

        public MateriaAdapter MateriaData
        {
            get => m_materiaData;
            set => m_materiaData = value;
        }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public void Delete(Materia materia)
        {
            MateriaData.Delete(materia);
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }
    }
}
