using System;

namespace Sudoku
{
	static class CheckSubMatriz
	{

		public static bool checkSubMatriz(int[,] matriz, int fila, int col, int numero) // recibe una matriz 9x9 y revisa que no se repitan numeros en las submatrices, si hay al menos una repeticion devuelve true
		{
			int imin,imax, jmin, jmax;
			imin = (fila / 3)*3;
			imax = imin + 3;
			jmin = (col / 3)*3;
			jmax = jmin + 3;

			for (int i = imin; i < imax; i++)
            {
				for (int j=jmin; j<jmax; j++)
                {
                    if (matriz[i, j] == numero)
                    {
						return true;
                    }
                }
            }
			return false;
        }

	}
}