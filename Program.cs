using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace Sudoku
{
    public partial class Program : Form
    {
        private Panel panel1;
        private Button JuegoNuevoBtn;
        private Button MosSolBtn;
        private int[,] matriz = new int[9, 9];
        private int[,] matrizSol = new int[9, 9];
        private SudokuCell[,] cells;

        public Program()
        {
            InitializeComponent();

            cells = new SudokuCell[9, 9];   //NO BORRAR      

            createCells(cells, panel1);  //NO BORRAR        

            Generar(2);

        }

        static void Main(string[] args)
        {
        
            
            
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());

            Console.WriteLine();

            

            //Console.ReadKey();

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.JuegoNuevoBtn = new System.Windows.Forms.Button();
            this.MosSolBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 376);
            this.panel1.TabIndex = 0;
            // 
            // JuegoNuevoBtn
            // 
            this.JuegoNuevoBtn.Location = new System.Drawing.Point(76, 394);
            this.JuegoNuevoBtn.Name = "JuegoNuevoBtn";
            this.JuegoNuevoBtn.Size = new System.Drawing.Size(105, 31);
            this.JuegoNuevoBtn.TabIndex = 1;
            this.JuegoNuevoBtn.Text = "Juego Nuevo";
            this.JuegoNuevoBtn.UseVisualStyleBackColor = true;
            this.JuegoNuevoBtn.Click += new System.EventHandler(this.JuegoNuevoBtn_Click);
            // 
            // MosSolBtn
            // 
            this.MosSolBtn.Location = new System.Drawing.Point(196, 394);
            this.MosSolBtn.Name = "MosSolBtn";
            this.MosSolBtn.Size = new System.Drawing.Size(114, 31);
            this.MosSolBtn.TabIndex = 2;
            this.MosSolBtn.Text = "Mostrar Solución";
            this.MosSolBtn.UseVisualStyleBackColor = true;
            this.MosSolBtn.Click += new System.EventHandler(this.MosSolBtn_Click);
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(385, 458);
            this.Controls.Add(this.MosSolBtn);
            this.Controls.Add(this.JuegoNuevoBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku 3000";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);

        }

        private void JuegoNuevoBtn_Click(object sender, EventArgs e)
        {
            /* Tiene que aparecer un menú pidiendo dificultad Facil/medio/dificil, 
             * generar la matriz correspondiente con códigos 1/2/3 para dificultad
             * y llenar las celdas del panel, dejando en estado bloqueado a las
             * que son solución
             */

            SeleccionDificultad form1 = new SeleccionDificultad();
            int dificultad = form1.EligeDificultad();

            matriz = new int[9, 9];
            matrizSol = new int[9, 9];

            Generar(dificultad);

        }

        private void MosSolBtn_Click(object sender, EventArgs e)
        {
            /* Tiene que reemplazar lo que esté en el panel (matrizNoSol)
             * por la matriz solucion (matrizSol)
             */
        }

        private void Program_Load(object sender, EventArgs e)
        {

        }

        private void Generar(int dificultad)
        {
            Console.WriteLine(dificultad);
            // SelecDif(matriz, dificultad);
            generarMatriz(matriz);  //NO BORRAR
            matrizSol = (int[,])matriz.Clone();     //NO BORRAR
            SelecDif(matriz, dificultad);  // Esto va en el boton de juego nuevo, está acá por motivos de testeo, borrar cuando esté implementado el botón

 
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[j, i].Text = matriz[i, j] == 0 ? "" : matriz[i, j].ToString();
                    cells[j, i].Enabled = (matriz[i, j] == 0);
                    Console.Write(matriz[i, j] + " ");


                }

                Console.WriteLine();

            }
            Console.WriteLine("solucion:");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrizSol[i, j] + " ");
                }

                Console.WriteLine();

            }

            panel1.Refresh();

            

 
        }
    }
}
