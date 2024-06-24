using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Trabalho_FInal_M15_V1
{
    public partial class Principal : Form
    {
        ligacaoBD a = new ligacaoBD();

        public int numeroCC;
        public string Gmail, Casa_favoritos;

        public Principal(string tipoConta, int cc, string gmail)
        {
            InitializeComponent();
            a.inicializa();

            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            label1.Text = "Casas";

            numeroCC = cc;
            Gmail = gmail;

            if (tipoConta == "comprador")
            {
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                button3.Visible = true;
                button4.Visible = true;
            }

            // Adicione o manipulador de evento para o fechamento do formulário
            this.FormClosing += new FormClosingEventHandler(this.Principal_FormClosing);

            panel6.Visible = true;

            panel1.Visible = false;
            panel4.Visible = false; //anunciar 
            panel7.Visible = false; //Conta

            string query = "SELECT img FROM Clientes WHERE n_cartao_cidadao = " + numeroCC;

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    /*O erro 'Unable to cast object of type 'System.DBNull' to type 'System.Byte[]'.' 
                      indica que o valor no banco de dados para a coluna img pode ser NULL, o que não pode 
                      ser diretamente convertido para um array de bytes (byte[]). Para resolver isso, você 
                      precisa verificar se o valor é DBNull antes de tentar a conversão.*/

                    if (reader["img"] != DBNull.Value)
                    {
                        byte[] imgBytes2 = (byte[])reader["img"];
                        Image img2 = ByteParamage(imgBytes2);
                        button9.BackgroundImage = img2;
                    }
                }
                reader.Close();
                a.close_connection();
            }
        }


        //para fechar a conexão quando se fechar o forms
        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (a.connection != null && a.connection.State == ConnectionState.Open)
            {
                a.close_connection();
            }
        }


        //Botão Casas
        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;
            label1.Text = "Casas";
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            panel1.Visible = true;

            Casa_favoritos = "casa";

            CarregarCasas();
        }

        //Botão Favoritos
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;
            label1.Text = "Favoritos";
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            panel1.Visible = true;

            Casa_favoritos = "favorito";

            Favoritos();
        }

        //Botão Anúncios
        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;
            label1.Text = "Anúncios";
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            panel1.Visible = true;

            Anuncios();
        }

        //Botão Anunciar
        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;

            panel4.Visible = true;
        }

        //Botão Conta
        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; //Casas            
            panel4.Visible = false; //Anunciar
            panel6.Visible = false; //Bem-Vindo
            label15.Visible = false;

            panel7.Visible = true; //Conta

            string query = "SELECT nome, telemovel, gmail, pass, img FROM Clientes WHERE n_cartao_cidadao = " + numeroCC;

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["img"] != DBNull.Value)
                    {
                        byte[] imgBytes2 = (byte[])reader["img"];
                        Image img2 = ByteParamage(imgBytes2);
                        pictureBox3.BackgroundImage = img2;
                    }
                    textBox3.Text = reader.GetString("nome");
                    maskedTextBox5.Text = reader.GetString("telemovel");
                    textBox6.Text = reader.GetString("gmail");
                    textBox7.Text = reader.GetString("pass");
                    textBox8.Text = textBox7.Text;
                }
                reader.Close();
                a.close_connection();
            }
        }

        //Inserir imgem
        private void button5_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Erro ao carregar a imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Converter imagem em bytes
        public byte[] ConverterImgParaByte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        //BOTÃO ANUNCIAR PUBICAR
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "" || textBox1.Text == "" || 
                    textBox2.Text == "" || pictureBox1.BackgroundImage == null)
                {
                    label8.Visible = true;
                }
                else
                {
                    label8.Visible = false;

                    //definir a query / pesquisa
                    string query = "INSERT INTO Casa (img, n_cartao_cidadao, nome_rua, cidade_distrito, ano, preco, n_visitas, quando_visitada)" +
                                    "VALUES(@img, @n_cartao_cidadao, @nome_rua, @cidade_distrito, @ano, @preco, @n_visitas, @quando_visitada)";

                    //abrir a ligação à BD
                    if (a.open_connection())
                    {
                        //criar o comando e associar a query com a ligação através do construtor 
                        MySqlCommand cmd = new MySqlCommand(query, a.connection);

                        byte[] imgBytes = ConverterImgParaByte(pictureBox1.BackgroundImage);

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

                        maskedTextBox1.Clear();
                        maskedTextBox2.Clear();
                        maskedTextBox3.Clear();
                        maskedTextBox4.Clear();
                        textBox1.Clear();
                        textBox2.Clear();

                        panel4.Visible = false;

                        panel3.Height = button1.Height;
                        panel3.Top = button1.Top;
                        label1.Text = "Casas";
                        panel1.Visible = true;
                        pictureBox1.BackgroundImage = null;

                        CarregarCasas();

                        MessageBox.Show("Registro feito com sucesso!");
                    }
                }
            }
            catch
            {
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                textBox1.Clear();
                textBox2.Clear();

                panel4.Visible = false;

                a.close_connection();

                panel3.Height = button1.Height;
                panel3.Top = button1.Top;
                panel1.Visible = true;
                label1.Text = "Casas";
                pictureBox1.BackgroundImage = null;
                CarregarCasas();
                MessageBox.Show("Erro ao publicar, tente escolher uma imagem com tamanho mais pequeno", "ERROOO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Botão Apagar Conta
        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que deseja apagar a CONTA ??", "BURRO do CARA***", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ApagarTudoDoUtilizador();

                string query = "DELETE FROM Clientes WHERE n_cartao_cidadao = @n_cartao_cidadao";

                if (a.open_connection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, a.connection);

                    cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                    cmd.ExecuteNonQuery();

                    a.close_connection();
                }

                MessageBox.Show("Até uma próxima", "Não Vai não :,)", MessageBoxButtons.OK);

                Close();
            }
            else
            {
                MessageBox.Show("Obrigado por ficar :)", "Lindo Menin@", MessageBoxButtons.OK);
            }
        }

        //Concluir e Voltar
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == textBox8.Text)
            {
                // Definir a query
                string query = "UPDATE clientes SET nome = @nome, morada = @morada, gmail = @gmail, pass = @pass WHERE n_cartao_cidadao = @n_cartao_cidadao";

                // Abrir a ligação à BD
                if (a.open_connection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, a.connection);

                    cmd.Parameters.AddWithValue("@nome", textBox3.Text);
                    cmd.Parameters.AddWithValue("@morada", maskedTextBox5.Text);
                    cmd.Parameters.AddWithValue("@gmail", textBox6.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox7.Text);
                    cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                    cmd.ExecuteNonQuery();

                    panel7.Visible = false;

                    a.close_connection();
                }

                CarregarCasas();

                panel3.Height = button1.Height;
                panel3.Top = button1.Top;
                label1.Text = "Casas";

                panel1.Visible = true;

                MessageBox.Show("Dados atualizados com sucesso ", "BOOO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                label15.Visible = false;
            }
            else
            {
                label15.Visible = true;
            }
        }

        //Botão carregar imagem de perfil
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog img2 = new OpenFileDialog();

                img2.Title = "Abrir Ficheiro";
                img2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                img2.Filter = "Imagem(.jpg) | *.jpg";

                if (img2.ShowDialog() == DialogResult.Cancel) return;
                {
                    pictureBox3.BackgroundImage = Image.FromFile(img2.FileName);
                }

                // Definir a nova imagem
                pictureBox3.BackgroundImage = Image.FromFile(img2.FileName);


                // Converter a imagem para byte array
                byte[] imgBytes2 = ConverterImgParaByte(pictureBox3.BackgroundImage);


                string query = "UPDATE clientes SET img = @img WHERE n_cartao_cidadao = @n_cartao_cidadao";

                if (a.open_connection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, a.connection);

                    cmd.Parameters.AddWithValue("@img", imgBytes2);
                    cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                    cmd.ExecuteNonQuery();

                    a.close_connection();
                }

                button9.BackgroundImage = pictureBox3.BackgroundImage;
            }
            catch
            {
                MessageBox.Show("Erro ao carregar a imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------/ FUNÇÕES PARA CARREGAR AS COISAS NO FLOWLAYOUTPANEL /---------------------------------


        private void CarregarCasas()
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa as casas existentes

            string query = "SELECT idCasa, nome_rua, cidade_distrito, preco, img FROM Casa";

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int casaId = reader.GetInt32("idCasa");
                    string titulo = reader.GetString("nome_rua");
                    string descricao = reader.GetString("cidade_distrito");
                    decimal precoDecimal = reader.GetDecimal("preco");
                    string preco = precoDecimal.ToString("F2");// Converte em string e para duas casas decimais
                    byte[] imgBytes = (byte[])reader["img"];

                    bool podeApagar = false;
                    bool podeFavoritar = true;

                    AddFlowLayoutPanel(titulo, descricao, preco, imgBytes, podeApagar, casaId, podeFavoritar);
                }

                reader.Close();
                a.close_connection();
            }
        }

        private void Favoritos()
        {
            flowLayoutPanel1.Controls.Clear();

            // retorna os dados da casa em que o id é igual nas duas tabelas e onde o cc é igual ao da pessoa logada

            string query = "SELECT c.idCasa, c.nome_rua, c.cidade_distrito, c.preco, c.img FROM Casa c " +
                           "INNER JOIN Favoritos f ON c.idCasa = f.idCasa " +
                           "WHERE f.n_cartao_cidadao = @n_cartao_cidadao";


            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);

                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int casaId = reader.GetInt32("idCasa");
                    string titulo = reader.GetString("nome_rua");
                    string descricao = reader.GetString("cidade_distrito");
                    decimal precoDecimal = reader.GetDecimal("preco");
                    string preco = precoDecimal.ToString("F2");// Converte em string e para duas casas decimais
                    byte[] imgBytes = (byte[])reader["img"];

                    bool podeApagar = false;
                    bool podeFavoritar = true;

                    AddFlowLayoutPanel(titulo, descricao, preco, imgBytes, podeApagar, casaId, podeFavoritar);
                }

                reader.Close();
                a.close_connection();
            }
        }

        private void Anuncios()
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa as casas existentes

            string query = "SELECT idCasa, nome_rua, cidade_distrito, preco, img, n_cartao_cidadao FROM Casa WHERE n_cartao_cidadao LIKE " + numeroCC;

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int casaId = reader.GetInt32("idCasa");
                    string titulo = reader.GetString("nome_rua");
                    string descricao = reader.GetString("cidade_distrito");
                    decimal precoDecimal = reader.GetDecimal("preco");
                    string preco = precoDecimal.ToString("F2");// Converte em string e para duas casas decimais
                    byte[] imgBytes = (byte[])reader["img"];
                    int numCC = reader.GetInt32("n_cartao_cidadao");

                    bool podeApagar = false;
                    bool podeFavoritar = false;


                    if (numCC == numeroCC)
                    {
                        podeApagar = true;
                    }

                    AddFlowLayoutPanel(titulo, descricao, preco, imgBytes, podeApagar, casaId, podeFavoritar);
                }

                reader.Close();
                a.close_connection();
            }
        }

        //----------------------------/ FUNÇÓES CONVERTER IMAGEM PARA JPG E CRIAR BOTÕES / ------------------------------------




        //Converter de bytes para jpg
        public Image ByteParamage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }


        //Função pa criar os paineis das casas
        private void AddFlowLayoutPanel(string titulo, string descricao, string preco, byte[] imgBytes, bool podeApagar, int casaId, bool podeFavoritar)
        {
            // Cria um novo painel
            Panel anuncioPanel = new Panel
            {
                Width = 274,
                Height = 250,
                BorderStyle = BorderStyle.None,
                BackColor = Color.LightGray,
                Tag = casaId,
            };
            anuncioPanel.Click += new EventHandler(panel_Click);

            // Converter de novo para jpg
            Image img = ByteParamage(imgBytes);

            // Cria uma PictureBox
            PictureBox pictureBox = new PictureBox
            {
                Width = 260,
                Height = 135,
                Location = new System.Drawing.Point(7, 8),

                // Defina a imagem da PictureBox aqui                
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = img
            };


            // Cria os três Labels
            Label labelTitulo = new Label
            {
                Width = 236,
                Height = 17,
                Text = titulo,
                Location = new System.Drawing.Point(7, 150),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            Label labelDescricao = new Label
            {
                Width = 205,
                Height = 15,
                Text = descricao,
                Location = new System.Drawing.Point(7, 174),
                Font = new Font("Segoe UI", 9F)
            };

            Label labelPreco = new Label
            {
                Width = 216,
                Height = 37,
                Text = preco + " €",
                Location = new System.Drawing.Point(7, 205),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
            };



            // Cria um botão
            Button buttonFavorito = new Button
            {
                Width = 30,
                Height = 30,
                BackgroundImage = Properties.Resources.favoritos,
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Popup,
                Location = new System.Drawing.Point(237, 211),
                Visible = podeFavoritar,
                Tag = casaId
            };
            // Configurações adicionais para o botão "Favorito"
            buttonFavorito.FlatAppearance.BorderSize = 0;
            buttonFavorito.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonFavorito.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonFavorito.Click += buttonFavorito_Click;


            Button buttonApagar = new Button
            {
                Width = 20,
                Height = 20,

                BackgroundImage = Properties.Resources.apagar,
                BackgroundImageLayout = ImageLayout.Stretch,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Location = new System.Drawing.Point(245, 222),
                Visible = podeApagar,
                Tag = casaId
            };
            // Configurações adicionais para o botão "Apagar"
            buttonApagar.FlatAppearance.BorderSize = 0;
            buttonApagar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonApagar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonApagar.Click += buttonApagar_Click; // Associa o botão ao método buttonApagar_Click



            // Adiciona os controles ao painel
            anuncioPanel.Controls.Add(pictureBox);
            anuncioPanel.Controls.Add(labelTitulo);
            anuncioPanel.Controls.Add(labelDescricao);
            anuncioPanel.Controls.Add(labelPreco);
            anuncioPanel.Controls.Add(buttonFavorito);
            anuncioPanel.Controls.Add(buttonApagar);

            // Adiciona o painel ao FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(anuncioPanel);
        }




        //---------------------------------------/ FUNÇÕES PARA OS BOTÕES FUNCIONAREM /--------------------------------------




        //EVENTO DO BOTÃO APAGAR
        private void buttonApagar_Click(object sender, EventArgs e)
        {
            try
            {

                Button button = sender as Button;

                if (button != null)
                {
                    DialogResult result = MessageBox.Show("Tem a certeza que deseja apagar este anúncio ??", "SEU IDIOTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Guarda a tag do anuncio a apagar
                        int casaId = (int)button.Tag;

                        // Remove a casa dos favoritos antes de excluí-la
                        RemoverCasaDosFavoritos(casaId);


                        string query = "DELETE FROM favoritos WHERE idCasa = @idCasa";
                        string query2 = "DELETE FROM casa WHERE idCasa = @idCasa";

                        // Open the database connection
                        if (a.open_connection())
                        {
                            MySqlCommand cmd = new MySqlCommand(query, a.connection);
                            cmd.Parameters.AddWithValue("@idCasa", casaId);

                            MySqlCommand cmd2 = new MySqlCommand(query2, a.connection);
                            cmd2.Parameters.AddWithValue("@idCasa", casaId);

                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();

                            a.close_connection();

                            Anuncios();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao apagar o seu anúncio", "ERROO TERRIVÉL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFavorito_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                // Obtém o ID da casa associado ao botão
                int casaId = (int)button.Tag;

                // Verifica se a casa já está nos favoritos do usuário
                bool jaNosFavoritos = VerificarCasaNosFavoritos(casaId);

                if (jaNosFavoritos)
                {
                    // Se a casa já estiver nos favoritos, remova-a
                    RemoverCasaDosFavoritos(casaId);
                }
                else
                {
                    // Se a casa não estiver nos favoritos, adicione-a
                    AdicionarCasaAosFavoritos(casaId);
                }

                if (Casa_favoritos == "casa")
                {
                    CarregarCasas();
                }
                else if (Casa_favoritos == "favorito")
                {
                    Favoritos();
                }
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel != null)
            {
                int ano = 0, n_visitas = 0;
                string quando_visitada = "";


                // Obtém o ID da casa associado ao botão
                int casaId = (int)panel.Tag;

                string query = "SELECT ano, n_visitas, quando_visitada FROM Casa WHERE idCasa LIKE " + casaId;

                if (a.open_connection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, a.connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ano = reader.GetInt32("ano");
                        n_visitas = reader.GetInt32("n_visitas");
                        quando_visitada = reader.GetString("quando_visitada");
                    }
                    reader.Close();
                    a.close_connection();
                }
                MessageBox.Show("Ano: " + ano + "\nNº de Visitas: " + n_visitas + "\nQuando foi Visitada: " + quando_visitada, "Informações Casa", MessageBoxButtons.OK);
            }
        }

        private bool VerificarCasaNosFavoritos(int casaId)
        {
            // Consulta para verificar se a casa está nos favoritos do usuário
            string query = "SELECT COUNT(*) FROM Favoritos WHERE idCasa = @idCasa AND n_cartao_cidadao = @n_cartao_cidadao";

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);
                cmd.Parameters.AddWithValue("@idCasa", casaId);
                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                a.close_connection();

                return count > 0;
            }

            return false;
        }

        private void AdicionarCasaAosFavoritos(int casaId)
        {
            // Consulta para adicionar a casa aos favoritos do usuário
            string query = "INSERT INTO Favoritos (idCasa, n_cartao_cidadao) VALUES (@idCasa, @n_cartao_cidadao)";

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);
                cmd.Parameters.AddWithValue("@idCasa", casaId);
                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                cmd.ExecuteNonQuery();

                a.close_connection();
            }
        }

        private void RemoverCasaDosFavoritos(int casaId)
        {
            // Consulta para remover a casa dos favoritos do usuário
            string query = "DELETE FROM Favoritos WHERE idCasa = @idCasa AND n_cartao_cidadao = @n_cartao_cidadao";

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);
                cmd.Parameters.AddWithValue("@idCasa", casaId);
                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                cmd.ExecuteNonQuery();

                a.close_connection();
            }
        }

        private void ApagarTudoDoUtilizador()
        {
            //Apagar do Favoritos
            string query = "DELETE FROM Favoritos WHERE n_cartao_cidadao = @n_cartao_cidadao";

            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, a.connection);
                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                cmd.ExecuteNonQuery();

                a.close_connection();
            }

            //Apagar casas
            string query2 = "DELETE FROM casa WHERE n_cartao_cidadao = @n_cartao_cidadao";

            // Open the database connection
            if (a.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query2, a.connection);
                cmd.Parameters.AddWithValue("@n_cartao_cidadao", numeroCC);

                cmd.ExecuteNonQuery();

                a.close_connection();

                Anuncios();
            }
        }


        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trabalho do M15 \n Feito por: Tiago Condeço Carvalho :)", "Obrigado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
