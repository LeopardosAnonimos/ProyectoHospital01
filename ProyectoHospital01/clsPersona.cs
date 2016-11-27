using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsPersona:clsDatos
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

        public clsDatos getDb()
        {
            return this.db;
        }

        public void crear(String id, string rol, String nombre, String apellido, String direccion, String telefono, char sexo, int edad, DateTime fechNac, String pswd)
        {          
            if(db.insertarPersona(id, rol, nombre, apellido, direccion, telefono, sexo, edad, pswd, fechNac))
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
            this.apellido = db.obtenerDatoPersona(id, "apellido"); //
            // completar los demas datos...
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

        public void crearRol(string id, string rol)
        {
            db.actualizarPersona(id, rol, "");
        }

        public bool tieneRol(string rol)
        {
            return db.existeCampo(id, rol);
        }

        public bool borrar()
        {
            return db.borrarPersona(this.id);
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getApellido()
        {
            return this.apellido;
        }

        // Crear los demas getters...

    }
}
