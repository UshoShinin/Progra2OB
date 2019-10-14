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
            MostrarProductos();
        }
        public static int PedirNumero(string msg, string msgError, int min, int max){
            int opc;
            bool exito = false;
            do
            {
                Console.WriteLine(msg + min +" y " + max);
                string sOpc = Console.ReadLine();
                if (int.TryParse(sOpc, out opc) && (opc >= min && opc <= max)){
                    exito = true;
                }
                else
                {
                    Console.WriteLine(msgError + min + " y " + max);
                }

            } while (!exito);
            return opc;
        }

        public static void MostrarProductos()
        {
            int cont=0;
            Console.WriteLine("-Tipos de producto");
            Console.WriteLine("1.Todos");
            Console.WriteLine("2.Frescos");
            Console.WriteLine("3.Congelados");
            Console.WriteLine("4.Hogar");
            Console.WriteLine("5.Textiles");
            Console.WriteLine("6.Tecnología");
            Console.WriteLine("0.Volver");
            int opc = PedirNumero("Ingrese una opcion entre ", "El valor debe ser numérico y estar entre ", 0, 6);

            if (opc == 1){
                foreach (Producto p in Administradora.Instancia.Productos)
                {
                    Console.WriteLine(p);
                    cont++;
                }
                if(cont==0)
                    Console.WriteLine("No hay productos registrados");
            }else if(opc == 0){
                Console.WriteLine("Chiao");
            }
            else{
                foreach (Producto p in Administradora.Instancia.Productos)
                {
                    if (p.Categoria == (Producto.EnumCategoria)opc - 1)
                    {
                        Console.WriteLine(p);
                        cont++;
                    }

                }
                if (cont == 0)
                    Console.WriteLine("No hay productos de esta categoría");
            }
            Console.ReadLine();

        }

    }
}
