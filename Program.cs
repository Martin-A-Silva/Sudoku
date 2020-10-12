using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] matriz = new int [9,9];   //Primer casilla (i) son filas, segunda casilla (j) son columnas
            matriz = generarMatriz();
            
            Console.ReadKey();
        }

        static int [,] generarMatriz(){
            int [,] matriz = new int [9,9];
            int numero;
            Random rnd = new Random();
            bool check = false;
            int fallos = 0;
            for (int i = 0; i < 9; i++)
            {
                InicioFila:
                for (int j = 0; j < 9; j++)
                {
                    do
                    {
                        numero = rnd.Next(1, 10);
                        if (CheckColumna.checkColumna(matriz, j, numero) || CheckFila.checkFila(matriz, i, numero) || CheckSubMatriz.checkSubMatriz(matriz,i,j,numero))
                        {
                            check = true;
                            fallos++;
                            check = false;
                            check = true;

                            /*for (int k = 0; k < 9; k++)
                            {
                                for (int l = 0; l < 9; l++)
                                {
                                    Console.Write(matriz[k, l] + " ");
                                }
                                Console.WriteLine();
                            }*/
                        }
                        else
                        {
                            fallos = 0;
                            matriz[i, j] = numero;
                            check = false;
                        }
                        if (fallos > 20)
                        {
                            for(int k=0; k < 9; k++)
                            {
                                matriz[i, k] = 0;
                            }
                            fallos = 0;
                            goto InicioFila;
                        }
                    } while (check == true);
                    

                }
            }
            Console.WriteLine("Matriz final:");
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
        


        /*static void checkSubMatriz(int [][] matriz){    //recibe matriz de 3x3 y se fija si hay numeros repetidos

        }*/

        /*static void checkFila(int [] fila){     
        }

        static void checkColumna(int [] columna){   //recibe un array y se fija si hay numeros repetidos
        }*/
    }
}
