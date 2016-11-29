using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoHospital01
{
    class clsFuncionario:clsPersona
    {


        private string oficina { get; set; }

        // Cambiar String a string
        public clsFuncionario(String id, String rol, String nombre, String apellido, String especialidad, String direccion, String telefono, char sexo, int edad, DateTime fechNac,string oficina)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);
            base.getDb().actualizarPersona(id, "oficina", oficina);
        }

        public clsFuncionario()
        {
        }

        public void buscar(string id)
        {
            base.buscar(id);
            this.oficina = base.getDb().obtenerDatoPersona(id, "oficina");
        }

       
        /*
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
        }*/

    }
}
