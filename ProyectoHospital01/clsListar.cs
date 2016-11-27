using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoHospital01
{

    

    class clsListar:clsDatos
    {
        private string pathPersonas = @"c:\hospital\personas";
        private string pathPacientes = @"c:\hospital\pacientes";


        public void obtener(string rol)
        {
            try
            {
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
                        string ci = base.obtenerArchivo(dir + "\\cedula.txt");
                        string nombre = base.obtenerArchivo(dir + "\\nombre.txt");

                        Console.WriteLine(ci + " - " + nombre);
                        i++;
                    }
                }

                Console.WriteLine("Existen {0} "+ rol +"s en el registro.", i);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }

}
