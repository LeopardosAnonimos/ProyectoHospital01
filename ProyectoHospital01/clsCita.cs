using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsCita
    {
        private clsMedico medico { get; set; }

        private DateTime fecha { get; set; }

        private DateTime hora { get; set; }


        public clsCita()
        {

            clsMedico medico = new clsMedico("", "", "", "");
            DateTime fecha = new DateTime();
            DateTime hora = new DateTime();
        }



    }
}
