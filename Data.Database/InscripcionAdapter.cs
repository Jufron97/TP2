using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Academia.Data.Database
{
    public class InscripcionAdapter : Adapter
    { 

    public List<Inscripcion> GetAll()
    {
        List<Inscripcion> Inscripciones = new List<Inscripcion>();
        try
        {
            OpenConnection();
            SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
            SqlDataReader drInscripciones = cmdAlumnoInscripcion.ExecuteReader();
            while (drInscripciones.Read())
            {
                Inscripcion AlIns = new Inscripcion();
                AlIns.ID = (int)drInscripciones["id_inscripcion"];
                //Objeto Alumno
                AlIns.Alumno = new PersonaAdapter().GetOne((int)drInscripciones["id_alumno"]);
                //Objeto Curso
                AlIns.Curso = new CursoAdapter().GetOne((int)drInscripciones["id_curso"]);
                AlIns.Condicion = (string)drInscripciones["condicion"];
                //Por si las notas no fueron cargadas
                if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                {
                    AlIns.Nota = 0;
                }
                else
                {
                        AlIns.Nota = (int)drInscripciones["nota"];
                }
                Inscripciones.Add(AlIns);
            }
            drInscripciones.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            CloseConnection();
        }
        return Inscripciones;
    }

    public List<Inscripcion> GetAll(Usuario usuario)
        {
            List<Inscripcion> Inscripciones = new List<Inscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@idAlumno", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = usuario.Persona.ID;
                SqlDataReader drInscripciones = cmdAlumnoInscripcion.ExecuteReader();
                while (drInscripciones.Read())
                {
                    Inscripcion AlIns = new Inscripcion();
                    AlIns.ID = (int)drInscripciones["id_inscripcion"];
                    //Objeto Curso
                    AlIns.Curso = new CursoAdapter().GetOne((int)drInscripciones["id_curso"]);
                    AlIns.Condicion = (string)drInscripciones["condicion"];
                    //Por si las notas no fueron cargadas
                    if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                    {
                        AlIns.Nota = 0;
                    }
                    else
                    {
                        AlIns.Nota = (int)drInscripciones["nota"];
                    }
                    Inscripciones.Add(AlIns);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Inscripciones;
        }


        public Inscripcion GetOne(int ID)
    {    
        Inscripcion AlIns = new Inscripcion();   
        try
        {
            OpenConnection();
            
            SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@idInscripcion", sqlConn);
            cmdInscripciones.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = ID;
            SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
            if (drInscripciones.Read())
            {
                AlIns.ID = (int)drInscripciones["id_inscripcion"];
                //Objeto Alumno
                AlIns.Alumno.ID = (int)drInscripciones["id_alumno"];
                //Objeto Curso
                AlIns.Curso.ID = (int)drInscripciones["id_curso"];
                AlIns.Condicion = (string)drInscripciones["condicion"];
                //Por si las notas no fueron cargadas
                if (String.IsNullOrEmpty(drInscripciones["nota"].ToString()))
                {
                    AlIns.Nota = 0;
                }
                else
                {
                    AlIns.Nota = (int)drInscripciones["nota"];
                }
            }
            drInscripciones.Close();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar datos de Comision", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            CloseConnection();
        }
        return AlIns;
    }

    public bool GetOne(Inscripcion insAlumno)
    {    
        Inscripcion AlIns = new Inscripcion();   
        try
        {
            OpenConnection();
            
            SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@idAlumno and id_curso=@idCurso", sqlConn);
            cmdInscripciones.Parameters.Add("@idAlumno", SqlDbType.Int).Value = insAlumno.Alumno.ID;
            cmdInscripciones.Parameters.Add("@idCurso", SqlDbType.Int).Value = insAlumno.Curso.ID;
            SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
            if(drInscripciones.HasRows)
                {
                    return true;
                }                  
            else
                {
                    return false;
                }                   
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            CloseConnection();
        }
    }

    public void Update(Inscripcion alumnoInscripcion)
    {
        try
        {
            OpenConnection();
            SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET nota = @notaAlumno,condicion=@condicion where id_alumno=@idAlumno and id_inscripcion=@idInscripcion", sqlConn);
            cmdSave.Parameters.Add("@notaAlumno", SqlDbType.Int).Value = alumnoInscripcion.Nota;
            cmdSave.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = alumnoInscripcion.ID;
            cmdSave.Parameters.Add("@idAlumno", SqlDbType.VarChar, 50).Value = alumnoInscripcion.IDAlumno;
            cmdSave.Parameters.Add("@condicion",SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
            cmdSave.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
        }
        finally
        {
            CloseConnection();
        }
    }
    public void Delete(Inscripcion alumnoInscripcion)
    {
        try
        {
            OpenConnection();
            SqlCommand cmdDelete = new SqlCommand("delete from alumnos_inscripciones where id_inscripcion=@idInscripcion", sqlConn);
            cmdDelete.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = alumnoInscripcion.ID;
            cmdDelete.ExecuteNonQuery();
        }
        catch (Exception Ex)
        {
            Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", Ex);
            throw ExcepcionManejada;
        }
        finally
        {
            CloseConnection();
        }
    }

    public void Insert(Inscripcion alumnoInscripcion)
    {
        try
        {
            OpenConnection();
            SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones (id_alumno,id_curso,condicion,nota)" +
            "values (@idAlumno,@idCurso,@condicion,@nota)" + "select @@identity", sqlConn);
            cmdSave.Parameters.Add("@idAlumno", SqlDbType.Int).Value = alumnoInscripcion.Alumno.ID;
            cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = alumnoInscripcion.Curso.ID;
            cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = alumnoInscripcion.Condicion;
            cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                //alumnoInscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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

    public void Save(Inscripcion alumnoInscripcion)
    {
        if (alumnoInscripcion.State == BusinessEntity.States.New)
        {
            Insert(alumnoInscripcion);
        }
        if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
        {
            Delete(alumnoInscripcion);
        }
        if (alumnoInscripcion.State == BusinessEntity.States.Modified)
        {
            Update(alumnoInscripcion);
        }
        alumnoInscripcion.State = BusinessEntity.States.Unmodified;
    }

}
}
