using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoHospital01
{



    class clsListar
    {
        private static string pathPersonas = @"c:\hospital\personas";
        private static string pathPacientes = @"c:\hospital\pacientes";

        private static clsDatos datos;


        public static void obtener(string rol)
        {
            try
            {
                datos = new clsDatos();
                string[] dirs = Directory.GetDirectories(pathPersonas);
                string file = rol + ".txt";
                string path = String.Empty;
                int i = 0;
                
                foreach (string dir in dirs)
                {
                    path = dir + "\\" + file;

                    // Console.WriteLine(path);
                    if (System.IO.File.Exists(path))
                    {
                        string ci = datos.obtenerArchivo(dir + "\\cedula.txt");
                        string nombre = datos.obtenerArchivo(dir + "\\nombre.txt");

                        Console.WriteLine(ci + " - " + nombre);
                        i++;
                    }
                }

                Console.WriteLine("Existen " + i + " "+ rol +"s en el registro.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }


        public static void obtenerHistorias(string id )
        {
            string pathHistorias = pathPersonas + "\\" + id + "\\historia" ;

            try
            {
                datos = new clsDatos();
                string[] dirs = Directory.GetDirectories(pathHistorias);
                int i = 0;

                foreach (string dir in dirs)
                {
                   
                    string[] carpetas = dir.Split('\\');
                    Console.WriteLine(carpetas[5]);
                    i++;
                    
                }

                Console.WriteLine("Existen " + i +  " Historias Clinicas en el registro.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }


        public void obtenerDatosHistCl()
        {

        }
    }
    
    
}
