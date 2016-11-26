using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsFuncionario:clsPersona
    {
        private String oficina;

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
        }
    }
}
