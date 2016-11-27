                              using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime.MinValue;

            /*
             
            */
            

            
            Console.WriteLine("Inserte Cedula");
            string id = Console.ReadLine();

            Console.WriteLine("Inserte Nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Inserte Apellido");
            string apellido = Console.ReadLine();

            Console.WriteLine("Inserte Direccion");
            string direccion = Console.ReadLine();

            Console.WriteLine("Inserte Telefono");
            string telefono = Console.ReadLine();

            Console.WriteLine("Inserte sexo");
            string sexo = Console.ReadLine();

            Console.WriteLine("Inserte Edad");
            string edad = Console.ReadLine();

            Console.WriteLine("Inserte Contrasena");
            string pasword = Console.ReadLine();

            char sexoChar = Convert.ToChar(sexo);
            int edadInt = Convert.ToInt32(edad);
            clsMedico medico = new clsMedico(id, nombre, apellido, direccion, telefono, sexoChar, edadInt, fecha, pasword);

            medico.buscar(id);
            Console.WriteLine("El nombre es " + medico.getApellido());
            Console.ReadKey();










            /*
            persona.editar("nombre", "Lucrecia");
            Console.WriteLine("Nombre cambiado a " + persona.getNombre());
            Console.ReadKey();

            persona.borrar();
            Console.ReadKey();
            */


        }
    }
}
