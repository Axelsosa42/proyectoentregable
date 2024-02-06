using Microsoft.Data.SqlClient;
using proyecto_tp1.models;

namespace proyecto_tp1.data
{
    class UserData
    {
        public static string connectionString = @"Server=localhost\SQLEXPRESS;Database=ferreteria_axel;Trusted_Connection=true;TrustServerCertificate=True";
        // Cadena de conexión a la db bd
        public static List<User> GetUsers()
        {
            List<User> listUsers = new List<User>(); // tambien se puede usar  List<User>? listUsers = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "select * from _user";
                using (SqlCommand command = new SqlCommand(getAllQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                User usuario = new User();
                                usuario.id = Convert.ToInt32(reader["id"]);
                                usuario.Name = reader["Name"].ToString();
                                usuario.lastName = reader["lastName"].ToString();
                                usuario.password = reader["password"].ToString();
                                usuario.email = reader["email"].ToString();
                                usuario.username = reader["username"].ToString();

                                listUsers.Add(usuario);

                            }
                        }

                    }
                }

                connection.Close();
                return listUsers;
            }

        }
        public static User ObtenerUsuario(int id)
        {
            User user = null;// instanciacion de un obejeto aparti de la clase user (instaciacion = crear)

            using (SqlConnection connection = new SqlConnection(connectionString)) //conexion a la base de datos
            {
                string getIdQuery = "select * from _User where Id = @idUser"; //consulta 

                using (SqlCommand command = new SqlCommand(getIdQuery, connection))// comando de que quiero y donde hacerlo

                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUser";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = id;

                    command.Parameters.Add(parametro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())// se ejecuta la query en la base de datos
                    {
                        if (reader.HasRows)// pregunta si tiene filas , si la consulta arrojo algun resultado
                        {

                            while (reader.Read())// reader contiene la informacion que se obtuvo de la base de datos .read (leer lo que esta dentro)
                            {
                                user = new User
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    Name = reader["Name"].ToString(),
                                    lastName = reader["lastName"].ToString(),
                                    username = reader["Username"].ToString(),
                                    password = reader["Password"].ToString(),
                                    email = reader["email"].ToString(),

                                };

                            }
                        }

                    }
                }

                connection.Close();
                return user; //devolvemos el usuariuo que encontro
            }
        }
        public static void CrearUsuario(User usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "insert into _User (Name, lastName, Nickname, Password, Mail, InfusionFavorita) " +
                                     "values (@Nombre, @Apellido, @Nickname, @Password, @Mail, @InfusionFavorita)";
                using SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@Nombre", usuario.id);
                command.Parameters.AddWithValue("@Nombre", usuario.Name);
                command.Parameters.AddWithValue("@Apellido", usuario.lastName);
                command.Parameters.AddWithValue("@Nickname", usuario.password);
                command.Parameters.AddWithValue("@Password", usuario.email);
                command.Parameters.AddWithValue("@Mail", usuario.username);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el usuario. Filas afectadas: {rowsAffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el usuario: {ex.Message}");
                }
                connection.Close();
            }
        }
        public static void ModificarUsuario(User usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerUsuario(usuario.id) != null)
                {
                    string updateQuery = "update _user set Name = @NuevoNombre, lastName = @NuevoApellido, " +
                              "Username = @NuevoNickname, password = @NuevaPassword, " +
                              "email = @NuevoMail " +
                              "where id = @IdUsuario";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@IdUsuario", usuario.id);
                    command.Parameters.AddWithValue("@NuevoNombre", usuario.Name);
                    command.Parameters.AddWithValue("@NuevoApellido", usuario.lastName);
                    command.Parameters.AddWithValue("@NuevoNickname", usuario.username);
                    command.Parameters.AddWithValue("@NuevaPassword", usuario.password);
                    command.Parameters.AddWithValue("@NuevoMail", usuario.email);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el usuario. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el usuario: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerUsuario(id) != null)
                {
                    string deleteQuery = "delete from _user where Id = @IdUsuario";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdUsuario", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente al usuario. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar al usuario: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}