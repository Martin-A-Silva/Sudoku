using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form
    {
        public void generarMatriz(int[,] matriz)
        {
            
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

                        if (checkColumna(matriz, j, numero) || checkFila(matriz, i, numero) ||
                            checkSubMatriz(matriz, i, j, numero) || numerosIntentadosEnCelda.Contains(numero))      //Evaluamos si el numero a colocar es válido
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

            
        }

        private void createCells(SudokuCell[,] cells,Panel panel1)
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

                    panel1.Controls.Add(cells[i,j]);
                }
            }
        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            // Do nothing if the cell is locked
            if (cell.IsLocked)
                return;

            int value;



            // Add the pressed key value in the cell only if it is a number
            if (int.TryParse(e.KeyChar.ToString(), out value))                  //ACÁ SE TIENEN QUE EJECUTAR LOS MÉTODOS DE CHEQUEO TAMBIÉN
            {
                // Clear the cell value if pressed key is zero

                if (value == 0)
                {
                    cell.Clear();
                    matriz[cell.X, cell.Y] = value;
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
                        matriz[cell.X, cell.Y] = value;
                        cell.ForeColor = SystemColors.ControlDarkDark;
                    }
                }
                

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
