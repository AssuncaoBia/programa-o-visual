using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ListaDeTarefas.Dados;

namespace ListaDeTarefas.Interface
{
    public partial class FormularioPrincipal : Form
    {
        private readonly GerenciadorBancoDados? gerenciadorBanco;

        public FormularioPrincipal()
        {
            InitializeComponent();

            // Evita executar lógica quando aberto no Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            gerenciadorBanco = new GerenciadorBancoDados();
            botaoRecarregar.Click += (s, e) => CarregarTarefas();
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            if (gerenciadorBanco == null) return;

            try
            {
                DataTable tabela = gerenciadorBanco.ObterTarefasComoTabela();
                gradeTarefas.DataSource = tabela;
                AjustarColunas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tarefas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarColunas()
        {
            if (gradeTarefas.Columns.Count == 0) return;

            foreach (DataGridViewColumn coluna in gradeTarefas.Columns)
            {
                if (coluna.HeaderText.Equals("Descrição", StringComparison.OrdinalIgnoreCase))
                {
                    coluna.FillWeight = 250;
                }
                else if (coluna.HeaderText.Equals("Título", StringComparison.OrdinalIgnoreCase))
                {
                    coluna.FillWeight = 160;
                }
                else
                {
                    coluna.FillWeight = 100;
                }
            }
        }
    }
}
