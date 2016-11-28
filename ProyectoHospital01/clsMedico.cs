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
        public clsMedico(String id, String rol, String nombre, String apellido, String especialidad, String direccion, String telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);
            base.getDb().actualizarPersona(id, "especialidad", especialidad);
        }

        public clsMedico()
        {
        }

        public void buscar(string id)
        {
            base.buscar(id);
            this.especialidad =  base.getDb().obtenerDatoPersona(id, "especialidad"); 
        }

        public void Atender(clsPaciente p)
        {
            p.setEstadoPac(p.getEstado);
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
