using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CantidadProducto
    {
        private int cantidad;
        private Producto producto;

        public CantidadProducto(int cantidad, Producto producto)
        {
            this.cantidad = cantidad;
            this.producto = producto;
        }

        #region Properties
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }
        #endregion

    }
}
