﻿using System;
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


        //public int LectorOpciones()
        //{
        //    String abc = Console.ReadLine();
        //    if(abc.Length > 0)
        //    {

        //        int opc = Convert.ToInt32(abc);

        //        if (opc > 0 && opc <= 9)
        //        {
        //            return opc;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Opcion no valida! Ingrese el valor correcto: ");

        //        }

        //    }
        //    catch (System.FormatException)
        //    {
        //        Console.WriteLine("Se ha ingresado un valor no valido: " + abc + "\nIngrese el valor correcto: ");
        //        return 0


        //        int opc = Convert.ToInt16(abc);
        //        return opc;

        //    }

        //    Console.WriteLine("Se ha ingresado un valor no valido: " + abc + ".");
        //    return 0;
        //}


        public int LectorOpciones()
        {
            String abc = Console.ReadLine();
            if (abc.Length > 0)
            {
                int opc = Convert.ToInt16(abc);
                return opc;
            }

            Console.WriteLine("Se ha ingresado un valor no valido: " + abc + ".");
            return 0;
        }
       

     
           
        public void MenuBienvenida()
        {
            
            //do
            // {
            // selec = LectorOpciones();
            // } while (selec == 0);

            Console.Clear();
            Console.WriteLine("\tHOSPITAL VALLE CEREZO\n" + "Presione:\n" + 
                                "1.Ingresar al sistema \n" +
                                "2.Para Salir\n");

                 //do
                    // {
                           // selec = LectorOpciones();
                    // } while (selec == 0);

            selec = LectorOpciones();

            do
            {
                if (selec == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\nIngrese su numero de cedula...");

                    string id = Console.ReadLine();
                    clsPersona persona = new clsPersona();
                   // Console.Clear();

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
                        Console.Clear();
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
                                Console.Clear();
                                Console.WriteLine("\n\t\t\t\t\t==FIN==");
                                //Console.ReadKey();
                                { }
                                System.Console.Out.Close();
                                break;

                            default:
                                break;

                        }

                    }
                }
                else if (selec == 2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t\t==FIN==");
                    { } System.Console.Out.Close();
                }

            } while (selec != 2);

                
        }




        public void MenuPaciente(clsPaciente paciente)
        {
            string nombreUp = paciente.getNombre().ToUpper();
            string apellidoUp = paciente.getApellido().ToUpper();

            Console.Clear();
            Console.WriteLine("Bienvenido " + nombreUp + " "+ apellidoUp + " \nSelecciona una opcion:\n");

            Console.WriteLine("1. Listar Citas\n" +
                                "2. Consultar Historia Clinica\n" +
                                "3. Editar datos Ingresados\n" +
                                "4. Salir al Menu Anterior\n\n\t=>");
            do
            {
                selec = LectorOpciones();
                switch (selec)
                {
                    case 1:
                        {
                            //LISTAR CITAS
                            break;
                        }
                    case 2:
                        {
                            MenuPacienteConsultarHistoria(paciente.getId());
                            break;
                        }
                    case 3:
                        {
                            editarDatosPersona( paciente.getId() );
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
         
            //  Console.WriteLine("Bienvenido " +" " + medico.getNombre()+" " + medico.getApellido() + "\nSelecciona una opcion:\n");

            string nombreUp = medico.getNombre().ToUpper();
            string apellidoUp = medico.getApellido().ToUpper();
            Console.Clear();
            Console.WriteLine("Bienvenido " + nombreUp + " " + apellidoUp + " \nSelecciona una opcion:\n");
            Console.WriteLine("1. Listar Citas\n" +
                                "2. Informacion Pacientes\n" +
                                "3. Crear nueva historia clinica\n" +
                                "4. Salir\n\n\t=>");


            selec = LectorOpciones();
            Console.Clear();
           
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
                            Console.Clear();
                            
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
                Console.WriteLine("\nIngrese el numero de cedula del paciente al que desee acceder");
                string id = Console.ReadLine();
                clsListar.obtenerHistorias(id);
                MenuElegirHistoria(id);
                Console.ReadKey();
        }

       


        public void MenuElegirHistoria(string id)
        {
            Console.WriteLine("Desea: \n1. Editar los datos de una historia clinica" +
                                "\n2. Consultar una Historia Clinica");
            selec = LectorOpciones();
            clsHistClinica historia = new clsHistClinica();
            Console.WriteLine("Ingrese el numero de historia clinica al que desee acceder");
            //Lista de historias clinicas existentes...
            string no_HistCl = Console.ReadLine();
            historia.buscar(id, no_HistCl);

            if (selec == 1)
            {

                Console.WriteLine("Ingrese el numero del campo que desee modificar:" +
                                  "\n1. Estatura" + 
                                  "\n2. Peso" +
                                  "\n3. Concluciones Medicas" +
                                  "\n4. Diagnostico" +
                                  "\n5. Obsevaciones Generales" +
                                  "\n6. Sintomas" +
                                  "\n7. Temperatura" +
                                  "\n8. Estado ");
                selec = LectorOpciones();
                Console.WriteLine("Ingrese el texto que desea agregar");
                string cambioArchivo = Console.ReadLine();
                string[] opciones = { "", "Altura", "Peso", "Concluciones Medicas", "Diagnostico", "Observaciones Generales", "Sintomas", "Temperatura", "Estado" };
                string campo = opciones[selec];
                historia.actualizar(campo, cambioArchivo);

                Console.WriteLine("\n\nEl campo " + campo + " ha sido modificado correctamente!");
                Console.ReadKey();

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
            Console.WriteLine("\n\nIngrese el numero de cedula del paciente al que desee acceder");
            string id = Console.ReadLine();
            
            clsHistClinica historia = new clsHistClinica();
            
            Console.WriteLine("\n\nInserte las observacones generales");
            string obs = Console.ReadLine();

            Console.WriteLine("\n\nInserte los sintomas");
            string sintomas = Console.ReadLine();

            Console.WriteLine("\n\nInserte el peso");
            string peso = Console.ReadLine();

            Console.WriteLine("\n\nInserte la temperatura del paciente");
            string temperatura = Console.ReadLine();

            Console.WriteLine("\n\nInserte la altura paciente");
            string altura = Console.ReadLine();

            Console.WriteLine("\n\nInserte el diagnostico");
            string diagnostico = Console.ReadLine();

            Console.WriteLine("\n\nInserte las conclusiones medicas");
            string concluMedicas = Console.ReadLine();

            Console.WriteLine("\n\nInserte el estado del paciente, puede ser: Enfermo || En Tratamiento || Curado || Fallecido");
            string estado = Console.ReadLine();

            historia.insertarHistClinica(id, obs, sintomas, peso, temperatura,altura, diagnostico, concluMedicas, estado);
            Console.WriteLine("\n\t Los datos de la Historia clinica han sido ingresados correctamente!");

        }




        public void MenuFuncionario(clsFuncionario funcionario)
        {
            string nombreUp = funcionario.getNombre().ToUpper();
            string apellidoUp = funcionario.getApellido().ToUpper();
            Console.Clear();
            Console.WriteLine("Bienvenido " + nombreUp + " "  + apellidoUp + "\nSelecciona una opcion:\n");
            Console.WriteLine("1. Ingresar un nuevo Paciente\n" +
                                "2. Informacion(buscar) Paciente\n" +
                                "3. Ingresar un nuevo Medico\n" +
                                "4. Informacion(buscar) Medico\n" +
                                "5. Eliminar usuario\n"+
                                "6. Salir\n\n\t=>");


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
                            clsPaciente paciente = new clsPaciente();
                            Console.WriteLine("Ingrese el id del paciente del cual desee acceder a la informacion");
                            string id = Console.ReadLine();
                            if (!paciente.buscar(id))
                            {
                                Console.WriteLine("¡¡NO EXISTE EL REGISTRO!!");
                                Console.ReadKey();
                                Console.Clear();
                                MenuFuncionario(funcionario);

                            }
                            else
                            {
                                clsListar.obtener("paciente");
                                paciente.buscar(id);
                                Console.WriteLine("Nombre: " + paciente.getNombre());
                                Console.WriteLine("Apellido: " + paciente.getApellido());
                                Console.WriteLine("Edad: " + paciente.getEdad());
                                Console.WriteLine("Fecha de Nacimiento: " + paciente.getFechNac());
                                Console.WriteLine("Direccion: " + paciente.getDireccion());
                                Console.WriteLine("Numero de Telefono: " + paciente.getTelefono());
                                Console.ReadKey();
                            }
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
                            clsMedico medico = new clsMedico();
                            Console.WriteLine("Ingrese el id del medico del cual desee acceder a la informacion");
                            string id = Console.ReadLine();

                            if (!medico.buscar(id))
                            {
                                Console.WriteLine("¡¡NO EXISTE EL REGISTRO!!");
                                Console.ReadKey();
                                Console.Clear();
                                MenuFuncionario(funcionario);

                            }
                            else
                            {
                                clsListar.obtener("medico");
                                Console.WriteLine("Nombre: " + medico.getNombre());
                                Console.WriteLine("Apellido: " + medico.getApellido());
                                Console.WriteLine("Especialidad: " + medico.getEspecialidad());
                                Console.WriteLine("Edad: " + medico.getEdad());
                                Console.WriteLine("Fecha de Nacimiento: " + medico.getFechNac());
                                Console.WriteLine("Direccion: " + medico.getDireccion());
                                Console.WriteLine("Numero de Telefono: " + medico.getTelefono());
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 5:
                        {
                            clsDatos borrar = new clsDatos();

                            Console.WriteLine("Elija al tipo de usuario que desea eliminar: \n" +
                                              "1.Paciente\n" +
                                              "2.Medico");
                            selec = LectorOpciones();
                            Console.Clear();
                            if (selec == 1)
                            {
                                Console.WriteLine("\tUSUARIOS DE TIPO ==PACIENTE== ");
                                clsListar.obtener("paciente");
                                Console.WriteLine("\nIngrese la identificación del usuario a eliminar: ");
                                string id = Console.ReadLine();
                                borrar.borrarPersona(id);
                                Console.ReadKey();
                                Console.Clear();
                                MenuFuncionario(funcionario);
                            }
                            else if (selec == 2)
                            {
                                Console.WriteLine("\tUSUARIOS DE TIPO ==MEDICO== ");
                                clsListar.obtener("medico");
                                Console.WriteLine("Ingrese la identificación del usuario a eliminar: ");
                                string id = Console.ReadLine();
                                Console.Clear();
                                borrar.borrarPersona(id);
                                Console.ReadKey();
                                Console.Clear();
                                MenuFuncionario(funcionario);
                            }
                            break;
                        }
                    case 6:
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
            } while (selec != 6);
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

                    string oficina = " ";
                    clsFuncionario funcionario = new clsFuncionario(id, rol, nombre, apellido, direccion, telefono, sexoChar, edadInt, fecha, oficina);

                    MenuFuncionario(funcionario);
                    break;
                
                        
            }
            
            Console.ReadKey();
        }




        public void editarDatosPersona(string id)
        {
            clsDatos dts = new clsDatos();

            Console.WriteLine("Ingrese el numero del campo que desee modificar:" +
                                  "\n1. Nombre" +
                                  "\n2. Apellido" +
                                  "\n3. Direccion" +
                                  "\n4. Telefono" +
                                  "\n5. Sexo" +
                                  "\n6. Fecha de Nacimiento");

            selec = LectorOpciones();
            Console.WriteLine("Ingrese el texto que desea modificar");
            string cambioArchivo = Console.ReadLine();
            string[] opciones = { "", "nombre", "apellido", "direccion", "telefono", "sexo", "fechNac" };
            string campo = opciones[selec];
            dts.actualizarPersona(id, campo, cambioArchivo);

            Console.WriteLine("Los datos han sido modificados con exito!");

        }



    }
}