using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Business.Entities;
using Academia.Data.Database;

namespace Academia.Data.Database
{
    public class PlanAdapter:Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> Planes = new List<Plan>();
            try
            {
                OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);
                /*
                SqlCommand cmdPlanes = new SqlCommand("ListadoGeneralPlanes", sqlConn);
                cmdPlanes.CommandType = CommandType.StoredProcedure;*/
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pl = new Plan();
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    //Datos de especialidad
                    pl.Especialidad = new EspecialidadAdapter().GetOne((int)drPlanes["id_especialidad"]);
                    Planes.Add(pl);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Planes;
        }

        public Plan GetOne(int ID)
        {
            Plan pl = new Plan();
            try
            {
                OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@idPlan", sqlConn);
                /*SqlCommand cmdPlanes = new SqlCommand("BuscarPlanID", sqlConn);
                cmdPlanes.CommandType = CommandType.StoredProcedure;*/
                cmdPlanes.Parameters.Add("@idPlan", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    //Datos de especialidad
                    pl.Especialidad = new EspecialidadAdapter().GetOne((int)drPlanes["id_especialidad"]);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return pl;
        }

        public void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdSave = new SqlCommand("ActualizarPlan", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @descPlan, id_especialidad = @idEspecialidad "+
                "WHERE id_plan = @idPlan ", sqlConn) ;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@DescPlan", SqlDbType.VarChar, 50).Value = plan.Descripcion;    
                cmdSave.Parameters.Add("@idEspecialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Elimina el plan especificado por el ID
        /// </summary>
        /// <param name="plan"></param>
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdDelete = new SqlCommand("EliminarPlan", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;*/             
                SqlCommand cmdDelete = new SqlCommand("delete from planes where id_plan = @idPlan", sqlConn);
                cmdDelete.Parameters.Add("@idPlan", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Inserta los datos del objeto Plan en la BD
        /// </summary>
        /// <param name="plan"></param>
        public void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdSave = new SqlCommand("InsertarPlan", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                
                SqlCommand cmdSave = new SqlCommand("insert into planes(desc_plan, id_especialidad) "+
                "values(@descPlan, @idEspecialidad)", sqlConn);
                cmdSave.Parameters.Add("@descPlan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@idEspecialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                //Hay que ver si se nos solicita el ID del plan que se crea
                //plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            switch (plan.State)
            {
                case BusinessEntity.States.New:
                    Insert(plan);
                    break;
                case BusinessEntity.States.Modified:
                    Update(plan);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(plan.ID);
                    break;
                default:
                    plan.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }
}
