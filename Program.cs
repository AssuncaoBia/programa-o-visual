using System;
using System.Windows.Forms;
using ListaDeTarefas.Dados;
using ListaDeTarefas.Interface;

namespace ListaDeTarefas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Garante que o banco está pronto antes de abrir a UI
                var gerenciadorBanco = new GerenciadorBancoDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var telaLogin = new FormLogin();
            var resultado = telaLogin.ShowDialog();
            if (resultado != DialogResult.OK)
            {
                return;
            }

            Application.Run(new FormularioPrincipal());
        }
    }
}