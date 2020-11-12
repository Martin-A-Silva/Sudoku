using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Program : Form
    {
        public void Pista()
        {

            Random numero = new Random();
            int colum, fila;
            bool pista = false;

            do
            {
                colum = numero.Next(0, 9);
                fila = numero.Next(0, 9);
                if (matriz[fila, colum] == 0)
                {
                    matriz[fila, colum] = matrizSol[fila, colum];
                    cells[colum, fila].Text = matriz[fila, colum].ToString();
                    cells[colum, fila].Value = matriz[fila, colum];
                    cells[colum, fila].Enabled = false;
                    pista = true;
                }
                if (checkFin() == true)
                {
                    MessageBox.Show("Felicidades ha completado correctamente el juego", "Fin", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                }
            } while (pista == false);
        }
    }
}
