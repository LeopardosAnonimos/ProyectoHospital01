using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class clsHistClinica
    {
        private string no_HistCl { get; set; }
        private string obsGenerales { get; set; }
        private string sintomas { get; set; }
        private decimal peso { get; set; }
        private decimal temperatura { get; set; }
        private decimal altura { get; set; }
        private string diagnostico { get; set; }
        private string concluMedicas { get; set; }

        public clsHistClinica()
        {
            no_HistCl = "";
            obsGenerales = "";
            sintomas = "";
            peso = 0;
            temperatura = 0;
            altura = 0;
            diagnostico = "";
            concluMedicas = "";

        }
    }
}
