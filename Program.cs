using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;


namespace dotnet
{
class Program
{
static void Main(string[] args)
{

try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = ""; //agregar servidor de base de datos
                builder.UserID = "";     //agregar nombre de usuario       
                builder.Password = "";   //agregar contraseña  
                builder.InitialCatalog = ""; //agregar nombre de base de datos
                builder.Encrypt=false;
            
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nRealizando una consulta:");
                    Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    String sql = "SELECT * FROM datos";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
            


}


}

}
