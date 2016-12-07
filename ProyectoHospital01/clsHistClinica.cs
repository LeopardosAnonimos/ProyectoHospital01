using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoHospital01
{
    class clsHistClinica : clsDatos
    {
        clsPaciente paciente = new clsPaciente();
        private string no_HistCl;
        private string obsGenerales { get; set; }
        private string sintomas { get; set; }
        private decimal peso { get; set; }
        private decimal temperatura { get; set; }
        private decimal altura { get; set; }
        private string diagnostico { get; set; }
        private string concluMedicas;

        public string No_HistCl
        {
            get
            {
                return no_HistCl;
            }

            set
            {
                no_HistCl = value;
            }
        }

        public string ConcluMedicas
        {
            get
            {
                return concluMedicas;
            }

            set
            {
                concluMedicas = value;
            }
        }

        public bool insertarHistClinica(string id, string obsGenerales, string sintomas, decimal peso, decimal temperatura, decimal altura, string diagnostico, string concluMedicas)
        {
            string no_Histcl = DateTime.Now.ToString("ddMMyyyy-HHmmss");
            string path = @"c:\hospital\personas\" + id + "\\historia\\" + no_Histcl;
            string pesoString = Convert.ToString(peso);
            string temperaturaString = Convert.ToString(temperatura);
            string alturaString = Convert.ToString(altura);
            

            if (existe(path))
            {
                Console.WriteLine("La historia clinica ya existe " + no_Histcl);
                Console.WriteLine("En la carpeta " + path);
                Console.ReadKey();
                return false;
            }

           
            crearArchivo(no_Histcl, "#HistoriaClinica", path);
            crearArchivo(obsGenerales, "Observaciones Generales", path);
            crearArchivo(sintomas, "Sintomas", path);
            crearArchivo(pesoString, "Peso", path);
            crearArchivo(temperaturaString, "Temperatura", path);
            crearArchivo(alturaString, "Altura", path);
            crearArchivo(diagnostico, "Diagnostico", path);
            crearArchivo(concluMedicas, "Concluciones Medicas", path);
        
            return true;
        }

             public bool actualizarHistClinica(string no_HistCl, string campo, string contenido)
        {
            return insertarContendido(contenido, pathPersonaCampo(no_HistCl, campo));
        }

        public string obtenerDatoHistClinica(string no_HistCl, string campo)
        {
            return obtenerArchivo(pathPersonaCampo(no_HistCl, campo));

        }

        public bool borrarHistClinica(string no_HistCl)
        {
            if (no_HistCl.Length > 0)
            {
               // return borrarHistClinica(pathHistClinica(no_HistCl));
            }

            return false;

        }


    }





}