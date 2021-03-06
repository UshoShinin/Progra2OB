﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente
    {
        #region EnumDeclaration
        public enum EnumProcedencia
        {
            MONTEVIDEO = 1,
            INTERIOR
        }
        #endregion

        private List<Compra> compras;
        private string nombre;
        private string contraseña;
        private string email;
        private DateTime fecha;
        private EnumProcedencia procedencia;
        private string direccion;
        private string nombreDeUsuario;
        protected static double descuentazo = 0.05;

        protected Cliente(List<Compra> compras, string nombre, string contraseña, string email, DateTime fecha, EnumProcedencia procedencia, string direccion, string nombreDeUsuario)
        {
            this.compras = compras;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.email = email;
            this.fecha = fecha;
            this.procedencia = procedencia;
            this.direccion = direccion;
            this.nombreDeUsuario = nombreDeUsuario;
        }

        #region Properties
        public List<Compra> Compras
        {
            get { return compras; }
            set { compras = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
        }
        public EnumProcedencia Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string NombreDeUsuario
        {
            get { return nombreDeUsuario; }
            set { nombreDeUsuario = value; }
        }
        #endregion

        #region Methods
        //Metodo abstracto preparado para que hereden los hijos de la clase
        public abstract double calcularPorcentaje();

        public static bool NombreValido(string nombre)
        {
            return nombre.Length > 0;
        }

        public static bool ContraseñaValida(string contraseña)
        {
            return contraseña.Length > 0;
        }
        public double Antiguedad()
        {
            TimeSpan a = DateTime.Now - this.fecha;
            return a.Days / 365.25;
        }
        public static bool EmailValido(string email)
        {
            return email.Length > 0;
        }
        public static bool NUsuarioValido(string NUsuario)
        {
            return NUsuario.Length > 0;
        }
        public static bool DireccionValida(string direccion)
        {
            return direccion.Length > 0;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Fecha:{0} Nombre:{1} Email:{2}",Fecha.ToShortDateString(), Nombre,Email);
        }
    }
}
