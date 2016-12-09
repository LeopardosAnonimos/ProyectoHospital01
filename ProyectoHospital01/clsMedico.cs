using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsMedico:clsPersona
    {
        private string especialidad;
        
        
        public clsMedico(string id, string rol, string nombre, string apellido, string especialidad, string direccion, string telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);
            base.getDb().actualizarPersona(id, "especialidad", especialidad);
            base.buscar(id);
        }

        public string getEspecialidad()
        {
            return this.especialidad;
        }

        public clsMedico() { }

        
        public void verCitas()
        {

            Console.WriteLine("Citas pendientes");
            clsListar.obtenerCitasMedico(this.getId());
            Console.ReadKey();
        }  
             
       
    }
}
