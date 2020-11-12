
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{

    public partial class Program : Form
    {

        public int[,] SelecDif(int[,] matriz, int dificulty)
        {
            int maxNum = 0;
            int contador = 0;
            int aux = 0;
            int aux2 = 0;
            Random rnd = new Random();

            if (dificulty == 1)
            {
                maxNum = 32;
            }
            else if (dificulty == 2)
            {
                maxNum = 41;
            }
            else if (dificulty == 3)
            {
                maxNum = 53;
            }
            else
            {
                Console.WriteLine("La dificultad ingresada no es valida.");
            }

            while (contador < maxNum)
            {
                for (int fila = 0; fila < 9; fila++)
                {
                    for (int columna = 0; columna < 9; columna++)
                    {

                        if (aux < maxNum)
                        {
                            aux2 = rnd.Next(1, 5);

                            if (aux2 == 1)
                            {

                                matriz[fila, columna] = 0;
                                aux++;
                                contador++;
                            }
                        }
                    }
                }
            }

            return matriz;
        }

    }
}
