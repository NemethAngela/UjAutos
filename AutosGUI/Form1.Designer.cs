namespace AutosGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            buttonMentés = new Button();
            labelAzonosito = new Label();
            labelRendszam = new Label();
            labelMarka = new Label();
            labelUrtartalom = new Label();
            labelAr = new Label();
            buttonElozo = new Button();
            buttonKovetkezo = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            buttonBezar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(239, 20);
            label1.Name = "label1";
            label1.Size = new Size(164, 45);
            label1.TabIndex = 0;
            label1.Text = "Járművek";
            // 
            // buttonMentés
            // 
            buttonMentés.Location = new Point(239, 85);
            buttonMentés.Name = "buttonMentés";
            buttonMentés.Size = new Size(139, 23);
            buttonMentés.TabIndex = 1;
            buttonMentés.Text = "Rekord mentése";
            buttonMentés.UseVisualStyleBackColor = true;
            buttonMentés.Click += buttonMentés_Click;
            // 
            // labelAzonosito
            // 
            labelAzonosito.AutoSize = true;
            labelAzonosito.Location = new Point(201, 135);
            labelAzonosito.Name = "labelAzonosito";
            labelAzonosito.Size = new Size(60, 15);
            labelAzonosito.TabIndex = 2;
            labelAzonosito.Text = "Azonosító";
            // 
            // labelRendszam
            // 
            labelRendszam.AutoSize = true;
            labelRendszam.Location = new Point(201, 176);
            labelRendszam.Name = "labelRendszam";
            labelRendszam.Size = new Size(61, 15);
            labelRendszam.TabIndex = 3;
            labelRendszam.Text = "Rendszám";
            // 
            // labelMarka
            // 
            labelMarka.AutoSize = true;
            labelMarka.Location = new Point(201, 216);
            labelMarka.Name = "labelMarka";
            labelMarka.Size = new Size(43, 15);
            labelMarka.TabIndex = 4;
            labelMarka.Text = "lMarka";
            // 
            // labelUrtartalom
            // 
            labelUrtartalom.AutoSize = true;
            labelUrtartalom.Location = new Point(201, 254);
            labelUrtartalom.Name = "labelUrtartalom";
            labelUrtartalom.Size = new Size(64, 15);
            labelUrtartalom.TabIndex = 5;
            labelUrtartalom.Text = "Űrtartalom";
            // 
            // labelAr
            // 
            labelAr.AutoSize = true;
            labelAr.Location = new Point(201, 296);
            labelAr.Name = "labelAr";
            labelAr.Size = new Size(19, 15);
            labelAr.TabIndex = 6;
            labelAr.Text = "Ár";
            // 
            // buttonElozo
            // 
            buttonElozo.Location = new Point(69, 216);
            buttonElozo.Name = "buttonElozo";
            buttonElozo.Size = new Size(75, 23);
            buttonElozo.TabIndex = 7;
            buttonElozo.Text = "Előző";
            buttonElozo.UseVisualStyleBackColor = true;
            buttonElozo.Click += buttonElozo_Click;
            // 
            // buttonKovetkezo
            // 
            buttonKovetkezo.Location = new Point(455, 208);
            buttonKovetkezo.Name = "buttonKovetkezo";
            buttonKovetkezo.Size = new Size(75, 23);
            buttonKovetkezo.TabIndex = 8;
            buttonKovetkezo.Text = "Következő";
            buttonKovetkezo.UseVisualStyleBackColor = true;
            buttonKovetkezo.Click += buttonKovetkezo_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(303, 127);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(303, 168);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(303, 209);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(303, 251);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(303, 291);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 13;
            // 
            // buttonBezar
            // 
            buttonBezar.Location = new Point(489, 357);
            buttonBezar.Name = "buttonBezar";
            buttonBezar.Size = new Size(75, 23);
            buttonBezar.TabIndex = 14;
            buttonBezar.Text = "Bezár";
            buttonBezar.UseVisualStyleBackColor = true;
            buttonBezar.Click += buttonBezar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 450);
            Controls.Add(buttonBezar);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(buttonKovetkezo);
            Controls.Add(buttonElozo);
            Controls.Add(labelAr);
            Controls.Add(labelUrtartalom);
            Controls.Add(labelMarka);
            Controls.Add(labelRendszam);
            Controls.Add(labelAzonosito);
            Controls.Add(buttonMentés);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonMentés;
        private Label labelAzonosito;
        private Label labelRendszam;
        private Label labelMarka;
        private Label labelUrtartalom;
        private Label labelAr;
        private Button buttonElozo;
        private Button buttonKovetkezo;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button buttonBezar;
    }
}