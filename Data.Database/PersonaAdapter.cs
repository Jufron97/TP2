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
    public class PersonaAdapter: Adapter
    {

        /// <summary>
        /// Devuelve todos los datos de las personas de la Base de Datos
        /// </summary>
        /// <returns></returns>
        public List<Persona> GetAll()
        {
            List<Persona> Personas = new List<Persona>();
            try
            {
                OpenConnection();
                
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                //cmdPersonas.CommandType = CommandType.StoredProcedure;
                SqlDataReader drUsuarios = cmdPersonas.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Persona per = new Persona();
                    per.ID=(int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)drUsuarios["tipo_persona"];
                    per.Plan= new PlanAdapter().GetOne((int)drUsuarios["id_plan"]);
                    //Asi se verifica si son nulos o no los datos
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Direccion = "No posee";
                    }
                    else
                    {
                        per.Direccion = (string)drUsuarios["direccion"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Email = "No posee";
                    }
                    else
                    {
                        per.Email = (string)drUsuarios["email"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Telefono = "No posee";
                    }
                    else
                    {
                        per.Telefono = (string)drUsuarios["telefono"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drUsuarios["legajo"];
                    }
                    Personas.Add(per);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw Ex;
            }
            finally
            {
                CloseConnection();
            }
            return Personas;
        }

        /// <summary>
        /// Devuelve los datos de la persona con el ID especificado de la Base de Datos
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@idPersona", sqlConn);
                /*
                SqlCommand cmdPersonas = new SqlCommand("BuscarPersnaID", sqlConn);
                cmdPersonas.CommandType = CommandType.StoredProcedure;*/
                cmdPersonas.Parameters.Add("@idPersona", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdPersonas.ExecuteReader();
                if (drUsuarios.Read())
                {
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.TipoPersona = (Persona.TiposPersonas)drUsuarios["tipo_persona"];
                    per.Plan = new PlanAdapter().GetOne((int)drUsuarios["id_plan"]);
                    //Asi se verifica si son nulos o no los datos
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Direccion = "No posee";
                    }
                    else
                    {
                        per.Direccion = (string)drUsuarios["direccion"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Email = "No posee";
                    }
                    else
                    {
                        per.Email = (string)drUsuarios["email"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Telefono = "No posee";
                    }
                    else
                    {
                        per.Telefono = (string)drUsuarios["telefono"];
                    }
                    if (String.IsNullOrEmpty(drUsuarios["legajo"].ToString()))
                    {
                        per.Legajo = 0;
                    }
                    else
                    {
                        per.Legajo = (int)drUsuarios["legajo"];
                    }
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return per;
        }


        /// <summary>
        /// Actuzaliza los datos de la persona especificada por el ID en la Base de Datos
        /// /// </summary>
        /// <param name="persona"></param>
        public void Update(Persona persona)
        {
            
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Update personas set nombre=@nombrePer,apellido=@apellidoPer,email=@email,"+
                    "telefono=@telefono,fecha_nac=@fehcaNac,legajo=@legajo,tipo_persona=@tipoPersona,id_plan=@idPlan",sqlConn);
                /*
                SqlCommand cmdSave = new SqlCommand("ActualizarPersona", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                cmdSave.Parameters.Add("@nombrePer", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellidoPer", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipoPersona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = persona.IDPlan;
                //Aca queda pendiente con respecto a los datos de la persona, hay que discutirlo
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //sqlTran.Commit();
                CloseConnection();
            }
        }

        /// <summary>
        /// Se elimina a la persona especificada por el ID en la Base de Datos
        /// </summary>
        /// <param name="persona"></param>
        public void Delete(Persona persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("EliminarUsuario", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@idUsuario", SqlDbType.Int).Value = persona.ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al eliminar al usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Se inserta a la persona en la Base de Datos
        /// </summary>
        /// <param name="persona"></param>
        public void Insert(Persona persona)
        {
            
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)"+
                    "values (@nombrePer,apellidoPer,@direccion,@email,@telefono,@fechaNac,@legajo,@tipoPersona,@idPlan)",sqlConn);
                /*
                SqlCommand cmdSave = new SqlCommand("InsertarPersona", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                //Datos del objeto persona
                cmdSave.Parameters.Add("@nombrePer", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellidoPer", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipoPersona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = persona.IDPlan;
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw Ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Segun el tipo de operacion, se crea/actualiza/elimina a la persona
        /// </summary>
        /// <param name="persona"></param>
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                Delete(persona);
            }
            if (persona.State == BusinessEntity.States.Modified)
            {
                Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
