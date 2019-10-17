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

        public ClienteEmpresa(List<Compra> compras, string nombre, string contraseña, string email, DateTime fecha, EnumProcedencia procedencia, string direccion, string nombreDeUsuario, string razonSocial, long rut):
        base(compras, nombre, contraseña, email, fecha, procedencia, direccion, nombreDeUsuario)
        {
            this.razonSocial = razonSocial;
            this.rut = rut;
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
        #endregion

        public override double calcularPorcentaje()
        {
            double des = 0;
            //Todo pa tu body
            if (this.Procedencia == EnumProcedencia.INTERIOR)
            {
                des += 0.05;
            }

            return des;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Rut:{0}", Rut);
        }
    }
}
