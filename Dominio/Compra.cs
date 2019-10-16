using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        private List<CantidadProducto> productos;
        private Cliente cliente;
        private DateTime fecha;

        public Compra(List<CantidadProducto> productos, Cliente cliente, DateTime fecha)
        {
            this.productos = productos;
            this.cliente = cliente;
            this.fecha = fecha;
        }

        #region Properties
        public List<CantidadProducto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        #endregion

        #region Methods
        public double SubTotal()
        {
            double total = 0;
            foreach (CantidadProducto P in Productos)
            {
                total *= P.Producto.Precio * P.Cantidad;
            }
            return total;
        }

        public int CantidadProductos()
        {
            int contador = 0;
            foreach (CantidadProducto cp in productos)
                contador += cp.Cantidad;
            return contador;
        }

        public override string ToString()
        {
            return string.Format("{0}, fecha: {1} - Total productos: {2}", Cliente.Nombre, fecha, CantidadProductos());
        } 
        #endregion
    }
}
