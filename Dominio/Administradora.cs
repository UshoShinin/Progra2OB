using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administradora
    {
        #region Singleton
        private static Administradora instancia;

        public static Administradora Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Administradora();
                return instancia;
            }
        }

        private List<Producto> productos;
        private List<Cliente> clientes;
        private List<Compra> compras;

        #region Properties
        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        public List<Cliente> Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        public List<Compra> Compras
        {
            get { return compras; }
            set { compras = value; }
        } 
        #endregion

        private Administradora()
        {
            productos = new List<Producto>();
            clientes = new List<Cliente>();
            compras = new List<Compra>();

            #region Productos  
            Producto p1 = new Producto("Leche", "Leche de vaca, entera y pasteurizada", false, Producto.EnumCategoria.FRESCOS, 29);
            Producto p2 = new Producto("Papas fritas", "1Kg de papas fritas congeladas", true, Producto.EnumCategoria.CONGELADOS, 150);
            Producto p3 = new Producto("Camisa a cuadros", "Camisa roja y negra a cuadros, talle M", true, Producto.EnumCategoria.TEXTILES, 650);
            Producto p4 = new Producto("Microondas", "Microondas digital Panavox de acero inoxidable", false, Producto.EnumCategoria.HOGAR, 4200);
            Producto p5 = new Producto("Smart TV 40\"", "Smart TV Samsung 40\" Full HD", false, Producto.EnumCategoria.TECNOLOGIA, 14000);

            productos.Add(p1);
            productos.Add(p2);
            productos.Add(p3);
            productos.Add(p4);
            productos.Add(p5);
            #endregion

            #region Clientes
            List<Compra> comprasRealizadas = new List<Compra>();
            DateTime fechaRegistro1 = new DateTime(2014, 8, 17);
            DateTime fechaRegistro2 = new DateTime(2016, 2, 22);
            DateTime fechaRegistro3 = new DateTime(2018, 12, 27);
            DateTime fechaRegistro4 = new DateTime(2011, 3, 12);
            DateTime fechaRegistro5 = new DateTime(2015, 11, 24);
            DateTime fechaRegistro6 = new DateTime(2013, 5, 30);

            ClienteComun cc1 = new ClienteComun(comprasRealizadas, "Alejandro Britos", "AlejandroBritos1209", "AlejandroBritos@gmail.com", fechaRegistro1, Cliente.EnumProcedencia.INTERIOR, "Treinta y Tres 512", "AleBritos", 43245438, 98074334);
            ClienteComun cc2 = new ClienteComun(comprasRealizadas, "Manuel Bertinat", "ManuelBertinat2901", "ManuelBertinat@gmail.com", fechaRegistro2, Cliente.EnumProcedencia.MONTEVIDEO, "Jose L. Terra 2372 apto 4", "Manu55", 50787620, 99346534);
            ClienteComun cc3 = new ClienteComun(comprasRealizadas, "Guillermo Rodriguez", "GuillermoRodriguez1806", "GuillermoRodriguez@gmail.com", fechaRegistro3, Cliente.EnumProcedencia.INTERIOR, "18 de Julio 2204", "GuilleElMasCapito", 52432343, 96578757);
            ClienteEmpresa ce1 = new ClienteEmpresa(comprasRealizadas, "ADNexus", "GenexusIsTrash", "NicholasJodon@ADNexus.com.uy", fechaRegistro4, Cliente.EnumProcedencia.MONTEVIDEO, "No tienen sede física LoL", "ADNexus is Love", "ADNexus Es Mejor SRL", 213546823908);
            ClienteEmpresa ce2 = new ClienteEmpresa(comprasRealizadas, "MacroRough", "$250porUnaLicenciaEsUnPrecioJusto", "FacturaPuertas@MacroRough.com", fechaRegistro5, Cliente.EnumProcedencia.MONTEVIDEO, "El mundo LoL", "WeHateLinux", "MacroRough Corporation", 222876233645);
            ClienteEmpresa ce3 = new ClienteEmpresa(comprasRealizadas, "Sinaprole", "Conaprole", "Leche@vaca.muu.uy", fechaRegistro6, Cliente.EnumProcedencia.INTERIOR, "Por todo Uruguay", "Via Sinaprole", "Cooperativa Sinaprole", 153324541981);

            clientes.Add(cc1);
            clientes.Add(cc2);
            clientes.Add(cc3);
            clientes.Add(ce1);
            clientes.Add(ce2);
            clientes.Add(ce3);
            #endregion

            #region Compras
            DateTime fechaCompra1 = new DateTime(2016, 8, 17);
            DateTime fechaCompra2 = new DateTime(2017, 11, 17);
            DateTime fechaCompra3 = new DateTime(2018, 4, 14);
            DateTime fechaCompra4 = new DateTime(2019, 3, 12);
            DateTime fechaCompra5 = new DateTime(2019, 4, 13);
            DateTime fechaCompra6 = new DateTime(2012, 1, 31);

            CantidadProducto cp1 = new CantidadProducto(3, p1);
            CantidadProducto cp2 = new CantidadProducto(5, p2);
            CantidadProducto cp3 = new CantidadProducto(1, p3);
            CantidadProducto cp4 = new CantidadProducto(2, p4);
            CantidadProducto cp5 = new CantidadProducto(50, p5);

            List<CantidadProducto> listaP1 = new List<CantidadProducto> { cp1, cp3, cp4 };
            List<CantidadProducto> listaP2 = new List<CantidadProducto> { cp1, cp2, cp3, cp4, cp5 };
            List<CantidadProducto> listaP3 = new List<CantidadProducto> { cp1, cp3 };
            List<CantidadProducto> listaP4 = new List<CantidadProducto> { cp1, cp2, cp3 };
            List<CantidadProducto> listaP5 = new List<CantidadProducto> { cp1, cp2 };
            List<CantidadProducto> listaP6 = new List<CantidadProducto> { cp1, cp2, cp3, cp4 };

            Compra cm1 = new Compra(listaP1, cc1, fechaCompra1);
            Compra cm2 = new Compra(listaP2, ce2, fechaCompra2);
            Compra cm3 = new Compra(listaP3, cc1, fechaCompra3);
            Compra cm4 = new Compra(listaP4, cc3, fechaCompra4);
            Compra cm5 = new Compra(listaP5, cc3, fechaCompra5);
            Compra cm6 = new Compra(listaP6, ce1, fechaCompra6);

            compras.Add(cm1);
            compras.Add(cm2);
            compras.Add(cm3);
            compras.Add(cm4);
            compras.Add(cm5);
            compras.Add(cm6);

            clientes.ElementAt(0).Compras.Add(cm1);
            clientes.ElementAt(4).Compras.Add(cm2);
            clientes.ElementAt(0).Compras.Add(cm3);
            clientes.ElementAt(2).Compras.Add(cm4);
            clientes.ElementAt(2).Compras.Add(cm5);
            clientes.ElementAt(3).Compras.Add(cm6);
            #endregion
        }
        #endregion
        
        public void AgregarProducto(Producto p)
        {
            productos.Add(p);
        }

        public void AgregarCliente(Cliente c)
        {
            clientes.Add(c);
        }

        public void AgregarCompra(Compra cm)
        {
            compras.Add(cm);
        }

    }
}
