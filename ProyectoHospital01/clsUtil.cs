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
        private DateTime fecha = new DateTime();


        public int LectorOpciones()
        {
            String abc = Console.ReadLine();
            int opc = Convert.ToInt16(abc);
            return opc;
        }


        public void MenuBienvenida()
        {
            Console.WriteLine("\tHOSPITAL VALLE CEREZO\n" + "Presione:\n" + 
                                "1.Ingresar al sisema \n" +
                                "2.Para Salir\n");


            selec = LectorOpciones();


            Console.Clear();
            do
            {
                if (selec == 1)
                {
                    Console.WriteLine("\nIngrese su numero de cedula...");

                    string id = Console.ReadLine();
                    clsPersona persona = new clsPersona();
                    Console.Clear();

                    if (persona.buscar(id))
                    {
                        if (persona.tieneRol("paciente"))
                        {
                            clsPaciente paciente = new clsPaciente();
                            paciente.buscar(id);

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
                    else if (!persona.buscar(id))
                    {

                        Console.WriteLine("El usuario no existe, desea crear uno nuevo? (1. SI || 2. NO || 3. SALIR)");

                        selec = LectorOpciones();


                        switch (selec)
                        {
                            case 1:

                                Console.WriteLine("Seleccione una opción:\n" +
                                "1.MEDICO\n" +
                                "2.PACIENTE\n" +
                                "3.FUNCIONARIO\n\t==>");
                                do
                                {
                                    selec = LectorOpciones();
                                    if (selec == 1 || selec == 2 || selec == 3)
                                    {
                                        IngresarDatos(selec);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion no valida");
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

                else if (selec == 2)
                {
                    Console.WriteLine("\n\n\tFIN");
                    { }
                    System.Console.Out.Close();
                }

            } while (selec != 2);

                
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
                
                switch (selec)
                {
                    case 1:
                        {
                            //F(x) listar citas
                            break;
                        }
                    case 2:
                        {
                            clsListar.obtener("paciente");
                            MenuElegirPaciente();
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


       public void MenuElegirPaciente()
        {
            Console.WriteLine("Ingrese el numero de cedula del paciente al que desee acceder");
            string id = Console.ReadLine();
            clsListar.obtenerHistorias(id);
            MenuElegirHistoria();
            Console.ReadKey();

        }

        public void MenuElegirHistoria()
        {
            Console.WriteLine("Ingrese el numero de historia clinica al que desee acceder");
            string historia = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del campo que desee modificar: 1 Estatura || 2 Peso || 3 Concluciones Medicas || 4 Diagnostico || 5 Obsevaciones Generales || 6 Sintomas || 7 Temperatura ");

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

              
                switch (selec)
                {
                    case 1:
                        {
                            Console.WriteLine("A continucaion ingrese los datos del nuevo Paciente");
                            IngresarDatos(2);
                            break;
                        }
                    case 2:
                        {
                            
                            clsListar.obtener("paciente");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("A continucaion ingrese los datos del nuevo Medico");
                            IngresarDatos(1);
                            break;
                        }
                    case 4:
                        {
                            clsListar.obtener("medico");
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







        public void IngresarDatos(int selec)
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

            Console.WriteLine("Ingrese su fecha de nacimiento[DD/MM/AAAA]");
            string fechaNac = Console.ReadLine();

            DateTime fecha = DateTime.Parse(fechaNac);
            char sexoChar = Convert.ToChar(sexo);
            int edadInt = Convert.ToInt32(edad);

            switch (selec)
            {
                case 1:
                    string rol = "medico";
                    Console.WriteLine("Ingrese su especialidad");
                    string especialidad = Console.ReadLine();
                    clsMedico medico = new clsMedico(id, rol, nombre, apellido, especialidad, direccion, telefono, sexoChar, edadInt, fecha);
                    MenuMedico(medico);
                    break;

                case 2:
                    rol = "paciente";                    
                    clsPaciente paciente = new clsPaciente(id, rol, nombre, apellido, direccion, telefono, sexoChar, edadInt, fecha);
                    MenuPaciente(paciente);
                    break;

                case 3:
                    rol = "funcionario";
                    string oficina = "";
                    clsFuncionario funcionario = new clsFuncionario( id, rol, nombre, apellido, direccion, telefono, sexoChar, edadInt, fecha, oficina);
                    MenuFuncionario(funcionario);
                    break;
                
                        
            }
            
            Console.ReadKey();
        }



      


    }
}