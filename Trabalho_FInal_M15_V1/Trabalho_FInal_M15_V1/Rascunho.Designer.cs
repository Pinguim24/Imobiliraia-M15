namespace Trabalho_FInal_M15_V1
{
    partial class Rascunho
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new Button();
            maskedTextBox4 = new MaskedTextBox();
            maskedTextBox3 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            maskedTextBox1 = new MaskedTextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            openFileDialog1 = new OpenFileDialog();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(629, 461);
            button2.Name = "button2";
            button2.Size = new Size(111, 35);
            button2.TabIndex = 70;
            button2.Text = "Publicar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // maskedTextBox4
            // 
            maskedTextBox4.Anchor = AnchorStyles.Left;
            maskedTextBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox4.Location = new Point(141, 260);
            maskedTextBox4.Mask = "00/00/0000     00:00";
            maskedTextBox4.Name = "maskedTextBox4";
            maskedTextBox4.Size = new Size(168, 29);
            maskedTextBox4.TabIndex = 69;
            // 
            // maskedTextBox3
            // 
            maskedTextBox3.Anchor = AnchorStyles.Left;
            maskedTextBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox3.Location = new Point(141, 198);
            maskedTextBox3.Mask = "0000000";
            maskedTextBox3.Name = "maskedTextBox3";
            maskedTextBox3.Size = new Size(168, 29);
            maskedTextBox3.TabIndex = 68;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Anchor = AnchorStyles.Left;
            maskedTextBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox2.Location = new Point(141, 139);
            maskedTextBox2.Mask = "0000000000.00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(168, 29);
            maskedTextBox2.TabIndex = 67;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Anchor = AnchorStyles.Left;
            maskedTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox1.Location = new Point(141, 82);
            maskedTextBox1.Mask = "0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(168, 29);
            maskedTextBox1.TabIndex = 66;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(141, 386);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(168, 28);
            textBox2.TabIndex = 65;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(141, 318);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 28);
            textBox1.TabIndex = 64;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(11, 148);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 63;
            label6.Text = "Preço:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(600, 335);
            button1.Name = "button1";
            button1.Size = new Size(140, 28);
            button1.TabIndex = 62;
            button1.Text = "Inserir Imagem da Casa";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(9, 269);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 61;
            label5.Text = "Quando Visitada:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 207);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 60;
            label4.Text = "Nº de Visitas:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 91);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 59;
            label3.Text = "Ano:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 394);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 58;
            label2.Text = "Cidade e Destrito:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(9, 326);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 57;
            label1.Text = "Nome Da Rua:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(330, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 247);
            pictureBox1.TabIndex = 56;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(9, 11);
            label7.Name = "label7";
            label7.Size = new Size(191, 54);
            label7.TabIndex = 71;
            label7.Text = "Anunciar";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.IndianRed;
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(11, 448);
            label8.Name = "label8";
            label8.Size = new Size(232, 24);
            label8.TabIndex = 72;
            label8.Text = "*Todos os campos precisam de ser preenchidos e \r\n  tem de escolher uma imgem";
            label8.Visible = false;
            // 
            // Anunciar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fundo_Anunciar;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(label8);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(maskedTextBox4);
            Controls.Add(maskedTextBox3);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Anunciar";
            Size = new Size(744, 501);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private MaskedTextBox maskedTextBox4;
        private MaskedTextBox maskedTextBox3;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox maskedTextBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Button button1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label7;
        private OpenFileDialog openFileDialog1;
        private Label label8;
    }
}
