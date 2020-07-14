using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Business.Entities
{
    public class BusinessEntity
    {


        private int m_ID;
        private States m_state;

        public int ID
        {
            get => m_ID;
            set => m_ID = value; 
        }

        public States State 
        {
            get => m_state; 
            set => m_state = value;  
        }


        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified,
        }

        public BusinessEntity()
        {
            this.State = States.New;
        }
    }
}
