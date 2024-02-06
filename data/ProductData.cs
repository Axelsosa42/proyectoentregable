using Microsoft.Data.SqlClient;
using proyecto_tp1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.data
{
    class ProductData
    {
        public static string connectionString = @"Server=localhost\SQLEXPRESS;Database=ferreteria_axel;Trusted_Connection=true;TrustServerCertificate=True";
        // Cadena de conexión a la db bd
        public static List<Product> ListarProductos()
        {
            List<Product> productos = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "select * from _product";
                using (SqlCommand command = new SqlCommand(getAllQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                Product producto = new Product();
                                producto.id = Convert.ToInt32(reader["id"]);
                                producto.description = reader["description"].ToString();
                                producto.price = Convert.ToInt32(reader["Price"]);
                                producto.salePrice = Convert.ToInt32(reader["SalePrice"]);
                                producto.stock = Convert.ToInt32(reader["Stock"]);
                                producto.idUser = Convert.ToInt32(reader["IdUser"]);

                                productos.Add(producto);

                            }
                        }

                    }
                }

                connection.Close();
                return productos;
            }

        }
        public static Product ObtenerProducto(int id)
        {
            Product producto = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) //conexion a la base de datos
            {
                string getIdQuery = "select * from _product where Id = @idProduct"; //consulta 

                using (SqlCommand command = new SqlCommand(getIdQuery, connection))// comando de que quiero y donde hacerlo

                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idProduct";
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
                                producto = new Product
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    description = reader["description"].ToString(),
                                    price = Convert.ToInt32(reader["Price"]),
                                    salePrice = Convert.ToInt32(reader["SalePrice"]),
                                    stock = Convert.ToInt32(reader["Stock"]),
                                    idUser = Convert.ToInt32(reader["IdUser"]),

                            };

                            }
                        }

                    }
                }

                connection.Close();
                return producto; //devolvemos el usuariuo que encontro
            }
        }
        public static void CrearProducto(Product producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "insert into _producto ( description, Price, SalePrice, Stock, IdUser) " +
                                     "values (@description, @Price, @SalePrice, @Stock, @IdUser)";
                using SqlCommand command = new SqlCommand(insertQuery, connection);
                
                command.Parameters.AddWithValue("@description", producto.description);
                command.Parameters.AddWithValue("@Price", producto.price);
                command.Parameters.AddWithValue("@SalePrice", producto.salePrice);
                command.Parameters.AddWithValue("@Stock", producto.stock);
                command.Parameters.AddWithValue("@IdUser", producto.idUser);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el Producto. Filas afectadas: {rowsAffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el Producto: {ex.Message}");
                }
                connection.Close();
            }
        }
        public static void ModificarProducto(Product producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerProducto(producto.id) != null)
                {
                    string updateQuery = "update _producto set description = @description, Price = @Price, " +
                              "SalePrice = @SalePrice, Stock = @Stock, " +
                              "IdUser = @IdUser " +
                              "where id = @id";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@id", producto.description);
                    command.Parameters.AddWithValue("@description", producto.description);
                    command.Parameters.AddWithValue("@Price", producto.price);
                    command.Parameters.AddWithValue("@SalePrice", producto.salePrice);
                    command.Parameters.AddWithValue("@Stock", producto.stock);
                    command.Parameters.AddWithValue("@IdUser", producto.idUser);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se modificó correctamente el producto. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al modificar el producto: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerProducto(id) != null)
                {
                    string deleteQuery = "delete from _producto where Id = @Idproducto";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@IdProducto", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente al producto. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar al producto: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
