using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoHospital01
{
    class clsFuncionario:clsPersona
    {


        private clsCita cita = new clsCita();

        private string oficina { get; set; }

 
        public clsFuncionario(string id, string rol, string nombre, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fechNac,string oficina)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);
            base.getDb().actualizarPersona(id, "oficina", oficina);
            base.buscar(id);
        }

        public clsFuncionario()
        {
        }

        /*public void buscar(string id)
        {
            base.buscar(id);
            this.oficina = base.getDb().obtenerDatoPersona(id, "oficina");
        }*/

        public bool anadirCita(string id, string idMedico, string fecha, string hora)
        {
            return cita.insertarCita(id, idMedico, fecha, hora);

        }

        public void verCita(string id, string no_cita)
        {
            cita.buscar(id, no_cita);

            // Vista cita
            Console.WriteLine("Fecha: " + cita.getFecha());
            Console.WriteLine("Medico: " + cita.getMedico().getNombre());
        }

        public bool editarCita(string id, string no_cita, string campo, string contenido)
        {
            if(cita.buscar(id, no_cita))
            {
                return cita.actualizarCita(campo, contenido);
            }
            return false;
        }

        public bool borrarCita(string id, string no_cita)
        {
            return cita.borrar(id, no_cita);
        }

       
        /*
              public clsFuncionario(String nombre, String apellido, String direccion, String id, String telefono, char sexo, int edad,
                DateTime fechNac, String pswd, clsFuncionario secre)
            : base(nombre, apellido, direccion, id, telefono, sexo, edad, fechNac, pswd)
        {

        
        }

        public string Oficina1
        {
            get
            {
                return oficina;
            }

            set
            {
                oficina = value;
            }
        }*/

    }
}
