using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                    paciente.buscar(id);//el momento de ingresar un nuevo tipo de persona permitir ingresar datos generales y luego según la opción elejida agregar datos del tipo escojido 

                    MenuPaciente(paciente);
                }
                else if (persona.tieneRol("medico"))
                {
                    clsMedico medico = new clsMedico();
                    medico.buscar(id);

                    MenuMedico(medico);
                }
                else if (persona.tieneRol("funcionario"))
                {
                    clsFuncionario funcionario = new clsFuncionario();
                    funcionario.buscar(id);

                    MenuFuncionario(funcionario);
                }

            }


            else
            {

                Console.WriteLine("El usuario no existe, desea crear uno nuevo? (1. SI || 2. NO || 3. SALIR)");

                selec = LectorOpciones();


                switch (selec)
                {
                    case 1:
                        
                            //DateTime fecha = new DateTime();
                            //persona.crear(id, "", "", "", "", "", ' ', 0, fecha);

                            Console.WriteLine("Seleccione una opción:\n" +
                            "1.MEDICO\n" +
                            "2.PACIENTE\n" +
                            "3.FUNCIONARIO\n\t==>");
                            do
                            {
                                selec = LectorOpciones();
                                switch (selec)
                                {
                                    case 1:
                                            string rol = "medico";
                                            IngresarDatos();
                                            Console.WriteLine("Ingrese su especialidad:\t\t");
                                            string especialidad = Console.ReadLine();
                                            DateTime fecha = new DateTime();

                                            clsMedico medico = new clsMedico(id, rol, "", "", especialidad, "", "", ' ', 0, fecha);
                                            medico.buscar(id);
                                            //F(x) guardar...
                                            MenuMedico(medico);

                                            break;
                                        
                                    case 2:
                                            string rol = "paciente";
                                            IngresarDatos();
                                            DateTime fecha = new DateTime();

                                            clsPaciente paciente = new clsPaciente(id, rol, "", "", "", "", ' ', 0, fecha);
                                            paciente.buscar(id);
                                            //F(x) guardar...
                                            MenuPaciente(paciente);

                                            break;
                                        

                                    case 3:
                                            string rol = "funcionario";
                                            IngresarDatos();
                                            DateTime fecha = new DateTime();

                                            clsFuncionario funcionario = new clsFuncionario(id, rol, "", "", "", "", "", ' ', 0, fecha, "");

                                            Console.WriteLine(funcionario.generarLetra() + funcionario.generarEstructura());
                                            funcionario.buscar(id);
                                            //F(x) guardar...
                                            MenuFuncionario(funcionario);

                                            break;
                                        
                                    case 4:
                                        Console.WriteLine("SI FUNCIONA EL SwITCH");
                                        break;

                                    default:
                                            Console.WriteLine("Opcion no valida!");
                                            break;
                                        
                                }

                            } while (selec != 4);

                            break;
                        


                    case 2:
                        MenuBienvenida();
                        break;
                    case 3:
                        Console.ReadKey();
                        break;

                    default:
                        break;

                }

            }
        }








        public void MenuPaciente(clsPaciente paciente)
        {
            Console.WriteLine("Bienvenido" + paciente.getNombre() + paciente.getApellido() + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Consultar Concluciones Medicas\n" +
                                "3. Consultar ..........\n" +
                                "4. Salir al Menu Anterior\n\n\t=>");
            do
            {
                selec = LectorOpciones();
                switch (selec)
                {
                    case 1:
                        {
                            //F(x) listar citas
                            break;
                        }
                    case 2:
                        {
                            //consultar HC.Concluciones
                            break;
                        }
                    case 3:
                        {
                            //consulta algo....
                            break;
                        }
                    case 4:
                        {
                            MenuBienvenida();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opcion no valida!");
                            break;
                        }
                }
            } while (selec != 4);
        }




        public void MenuMedico(clsMedico medico)
        {
            Console.WriteLine("Bienvenido" + medico.getNombre() + medico.getApellido() + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Informacion Pacientes\n" +
                                "3. Consultar Rol de Pago\n" +
                                "4. Salir\n\n\t=>");
            selec = LectorOpciones();


            do
            {
                selec = LectorOpciones();
                switch (selec)
                {
                    case 1:
                        {
                            //F(x) listar citas
                            break;
                        }
                    case 2:
                        {
                            //Informacion Pacientes
                            break;
                        }
                    case 3:
                        {
                            //consulta algo....
                            break;
                        }
                    case 4:
                        {
                            MenuBienvenida();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opcion no valida!");
                            break;
                        }
                }
            } while (selec != 4);
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

            do
            {
                selec = LectorOpciones();
                switch (selec)
                {
                    case 1:
                        {
                            //Ingresar un nuevo paciente
                            break;
                        }
                    case 2:
                        {
                            //Buscar un paciente
                            //FALTA HACER UN MENU DE EDICION DE HC DE PACIENTE....
                            break;
                        }
                    case 3:
                        {
                            //Ingresar un nuevo medico
                            break;
                        }
                    case 4:
                        {
                            //Buscar medico
                            break;
                        }
                    case 5:
                        {
                            MenuBienvenida();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opcion no valida!");
                            break;
                        }
                }
            } while (selec != 5);
        }







        public void IngresarDatos()
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
            string fechaNac = Console.ReadLine();

            DateTime fecha = DateTime.Parse(fechaNac);
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