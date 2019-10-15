using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteComun : Cliente
    {
        
        private int cedula;
        private int celular;

        public ClienteComun(List<Compra> compras, string nombre, string contraseña, string email, DateTime fecha, EnumProcedencia procedencia, string direccion, string nombreDeUsuario, int cedula, int celular) :
        base(compras, nombre, contraseña, email, fecha, procedencia, direccion, nombreDeUsuario)
        {
            this.cedula = cedula;
            this.celular = celular;
        }

        #region Properties
        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }


        public int Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        #endregion

        #region Methods
        public static bool CedulaValida(int cedula)
        {
            return cedula > 999999;
        }

        public static bool CalularValido(int celular)
        {
            return celular > 99999999 && celular < 999999999;
        }

        public override double calcularPorcentaje()
        {
            double des = 0;
            if (this.Procedencia == EnumProcedencia.INTERIOR)
            {
                des += 0.05;
            }
            if (this.Antiguedad() >= 2)
                des += 0.05;//Esto lo tiene que decir el profesoraso
            return des;
        }
        #endregion

        public override string ToString()
        {
            return base.ToString() + string.Format(" Cédula:{0}",Cedula);
        }

    }
}
