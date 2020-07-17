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
    public class MateriaAdapter:Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> Materias = new List<Materia>();
            try
            {
                OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                    Materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return mat;
        }

        public void Update(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia=@desc_materia,hs_semanales=@hs_semanales,"+
                    "hs_totales=@hs_totales,id_plan=@id_plan WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete from materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar a la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into materias (desc_materia,hs_semanales,hs_totales,id_plan) " +
                "values (@desc_materia,@hs_semanales,@hs_totales,@id_plan) " + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}

