using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsCita : clsDatos
    {
        private clsMedico medico = new clsMedico();
        public string id;
        private string no_cita;
        private string fecha;
        private string hora;

        public clsMedico getMedico()
        {
            return medico;
        }

        public string getNo_cita()
        {
            return no_cita;
        }

        public string getFecha()
        {
            return fecha;
        }

        public string getHora()
        {
            return hora;
        }

        public bool insertarCita(string id, string idMedico, string fecha, string hora)
        {
            string no_cita = idMedico +  "-" + DateTime.Now.ToString("ddMMyyyy-HHmm");
            string path = pathCita(id, no_cita);

            if (existe(path))
            {
                Console.WriteLine("La cita ya existe " + no_cita);
                Console.WriteLine("En la carpeta " + path);
                Console.ReadKey();
                return false;
            }

            crearArchivo(no_cita, "Cita", path);
            crearArchivo(idMedico, "idMedico", path);
            crearArchivo(fecha, "Fecha", path);
            crearArchivo(hora, "Hora", path);

            buscar(id, no_cita);
            return true;
        }
        public bool buscar(string id, string no_cita)
        {
            string dirCita = pathCita(id, no_cita);
            if (!existe(dirCita))
            {
                return false;
            }

            this.id = id;
            this.no_cita = no_cita;
            string idMedico = base.obtenerArchivo(dirCita + "\\idMedico.txt");
            this.fecha = base.obtenerArchivo(dirCita + "\\Fecha.txt");
            this.hora = base.obtenerArchivo(dirCita + "\\Hora.txt");
            buscarMedico(idMedico);
            return true;
        }

        public bool buscarMedico(string idMedico)
        {
            return medico.buscar(idMedico);
        }

        public bool actualizarCita(string campo, string contenido)
        {
            bool seInserto = insertarContendido(contenido, pathCitaCampo(campo));
            buscar(id, no_cita);
            return seInserto;
        }

        public bool borrar()
        {
            if (no_cita.Length > 0)
            {
                base.borrarArchivo(pathCita(id, no_cita));
                return true;
            }

            return false;
        }

        public bool borrar(string id, string no_cita)
        {
            if (no_cita.Length > 0)
            {
                return base.borrarArchivo(pathCita(id, no_cita));
            }

            return false;
        }

        private string pathCitaCampo(string campo)
        {
            return pathCita(id, no_cita) + "\\" + campo + ".txt";
        }

        private string pathCita(string id, string no_cita)
        {
            return @"c:\hospital\personas\" + id + "\\citas\\" + no_cita;
        }
    }
    
    
}
