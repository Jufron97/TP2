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
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan pl = new Plan();
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IDEspecialidad = (int)drPlanes["id_especialidad"];
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
                SqlCommand cmdPlanes = new SqlCommand("select * from Planes where id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IDEspecialidad = (int)drPlanes["id_especialidad"];
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
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan=@desc_plan,id_especialidad=@id_especialidad" +
                "WHERE id_plan=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
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
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete from planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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

        public void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan,id_especialidad)" +
                "values (@desc_plan,@id_especialidad)" +
                "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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
            if (plan.State == BusinessEntity.States.New)
            {
                Insert(plan);
            }
            if (plan.State == BusinessEntity.States.Deleted)
            {
                Delete(plan.ID);
            }
            if (plan.State == BusinessEntity.States.Modified)
            {
                Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }



    }
}
