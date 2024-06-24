using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_FInal_M15_V1
{
    public partial class Rascunho : UserControl
    {
        ligacaoBD a = new ligacaoBD();

        public Rascunho()
        {
            InitializeComponent();            
            a.inicializa();
        }

        //img
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();

            img.Title = "Abrir Ficheiro";
            img.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            img.Filter = "Imagem(.jpg) | *.jpg";

            if (img.ShowDialog() == DialogResult.Cancel) return;
            {
                pictureBox1.BackgroundImage = Image.FromFile(img.FileName);
            }
        }

        //converter em 0 e 1
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        // Método público para definir o número do cartão de cidadão

        private string numeroCC;

        public void CartaoCidadao(string cc)
        {
            numeroCC = cc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "" || textBox1.Text == "" || textBox2.Text == "" || pictureBox1.BackgroundImage == null)
            {
                label8.Visible = true;
            }
            else
            {
                label2.Visible = false;

                //definir a query / pesquisa
                string query = "INSERT INTO Casa (img, n_cartao_cidadao, nome_rua, cidade_distrito, ano, preco, n_visitas, quando_visitada)" +
                                "VALUES(@img, @n_cartao_cidadao, @nome_rua, @cidade_distrito, @ano, @preco, @n_visitas, @quando_visitada)";

                //abrir a ligação à BD
                if (a.open_connection())
                {
                    //criar o comando e associar a query com a ligação através do construtor 
                    MySqlCommand cmd = new MySqlCommand(query, a.connection);

                    byte[] imgBytes = ImageToByteArray(pictureBox1.BackgroundImage);

                    cmd.Parameters.AddWithValue("@img", imgBytes);
                    cmd.Parameters.AddWithValue("@ano", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@preco", maskedTextBox2.Text);
                    cmd.Parameters.AddWithValue("@n_visitas", maskedTextBox3.Text);
                    cmd.Parameters.AddWithValue("@quando_visitada", maskedTextBox4.Text);
                    cmd.Parameters.AddWithValue("@nome_rua", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cidade_distrito", textBox2.Text);
                    cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                    //executar o comando 
                    cmd.ExecuteNonQuery();

                    //fechar a ligação à BD 
                    a.close_connection();

                    this.Visible = false;

                    MessageBox.Show("Registro feito com sucesso!");
                }

            }
        }
    }
}
