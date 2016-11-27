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

            }
            else
            {
                Console.WriteLine("El usuario no existe, desea crear uno nuevo? (1. SI || 2. NO || 3. SALIR)\n\t");
                    selec = LectorOpciones();
                if (selec == 1)
                {
                    Console.WriteLine("Seleccione una opcion:\n" +
                                        "1.MEDICO\n" +
                                        "2.PACIENTE\n" +
                                        "3.FUNCIONARIO\n\t=>");
                    do
                    {
                        selec = LectorOpciones();
                        switch (selec)
                        {
                            case 1:
                                {
                                    string rol = "medico";
                                    IngresarDatos();
                                    Console.WriteLine("Ingrese su especialidad");
                                    string especialidad = Console.ReadLine();

                                    clsMedico medico = new clsMedico(id, rol, nombre, apellido, especialidad, direccion, telefono, sexoChar, edadInt, fecha);
                                    medico.buscar(id);
                                    //F(x) guardar...
                                    MenuMedico(medico);

                                    break;
                                }

                            case 2:
                                {
                                    string rol = "paciente";
                                    IngresarDatos();
                                    
                                    clsPaciente paciente = new clsPaciente(id, rol, nombre, apellido, especialidad, direccion, telefono, sexoChar, edadInt, fecha);
                                    paciente.buscar(id);
                                    //F(x) guardar...
                                    MenuPaciente(paciente);

                                    break;
                                }

                            case 3:
                                {
                                    string rol = "funcionario";
                                    IngresarDatos();

                                    clsFuncionario funcionario = new clsFuncionario(id, rol, nombre, apellido, especialidad, direccion, telefono, sexoChar, edadInt, fecha);
                                    funcionario.buscar(id);
                                    //F(x) guardar...
                                    MenuFuncionario(funcionario);

                                    break;
                                }

                            case 4:
                                {
                                    default(/* algo de error */);
                                    break;
                                }
                        }
                    } while (selec != 4);
                            //IngresarDatos();
                            //Console.WriteLine("El usuario se ha ingresado correctamente..!");
                            //MenuBienvenida();// Reconocer que rol tiene el usuario y dejarlo en su menu 
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
                                "2. Consultar Concluciones Medicas\n" +
                                "3. Consultar Pago\n" +
                                "4. Salir al Menu Anterior\n\n\t=>");
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
                                "5. Salir\n\n\t=>");
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

            Console.WriteLine("Inserte sexo (m/f)");
            string sexo = Console.ReadLine();

            Console.WriteLine("Inserte Edad");
            string edad = Console.ReadLine();

            //Console.WriteLine("Inserte rol");
            //string rol = Console.ReadLine();

            Console.WriteLine("Ingrese su fecha de nacimiento[DD/MM/AAA]");
            string fechaNac=Console.ReadLine();

            DateTime fecha=DateTime.Parse(fechaNac);
            char sexoChar = Convert.ToChar(sexo);
            int edadInt = Convert.ToInt32(edad);
           
            Console.ReadKey();
        }



      /*  clsMedico medico = new clsMedico(id, rol, nombre, apellido, especialidad, direccion, telefono, sexoChar, edadInt, fecha);

        medico.buscar(id);
            Console.WriteLine("El nombre es " + medico.getApellido());
            */


    }
}
