using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        private EspecialidadAdapter m_especialidadData;

        #region Propiedades

        public EspecialidadAdapter EspecialidadData
        {
            get => m_especialidadData;
            set => m_especialidadData = value;
        }

        #endregion

        #region Constructores

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        #endregion 

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public void Delete(Especialidad especialidad)
        {
            EspecialidadData.Delete(especialidad);
        }

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
            
        }
    }
}

