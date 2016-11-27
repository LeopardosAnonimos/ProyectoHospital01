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



        // Cambiar String a string
        public clsPaciente(String id, String rol, String nombre, String apellido, String especialidad, String direccion, String telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);
           // base.getDb().actualizarPersona(id, "especialidad", especialidad);
        }

        public clsPaciente()
        {
        }

        public void buscar(string id)
        {
            base.buscar(id);
            //this.historia = base.getDb().obtenerDatoPersona(id, historia);
        }


        /*
         * 
         * No_HistC, medico, observaciones generales / síntomas, peso, temperatura, altura, diagnostico, conclusiones medicas (medicamentos).

         * 
         * 
         * 
        public clsHistClinica Historia 
        {
            get
            {
<<<<<<< HEAD
 
=======
          
                
>>>>>>> origin/master
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
        */
    }
}
