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
            if(abc.Length > 0)
            {
                int opc = Convert.ToInt16(abc);
                return opc;
            }

            Console.WriteLine("Se ha ingresado un valor no valido: " + abc + ".");
            return 0;
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
            string nombreUp = paciente.getNombre().ToUpper();
            string apellidoUp = paciente.getApellido().ToUpper();
            Console.WriteLine("Bienvenido " + nombreUp + " "+ apellidoUp + " \nSelecciona una opcion:\n");

            Console.WriteLine("1. Listar Citas\n" +
                                "2. Consultar Historia Clinica\n" +
                                "3. Consulta algo...\n" +
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
                            MenuPacienteConsultarHistoria(paciente.getId());
                            break;
                        }
                    case 3:
                        {
                            //////
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

       
        public void MenuPacienteConsultarHistoria( string id)
        {
            Console.WriteLine("Sus hisorias clinicas son: ");
            clsListar.obtenerHistorias(id);
            clsHistClinica historia = new clsHistClinica();
            Console.WriteLine("Ingrese el numero de historia clinica al que desee acceder");
            string no_HistCl = Console.ReadLine();
            historia.buscar(id, no_HistCl);
            Console.WriteLine("En la historia clinica numero: " + historia.getNo_HistCl() + " existen los siguientes registros: ");
            Console.WriteLine("La altura es: " + historia.getAltura());
            Console.WriteLine("El peso es: " + historia.getPeso());
            Console.WriteLine("Las concluciones medicas son:" + historia.getConcluMedicas());
            Console.WriteLine("El diagnostico es: " + historia.getDiagnostico());
            Console.WriteLine("Las observaciones generales son: " + historia.getObsGenerales());
            Console.WriteLine("Los sintomas son: " + historia.getSintomas());
            Console.WriteLine("La temperatura fue: " + historia.getTemperatura());


        }


        public void MenuMedico(clsMedico medico)
        {
            string nombreUp = medico.getNombre().ToUpper();
            string apellidoUp = medico.getApellido().ToUpper();
            Console.WriteLine("Bienvenido " + nombreUp + " " + apellidoUp + " \nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Informacion Pacientes\n" +
                                "3. Crear nueva historia clinica\n" +
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
                            MenuInsertarHistoria();
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
                MenuElegirHistoria(id);
                Console.ReadKey();
                                   
            
        }

       

        public void MenuElegirHistoria(string id)
        {
            Console.WriteLine("Desea: 1 Editar los datos de una historia clinica | 2 Consultar una Historia Clinica");
            selec = LectorOpciones();
            clsHistClinica historia = new clsHistClinica();
            Console.WriteLine("Ingrese el numero de historia clinica al que desee acceder");
            string no_HistCl = Console.ReadLine();
            historia.buscar(id, no_HistCl);

            if (selec == 1)
            {

                               
                Console.WriteLine("Ingrese el numero del campo que desee modificar: 1 Estatura || 2 Peso || 3 Concluciones Medicas || 4 Diagnostico || 5 Obsevaciones Generales || 6 Sintomas || 7 Temperatura || 8 Estado  ");
                selec = LectorOpciones();
                Console.WriteLine("Ingrese el texto que desea agregar");
                string cambioArchivo = Console.ReadLine();
                string[] opciones = { "", "Altura", "Peso", "Concluciones Medicas", "Diagnostico", "Observaciones Generales", "Sintomas", "Temperatura", "Estado" };
                string campo = opciones[selec];
                historia.actualizar(campo, cambioArchivo);
            }
            else
            {
                Console.WriteLine("En la historia clinica numero: " + historia.getNo_HistCl() + " existen los siguientes registros: ");
                Console.WriteLine("La altura es: " + historia.getAltura());
                Console.WriteLine("El peso es: " + historia.getPeso());
                Console.WriteLine("Las concluciones medicas son:" + historia.getConcluMedicas());
                Console.WriteLine("El diagnostico es: " + historia.getDiagnostico());
                Console.WriteLine("Las observaciones generales son: " + historia.getObsGenerales());
                Console.WriteLine("Los sintomas son: " + historia.getSintomas());
                Console.WriteLine("El estado es: " + historia.getEstado());


            }
             
                               
        }

        public void MenuInsertarHistoria()
        {
            Console.WriteLine("Ingrese el numero de cedula del paciente al que desee acceder");
            string id = Console.ReadLine();
            
            clsHistClinica historia = new clsHistClinica();
            
            Console.WriteLine("Inserte las observacones generales ");
            string obs = Console.ReadLine();

            Console.WriteLine("Inserte los sintomas");
            string sintomas = Console.ReadLine();

            Console.WriteLine("Inserte el peso");
            string peso = Console.ReadLine();

            Console.WriteLine("Inserte la temperatura del paciente");
            string temperatura = Console.ReadLine();

            Console.WriteLine("Inserte la altura paciente");
            string altura = Console.ReadLine();

            Console.WriteLine("Inserte el diagnostico");
            string diagnostico = Console.ReadLine();

            Console.WriteLine("Inserte las conclusiones medicas");
            string concluMedicas = Console.ReadLine();

            Console.WriteLine("Inserte el estado del paciente, puede ser: Enfermo || En Tratamiento || Curado || Fallecido");
            string estado = Console.ReadLine();

            historia.insertarHistClinica(id, obs, sintomas, peso, temperatura,altura, diagnostico, concluMedicas, estado);
                
        }




        public void MenuFuncionario(clsFuncionario funcionario)
        {
            string nombreUp = funcionario.getNombre().ToUpper();
            string apellidoUp = funcionario.getApellido().ToUpper();
            Console.WriteLine("Bienvenido " + nombreUp + " "  + apellidoUp + "\nSelecciona una opcion:\n");
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
                            Console.WriteLine("A continuacion ingrese los datos del nuevo Paciente");
                            IngresarDatos(2);
                            break;
                        }
                    case 2:
                        {
                            
                            clsListar.obtener("paciente");
                            clsPaciente paciente = new clsPaciente();
                            Console.WriteLine("Ingrese el id del paciente del cual desee acceder a la informacion");
                            string id = Console.ReadLine();
                            paciente.buscar(id);
                            Console.WriteLine("Nombre: " + paciente.getNombre());
                            Console.WriteLine("Apellido: " + paciente.getApellido());
                            Console.WriteLine("Edad: " + paciente.getEdad());
                            Console.WriteLine("Fecha de Nacimiento: " + paciente.getFechNac());
                            Console.WriteLine("Direccion: " + paciente.getDireccion());
                            Console.WriteLine("Numero de Telefono: " + paciente.getTelefono());
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("A continuacion ingrese los datos del nuevo Medico");
                            IngresarDatos(1);
                            break;
                        }
                    case 4:
                        {
                            clsListar.obtener("medico");
                            clsMedico medico = new clsMedico();
                            Console.WriteLine("Ingrese el id del medico del cual desee acceder a la informacion");
                            string id = Console.ReadLine();
                            medico.buscar(id);
                            Console.WriteLine("Nombre: " + medico.getNombre());
                            Console.WriteLine("Apellido: " + medico.getApellido());
                            Console.WriteLine("Especialidad: " + medico.getEspecialidad());
                            Console.WriteLine("Edad: " + medico.getEdad());
                            Console.WriteLine("Fecha de Nacimiento: " + medico.getFechNac());
                            Console.WriteLine("Direccion: " + medico.getDireccion());
                            Console.WriteLine("Numero de Telefono: " + medico.getTelefono());
                            Console.ReadKey();
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

            Console.WriteLine("Ingrese su fecha de nacimiento[DD/MM/AAAA]");
            string fechaNac = Console.ReadLine();

            string[] partesFecha = fechaNac.Split('/');
            string anioNac = partesFecha[2];
            int anioNacInt = Convert.ToInt32(anioNac);
            int edadInt = 2016 - anioNacInt;

            DateTime fecha = DateTime.Parse(fechaNac);
            char sexoChar = Convert.ToChar(sexo);
            

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