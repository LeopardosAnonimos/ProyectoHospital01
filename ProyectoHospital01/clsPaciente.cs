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
        public string estado;

        public String getEstado()
        {
            return this.estado;
        }


        public String setEstadoPac(int estado)
        {
            switch (estado)
            {
                case 1:
                        this.estado = "Enfermo";
                        return "Enfermo";   
                case 2:
                    this.estado = "En tratamiento";
                        return this.estado;
                case 3:
                    this.estado = "Curado";
                        return this.estado;
                default:
                    return null;
            }
            
        }

       

        
        public clsPaciente(string id, string rol, string nombre, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);

            clsHistClinica histClinica = new clsHistClinica();

            histClinica.insertarHistClinica( id, "empty", "empty", 0 , 0 , 0 , "empty", "empty");
        }

        public clsPaciente()
        {
        } 

        public void buscar(string id)
        {
            base.buscar(id);
            //this.historia = base.getDb().obtenerDatoPersona(id, historia);
        }
               

       
    }
}
