using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class CantidadProducto
    {
        private int cantidad;
        private Producto producto;

        #region Propertys
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
