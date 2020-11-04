using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Sudoku
{
    public partial class Program : Form
    {
        private Panel panel1;
        private Button JuegoNuevoBtn;
        private Button MosPistaBtn;
        private int[,] matriz = new int[9, 9];
        private int[,] matrizSol = new int[9, 9];
        private SudokuCell[,] cells;

        public Program()
        {
            InitializeComponent();

            cells = new SudokuCell[9, 9];   //NO BORRAR      

            createCells(cells, panel1);  //NO BORRAR        

            generarPartida(2);

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
            this.MosPistaBtn = new System.Windows.Forms.Button();
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
            // MosPistaBtn
            // 
            this.MosPistaBtn.Location = new System.Drawing.Point(196, 394);
            this.MosPistaBtn.Name = "MosPistaBtn";
            this.MosPistaBtn.Size = new System.Drawing.Size(114, 31);
            this.MosPistaBtn.TabIndex = 2;
            this.MosPistaBtn.Text = "Mostrar Pista";
            this.MosPistaBtn.UseVisualStyleBackColor = true;
            this.MosPistaBtn.Click += new System.EventHandler(this.MosSolBtn_Click);
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(385, 458);
            this.Controls.Add(this.MosPistaBtn);
            this.Controls.Add(this.JuegoNuevoBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Program";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku 3000";
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

            if (dificultad != 0)
            {
                matriz = new int[9, 9];
                matrizSol = new int[9, 9];

                generarPartida(dificultad);
            }

            

        }

        private void MosSolBtn_Click(object sender, EventArgs e)
        {
            /* Tiene que llenar al azar una celda correctamente,
             * poniendo un valor de la matrizSol en su celda vacía correspondiente
             */
        }
    }
    }
