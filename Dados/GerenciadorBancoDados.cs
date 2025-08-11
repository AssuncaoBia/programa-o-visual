using MySql.Data.MySqlClient;
using System.Data;

namespace ListaDeTarefas.Dados
{
    public class GerenciadorBancoDados
    {
        private readonly string _stringConexao;
        private readonly string _stringConexaoComBanco;

        public GerenciadorBancoDados()
        {
            // Configuração para MySQL 5.5 - sem especificar banco inicialmente
            _stringConexao = "Server=localhost;Uid=root;Pwd=0000;CharSet=utf8;";
            _stringConexaoComBanco = "Server=localhost;Database=listadetarefas;Uid=root;Pwd=0000;CharSet=utf8;";
            InicializarBancoDados();
        }

        private void InicializarBancoDados()
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexao);
                conexao.Open();

                // Criar banco de dados se não existir
                using var comandoCriarBanco = new MySqlCommand(
                    "CREATE DATABASE IF NOT EXISTS listadetarefas CHARACTER SET utf8 COLLATE utf8_general_ci;", 
                    conexao);
                comandoCriarBanco.ExecuteNonQuery();

                // Usar o banco de dados
                conexao.ChangeDatabase("listadetarefas");

                // Criar tabela de tarefas
                string sqlCriarTabela = @"
                    CREATE TABLE IF NOT EXISTS tarefas (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        titulo VARCHAR(255) NOT NULL,
                        descricao TEXT,
                        concluida BOOLEAN DEFAULT FALSE,
                        data_criacao DATETIME,
                        data_conclusao DATETIME NULL
                    )";

                using var comandoCriarTabela = new MySqlCommand(sqlCriarTabela, conexao);
                comandoCriarTabela.ExecuteNonQuery();

                Console.WriteLine("Banco de dados inicializado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inicializar banco de dados: {ex.Message}");
                throw;
            }
        }

        public bool TestarConexao()
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na conexão: {ex.Message}");
                return false;
            }
        }

        public void ExecutarConsulta(string sql)
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                using var comando = new MySqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar consulta: {ex.Message}");
            }
        }

        public DataTable ObterTarefasComoTabela()
        {
            var tabela = new DataTable();

            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                string sql = @"SELECT 
                                    id AS 'ID',
                                    titulo AS 'Título',
                                    descricao AS 'Descrição',
                                    CASE WHEN concluida THEN 'Sim' ELSE 'Não' END AS 'Concluída',
                                    data_criacao AS 'Criada em',
                                    data_conclusao AS 'Concluída em'
                               FROM tarefas
                               ORDER BY COALESCE(data_criacao, '1970-01-01') DESC, id DESC";

                using var adaptador = new MySqlDataAdapter(sql, conexao);
                adaptador.Fill(tabela);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter tarefas: {ex.Message}");
            }

            return tabela;
        }
    }
} 