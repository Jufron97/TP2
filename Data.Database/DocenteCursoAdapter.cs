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
                SqlCommand cmdComisiones = new SqlCommand("select * from docentes_curso", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drComisiones["id_dictado"];
                    docCurso.Curso = new CursoAdapter().GetOne((int)drComisiones["id_curso"]);
                    docCurso.Docente = new PersonaAdapter().GetOne((int)drComisiones["id_persona"]);
                    docCurso.Cargo = (DocenteCurso.TiposCargos)drComisiones["cargo"];
                    DocentesCursos.Add(docCurso);
                }
                drComisiones.Close();
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

        public DocenteCurso GetOne(Persona persona)
        {
            DocenteCurso docCurso = new DocenteCurso();
            try
            {
                OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from docentes_curso where id_docente=@idDocente", sqlConn);
                cmdComisiones.Parameters.Add("@idDocente", SqlDbType.Int).Value = persona.ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    docCurso.ID = (int)drComisiones["id_dictado"];
                    docCurso.Curso = new CursoAdapter().GetOne((int)drComisiones["id_curso"]);
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

        public void Update(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision,id_plan=@id_plan,anio_especialidad=@anio_especialidad " +
                "WHERE id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
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
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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

        public void Insert(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision,id_plan,anio_especialidad)" +
                "values (@desc_comision,@id_plan,@anio_especialidad)", sqlConn);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
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

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                Insert(comision);
            }
            if (comision.State == BusinessEntity.States.Deleted)
            {
                Delete(comision.ID);
            }
            if (comision.State == BusinessEntity.States.Modified)
            {
                Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }

    }

}
