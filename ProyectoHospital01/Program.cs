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


            clsUtil menus = new clsUtil();




            menus.MenuBienvenida();
            
            
            
            Console.WriteLine("Inserte Cedula");
            string id = Console.ReadLine();

            Console.WriteLine("Inserte Rol (medico|funcionario|paciente)");
            string rol = Console.ReadLine();

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
            clsMedico medico = new clsMedico(id, rol, nombre, apellido, "cardiologo", direccion, telefono, sexoChar, edadInt, fecha, pasword);
            //
            new clsListar().obtener("paciente");
            Console.ReadKey();

            new clsListar().obtener("medico");
            Console.ReadKey();
            
            medico.buscar(id);
            Console.WriteLine("El nombre es " + medico.getApellido());

            Console.WriteLine("Es medico? " + medico.tieneRol("medico"));
            Console.WriteLine("Es paciente? " + medico.tieneRol("paciente"));
            Console.WriteLine("Es funcionario? " + medico.tieneRol("funcionario"));
            Console.ReadKey();

            
            
            medico.editar("nombre", "Lucrecia");
            Console.WriteLine("Nombre cambiado a " + medico.getNombre());
            Console.ReadKey();

            /*
            persona.borrar();
            Console.ReadKey();
            */


        }
    }
}
