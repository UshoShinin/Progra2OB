using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class ClienteEmpresa : Cliente
    {
        private string razonSocial;
        private long rut;

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
        public override double calcularPorcentaje()
        {
            double des = 0;
            if (this.Procedencia == EnumProcedencia.INTERIOR)
            {
                des += 0.05;
            }

            return des;
        }

    }
}
