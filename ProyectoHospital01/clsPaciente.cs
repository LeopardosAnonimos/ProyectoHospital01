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

        public clsHistClinica Historia
        {
            get
            {
                // comment
                // oasjdoi
                return historia;
            }
            set
            {
                historia = value;
            }
        }



        private clsCita cita;

        public clsPaciente(String nombre, String apellido, String direccion, String id, String telefono,
            char sexo, int edad, DateTime fechNac, String pswd)
            : base(nombre, apellido, direccion, id, telefono, sexo, edad, fechNac, pswd)
        {
            clsHistClinica historia = new clsHistClinica();
            clsCita cita = new clsCita();

        }
    }
}
