using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteEmpresa : Cliente
    {
        private string razonSocial;
        private long rut;
        private double descuento;

        public ClienteEmpresa(List<Compra> compras, string nombre, string contraseña, string email, DateTime fecha, EnumProcedencia procedencia, string direccion, string nombreDeUsuario, string razonSocial, long rut, double descuento):
        base(compras, nombre, contraseña, email, fecha, procedencia, direccion, nombreDeUsuario)
        {
            this.razonSocial = razonSocial;
            this.rut = rut;
            this.descuento = descuento;
        }

        #region Properties
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public long Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        #endregion

        public override double calcularPorcentaje()
        {
            double des = descuento;

            if (this.Antiguedad() >= 2)
            {
                des += descuentazo;
                if (this.Antiguedad() >= 5)
                    des += descuento; 
            }
            return des;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Rut:{0}", Rut);
        }
    }
}
