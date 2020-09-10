using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class InscripcionLogic:BusinessLogic
    {
        private InscripcionAdapter m_inscripcionData;

        public InscripcionAdapter InscripcionData
        {
            get => m_inscripcionData;
            set => m_inscripcionData = value;
        }

        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }

        public List<Inscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public List<Inscripcion> GetAll(Usuario usuario)
        {
            return InscripcionData.GetAll(usuario);
        }

        public Inscripcion GetOne(int id)
        {
            return InscripcionData.GetOne(id);
        }

        public void Delete(Inscripcion InscripAlumno)
        {
            InscripcionData.Delete(InscripAlumno);
        }

        public void Save(Inscripcion InscripAlumno)
        {
            InscripcionData.Save(InscripAlumno);
        }

        /// <summary>
        /// Metodo que valida que el alumno no este inscripto en ese curso
        /// </summary>
        /// <param name="InscripAlumno"></param>
        /// <returns></returns>
        public bool validarInscripcion(Inscripcion InscripAlumno)
        {
            return InscripcionData.GetOne(InscripAlumno);
        }

    }
}
