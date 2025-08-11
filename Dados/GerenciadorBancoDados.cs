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

        public int InserirTarefa(string titulo, string descricao)
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                const string sql = "INSERT INTO tarefas (titulo, descricao, concluida, data_criacao) VALUES (@titulo, @descricao, 0, NOW()); SELECT LAST_INSERT_ID();";
                using var comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@descricao", descricao);
                object? result = comando.ExecuteScalar();
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir tarefa: {ex.Message}");
                return -1;
            }
        }

        public bool AtualizarTarefa(int id, string titulo, string descricao)
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                const string sql = "UPDATE tarefas SET titulo = @titulo, descricao = @descricao WHERE id = @id";
                using var comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@descricao", descricao);
                return comando.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar tarefa: {ex.Message}");
                return false;
            }
        }

        public bool MarcarConcluida(int id, bool concluida)
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                string sql = concluida
                    ? "UPDATE tarefas SET concluida = 1, data_conclusao = NOW() WHERE id = @id"
                    : "UPDATE tarefas SET concluida = 0, data_conclusao = NULL WHERE id = @id";

                using var comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@id", id);
                return comando.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar status da tarefa: {ex.Message}");
                return false;
            }
        }

        public bool RemoverTarefa(int id)
        {
            try
            {
                using var conexao = new MySqlConnection(_stringConexaoComBanco);
                conexao.Open();

                const string sql = "DELETE FROM tarefas WHERE id = @id";
                using var comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@id", id);
                return comando.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover tarefa: {ex.Message}");
                return false;
            }
        }
    }
} 