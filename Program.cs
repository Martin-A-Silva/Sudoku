using System;
using System.Collections.Generic;
using System.Linq;



namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
        
            int[,] matriz = new int[9, 9];   //Primer casilla (i) son filas, segunda casilla (j) son columnas


            matriz = generarMatriz();

            Console.WriteLine();

            matriz = Dificulty.SelecDif(matriz, 1);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }

                Console.WriteLine();

            }
            Console.ReadKey();
            
        }

        static int[,] generarMatriz()
        {
            int[,] matriz = new int[9, 9];
            int numero;
            bool numeroColocado = true;
            int fallos = 0;
            Random rnd = new Random();
            List<int> numerosRestantesEnFila = new List<int> { };
            List<int> numerosIntentadosEnCelda = new List<int> { };
            IEnumerable<int> numerosRestantesEnCelda;
            int[] defArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 9; i++)
            {
            InicioFila:
                numerosRestantesEnFila.AddRange(defArr);    //Reiniciamos la lista de números faltantes en la fila
                for (int j = 0; j < 9; j++)
                {
                    do
                    {

                        numerosRestantesEnCelda = numerosRestantesEnFila.Where(z => !numerosIntentadosEnCelda.Contains(z));          //Filtramos las numeros restantes en la fila con los ya intentados en la celda              
                        numero = numerosRestantesEnCelda.ToList().ElementAt(rnd.Next(0, numerosRestantesEnCelda.ToList().Count));       //Elegimos aleatoriamente uno de los numeros filtrados

                        if (CheckColumna.checkColumna(matriz, j, numero) || CheckFila.checkFila(matriz, i, numero) ||
                            CheckSubMatriz.checkSubMatriz(matriz, i, j, numero) || numerosIntentadosEnCelda.Contains(numero))      //Evaluamos si el numero a colocar es válido
                        {

                            numeroColocado = false;
                            numerosIntentadosEnCelda.Add(numero);

                            if (numerosRestantesEnCelda.ToList().Count == 0)    //Cuando ya no quedan números por intentar, es imposible llenar la fila y hay que volver a llenarla, reini
                            {
                                numerosIntentadosEnCelda.Clear();

                                fallos++;                                       //Contador de fallas, si ocurre demasiado habrá que borrar 2 filas
                                for (int k = 0; k < 9; k++)
                                {
                                    matriz[i, k] = 0;
                                }
                                goto InicioFila;
                            }

                        }
                        else            //Si es válido lo colocamos, quitamos el numero de los restantes, y reiniciamos los numeros intentados
                        {
                            matriz[i, j] = numero;
                            numerosRestantesEnFila.Remove(numero);
                            numerosIntentadosEnCelda.Clear();

                            numeroColocado = true;
                        }
                        if (fallos > 20)        //Para cuando la fila es imposible de llenar, se borran 2 filas. La cantidad de fallos es arbitraria
                        {
                            numerosRestantesEnFila.Clear();
                            numerosIntentadosEnCelda.Clear();
                            for (int k = 0; k < 9; k++)
                            {
                                matriz[i, k] = 0;
                                matriz[i - 1, k] = 0;
                            }
                            fallos = 0;
                            i--;
                            goto InicioFila;
                        }
                    } while (numeroColocado == false);


                }

            }

            Console.WriteLine("Matriz generada:");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }

            return matriz;
        }

    }
}
