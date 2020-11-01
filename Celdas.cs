using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form
    {
        private void createCells(SudokuCell[,] cells, Panel panel1)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Create 81 cells for with styles and locations based on the index
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;



                    // Assign key press event for each cells
                    cells[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            
            if (cell.IsLocked)
                return;

            int value;



            
            if (int.TryParse(e.KeyChar.ToString(), out value))                  //ACÁ SE TIENEN QUE EJECUTAR LOS MÉTODOS DE CHEQUEO TAMBIÉN
            {
                

                if (value == 0)
                {
                    cell.Clear();
                    matriz[cell.Y, cell.X] = value;
                }
                else
                {
                    cell.Text = value.ToString();


                    if (checkColumna(matriz, cell.X, value))
                    {
                        cell.ForeColor = Color.Red;
                    }
                    else
                    {
                        matriz[cell.Y, cell.X] = value;
                        cell.ForeColor = SystemColors.ControlDarkDark;
                    }
                }


            }

            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {                    
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }


            /*if (!checkColumna || checkFila || checkSubMatriz)
            {
                cell.ForeColor = Color.Red;
            }
            else if (checkMatrizCompleta)
            {
                //cartel de partida ganada
            }*/
        }
    }
}
