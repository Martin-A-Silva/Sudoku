using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form 
    {
        public bool checkFin()
        {                       
            foreach (var cell in cells)
            {
                
                if (cell.Value == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
