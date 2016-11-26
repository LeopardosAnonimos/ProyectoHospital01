                              using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoHospital01
{
    class Program
    {
        static void Main(string[] args)
        {
            clsDatos archivo = new clsDatos();
            archivo.crearPaciente("juan");

            archivo.obtenerPaciente("juan");
        }
    }
}
