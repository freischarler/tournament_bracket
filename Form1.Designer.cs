
namespace FixT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Aside = new System.Windows.Forms.ListBox();
            this.Bside = new System.Windows.Forms.ListBox();
            this.cList = new System.Windows.Forms.RichTextBox();
            this.Run = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTournament = new System.Windows.Forms.TextBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMat = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cBcategoria = new System.Windows.Forms.ComboBox();
            this.cBbelt = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMat)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Aside
            // 
            this.Aside.FormattingEnabled = true;
            this.Aside.Location = new System.Drawing.Point(6, 19);
            this.Aside.Name = "Aside";
            this.Aside.Size = new System.Drawing.Size(261, 251);
            this.Aside.TabIndex = 1;
            // 
            // Bside
            // 
            this.Bside.FormattingEnabled = true;
            this.Bside.Location = new System.Drawing.Point(9, 19);
            this.Bside.Name = "Bside";
            this.Bside.Size = new System.Drawing.Size(270, 251);
            this.Bside.TabIndex = 2;
            // 
            // cList
            // 
            this.cList.Location = new System.Drawing.Point(6, 19);
            this.cList.Name = "cList";
            this.cList.Size = new System.Drawing.Size(331, 257);
            this.cList.TabIndex = 4;
            this.cList.Text = "";
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(57, 19);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(95, 39);
            this.Run.TabIndex = 5;
            this.Run.Text = "Generar llave";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Categoría";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cinturón";
            // 
            // txtTournament
            // 
            this.txtTournament.Location = new System.Drawing.Point(57, 22);
            this.txtTournament.Name = "txtTournament";
            this.txtTournament.Size = new System.Drawing.Size(137, 20);
            this.txtTournament.TabIndex = 11;
            this.txtTournament.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(57, 64);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(95, 39);
            this.btnPDF.TabIndex = 14;
            this.btnPDF.Text = "Generar PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBbelt);
            this.groupBox1.Controls.Add(this.cBcategoria);
            this.groupBox1.Controls.Add(this.txtMat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTournament);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 162);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del torneo";
            // 
            // txtMat
            // 
            this.txtMat.Location = new System.Drawing.Point(68, 126);
            this.txtMat.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtMat.Name = "txtMat";
            this.txtMat.Size = new System.Drawing.Size(126, 20);
            this.txtMat.TabIndex = 20;
            this.txtMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "MAT n°";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cList);
            this.groupBox2.Location = new System.Drawing.Point(235, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 282);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Luchadores ( id , equipo )";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Run);
            this.groupBox3.Controls.Add(this.btnPDF);
            this.groupBox3.Location = new System.Drawing.Point(12, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 114);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controles";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Aside);
            this.groupBox4.Location = new System.Drawing.Point(12, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 282);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lado A";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Bside);
            this.groupBox5.Location = new System.Drawing.Point(293, 300);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(288, 282);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lado B";
            // 
            // cBcategoria
            // 
            this.cBcategoria.FormattingEnabled = true;
            this.cBcategoria.Items.AddRange(new object[] {
            "Galo",
            "Pluma",
            "Pena",
            "Leve",
            "Medio",
            "Medio pesado",
            "Pesado ",
            "Super pesado",
            "Ultra pesado",
            "Absoluto"});
            this.cBcategoria.Location = new System.Drawing.Point(68, 53);
            this.cBcategoria.Name = "cBcategoria";
            this.cBcategoria.Size = new System.Drawing.Size(126, 21);
            this.cBcategoria.TabIndex = 21;
            // 
            // cBbelt
            // 
            this.cBbelt.FormattingEnabled = true;
            this.cBbelt.Items.AddRange(new object[] {
            "Blanco",
            "Gris",
            "Amarillo",
            "Naranja",
            "Verde",
            "Azul",
            "Violeta",
            "Marron",
            "Negro"});
            this.cBbelt.Location = new System.Drawing.Point(68, 87);
            this.cBbelt.Name = "cBbelt";
            this.cBbelt.Size = new System.Drawing.Size(126, 21);
            this.cBbelt.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 601);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 640);
            this.MinimumSize = new System.Drawing.Size(610, 640);
            this.Name = "Form1";
            this.Text = "Tournament Bracket v1.0.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox Aside;
        private System.Windows.Forms.ListBox Bside;
        private System.Windows.Forms.RichTextBox cList;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTournament;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown txtMat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBcategoria;
        private System.Windows.Forms.ComboBox cBbelt;
    }
}

