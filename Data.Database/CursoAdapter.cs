using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Academia.Business.Entities;

namespace Academia.Data.Database
{
    public class CursoAdapter:Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> Cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    //Objeto Comision
                    cur.Comision = new ComisionAdapter().GetOne((int)drCursos["id_comision"]);
                    //Objeto Materia
                    cur.Materia = new MateriaAdapter().GetOne((int)drCursos["id_materia"]);
                    Cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.ID = (int)drCursos["id_curso"];
                    //Objeto Comision
                    cur.Comision = new ComisionAdapter().GetOne((int)drCursos["id_comision"]);
                    //Objeto Materia
                    cur.Materia = new MateriaAdapter().GetOne((int)drCursos["id_materia"]);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return cur;
        }

        public void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET cupo=@cupo,id_comision=@idComision," +
                    "anio_calendario=@anioCalendario,id_materia=@idMateria WHERE id_curso=@idCurso", sqlConn);
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@idComision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@idMateria", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete from cursos where id_curso=@idCurso", sqlConn);
                cmdDelete.Parameters.Add("@idCurso", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos (id_comision,cupo,anio_calendario,id_materia) " +
                "values (@idComision,@cupo,@anioCalendario,@idMateria) " + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@idComision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@idMateria", SqlDbType.Int).Value = curso.IDMateria;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }



    }
}
