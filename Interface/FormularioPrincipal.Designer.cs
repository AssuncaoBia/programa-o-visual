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
            this.rotuloTitulo = new System.Windows.Forms.Label();
            this.botaoRecarregar = new System.Windows.Forms.Button();
            this.gradeTarefas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTarefas)).BeginInit();
            this.SuspendLayout();
            // 
            // rotuloTitulo
            // 
            this.rotuloTitulo.AutoSize = true;
            this.rotuloTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rotuloTitulo.Location = new System.Drawing.Point(15, 15);
            this.rotuloTitulo.Name = "rotuloTitulo";
            this.rotuloTitulo.Size = new System.Drawing.Size(269, 25);
            this.rotuloTitulo.TabIndex = 0;
            this.rotuloTitulo.Text = "Sistema de Lista de Tarefas";
            // 
            // botaoRecarregar
            // 
            this.botaoRecarregar.Location = new System.Drawing.Point(15, 50);
            this.botaoRecarregar.Name = "botaoRecarregar";
            this.botaoRecarregar.Size = new System.Drawing.Size(110, 34);
            this.botaoRecarregar.TabIndex = 1;
            this.botaoRecarregar.Text = "Recarregar";
            this.botaoRecarregar.UseVisualStyleBackColor = true;
            // 
            // gradeTarefas
            // 
            this.gradeTarefas.AllowUserToAddRows = false;
            this.gradeTarefas.AllowUserToDeleteRows = false;
            this.gradeTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeTarefas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gradeTarefas.BackgroundColor = System.Drawing.Color.White;
            this.gradeTarefas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradeTarefas.Location = new System.Drawing.Point(15, 95);
            this.gradeTarefas.MultiSelect = false;
            this.gradeTarefas.Name = "gradeTarefas";
            this.gradeTarefas.ReadOnly = true;
            this.gradeTarefas.RowTemplate.Height = 25;
            this.gradeTarefas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gradeTarefas.Size = new System.Drawing.Size(850, 420);
            this.gradeTarefas.TabIndex = 2;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.gradeTarefas);
            this.Controls.Add(this.botaoRecarregar);
            this.Controls.Add(this.rotuloTitulo);
            this.Name = "FormularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Tarefas";
            ((System.ComponentModel.ISupportInitialize)(this.gradeTarefas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
