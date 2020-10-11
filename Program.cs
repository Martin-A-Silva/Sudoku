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
            
        }

        static int [,] generarMatriz(){
            int [,] matriz = new int [9,9];
            Random rnd = new Random();
            bool check = false;
            
            for (int i=0;i<9;i++){
                for(int j=0;j<9;j++){
                    do{
                        matriz[i,j] = rnd.Next(1,9);
                        check = CheckFila.checkFila(matriz,i);
                        check = CheckColumna.checkColumna(matriz,j);
                        check = CheckSubMatriz.checkSubMatriz(matriz);
                    }while(check);
                    
                }
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
