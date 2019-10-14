﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        #region EnumDeclaration
        public enum EnumCategoria {
            FRESCOS = 1,
            CONGELADOS,
            HOGAR,
            TEXTILES,
            TECNOLOGIA
        }
        #endregion
        
        private int id;
        private string nombre;
        private string descripcion;
        private bool exclusivo;
        private EnumCategoria categoria;
        private double precio;

        private static int contadorId = 1;

        public Producto(string nombre, string descripcion, bool exclusivo, EnumCategoria categoria, double precio)
        {
            this.id = contadorId;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.exclusivo = exclusivo;
            this.categoria = categoria;
            this.precio = precio;
            contadorId++;
        }

        #region  Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public bool Exclusivo
        {
            get { return exclusivo; }
            set { exclusivo = value; }
        }

        public EnumCategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        #endregion

        #region Methods
        public static bool NombreValido(string nombre)
        {
            return nombre.Length == 0;
        }
        public static bool DireccionValida(string direccion)
        {
            return direccion.Length == 0;
        }
        public static bool PrecioValido(string sPrecio)
        {
            bool exito = false;
            double precio;
            exito = sPrecio.Length > 0 && Double.TryParse(sPrecio, out precio) && precio > 0;
            return exito;
        } 
        #endregion
    }
}
