using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsPaciente:clsPersona
    {
        public clsHistClinica historia;
        public string estado;

        public String getEstado()
        {
            return this.estado;
        }


          

        
        public clsPaciente(string id, string rol, string nombre, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);

            base.buscar(id);
           
            clsHistClinica histClinica = new clsHistClinica();
            
            histClinica.insertarHistClinica( id, "empty", "empty", " " , " " , " " , "empty", "empty", "empty");
        }

        public clsPaciente()
        {
        } 
 
       
    }
}
