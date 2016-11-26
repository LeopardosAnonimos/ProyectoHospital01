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

            
             new clsPersona().crear("maria", "gutierrez", "la paz", "1702393783", "2038923", 'h', 18, fecha, "12345678");
             System.Console.ReadKey();
             

            clsPersona persona = new clsPersona();
            persona.buscar("1702393783");
            Console.WriteLine("El nombre es " + persona.getNombre());
            Console.ReadKey();

            persona.editar("nombre", "Lucrecia");
            Console.WriteLine("Nombre cambiado a " + persona.getNombre());
            Console.ReadKey();

            persona.borrar();
            Console.ReadKey();


        }
    }
}
