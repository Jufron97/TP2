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
    public class UsuarioAdapter:Adapter
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

        public List<Usuario> GetAll()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("ListadoGeneral", sqlConn);
                cmdUsuarios.CommandType=CommandType.StoredProcedure;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario()
                    {
                        Persona = new Persona()
                    };
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //Datos de la persona 
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
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

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario()
            { 
                Persona = new Persona() 
            };
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("BuscarUsuarioID", sqlConn);
                cmdUsuarios.CommandType = CommandType.StoredProcedure;
                cmdUsuarios.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //Datos del objeto persona
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
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

        public Usuario GetOne(string nomUsu, string claveUsu)
        {
            Usuario usr = new Usuario()
            {
                Persona = new Persona()
            };
            //Se simplifica la inicializacion con las llaves
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("BuscarUsuario", sqlConn);
                cmdUsuarios.CommandType = CommandType.StoredProcedure;
                cmdUsuarios.Parameters.Add("@nombUsu", SqlDbType.VarChar, 50).Value = nomUsu;
                cmdUsuarios.Parameters.Add("@claveUsu", SqlDbType.VarChar, 50).Value = claveUsu;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //Datos para el objeto Persona
                    //Esto es ya que el usuario admin no tiene un objeto persona ligado en si, y hay campos que tienen que ser
                    //No nulos, y traen problemas ocn las conversiones
                    //AHORA QUE PIENSO, SI HAY UN USUARIO DONDE LA PERSONA TIENE CAMPOS NULOS, VA A PASAR LO MISM OQUE ANTES
                    if (usr.NombreUsuario!="admin")
                    {
                        usr.Persona.ID = (int)drUsuarios["id_persona"];
                        usr.Persona.Nombre = (string)drUsuarios["nombre"];
                        usr.Persona.Apellido = (string)drUsuarios["apellido"];
                        usr.Persona.Direccion = (string)drUsuarios["direccion"];
                        usr.Persona.Email = (string)drUsuarios["email"];
                        usr.Persona.Telefono = (string)drUsuarios["telefono"];
                        usr.Persona.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                        usr.Persona.Legajo = (int)drUsuarios["legajo"];
                        usr.Persona.TipoPersona = (Persona.TiposPersonas)drUsuarios["tipo_persona"];
                        usr.Persona.IDPlan = (int)drUsuarios["id_Plan"];
                    }
                    else
                    {
                        //Se cargar los atributos que se necesitan para 
                        usr.Persona.Nombre = "Adminsitrador";
                        usr.Persona.TipoPersona = Persona.TiposPersonas.Admin;
                    }
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al recuperar al usuario", Ex);
                throw ExcepcionManejada;
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
                //ESTO SE RESUELVE CON SQLTRANSACTIONS, BUSCAR EN INTERNET
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario,clave=@clave," +
                "habilitado=@habilitado,nombre=@nombre,apellido=@apellido,email=@email WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
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
                CloseConnection();
            }
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("EliminarUsuario", sqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ID;
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
                //VER CLASE SQLTRANSACTION, PODRIAMOS APLICARLA PARA RESOLVER TODO ESTO
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into usuarios (nombre_usuario,clave,habilitado)"+
                "values (@nombre_usuario,@clave,@habilitado)"+
                "select @@identity",sqlConn); 
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //
                /* TODO ESTO SERIA EL OBJETO PERSONA QUE SE CREARIA CON EL USUARIO, HAY QUE MODIFICAR EL FORM PARA ESO
                cmdSave = new SqlCommand("insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                "values (@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = usuario.Persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = usuario.Persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.VarChar, 50).Value = usuario.Persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = usuario.Persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = usuario.Persona.IDPlan;
                usuario.Persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                */
            }
            catch (Exception Ex)
            {
                //ACA SE DEJARIA ASENTADO CUAL FUE EL TIPO DE ERROR EN EL LOG
                //new Log(Ex.Message);
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                Insert(usuario);
            }
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                Delete(usuario.ID);
            }
            if (usuario.State == BusinessEntity.States.Modified)
            {
                Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }       
    }
}
