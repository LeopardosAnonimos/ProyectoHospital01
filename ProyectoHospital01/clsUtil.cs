using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsUtil
    {
        public int selec;



        public int LectorOpciones()
        {
            int opc = Console.Read();
            return opc;
        }

        /*public char LectorOpcionesC()
        {
            int aux;
            char opc;

            aux = Console.Read();

            opc = (char)aux;

            return opc;
        }*/

        public void MenuBienvenida()
        {
            Console.WriteLine("\tHOSPITAL VALLE CEREZO\n" + "Ingrese su numero de cedula...:");
            //Console.ReadLine
            Console.WriteLine();
        }


        public void MenuPaciente(/*clsPaciente p1.nombre + p1.apellido*/)
        {
            Console.WriteLine("Bienvenido" /*+ p1.nombre + p1.apellido*/ + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Consultar Recetas\n" +
                                "3. Consultar Pago\n" +
                                "4. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void MenuMedico(/*clsMedico m1*/)
        {
            Console.WriteLine("Bienvenido" /*+ m1.nombre + m1.apellido*/ + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Informacion Pacientes\n" +
                                "3. Consultar Rol de Pago\n" +
                                "4. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void MenuFuncionario(/*clsFuncionario f1*/)
        {
            Console.WriteLine("Bienvenido" /*+ f1.nombre + f1.apellido*/ + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Ingresar un nuevo Paciente\n" +
                                "2. Informacion(buscar) Paciente\n" +
                                "3. Ingresar un nuevo Medico\n" +
                                "4. Informacion(buscar) Medico\n" +
                                "5. Listar Habitaciones\n" +
                                "6. Listar Consultorios\n" +
                                "7. Listar Oficinas\n" +
                                "8. \n" +
                                "*. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void IngresarDatos(/*cls.......*/)
        {
            Console.WriteLine("Ingresa el nombre: \t");
            Console.ReadLine();
            Console.WriteLine("Ingresa el apellido: \t");

            Console.WriteLine("Ingresa la direccion: \t");

            Console.WriteLine("Ingresa el numero de cedula: \t");

            Console.WriteLine("Ingresa el genero (1. Masculino / 2. Femenino): \t");
            Console.WriteLine("Ingresa su rol (1. medico / 2. paciente / 3.funcionario): \t");

            
            

            /*
            do
            {
                selec = LectorOpciones();
                 if (selec == 1)
                    a.setSexo() = 'm'
                 if (selec == 2)
            } while (selec != (1 | 2));*/

            Console.WriteLine("Ingresa la fecha de nacimiento (aaaa/mm/dd): \t");

            Console.WriteLine("Ingresa el telefono: \t");
        }

    }
}
