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

        //string historia1 = historia.obtenerDatoHistClinica(" ","Conclusiones Medicas");

        // Cambiar String a string
        public clsPaciente(String id, String rol, String nombre, String apellido, String direccion, String telefono, char sexo, int edad, DateTime fechNac)
            :base()
        {
            base.crear(id, rol, nombre, apellido, direccion, telefono, sexo, edad, fechNac);

            clsHistClinica histClinica = new clsHistClinica();

            histClinica.insertarHistClinica( id, "observaciones Generales", "Sintomas", 21 , 2555 , 2544 , "Diagnostico", "Concluciones");
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
