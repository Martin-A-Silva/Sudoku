using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form 
    {
        public bool checkFin()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
