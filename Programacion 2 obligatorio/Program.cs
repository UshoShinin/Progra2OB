using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = PedirNumero("Ingrese una opcion entre 1 y 3", "El valor debe ser numérico y estar entre 1 y 3", 1, 3);
            switch (opc)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
            }
        }
        public static int PedirNumero(string msg, string msgError, int min, int max){
            int opc;
            bool exito = false;
            do
            {
                Console.WriteLine(msg);
                string sOpc = Console.ReadLine();
                if (int.TryParse(sOpc, out opc) && (opc >= min && opc <= max)){
                    exito = true;
                }
                else
                {
                    Console.WriteLine(msgError);
                }

            } while (!exito);
            return opc;
        }

    }
}
