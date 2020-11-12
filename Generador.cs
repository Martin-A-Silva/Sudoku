using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
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

  
      
        

        private void generarPartida(int dificultad)
        {
            
            generarMatriz(matriz);
            matrizSol = (int[,])matriz.Clone();
            SelecDif(matriz, dificultad);
     
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[j, i].Text = matriz[i, j] == 0 ? "" : matriz[i, j].ToString();
                    cells[j, i].Value = matriz[i, j];
                    cells[j, i].Enabled = (matriz[i, j] == 0);
                    
                }

            }            
            panel1.Refresh();
        }
    }
}
