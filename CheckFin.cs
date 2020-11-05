using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form
    {
        public bool checkFila(int[,] matriz, int fila, int numero)  //recibe una fila y devuelve true si hay al menos una repeticion de numero
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == fila)
                    {
                        if (matriz[i, j] == numero)
                        {
                            //Console.WriteLine("El número " + numero + " ya está en columna " + fila + " y fila " + j);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
