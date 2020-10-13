namespace Sudoku
{
    static class CheckColumna
    {
        public static bool checkColumna(int[,] matriz, int columna, int numero)  //recibe una columna y devuelve true si hay al menos una repeticion de numero
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == columna)
                    {
                        if (matriz[i, j] == numero)
                        {
                            //Console.WriteLine("El número " + numero+" ya está en columna "+columna+" y fila "+i);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
