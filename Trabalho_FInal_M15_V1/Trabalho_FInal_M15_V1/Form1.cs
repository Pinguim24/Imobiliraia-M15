using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Trabalho_FInal_M15_V1
{
    public partial class Form1 : Form
    {
        ligacaoBD a = new ligacaoBD();

        public Form1()
        {
            InitializeComponent();
            a.inicializa();

            if (a.open_connection())
            {
                MessageBox.Show("A ligação à base de dados " + a.data_base + " foi bem sucedida.");
            }
            else
            {
                MessageBox.Show("A ligação à base de dados " + a.data_base + " NÃO FOI POSSIVÉL.");
                a.close_connection();
                MessageBox.Show("A ligação à base de dados " + a.data_base + " foi desativada.");
            }
        }

        public int x = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox2.Text;

            if (x == 0)
            {
                button1.Image = Properties.Resources.Olho_branco_cortado3;
                x = 1;

                textBox2.PasswordChar = '\0'; // o \0 quer dizer nenhum caractere
            }
            else if (x == 1)
            {
                button1.Image = Properties.Resources.Olho_Branco;
                x = 0;
                
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();

            registrar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label4.Visible = false;

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    label4.Text = "*Todos os campos precisam de ser preenchidos";
                    label4.Location = new Point(171, 283);
                    label4.Visible = true;
                }

                else
                {
                    string gmail = textBox1.Text;
                    string pass = textBox2.Text;

                    string query = "SELECT COUNT(*), n_cartao_cidadao, vendedor_ou_comprador FROM clientes WHERE gmail = @gmail and pass = @pass";

                    // Criar o comando de verificação e associar a query com a ligação
                    MySqlCommand verSeExisteConta = new MySqlCommand(query, a.connection);

                    verSeExisteConta.Parameters.AddWithValue("@gmail", gmail);
                    verSeExisteConta.Parameters.AddWithValue("@pass", pass);

                    MySqlDataReader reader = verSeExisteConta.ExecuteReader();

                    if (reader.Read())
                    {
                        int contaExiste = reader.GetInt32(0);

                        if (contaExiste > 0)
                        {
                            int cc = reader.GetInt32(1); //GetString(1) lê a coluna 2 da pesquisa
                            string tipoConta = reader.GetString(2); //GetString(2) lê a coluna 3 da pesquisa

                            Principal principal = new Principal(tipoConta, cc, gmail);
                            principal.Show();

                            textBox1.Clear();
                            textBox2.Clear();

                            reader.Close();
                        }
                        else if (contaExiste == 0)
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                            label4.Visible = true;
                            label4.Text = "*Palavra-Pass ou Mail incorretos";
                        }
                    }

                    reader.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao iniciar sessão tente mais tarde", "Erro Catastrófico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}