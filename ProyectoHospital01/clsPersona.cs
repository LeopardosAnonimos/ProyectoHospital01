using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsPersona
    {
        protected String nombre { get; set; }
        protected String apellido { get; set; }
        protected String direccion { get; set; }
        private String id;
        protected String telefono { get; set; }
        protected char sexo { get; set; }
        protected int edad { get; set; }

        protected DateTime fechNac { get; set; }

        protected String pswd { get; set; }

        protected string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public clsPersona(String nombre, String apellido, String direccion, String id, String telefono, char sexo, int edad, DateTime fechNac, String pswd)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.Id = id;
            this.telefono = telefono;
            this.sexo = sexo;
            this.edad = edad;
            this.fechNac = fechNac;
            this.pswd = pswd;

        }

        public clsPersona(String nombre, String apellido, String telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }
    }
}
