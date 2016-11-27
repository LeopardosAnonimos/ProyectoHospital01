using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsMedico:clsPersona
    {
        private String especialidad { get; set; }
        
        // Cambiar String a string
        public clsMedico(String id, String nombre, String apellido, String direccion, String telefono, char sexo, int edad, DateTime fechNac, String pswd)
            :base()
        {
            base.crear(id, nombre, apellido, direccion, telefono, sexo, edad, fechNac, pswd);
        }
        /*
        public clsMedico(String nombre, String apellido, String direccion, String id, String telefono, char sexo, int edad,
            DateTime fechNac, String pswd)
            : base(nombre, apellido, direccion, id, telefono, sexo, edad, fechNac, pswd)
        {
            
        }

        public clsMedico(String nombre, String apellido, String telefono, String especialidad)
            : base(nombre, apellido, telefono)
        {
            this.especialidad = especialidad;
        }
        */
    }
}
