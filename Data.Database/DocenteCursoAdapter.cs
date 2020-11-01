using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using System.Data.SqlClient;
using System.Data;


namespace Academia.Data.Database
{
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> DocentesCursos = new List<DocenteCurso>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocCurso = new SqlCommand("select * from docentes_curso", sqlConn);
                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();
                while (drDocCurso.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocCurso["id_dictado"];
                    //Se busca el objeto Curso
                    docCurso.Curso = new CursoAdapter().GetOne((int)drDocCurso["id_curso"]);
                    //Se busca el objeto Persona
                    docCurso.Docente = new PersonaAdapter().GetOne((int)drDocCurso["id_persona"]);
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drDocCurso["cargo"];
                    DocentesCursos.Add(docCurso);
                }
                drDocCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos-Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return DocentesCursos;
        }

        /// <summary>
        /// Devuelve los docentes respectivamente por curso
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Persona> GetAll(Curso curso)
        {
            List<Persona> DocentesCurso = new List<Persona>();
            try
            {
                OpenConnection();
                SqlCommand cmdDocCurso = new SqlCommand("select id_docente from docentes_curso where id_curso=@idCurso", sqlConn);
                
                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();
                while (drDocCurso.Read())
                {
                    Persona docente = new Persona();
                    docente = new PersonaAdapter().GetOne((int)drDocCurso["id_docente"]);
                    DocentesCurso.Add(docente);
                }
                drDocCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Cursos-Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return DocentesCurso;
        }

        public DocenteCurso GetOne(int id)
        {
            DocenteCurso docCurso = new DocenteCurso();
            try
            {
                OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from docentes_curso where id_docente=@idDocente", sqlConn);
                cmdComisiones.Parameters.Add("@idDocente", SqlDbType.Int).Value = id;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    docCurso.ID = (int)drComisiones["id_dictado"];
                    //Se busca el objeto Curso
                    docCurso.Curso = new CursoAdapter().GetOne((int)drComisiones["id_curso"]);
                    //Se busca el objeto Persona
                    docCurso.Docente = new PersonaAdapter().GetOne((int)drComisiones["id_persona"]);
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drComisiones["cargo"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar Docente-Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return docCurso;
        }

        public void Update(DocenteCurso docCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@idCurso,id_docente=@idDocente,cargo=@cargo" +
                "WHERE id_dictado=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.ID;
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = docCurso.Curso.ID;
                cmdSave.Parameters.Add("@idDocente", SqlDbType.Int).Value = docCurso.Docente.ID;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Delete(DocenteCurso docCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(DocenteCurso docCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos (id_curso,id_docente,cargo)" +
                "values (@idCurso,@idDocente,@cargo)", sqlConn);
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = docCurso.Curso.ID;
                cmdSave.Parameters.Add("@idDocente", SqlDbType.Int).Value = docCurso.Docente.ID;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.Cargo;
                //comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(DocenteCurso docente)
        {
            switch (docente.State)
            {
                case BusinessEntity.States.New:
                    Insert(docente);
                    break;
                case BusinessEntity.States.Modified:
                    Update(docente);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(docente);
                    break;
                default:
                    docente.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }

}
