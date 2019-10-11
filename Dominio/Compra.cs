﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Compra
    {

        private List<CantidadProducto> Productos;
        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public double SubTotal(){
            double total=0;
            foreach(CantidadProducto P in Productos)
            {
                total *= P.Producto.Precio * P.Cantidad;
            }
            return total;
        }

}
}