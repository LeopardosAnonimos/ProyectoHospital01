﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoHospital01
{
    class clsFuncionario:clsPersona
    {
        List<clsPaciente> pacientes = new List<clsPaciente>();

        public void crearListasPacientes()
        {
            for (int i = 0; i < pacientes.Count(); i++)
            {
                clsPaciente p = new clsPaciente();
                //pedir datos del paciente por teclado
            }
        }
        

        private string oficina { get; set; }

        // Cambiar String a string
        public clsFuncionario(string id, string rol, string nombre, string apellido, string direccion, string telefono, char sexo, int edad, DateTime fechNac,string oficina)
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
