using System;
using System.Collections.Generic;
using System.Text;
using Academia.Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Academia.Util;

namespace Academia.Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        /*
        #region DatosEnMemoria
        
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Usuario>();
                    Usuario usr;
                    usr = new Usuario();
                    usr.ID = 1;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 2;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Usuario();
                    usr.ID = 3;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);
                }
                return _Usuarios;
            }
        }       
        #endregion
            */

        /// <summary>
        /// Devuelve una coleccion con todos los Usuarios de la BD
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAll()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //Datos de la persona 
                    if (!String.IsNullOrEmpty(drUsuarios["id_persona"].ToString()))
                    {
                        usr.Persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
                    }
                    Usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return Usuarios;
        }

        /// <summary>
        /// Devuelve un objeto Usuario especificado por el ID ingresado
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdUsuarios = new SqlCommand("BuscarUsuarioID", sqlConn);
                cmdUsuarios.CommandType = CommandType.StoredProcedure;*/
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios usu " +
                "inner join personas per on per.id_persona = usu.id_persona " +
                "where usu.id_usuario = @idUsuario", sqlConn);
                cmdUsuarios.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //Datos del objeto persona
                    usr.Persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
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
            return usr;
        }

        /// <summary>
        /// Metodo utilizado para buscar un usuario por su Nombre y Clave
        /// </summary>
        /// <param name="nomUsu"></param>
        /// <param name="claveUsu"></param>
        /// <returns></returns>
        public Usuario GetOne(string nomUsu, string claveUsu)
        {
            Usuario usr = new Usuario();
            //Se simplifica la inicializacion con las llaves
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdUsuarios = new SqlCommand("BuscarUsuario", sqlConn);
                cmdUsuarios.CommandType = CommandType.StoredProcedure;
                */
                SqlCommand cmdUsuarios = new SqlCommand("select usu.id_usuario,usu.habilitado,usu.nombre_usuario,usu.id_persona from usuarios usu " +
                "left join personas per on per.id_persona = usu.id_persona " +
                "where usu.nombre_usuario = @nombUsu and usu.clave = @claveUsu ", sqlConn);
                cmdUsuarios.Parameters.Add("@nombUsu", SqlDbType.VarChar, 50).Value = nomUsu;
                cmdUsuarios.Parameters.Add("@claveUsu", SqlDbType.VarChar, 50).Value = claveUsu;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    if (String.IsNullOrEmpty(drUsuarios["id_persona"].ToString()))
                    {
                        usr.Persona.Nombre = "Adminsitrador";
                        usr.Persona.TipoPersona = Persona.TiposPersonas.Admin;
                    }
                    else
                    {
                        usr.Persona = new PersonaAdapter().GetOne((int)drUsuarios["id_persona"]);
                    }
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al recuperar al usuario", Ex);
                throw Ex;
            }
            finally
            {
                CloseConnection();
            }
            return usr;
        }

        public void Update(Usuario usuario)
        {

            try
            {
                OpenConnection();
                /*
                SqlCommand cmdSave = new SqlCommand("ActualizarUsuario",sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombUsu, clave = @claveUsu, habilitado = @habilitadoUsu " +
                "WHERE id_usuario = @idUsu;", sqlConn);
                /*"Update personas set nombre = @nombrePer, apellido = @apellidoPer, tipo_persona = @tipoPersona, fecha_nac = @fechaNac, id_plan = @idPlan, direccion = @direccion, email = @email,telefono = @telefono "+
                "where id_persona = @idPer", sqlConn);*/
                //Usuario
                cmdSave.Parameters.Add("@nombUsu", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@claveUsu", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitadoUsu", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@idUsu", SqlDbType.Int).Value = usuario.ID;
                cmdSave.ExecuteNonQuery();
                //Persona
                new PersonaAdapter().Update(usuario.Persona);
                /*
                cmdSave.Parameters.Add("@idPer", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = usuario.Persona.IDPlan;
                cmdSave.Parameters.Add("@nombrePer", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@apellidoPer", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@tipoPersona", SqlDbType.Int).Value = usuario.Persona.TipoPersona;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = usuario.Persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = usuario.Persona.Telefono;
                cmdSave.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = usuario.Persona.FechaNacimiento;
                //cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = usuario.Persona.Legajo;*/
                //

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

        public void Delete(Usuario usu)
        {
            try
            {
                OpenConnection();
                /*
                SqlCommand cmdDelete = new SqlCommand("EliminarUsuario", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;*/
                SqlCommand cmdDelete = new SqlCommand("delete from usuarios where id_usuario = @idUsuario", sqlConn);
                cmdDelete.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usu.ID;
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

        public void Insert(Usuario usuario)
        {
            try
            {
                OpenConnection();
                //Persona
                var idPersona = new PersonaAdapter().Insert(usuario.Persona);
                /*
                SqlCommand cmdSave = new SqlCommand("InsertarUsuario", sqlConn);
                cmdSave.CommandType = CommandType.StoredProcedure;*/
                SqlCommand cmdSave = new SqlCommand("insert into usuarios(nombre_usuario, clave, habilitado, id_persona) " +
                "values(@nombUsu, @claveUsu, @habilitadoUsu, @idPersona); ", sqlConn);
                //Usuario
                cmdSave.Parameters.Add("@idPersona", SqlDbType.Int).Value = idPersona;
                cmdSave.Parameters.Add("@nombUsu", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@claveUsu", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitadoUsu", SqlDbType.Bit).Value = usuario.Habilitado;
                /*
                cmdSave.Parameters.Add("@nombrePer", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@apellidoPer", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = usuario.Persona.Telefono;
                cmdSave.Parameters.Add("@fechaNac", SqlDbType.DateTime).Value = usuario.Persona.FechaNacimiento;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = usuario.Persona.Direccion;
                //cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = usuario.Persona.Legajo;
                cmdSave.Parameters.Add("@tipoPersona", SqlDbType.Int).Value = usuario.Persona.TipoPersona;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = usuario.Persona.IDPlan;
                */
                cmdSave.ExecuteNonQuery();
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
        public void Save(Usuario usuario)
        {
            switch (usuario.State)
            {
                case BusinessEntity.States.New:
                    Insert(usuario);
                    break;
                case BusinessEntity.States.Modified:
                    Update(usuario);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(usuario);
                    break;
                default:
                    usuario.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }
}
