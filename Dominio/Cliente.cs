﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    abstract class Cliente
    {
        #region EnumDeclaration
        public enum EnumProcedencia
        {
            MONTEVIDEO,
            INTERIOR
        }
        #endregion

        private List<Compra> Compras;

        private string nombre;
        private string contraseña;
        private string email;
        private DateTime fecha;
        private EnumProcedencia procedencia;
        private string direccion;
        private string nombreDeUsuario;

        #region Propertys
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


        public abstract double calcularPorcentaje();

        public static bool NombreValido(string nombre) {
            return nombre.Length > 0;
        }

        public static bool ContraseñaValida(string contraseña)
        {
            return contraseña.Length>0;
        }
        public int Antiguedad()
        {
            TimeSpan a = DateTime.Now - this.fecha;
            return a.Days/364;
        }
        public static bool EmailVelido(string email)
        {
            return email.Length > 0;
        }
        public static bool NUsuarioValido   (string NUsuario)
        {
            return NUsuario.Length > 0;
        }
        public static bool DireccionValida(string direccion)
        {
            return direccion.Length > 0;
        }

    }
}