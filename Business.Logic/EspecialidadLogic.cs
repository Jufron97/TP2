using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;
using Data.Database;

namespace Academia.Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        private EspecialidadAdapter m_especialidadData;

        public EspecialidadAdapter EspecialidadData
        {
            get => m_especialidadData;
            set => m_especialidadData = value;
        }
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
            
        }
    }
}

