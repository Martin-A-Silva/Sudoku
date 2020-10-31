using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SeleccionDificultad : Form
    {
        private int dificultad = 0;
        public SeleccionDificultad()
        {
            InitializeComponent();
        }

        private void SeleccionDificultad_Load(object sender, EventArgs e)
        {

        }

        public int EligeDificultad()
        {
            this.optDificultadNormal.Select();
            this.optDificultadNormal.Checked = true;
            this.ShowDialog();


            return this.dificultad;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (optDificultadFacil.Checked)
            {
                this.dificultad = 1;
            } else if (optDificultadNormal.Checked)
            {
                this.dificultad = 2;
            } else if (optDificultadDificil.Checked)
            {
                this.dificultad = 3;
            }



            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
