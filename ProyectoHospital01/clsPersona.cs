using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsPersona:clsDatos
    {
        protected String nombre;
        protected String apellido;
        protected String direccion;
        private String id;
        protected String telefono;
        protected char sexo;
        protected int edad;
        protected DateTime fechNac;

      

        private clsDatos db;

      public String getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public clsPersona()
        {
            this.db = new clsDatos();
        }

        public clsDatos getDb()
        {
            return this.db;
        }

        public bool crear(string id, string rol, string nombre, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fechNac)
        {          
            if(db.insertarPersona(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac))
            {
                Console.WriteLine("Persona creada " + id + " | " + nombre);
                return true;
            }

            Console.WriteLine("No se ha podido crear la persona " + id + " | " + nombre);
            return false;
            
        }

        public bool buscar(string id)
        {
            string sexoString = Convert.ToString(this.sexo);
            string edadString = Convert.ToString(this.edad);
            string fechNacString = Convert.ToString(this.fechNac);

            if (!db.existe(db.pathPersona(id)))
            {
                return false;
            }
            this.id = id;
            this.nombre = db.obtenerDatoPersona(id, "nombre");
            this.apellido = db.obtenerDatoPersona(id, "apellido");
            this.direccion = db.obtenerDatoPersona(id, "direccion");
            this.telefono = db.obtenerDatoPersona(id, "telefono");
            sexoString = db.obtenerDatoPersona(id, "sexo");
            edadString = db.obtenerDatoPersona(id, "edad");
            fechNacString = db.obtenerDatoPersona(id, "fechNac");

            return true;
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
        public string getDireccion()
        {
            return this.direccion;
        }
        public string getTelefono()
        {
            return this.telefono;
        }
        public char getSexo()
        {
            return this.sexo;
        }
        public int getEdad()
        {
            return this.edad;
        }
        public DateTime getFechNac()
        {
            //ME ESTA TRAYENDO UN EMPTY DATETIME!!!!!!!!!!!!!
            //string fecha =  
            //fechNac = fechNac.ToShortDateString;
            return this.fechNac;
        }

        public char generarLetra()
        {
            Random abc = new Random();

            int letras = abc.Next(65, 67);
            char letras1 = Convert.ToChar(letras);
            return letras1;
        }

        public int generarEstructura()
        {
            Random rnd = new Random();
            int oficina = rnd.Next(1, 10);
            return oficina;
        }


    }
}
