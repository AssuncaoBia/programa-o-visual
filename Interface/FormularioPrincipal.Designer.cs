using System.Windows.Forms;
using System.Drawing;

namespace ListaDeTarefas.Interface
{
    partial class FormularioPrincipal
    {
        private Label rotuloTitulo;
        private Button botaoRecarregar;
        private DataGridView gradeTarefas;

        private void InitializeComponent()
        {
            rotuloTitulo = new Label();
            botaoRecarregar = new Button();
            gradeTarefas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gradeTarefas).BeginInit();
            SuspendLayout();
            // 
            // rotuloTitulo
            // 
            rotuloTitulo.AutoSize = true;
            rotuloTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            rotuloTitulo.Location = new Point(17, 20);
            rotuloTitulo.Name = "rotuloTitulo";
            rotuloTitulo.Size = new Size(319, 32);
            rotuloTitulo.TabIndex = 0;
            rotuloTitulo.Text = "Sistema de Lista de Tarefas";
            // 
            // botaoRecarregar
            // 
            botaoRecarregar.Location = new Point(17, 65);
            botaoRecarregar.Margin = new Padding(3, 4, 3, 4);
            botaoRecarregar.Name = "botaoRecarregar";
            botaoRecarregar.Size = new Size(126, 45);
            botaoRecarregar.TabIndex = 1;
            botaoRecarregar.Text = "Recarregar";
            botaoRecarregar.UseVisualStyleBackColor = true;
            // 
            // gradeTarefas
            // 
            gradeTarefas.AllowUserToAddRows = false;
            gradeTarefas.AllowUserToDeleteRows = false;
            gradeTarefas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gradeTarefas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gradeTarefas.BackgroundColor = Color.White;
            gradeTarefas.ColumnHeadersHeight = 29;
            gradeTarefas.Location = new Point(17, 127);
            gradeTarefas.Margin = new Padding(3, 4, 3, 4);
            gradeTarefas.MultiSelect = false;
            gradeTarefas.Name = "gradeTarefas";
            gradeTarefas.ReadOnly = true;
            gradeTarefas.RowHeadersWidth = 51;
            gradeTarefas.RowTemplate.Height = 25;
            gradeTarefas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gradeTarefas.Size = new Size(971, 560);
            gradeTarefas.TabIndex = 2;
            // 
            // FormularioPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 748);
            Controls.Add(gradeTarefas);
            Controls.Add(botaoRecarregar);
            Controls.Add(rotuloTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormularioPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Tarefas";
            ((System.ComponentModel.ISupportInitialize)gradeTarefas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
