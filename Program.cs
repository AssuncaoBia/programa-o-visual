using ListaDeTarefas.Dados;

namespace ListaDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE LISTA DE TAREFAS ===");
            Console.WriteLine(new string('=', 50));

            try
            {
                // Testar conexão com banco de dados
                var gerenciadorBanco = new GerenciadorBancoDados();
                Console.WriteLine("Conexão com banco de dados estabelecida com sucesso!");
                
                // Menu básico para teste
                ExibirMenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
            }
        }

        static void ExibirMenuPrincipal()
        {
            Console.WriteLine("\n=== MENU PRINCIPAL ===");
            Console.WriteLine("1 - Adicionar nova tarefa");
            Console.WriteLine("2 - Listar todas as tarefas");
            Console.WriteLine("3 - Marcar tarefa como concluída");
            Console.WriteLine("4 - Editar tarefa");
            Console.WriteLine("5 - Remover tarefa");
            Console.WriteLine("6 - Filtrar tarefas por status");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");
            
            string opcao = Console.ReadLine() ?? "";
            
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "2":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "3":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "4":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "5":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "6":
                    Console.WriteLine("Funcionalidade será implementada posteriormente...");
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            ExibirMenuPrincipal();
        }
    }
} 