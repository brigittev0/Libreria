using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-RPPC58U\\SQLEXPRESS;Database=libreria_cf;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta los datos de la tabla "libros"
                string librosQuery = "SELECT * FROM libros";
                using (SqlCommand librosCommand = new SqlCommand(librosQuery, connection))
                {
                    SqlDataReader librosReader = librosCommand.ExecuteReader();
                    Console.WriteLine("Datos de la tabla 'libros':");
                    Console.WriteLine("=================================");
                    while (librosReader.Read())
                    {
                        int libroId = librosReader.GetInt32(0);
                        int autorId = librosReader.GetInt32(1);
                        string titulo = librosReader.GetString(2);
                        string descripcion = librosReader.GetString(3);
                        int paginas = librosReader.GetInt32(4);
                        DateTime fechaPublicacion = librosReader.GetDateTime(5);
                        DateTime fechaCreacion = librosReader.GetDateTime(6);

                        Console.WriteLine($"ID: {libroId}");
                        Console.WriteLine($"Autor ID: {autorId}");
                        Console.WriteLine($"Título: {titulo}");
                        Console.WriteLine($"Descripción: {descripcion}");
                        Console.WriteLine($"Páginas: {paginas}");
                        Console.WriteLine($"Fecha de Publicación: {fechaPublicacion}");
                        Console.WriteLine($"Fecha de Creación: {fechaCreacion}");
                        Console.WriteLine("=================================");
                    }
                    librosReader.Close();
                }

                // Consulta los datos de la tabla "autores"
                string autoresQuery = "SELECT * FROM autores";
                using (SqlCommand autoresCommand = new SqlCommand(autoresQuery, connection))
                {
                    SqlDataReader autoresReader = autoresCommand.ExecuteReader();
                    Console.WriteLine("Datos de la tabla 'autores':");
                    Console.WriteLine("=================================");
                    while (autoresReader.Read())
                    {
                        int autorId = autoresReader.GetInt32(0);
                        string nombre = autoresReader.GetString(1);
                        string apellido = autoresReader.GetString(2);
                        string seudonimo = autoresReader.IsDBNull(3) ? "" : autoresReader.GetString(3);
                        DateTime fechaNacimiento = autoresReader.GetDateTime(4);
                        string paisOrigen = autoresReader.GetString(5);
                        DateTime fechaCreacion = autoresReader.GetDateTime(6);

                        Console.WriteLine($"ID: {autorId}");
                        Console.WriteLine($"Nombre: {nombre}");
                        Console.WriteLine($"Apellido: {apellido}");
                        Console.WriteLine($"Seudónimo: {seudonimo}");
                        Console.WriteLine($"Fecha de Nacimiento: {fechaNacimiento}");
                        Console.WriteLine($"País de Origen: {paisOrigen}");
                        Console.WriteLine($"Fecha de Creación: {fechaCreacion}");
                        Console.WriteLine("=================================");
                    }
                    autoresReader.Close();
                }

                connection.Close();
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
