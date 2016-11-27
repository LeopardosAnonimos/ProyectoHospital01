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


        public void MenuBienvenida()
        {
            Console.WriteLine("\tHOSPITAL VALLE CEREZO\n" + "Ingrese su numero de cedula...:");
                    string id = Console.ReadLine();

            clsPersona persona = new clsPersona();
            if (persona.buscar(id))
            {
                if (persona.tieneRol("paciente"))
                {
                    clsPaciente paciente = new clsPaciente();
                    paciente.buscar(id);
                    
                    MenuPaciente(paciente);
                } else if (persona.tieneRol("medico"))
                {
                    clsMedico medico = new clsMedico();
                    medico.buscar(id);

                    MenuMedico(medico);
                } else if (persona.tieneRol("funcionario"))
                {
                    clsFuncionario funcionario = new clsFuncionario();
                    funcionario.buscar(id);

                    MenuFuncionario(funcionario);
                }

            }else
            {
                Console.WriteLine("El usuario no existe, desea crear uno nuevo? (1. SI || 2. NO || 3. SALIR)\n\t");
                    selec = LectorOpciones();
                if (selec == 1)
                {
                    IngresarDatos();
                    Console.WriteLine("El usuario se ha ingresado correctamente..!");
                    MenuBienvenida();
                }
                else if (selec == 2)
                    MenuBienvenida();
                else if (selec == 3)
                    Console.ReadKey();
            }
            Console.WriteLine();
        }


        public void MenuPaciente(clsPaciente paciente)
        {
            Console.WriteLine("Bienvenido" + paciente.getNombre() + paciente.getApellido() + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Consultar Recetas\n" +
                                "3. Consultar Pago\n" +
                                "4. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void MenuMedico(clsMedico medico)
        {
            Console.WriteLine("Bienvenido" + medico.getNombre() + medico.getApellido() + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Informacion Pacientes\n" +
                                "3. Consultar Rol de Pago\n" +
                                "4. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void MenuFuncionario(clsFuncionario funcionario)
        {
            Console.WriteLine("Bienvenido" + funcionario.getNombre() + funcionario.getApellido() + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Ingresar un nuevo Paciente\n" +
                                "2. Informacion(buscar) Paciente\n" +
                                "3. Ingresar un nuevo Medico\n" +
                                "4. Informacion(buscar) Medico\n" +
                                "5. Listar Habitaciones\n" +
                                "6. Listar Consultorios\n" +
                                "7. Listar Oficinas\n" +
                                "8. Salir\n\n\t=>");
            selec = LectorOpciones();
        }


        public void IngresarDatos(/*cls.......*/)
        {
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


            char sexoChar = Convert.ToChar(sexo);
            int edadInt = Convert.ToInt32(edad);
            clsMedico medico = new clsMedico(id, rol, nombre, apellido,direccion, telefono, sexoChar, edadInt);
            //String id, String rol, String nombre, String apellido, String especialidad, String direccion, String telefono, char sexo, int edad, DateTime fechNa    



            medico.buscar(id);
            Console.WriteLine("El nombre es " + medico.getApellido());
            Console.ReadKey();
        }

    }
}
