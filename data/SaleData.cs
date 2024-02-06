using Microsoft.Data.SqlClient;
using proyecto_tp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.data
{
    class SaleData
    {
        public static string connectionString = @"Server=localhost\SQLEXPRESS;Database=ferreteria_axel;Trusted_Connection=true;TrustServerCertificate=True";
        // Cadena de conexión a la db bd
        public static List<Sale> ListarSale()
        {
            List<Sale> productos = new List<Sale>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "select * from _sale";
                using (SqlCommand command = new SqlCommand(getAllQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Sale sale = new Sale();
                                sale._id = Convert.ToInt32(reader["id"]);
                                sale._comments = reader["comments"].ToString();
                                sale.iduser = Convert.ToInt32(reader["idUser"]);
                              

                                productos.Add(sale);

                            }
                        }

                    }
                }

                connection.Close();
                return productos;
            }

        }
        public static Sale ObtenerSale(int id)
        {
            Sale sale = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) //conexion a la base de datos
            {
                string getIdQuery = "select * from _sale where Id = @id"; //consulta 

                using (SqlCommand command = new SqlCommand(getIdQuery, connection))// comando de que quiero y donde hacerlo

                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "id";
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
                                sale = new Sale
                                {
                                    _id = Convert.ToInt32(reader["id"]),
                                    _comments = reader["comments"].ToString(),
                                    iduser = Convert.ToInt32(reader["idUser"]),
                                };

                            }
                        }

                    }
                }

                connection.Close();
                return sale; //devolvemos el usuariuo que encontro
            }
        }
        public static void CrearSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "insert into _sale (comments, idUser) " +
                                     "values (@comments, @idUser)";
                using SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@comments", sale._comments);
                command.Parameters.AddWithValue("@idUser", sale.iduser);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el sale. Filas afectadas: {rowsAffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el sale: {ex.Message}");
                }
                connection.Close();
            }
        }
        public static void ModificarProducto(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerSale(sale._id) != null)
                {
                    string updateQuery = "update _sale set comments = @comments, idUser = @idUser, " +                                                            
                              "where id = @id";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@comments", sale._comments);
                    command.Parameters.AddWithValue("@idUser", sale.iduser);
                    command.Parameters.AddWithValue("@id", sale._id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el sale. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el sale: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerSale(id) != null)
                {
                    string deleteQuery = "delete from _sale where Id = @Id";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente al sale. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar al sale: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
