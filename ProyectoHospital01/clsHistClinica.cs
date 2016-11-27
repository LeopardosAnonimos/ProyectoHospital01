using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoHospital01
{
    class clsHistClinica
    {
        clsPaciente paciente = new clsPaciente();
        private string no_HistCl;
        private string obsGenerales { get; set; }
        private string sintomas { get; set; }
        private decimal peso { get; set; }
        private decimal temperatura { get; set; }
        private decimal altura { get; set; }
        private string diagnostico { get; set; }
        private string concluMedicas;

        public string No_HistCl
        {
            get
            {
                return no_HistCl;
            }

            set
            {
                no_HistCl = value;
            }
        }

        public string ConcluMedicas
        {
            get
            {
                return concluMedicas;
            }

            set
            {
                concluMedicas = value;
            }
        }

        private string pathHistClinica = @"c:\hospital\personas\paciente\histClinica";//editado ...para acceder a los datos de hist clinica
        private string pathPersonas = @"c:\hospital\personas";
        private string currentPath = String.Empty;


        public bool insertarHistClinica(string no_Histcl, string obsGenerales, string sintomas, decimal peso, decimal temperatura, decimal altura, string diagnostico, string concluMedicas)
        {

            string path = pathHistClinica + "\\" + no_Histcl;
            string pesoString = Convert.ToString(peso);
            string temperaturaString = Convert.ToString(temperatura);
            string alturaString = Convert.ToString(altura);

            if (System.IO.File.Exists(path))
            {
                Console.WriteLine("La historia clinica ya existe " + no_Histcl);
                Console.WriteLine("En la carpeta " + path);
                Console.ReadKey();
                return false;
            }

            // Crear nombre.txt;
            // Crear apellido.txt, etc..
            crearArchivo(no_Histcl, "#HistoriaClinica", path);
            crearArchivo(obsGenerales, "Observaciones Generales", path);
            crearArchivo(sintomas, "Sintomas", path);
            crearArchivo(pesoString, "Peso", path);
            crearArchivo(temperaturaString, "Temperatura", path);
            crearArchivo(alturaString, "Altura", path);
            crearArchivo(diagnostico, "Diagnostico", path);
            crearArchivo(concluMedicas, "Concluciones Medicas", path);


            return true;
        }

             public bool actualizarHistClinica(string no_HistCl, string campo, string contenido)
        {
            return insertarContendido(contenido, pathPersonaCampo(no_HistCl, campo));
        }

        public string obtenerDatoHistClinica(string no_HistCl, string campo)
        {
            return obtenerArchivo(pathPersonaCampo(no_HistCl, campo));

        }

        public bool borrarHistClinica(string no_HistCl)
        {
            if (no_HistCl.Length > 0)
            {
                return borrarHistClinica(pathHistClinica(no_HistCl));
            }

            return false;

        }

        public bool existe(string no_HistClinica)
        {
            return System.IO.File.Exists(pathPersona(no_HistClinica));
        }

        public bool existeCampo(string no_HistClinica, string campo)
        {
            return System.IO.File.Exists(pathPersonaCampo(no_HistClinica, campo));
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
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
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





 
   /* public string Parse()
    {
        
        string conclu = h.ConcluMedicas;
        return conclu;
            
       }*/





    //public clsHistClinica()
    //{
    //    no_HistCl = "";
    //    obsGenerales = "";
    //    sintomas = "";
    //    peso = 0;
    //    temperatura = 0;
    //    altura = 0;
    //    diagnostico = "";
    //    concluMedicas = "";

    //}
}