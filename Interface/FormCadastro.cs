using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ListaDeTarefas.Interface
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
            botaoCadastrar.Click += (s, e) => Cadastrar();
            botaoCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void Cadastrar()
        {
            string usuario = (caixaUsuario.Text ?? string.Empty).Trim();
            string senha = (caixaSenha.Text ?? string.Empty).Trim();
            string confirmar = (caixaConfirmar.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Informe usuário e senha.");
                return;
            }
            if (senha != confirmar)
            {
                MessageBox.Show("Senha e confirmação não conferem.");
                return;
            }

            try
            {
                using var conexao = new MySqlConnection("Server=localhost;Database=listadetarefas;Uid=root;Pwd=0000;CharSet=utf8;");
                conexao.Open();

                // Verificar se existe
                using (var verificar = new MySqlCommand("SELECT COUNT(1) FROM usuarios WHERE usuario = @u", conexao))
                {
                    verificar.Parameters.AddWithValue("@u", usuario);
                    int existe = Convert.ToInt32(verificar.ExecuteScalar());
                    if (existe > 0)
                    {
                        MessageBox.Show("Usuário já existe.");
                        return;
                    }
                }

                // Inserir
                using (var inserir = new MySqlCommand("INSERT INTO usuarios (usuario, senha) VALUES (@u, @s)", conexao))
                {
                    inserir.Parameters.AddWithValue("@u", usuario);
                    inserir.Parameters.AddWithValue("@s", senha);
                    inserir.ExecuteNonQuery();
                }

                MessageBox.Show("Usuário cadastrado com sucesso!");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}");
            }
        }
    }
}
