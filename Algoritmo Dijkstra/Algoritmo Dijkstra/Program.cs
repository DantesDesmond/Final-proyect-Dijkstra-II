using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int inicio = 0;
            int final = 0;
            int distancia = 0;
            int n = 0;
            int cantNodos = 7;
            string dato = "";
            int actual = 0;
            int columna = 0;


            //Creacion del grafo

            Grafo miGrafo = new Grafo(cantNodos);
            miGrafo.AdicionaArista(0, 1, 2);
            miGrafo.AdicionaArista(0, 3, 1);
            miGrafo.AdicionaArista(1, 3, 3);
            miGrafo.AdicionaArista(1, 4, 10);
            miGrafo.AdicionaArista(2, 0, 4);
            miGrafo.AdicionaArista(2, 5, 5);
            miGrafo.AdicionaArista(3, 2, 2);
            miGrafo.AdicionaArista(3, 4, 2);
            miGrafo.AdicionaArista(3, 5, 8);
            miGrafo.AdicionaArista(3, 6, 4);
            miGrafo.AdicionaArista(4, 6, 6);
            miGrafo.AdicionaArista(6, 5, 1);

            miGrafo.MuestraAdyacencia();

            Console.WriteLine("Pasa el indice para el primer nodo");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo terminal");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);

            // Hacemos una tabla

            int[,] tabla = new int[cantNodos, 3];

            // Arranque de la tabla con contador for

            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0;
            }
            tabla[inicio, 1] = 0;
            MostrarTabla(tabla);

            // Arranque DKAS
            actual = inicio;

            do
            {
                tabla[actual, 0] = 1;

                for (columna = 0; columna < cantNodos; columna++)
                {

                    if (miGrafo.ObtenerAdyancencia(actual, columna) != 0)
                    {
                        distancia = miGrafo.ObtenerAdyancencia(actual, columna) + tabla[actual, 1];

                        if (distancia < tabla[columna, 1])
                        {
                            tabla[columna, 1] = distancia;
                            tabla[columna, 2] = actual;

                        }
                    }


                }

                int indiceMenor = -1;
                int distanciaMenor = int.MaxValue;

                for (int x = 0; x < cantNodos; x++)
                {
                    if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                    {
                        indiceMenor = x;
                        distanciaMenor = tabla[x, 1];
                    }
                }

                actual = indiceMenor;

            } while (actual != -1);

            MostrarTabla(tabla);

            // saquese la via

            List<int> ruta = new List<int>();
            int nodo = final;

            while (nodo != inicio)
            {

                ruta.Add(nodo);
                nodo = tabla[nodo, 2];
            }

            ruta.Add(inicio);
            ruta.Reverse();

            foreach (int posicion in ruta)
                Console.Write("{0}->", posicion);
            Console.WriteLine();
        }

        public static void MostrarTabla(int[,] pTabla)
        {
            int n = 0;

            for (n = 0; n < pTabla.GetLength(0); n++)
            {
                Console.WriteLine("{0}-> {1}\t{2}\t{3}", n, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);
            }

            Console.WriteLine("---------");
        }
    }
}


            
            