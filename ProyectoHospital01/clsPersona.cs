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

        private clsDatos db;

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

        public clsPersona()
        {
            this.db = new clsDatos();
        }

        public void crear(String nombre, String apellido, String direccion, String id, String telefono, char sexo, int edad, DateTime fechNac, String pswd)
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

            
            if(db.insertarPersona(id, nombre, apellido, direccion, telefono, sexo, edad, pswd, fechNac))
            {
                Console.WriteLine("Persona creada " + id + " | " + nombre);
            } else
            {
                Console.WriteLine("No se ha podido crear la persona " + id + " | " + nombre);
            }
            
        }

        public void buscar(string id)
        {
            this.id = id;
            this.nombre = db.obtenerDatoPersona(id, "nombre");
            this.apellido = db.obtenerDatoPersona(id, "apellido");

        }

        public bool editar(string campo, string contenido)
        {
            if(db.actualizarPersona(this.id, campo, contenido))
            {
                buscar(this.id);
                return true;
            }
            return false;
        }

        public bool borrar()
        {
            return db.borrarPersona(this.id);
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getApellido(string id)
        {
            return this.apellido;
        }

    }
}
