namespace Sudoku
{
    partial class SeleccionDificultad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optDificultadFacil = new System.Windows.Forms.RadioButton();
            this.optDificultadNormal = new System.Windows.Forms.RadioButton();
            this.btnJugar = new System.Windows.Forms.Button();
            this.optDificultadDificil = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optDificultadDificil);
            this.groupBox1.Controls.Add(this.optDificultadNormal);
            this.groupBox1.Controls.Add(this.optDificultadFacil);
            this.groupBox1.Location = new System.Drawing.Point(33, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // optDificultadFacil
            // 
            this.optDificultadFacil.AutoSize = true;
            this.optDificultadFacil.Location = new System.Drawing.Point(6, 21);
            this.optDificultadFacil.Name = "optDificultadFacil";
            this.optDificultadFacil.Size = new System.Drawing.Size(58, 21);
            this.optDificultadFacil.TabIndex = 1;
            this.optDificultadFacil.TabStop = true;
            this.optDificultadFacil.Text = "Facil";
            this.optDificultadFacil.UseVisualStyleBackColor = true;
            this.optDificultadFacil.CheckedChanged += new System.EventHandler(this.SeleccionDificultad_Load);
            // 
            // optDificultadNormal
            // 
            this.optDificultadNormal.AutoSize = true;
            this.optDificultadNormal.Location = new System.Drawing.Point(6, 48);
            this.optDificultadNormal.Name = "optDificultadNormal";
            this.optDificultadNormal.Size = new System.Drawing.Size(74, 21);
            this.optDificultadNormal.TabIndex = 2;
            this.optDificultadNormal.TabStop = true;
            this.optDificultadNormal.Text = "Normal";
            this.optDificultadNormal.UseVisualStyleBackColor = true;
            this.optDificultadNormal.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(63, 170);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(102, 49);
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = true;
            this.btnJugar.Click += new System.EventHandler(this.button1_Click);
            // 
            // optDificultadDificil
            // 
            this.optDificultadDificil.AutoSize = true;
            this.optDificultadDificil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDificultadDificil.Location = new System.Drawing.Point(6, 75);
            this.optDificultadDificil.Name = "optDificultadDificil";
            this.optDificultadDificil.Size = new System.Drawing.Size(62, 21);
            this.optDificultadDificil.TabIndex = 3;
            this.optDificultadDificil.TabStop = true;
            this.optDificultadDificil.Text = "Dificil";
            this.optDificultadDificil.UseVisualStyleBackColor = true;
            // 
            // SeleccionDificultad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 239);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SeleccionDificultad";
            this.Text = "Dificultad";
            this.Load += new System.EventHandler(this.SeleccionDificultad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDificultadNormal;
        private System.Windows.Forms.RadioButton optDificultadFacil;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.RadioButton optDificultadDificil;
    }
}