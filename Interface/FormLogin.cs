using System;
using System.Data;
using System.Windows.Forms;
using ListaDeTarefas.Dados;

namespace ListaDeTarefas.Interface
{
    public partial class FormLogin : Form
    {
        private readonly GerenciadorBancoDados gerenciador;

        public string UsuarioLogado { get; private set; } = string.Empty;

        public FormLogin()
        {
            InitializeComponent();
            gerenciador = new GerenciadorBancoDados();

            botaoEntrar.Click += (s, e) => TentarLogin();
            botaoCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            GarantirTabelaUsuarios();
        }

        private void GarantirTabelaUsuarios()
        {
            // Cria tabela de usuários básica se não existir e insere um usuário padrão admin/admin123
            const string criarTabela = @"CREATE TABLE IF NOT EXISTS usuarios (
                                            id INT AUTO_INCREMENT PRIMARY KEY,
                                            usuario VARCHAR(100) NOT NULL UNIQUE,
                                            senha VARCHAR(200) NOT NULL
                                         )";
            gerenciador.ExecutarConsulta(criarTabela);

            // Insere admin se não existir
            const string inserirAdmin = @"INSERT INTO usuarios (usuario, senha)
                                         SELECT * FROM (SELECT 'admin' AS usuario, 'admin123' AS senha) AS tmp
                                         WHERE NOT EXISTS (SELECT 1 FROM usuarios WHERE usuario = 'admin')
                                         LIMIT 1";
            gerenciador.ExecutarConsulta(inserirAdmin);
        }

        private void TentarLogin()
        {
            string usuario = caixaUsuario.Text.Trim();
            string senha = caixaSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Informe usuário e senha.");
                return;
            }

            if (ValidarCredenciais(usuario, senha))
            {
                UsuarioLogado = usuario;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.");
            }
        }

        private bool ValidarCredenciais(string usuario, string senha)
        {
            try
            {
                using var conexao = new MySql.Data.MySqlClient.MySqlConnection(GetConnString());
                conexao.Open();
                const string sql = "SELECT COUNT(1) FROM usuarios WHERE usuario = @u AND senha = @s";
                using var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@s", senha);
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar login: {ex.Message}");
                return false;
            }
        }

        private string GetConnString()
        {
            // Usa a mesma conexão do gerenciador (com banco definido)
            return "Server=localhost;Database=listadetarefas;Uid=root;Pwd=0000;CharSet=utf8;";
        }
    }
}
