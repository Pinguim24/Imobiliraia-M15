namespace Trabalho_FInal_M15_V1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Stencil", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(275, 107);
            label1.Name = "label1";
            label1.Size = new Size(66, 21);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(172, 153);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(259, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(172, 212);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(259, 27);
            textBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.Olho_Branco;
            button1.Location = new Point(436, 210);
            button1.Name = "button1";
            button1.Size = new Size(31, 31);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(172, 138);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Mail";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(171, 197);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 5;
            label3.Text = "Palavra-Passe";
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            button2.ForeColor = Color.Silver;
            button2.Location = new Point(239, 238);
            button2.Name = "button2";
            button2.Size = new Size(139, 22);
            button2.TabIndex = 6;
            button2.Text = "Ainda não tenho conta";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(490, 337);
            button3.Name = "button3";
            button3.Size = new Size(118, 32);
            button3.TabIndex = 7;
            button3.Text = "Entrar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = Properties.Resources.sair_branco;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Location = new Point(5, 346);
            button4.Name = "button4";
            button4.Size = new Size(30, 30);
            button4.TabIndex = 8;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.IndianRed;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(220, 283);
            label4.Name = "label4";
            label4.Size = new Size(190, 15);
            label4.TabIndex = 23;
            label4.Text = "*Palavra-Passe ou Mail incorretos";
            label4.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(620, 381);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Imobiliário";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label2;
        private Label label3;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label4;
    }
}