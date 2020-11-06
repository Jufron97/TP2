using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class PlanLogic:BusinessLogic
    {
        private PlanAdapter m_planData;

        public PlanAdapter PlanData
        {
            get => m_planData;
            set => m_planData = value;
        }
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Plan GetOne(int id)
        {
            return PlanData.GetOne(id);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public void Delete(Plan plan)
        {
            PlanData.Delete(plan.ID);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }




    }
}
