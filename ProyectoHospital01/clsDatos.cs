using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoHospital01
{
    class clsDatos
    {
        private string pathHospital =  @"c:\hospital";
        private string pathPersonas = @"c:\hospital\personas";
        private string pathPacientes = @"c:\hospital\pacientes";
        private string currentPath = String.Empty;

        public bool insertarPersona(string id, string rol, string name, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fecha)
        {
            // hospital\personas\{id}
            string path = pathPersona(id);
            string edadString = Convert.ToString(edad);
            string fechaString = Convert.ToString(fecha);
            string sexoString = Convert.ToString(sexo);

            if (existe(path))
            {
                Console.WriteLine("El ID de la persona ya existe " + id);
                Console.WriteLine("En la carpeta " + path);
                Console.ReadKey();
                return false;
            }

            // Crear nombre.txt;
            // Crear apellido.txt, etc..
            crearArchivo(id, "cedula", path);
            crearArchivo(name, "nombre", path);
            crearArchivo(apellido, "apellido", path);
            crearArchivo(direccion, "direccion", path);
            crearArchivo(telefono, "telefono", path);
            crearArchivo(sexoString, "sexo", path);
            crearArchivo(edadString, "edad", path);
            crearArchivo(fechaString, "fechNac", path);
            crearArchivo(String.Empty, rol, path);

            return true;

        }

        public bool actualizarPersona(string id, string campo, string contenido)
        {
            return insertarContendido(contenido, pathPersonaCampo(id, campo));
        }

        public string obtenerDatoPersona(string id, string campo)
        {
            return obtenerArchivo(pathPersonaCampo(id, campo));
            
        }

        public bool borrarPersona(string id)
        {
            if (id.Length > 0)
            {
                return borrarArchivo(pathPersona(id));
            }

            return false;

        }

        public bool existe(string id)
        {
            return System.IO.Directory.Exists(pathPersona(id));
        }

        public bool existeCampo(string id, string campo)
        {
            return System.IO.File.Exists(pathPersonaCampo(id, campo));
        }

        public string obtenerArchivo(string path)
        {
            // Read and display the data from your file.
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    // Console.WriteLine(line);
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return String.Empty;
            
        }

        private string pathPersona(string id)
        {
            return pathPersonas + "\\" + id;
        }

        private string pathPersonaCampo(string id, string campo)
        {
            return pathPersonas + "\\" + id + "\\" + campo + ".txt";
        }

        private void crearArchivo(string content, string filename, string path)
        {

            string pathString = path;

 
            System.IO.Directory.CreateDirectory(pathString);

            // Create a file name for the file you want to create. 
            string fileName = filename + ".txt";

            // Use Combine again to add the file name to the path.
            pathString = System.IO.Path.Combine(pathString, fileName);

            // Verify the path that you have constructed.
            Console.WriteLine("Ruta a crear: {0}\n", pathString);

       
            if (!System.IO.File.Exists(pathString))
            {
                insertarContendido(content, pathString);
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            Console.WriteLine("archivo creado {0}", filename);
            
        }

        private bool insertarContendido(string content, string path)
        {
            try
            {
                using (System.IO.FileStream fs = System.IO.File.Create(path))
                {
                    Byte[] contenido = new UTF8Encoding(true).GetBytes(content);

                    fs.Write(contenido, 0, contenido.Length);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido insertar el contenido en " + path);
                Console.WriteLine(e.Message);
            }
            return false;
        }

        private bool borrarArchivo(string path)
        {
            try
            {
                Directory.Delete(path, true);
                Console.WriteLine("Directorio borrado " + path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
            return false;
        }


    }
}
