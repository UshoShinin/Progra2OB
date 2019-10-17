using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {

        #region EnumDeclaration
        public enum EnumFormaPago
        {
            TARJETA = 1,
            EFECTIVO
        } 

        public enum EnumTipoEntrega
        {
            RETIROLOCAL  = 1,
            DOMICILIO
        }
        #endregion

        private List<CantidadProducto> productos;
        private Cliente cliente;
        private DateTime fecha;
        private EnumFormaPago formaDePago;
        private EnumTipoEntrega tipoEntrega;        

        public Compra(List<CantidadProducto> productos, Cliente cliente, DateTime fecha, EnumFormaPago formaDePago, EnumTipoEntrega tipoEntrega)
        {
            this.productos = productos;
            this.cliente = cliente;
            this.fecha = fecha;
            this.formaDePago = formaDePago;
            this.tipoEntrega = tipoEntrega;
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

        public EnumFormaPago FormaDePago
        {
            get { return formaDePago; }
            set { formaDePago = value; }
        }

        public EnumTipoEntrega TipoEntrega
        {
            get { return tipoEntrega; }
            set { tipoEntrega = value; }
        }
        #endregion

        #region Methods
        //Se calcula el valor bruto de todos los productos dentro de la lista de compra.
        public double SubTotal()
        {
            double subtotal = 0;
            foreach (CantidadProducto P in Productos)
            {
                if (P.Producto.Exclusivo && P.Cantidad >= 2)
                {
                    subtotal += P.Producto.Precio * (P.Cantidad - 1);
                } else
                {
                    subtotal += P.Producto.Precio * P.Cantidad;
                }               
            }
            return subtotal;
        }

        //A partir del subtotal se aplican descuentos y gastos de envío 
        public double Total()
        {
            double total = SubTotal();
            double descuento = 0;
            if (total >= 5000)
                descuento += 0.04;
            descuento += cliente.calcularPorcentaje();
            total -= total * descuento;
            if (cliente.Procedencia == Cliente.EnumProcedencia.INTERIOR && tipoEntrega == EnumTipoEntrega.DOMICILIO)
                total += 1000; //Te fajamos con el envío
            return total;
        }

        //Suma las cantidades de cada producto en la lista de compras para tener una cantidad de productos totales.
        public int CantidadProductos()
        {
            int contador = 0;
            foreach (CantidadProducto cp in productos)
                contador += cp.Cantidad;            
            return contador;
        }

        public override string ToString()
        {
            return string.Format("{0}, fecha: {1} - Total productos: {2}", Cliente.Nombre, fecha.ToShortDateString(), CantidadProductos());
        } 
        #endregion
    }
}
