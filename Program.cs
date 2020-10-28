using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Sudoku
{
    public partial class Program : Form
    {
        public Program()
        {
            InitializeComponent();
        }
        static void Main(string[] args)
        {
        
            int[,] matriz = new int[9, 9];   //Primer casilla (i) son filas, segunda casilla (j) son columnas


            matriz = Generador.generarMatriz();

            Console.WriteLine();

            matriz = Dificulty.SelecDif(matriz, 1);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }

                Console.WriteLine();

            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
            

            //Console.ReadKey();
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(379, 261);
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku 3000";
            this.ResumeLayout(false);

        }

        

    }
}
