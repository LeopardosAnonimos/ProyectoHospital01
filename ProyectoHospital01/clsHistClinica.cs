﻿using System;
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
        private string cedula;
        private string obsGenerales;
        private string sintomas;
        private string peso;
        private string temperatura;
        private string altura;
        private string diagnostico;
        private string concluMedicas;
       

        public string getPeso()
        {
            return peso;
        }

        public string getNo_HistCl()
        {
            return no_HistCl;
        }

        public string getAltura()
        {
            return altura;
        }

        public string getDiagnostico()
        {
            return diagnostico;
        }

        public string getSintomas()
        {
            return sintomas;
        }

        public string getTemperatura()
        {
            return temperatura;
        }

        public string getConcluMedicas()
        {
            return concluMedicas;
        }

        public string getObsGenerales()
        {
            return obsGenerales;
        }


        public bool insertarHistClinica(string id, string obsGenerales, string sintomas, decimal peso, decimal temperatura, decimal altura, string diagnostico, string concluMedicas)
        {
            string no_Histcl = DateTime.Now.ToString("ddMMyyyy-HHmmss");
            string path = pathHistoria(id, no_HistCl);
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

        public bool buscar(string id, string no_HistCl)
        {
            string dirHistoria = pathHistoria(id, no_HistCl);
            if (!existe(dirHistoria))
            {
                return false;
            }
            this.cedula = id;
            this.no_HistCl = no_HistCl;
            this.peso = base.obtenerArchivo(dirHistoria + "\\Peso.txt");
            this.altura = base.obtenerArchivo(dirHistoria + "\\Altura.txt");
            this.obsGenerales = base.obtenerArchivo(dirHistoria + "\\Observaciones Generales.txt");
            this.sintomas = base.obtenerArchivo(dirHistoria + "\\Sintomas.txt");
            this.temperatura = base.obtenerArchivo(dirHistoria + "\\Temperatura.txt");
            this.concluMedicas = base.obtenerArchivo(dirHistoria + "\\Concluciones Medicas.txt");
            this.diagnostico = base.obtenerArchivo(dirHistoria + "\\Diagnostico.txt");

            return true;
        }

        public bool actualizar(string campo, string contenido)
        {
            bool seInserto = insertarContendido(contenido, pathHistoriaCampo(campo));
            buscar(cedula, no_HistCl);
            return seInserto;
        }


        public bool borrar()
        {
            if (no_HistCl.Length > 0)
            {                
                base.borrarArchivo(pathHistoria(cedula, no_HistCl));
                return true;
            }

            return false;

        }

        private string pathHistoriaCampo(string campo)
        {
            return @"c:\hospital\personas\" + cedula + "\\historia\\" + no_HistCl + "\\" + campo + ".txt";
        }

        private string pathHistoria(string id, string no_HistCl)
        {
            return @"c:\hospital\personas\" + id + "\\historia\\" + no_HistCl;
        }
    }

}