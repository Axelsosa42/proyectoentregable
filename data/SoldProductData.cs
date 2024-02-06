using Microsoft.Data.SqlClient;
using proyecto_tp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tp1.data
{
     class SoldProductData
    {
        public static string connectionString = @"Server=localhost\SQLEXPRESS;Database=ferreteria_axel;Trusted_Connection=true;TrustServerCertificate=True";
        public static List<SoldProduct> ListarSoldProduct()
        {
            List<SoldProduct> listProductSale = new List<SoldProduct>(); // tambien se puede usar  List<User>? listProductSale = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getAllQuery = "select * from _soldproduct";
                using (SqlCommand command = new SqlCommand(getAllQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                SoldProduct soldProduct = new SoldProduct();
                                soldProduct._id = Convert.ToInt32(reader["id"]);
                                soldProduct._idproduct = Convert.ToInt32(reader["idproduct"]);
                                soldProduct._stock = Convert.ToInt32(reader["stock"]);
                                soldProduct._idSale = Convert.ToInt32(reader["idsale"]);
                                

                                listProductSale.Add(soldProduct);

                            }
                        }

                    }
                }

                connection.Close();
                return listProductSale;
            }

        }
        public static SoldProduct ObtenerSoldProduct(int id)
        {
            SoldProduct soldProduct = null;// instanciacion de un obejeto aparti de la clase user (instaciacion = crear)

            using (SqlConnection connection = new SqlConnection(connectionString)) //conexion a la base de datos
            {
                string getIdQuery = "select * from _soldproduct where Id = @idSoldProduct"; //consulta 

                using (SqlCommand command = new SqlCommand(getIdQuery, connection))// comando de que quiero y donde hacerlo

                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idSoldProduct";
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
                                soldProduct = new SoldProduct
                                {
                                    _id = Convert.ToInt32(reader["id"]),
                                    _idproduct = Convert.ToInt32(reader["idproduct"]),
                                    _stock = Convert.ToInt32(reader["stock"]),
                                    _idSale = Convert.ToInt32(reader["idsale"]),
                                };

                            }
                        }

                    }
                }

                connection.Close();
                return soldProduct;
            }
        }
        public static void CrearUsuario(SoldProduct soldProduct)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "insert into _soldproduct (idproduct, stock, idsale) " +
                                     "values (@idproduct, @stock, @idsale, @Password, @Mail, @InfusionFavorita)";
                using SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@idproduct", soldProduct._idproduct);
                command.Parameters.AddWithValue("@stock", soldProduct._stock);
                command.Parameters.AddWithValue("@idsale", soldProduct._idSale);                

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Se insertó correctamente el soldProduct. Filas afectadas: {rowsAffected}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar el soldProduct: {ex.Message}");
                }
                connection.Close();
            }
        }
        public static void ModificarUsuario(SoldProduct soldProduct)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (ObtenerSoldProduct(soldProduct._id) != null)
                {
                    string updateQuery = "update _soldproduct set idproduct = @idproduct, stock = @stock, " +
                              "idsale = @idsale " +                              
                              "where id = @id";
                    using SqlCommand command = new SqlCommand(updateQuery, connection);

                    command.Parameters.AddWithValue("@idproduct", soldProduct._idproduct);
                    command.Parameters.AddWithValue("@stock", soldProduct._stock);
                    command.Parameters.AddWithValue("@idsale", soldProduct._idSale);
                    command.Parameters.AddWithValue("@id", soldProduct._id);


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
                if (ObtenerSoldProduct(id) != null)
                {
                    string deleteQuery = "delete from _soldproduct where Id = @Id";
                    using SqlCommand command = new SqlCommand(deleteQuery, connection);

                    command.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminó correctamente al soldProduct. Filas afectadas: {rowsAffected}");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error al eliminar al soldProduct: {ex.Message}");
                    }
                    connection.Close();
                }
            }
        }
    }
}
