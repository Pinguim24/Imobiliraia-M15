using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Trabalho_FInal_M15_V1
{
    public partial class Registrar : Form
    {
        ligacaoBD a = new ligacaoBD();

        public Registrar()
        {
            InitializeComponent();
            a.inicializa();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || !radioButton1.Checked && !radioButton2.Checked)
                {
                    label2.Text = "*Todos os campos precisam de ser preenchidos";
                    label2.Visible = true;
                }
                else
                {
                    if (textBox4.Text != textBox5.Text)
                    {
                        label2.Visible = true;
                        label2.Text = "*As palavavas-passe não coincidem";
                    }
                    else
                    {
                        label2.Visible = false;

                        string cc = maskedTextBox2.Text;
                        string mail = textBox3.Text;

                        //definir a query / pesquisa
                        string query = "INSERT INTO clientes (n_cartao_cidadao, nome, morada, telemovel, gmail, pass, vendedor_ou_comprador) " + 
                                       "VALUES (@n_cartao_cidadao, @nome, @morada, @telemovel, @gmail, @pass, @vendedor_ou_comprador)";

                        string query2 = "SELECT COUNT(*) FROM clientes WHERE n_cartao_cidadao = @n_cartao_cidadao OR gmail = @gmail";

                        //abrir a ligação à BD
                        if (a.open_connection())
                        {
                            // Criar o comando de verificação e associar a query com a ligação
                            MySqlCommand verSeExiste = new MySqlCommand(query2, a.connection);

                            verSeExiste.Parameters.AddWithValue("@n_cartao_cidadao", cc);
                            verSeExiste.Parameters.AddWithValue("@gmail", mail);

                            // Executar o comando de verificação e obter o resultado
                            int contaExistente = Convert.ToInt32(verSeExiste.ExecuteScalar());

                            if (contaExistente > 0)
                            {
                                MessageBox.Show("Número de cartão de cidadão ou Email já estão registados.");
                            }
                            else
                            {
                                string comprador_vendedor = "";


                                if (radioButton1.Checked)
                                {
                                    comprador_vendedor = "comprador";
                                }
                                else if (radioButton2.Checked)
                                {
                                    comprador_vendedor = "vendedor";
                                }

                                //criar o comando e associar a query com a ligação através do construtor 
                                MySqlCommand cmd = new MySqlCommand(query, a.connection);

                                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                                cmd.Parameters.AddWithValue("@n_cartao_cidadao", maskedTextBox2.Text);
                                cmd.Parameters.AddWithValue("@morada", textBox2.Text);
                                cmd.Parameters.AddWithValue("@telemovel", maskedTextBox1.Text);
                                cmd.Parameters.AddWithValue("@gmail", textBox3.Text);
                                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                                cmd.Parameters.AddWithValue("@vendedor_ou_comprador", comprador_vendedor.ToString());

                                //executar o comando 
                                cmd.ExecuteNonQuery();

                                //fechar a ligação à BD 
                                a.close_connection();

                                Close();

                                MessageBox.Show("Registro feito com sucesso!");

                            }
                        }
                    }               
                }
            }
            catch
            {
                MessageBox.Show("Erro a fazer o login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
