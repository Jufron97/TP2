using Academia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Data.Database;

namespace Academia.Business.Logic
{
    public class AlumnoInscripcionLogic:BusinessLogic
    {
        private AlumnoInscripcionAdapter m_inscripcionData;

        public AlumnoInscripcionAdapter InscripcionData
        {
            get => m_inscripcionData;
            set => m_inscripcionData = value;
        }

        public AlumnoInscripcionLogic()
        {
            InscripcionData = new AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public List<AlumnoInscripcion> GetAll(Usuario usuario)
        {
            return InscripcionData.GetAll(usuario);
        }

        public AlumnoInscripcion GetOne(int id)
        {
            return InscripcionData.GetOne(id);
        }

        public void Delete(AlumnoInscripcion InscripAlumno)
        {
            InscripcionData.Delete(InscripAlumno);
        }

        public void Save(AlumnoInscripcion InscripAlumno)
        {
            InscripcionData.Save(InscripAlumno);
        }

        /// <summary>
        /// Metodo que valida que el alumno no este inscripto en ese curso
        /// </summary>
        /// <param name="InscripAlumno"></param>
        /// <returns></returns>
        public bool validarInscripcion(AlumnoInscripcion InscripAlumno)
        {
            return InscripcionData.GetOne(InscripAlumno);
        }

    }
}
