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
            try
            {   //Se devuelven las inscripciones dependiendo el tipo persona
                switch (usuario.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Alumno:
                        return InscripcionData.GetInscripcionesAlumno(usuario);

                    case Persona.TiposPersonas.Docente:
                        return InscripcionData.GetInscripcionesDocente(usuario);

                    default: return null;
                }
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
            
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
