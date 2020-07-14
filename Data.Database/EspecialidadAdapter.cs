using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data.Database;
using Academia.Business.Entities;

namespace Academia.Data.Database
{
    public class EspecialidadAdapter:Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> Especialidades = new List<Especialidad>();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];                
                    Especialidades.Add(esp);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad=@id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];          
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return esp;
        }

        public void Update(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc_especialidad WHERE id_especialidad=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete from especialidades where id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar a la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into especialidades (desc_especialidad) "+
                "values (@desc_especialidad) "+"select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;   
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}

