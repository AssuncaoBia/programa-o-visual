using System.Windows.Forms;
using System.Drawing;

namespace ListaDeTarefas.Interface
{
    partial class FormCadastro
    {
        private Label rotuloTitulo;
        private Label rotuloUsuario;
        private Label rotuloSenha;
        private Label rotuloConfirmar;
        private TextBox caixaUsuario;
        private TextBox caixaSenha;
        private TextBox caixaConfirmar;
        private Button botaoCadastrar;
        private Button botaoCancelar;

        private void InitializeComponent()
        {
            rotuloTitulo = new Label();
            rotuloUsuario = new Label();
            rotuloSenha = new Label();
            rotuloConfirmar = new Label();
            caixaUsuario = new TextBox();
            caixaSenha = new TextBox();
            caixaConfirmar = new TextBox();
            botaoCadastrar = new Button();
            botaoCancelar = new Button();
            SuspendLayout();
            // 
            // rotuloTitulo
            // 
            rotuloTitulo.AutoSize = true;
            rotuloTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            rotuloTitulo.Location = new Point(16, 12);
            rotuloTitulo.Name = "rotuloTitulo";
            rotuloTitulo.Size = new Size(245, 32);
            rotuloTitulo.TabIndex = 0;
            rotuloTitulo.Text = "Cadastro de Usuário";
            // 
            // rotuloUsuario
            // 
            rotuloUsuario.AutoSize = true;
            rotuloUsuario.Location = new Point(18, 56);
            rotuloUsuario.Name = "rotuloUsuario";
            rotuloUsuario.Size = new Size(62, 20);
            rotuloUsuario.TabIndex = 1;
            rotuloUsuario.Text = "Usuário:";
            // 
            // rotuloSenha
            // 
            rotuloSenha.AutoSize = true;
            rotuloSenha.Location = new Point(18, 92);
            rotuloSenha.Name = "rotuloSenha";
            rotuloSenha.Size = new Size(52, 20);
            rotuloSenha.TabIndex = 3;
            rotuloSenha.Text = "Senha:";
            // 
            // rotuloConfirmar
            // 
            rotuloConfirmar.AutoSize = true;
            rotuloConfirmar.Location = new Point(18, 128);
            rotuloConfirmar.Name = "rotuloConfirmar";
            rotuloConfirmar.Size = new Size(78, 20);
            rotuloConfirmar.TabIndex = 5;
            rotuloConfirmar.Text = "Confirmar:";
            // 
            // caixaUsuario
            // 
            caixaUsuario.Location = new Point(120, 52);
            caixaUsuario.Name = "caixaUsuario";
            caixaUsuario.Size = new Size(260, 27);
            caixaUsuario.TabIndex = 2;
            // 
            // caixaSenha
            // 
            caixaSenha.Location = new Point(120, 88);
            caixaSenha.Name = "caixaSenha";
            caixaSenha.PasswordChar = '•';
            caixaSenha.Size = new Size(260, 27);
            caixaSenha.TabIndex = 4;
            // 
            // caixaConfirmar
            // 
            caixaConfirmar.Location = new Point(120, 124);
            caixaConfirmar.Name = "caixaConfirmar";
            caixaConfirmar.PasswordChar = '•';
            caixaConfirmar.Size = new Size(260, 27);
            caixaConfirmar.TabIndex = 6;
            // 
            // botaoCadastrar
            // 
            botaoCadastrar.Location = new Point(212, 168);
            botaoCadastrar.Name = "botaoCadastrar";
            botaoCadastrar.Size = new Size(90, 33);
            botaoCadastrar.TabIndex = 7;
            botaoCadastrar.Text = "Cadastrar";
            // 
            // botaoCancelar
            // 
            botaoCancelar.Location = new Point(308, 168);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(78, 33);
            botaoCancelar.TabIndex = 8;
            botaoCancelar.Text = "Cancelar";
            // 
            // FormCadastro
            // 
            AcceptButton = botaoCadastrar;
            CancelButton = botaoCancelar;
            ClientSize = new Size(403, 225);
            Controls.Add(rotuloTitulo);
            Controls.Add(rotuloUsuario);
            Controls.Add(caixaUsuario);
            Controls.Add(rotuloSenha);
            Controls.Add(caixaSenha);
            Controls.Add(rotuloConfirmar);
            Controls.Add(caixaConfirmar);
            Controls.Add(botaoCadastrar);
            Controls.Add(botaoCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCadastro";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
