﻿using System;
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

        public bool insertarPersona(string id, string name, string apellido, string direccion, string telefono, char sexo, int edad, string password, DateTime fecha)
        {
            // hospital\personas\{id}
            string path = pathPersonas + "\\" + id;
            string edadString = Convert.ToString(edad);
            string fechaString = Convert.ToString(fecha);
            string sexoString = Convert.ToString(sexo);

            if (System.IO.File.Exists(path))
            {
                Console.WriteLine("El ID de la persona ya existe " + id);
                Console.WriteLine("En la carpeta " + path);
                Console.ReadKey();
                return false;
            }

            // Crear nombre.txt;
            // Crear apellido.txt, etc..
            crearArchivo(name, "nombre", path);
            crearArchivo(apellido, "apellido", path);
            crearArchivo(direccion, "direccion", path);
            crearArchivo(telefono, "telefono", path);
            crearArchivo(sexoString, "sexo", path);
            crearArchivo(edadString, "edad", path);
            crearArchivo(password, "password", path);
            crearArchivo(fechaString, "fecha", path);

            return true;

        }

        public bool actualizarPersona(string id, string campo, string contenido)
        {
            string path = pathPersonas + "\\" + id + "\\" + campo + ".txt";

            return insertarContendido(contenido, path);
        }
        public string obtenerDatoPersona(string id, string campo)
        {
            string path = pathPersonas + "\\" + id + "\\" + campo + ".txt";
            // Console.WriteLine(path);

            return obtenerArchivo(path);
            
        }

        public bool borrarPersona(string id)
        {
            if (id.Length > 0)
            {
                string path = pathPersonas + "\\" + id;
                return borrarArchivo(path);
            }

            return false;

        }

        private void crearArchivo(string content, string filename, string path)
        {
            // System.Console.ReadKey();

            // To create a string that specifies the path to a subfolder under your 
            // top-level folder, add a name for the subfolder to folderName.
            string pathString = path;

            // You can extend the depth of your path if you want to.
            //pathString = System.IO.Path.Combine(pathString, "SubSubFolder");

            // Create the subfolder. You can verify in File Explorer that you have this
            // structure in the C: drive.
            //    Local Disk (C:)
            //        Top-Level Folder
            //            SubFolder
            System.IO.Directory.CreateDirectory(pathString);

            // Create a file name for the file you want to create. 
            string fileName = filename + ".txt";

            // Use Combine again to add the file name to the path.
            pathString = System.IO.Path.Combine(pathString, fileName);

            // Verify the path that you have constructed.
            Console.WriteLine("Ruta a crear: {0}\n", pathString);

            // Check that the file doesn't already exist. If it doesn't exist, create
            // the file and write integers 0 - 99 to it.
            // DANGER: System.IO.File.Create will overwrite the file if it already exists.
            // This could happen even with random file names, although it is unlikely.
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

        private string obtenerArchivo(string path)
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
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
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
