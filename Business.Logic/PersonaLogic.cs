using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class PersonaLogic
    {
        private PersonaAdapter m_personaAdapter;

        public PersonaAdapter PersonaData
        {
            get => m_personaAdapter;
            set => m_personaAdapter = value;
        }
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public void Delete(Persona persona)
        {
            PersonaData.Delete(persona);
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }

    }
}
