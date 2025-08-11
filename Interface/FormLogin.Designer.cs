using System.Windows.Forms;
using System.Drawing;

namespace ListaDeTarefas.Interface
{
    partial class FormLogin
    {
        private Label rotuloTitulo;
        private Label rotuloUsuario;
        private Label rotuloSenha;
        private TextBox caixaUsuario;
        private TextBox caixaSenha;
        private Button botaoEntrar;
        private Button botaoCancelar;

        private void InitializeComponent()
        {
            rotuloTitulo = new Label();
            rotuloUsuario = new Label();
            rotuloSenha = new Label();
            caixaUsuario = new TextBox();
            caixaSenha = new TextBox();
            botaoEntrar = new Button();
            botaoCancelar = new Button();
            SuspendLayout();
            // 
            // rotuloTitulo
            // 
            rotuloTitulo.AutoSize = true;
            rotuloTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            rotuloTitulo.Location = new Point(20, 15);
            rotuloTitulo.Name = "rotuloTitulo";
            rotuloTitulo.Size = new Size(223, 32);
            rotuloTitulo.TabIndex = 0;
            rotuloTitulo.Text = "Acesso ao Sistema";
            // 
            // rotuloUsuario
            // 
            rotuloUsuario.AutoSize = true;
            rotuloUsuario.Location = new Point(22, 60);
            rotuloUsuario.Name = "rotuloUsuario";
            rotuloUsuario.Size = new Size(62, 20);
            rotuloUsuario.TabIndex = 1;
            rotuloUsuario.Text = "Usuário:";
            // 
            // rotuloSenha
            // 
            rotuloSenha.AutoSize = true;
            rotuloSenha.Location = new Point(22, 95);
            rotuloSenha.Name = "rotuloSenha";
            rotuloSenha.Size = new Size(52, 20);
            rotuloSenha.TabIndex = 3;
            rotuloSenha.Text = "Senha:";
            // 
            // caixaUsuario
            // 
            caixaUsuario.Location = new Point(90, 56);
            caixaUsuario.Name = "caixaUsuario";
            caixaUsuario.Size = new Size(240, 27);
            caixaUsuario.TabIndex = 2;
            // 
            // caixaSenha
            // 
            caixaSenha.Location = new Point(90, 91);
            caixaSenha.Name = "caixaSenha";
            caixaSenha.PasswordChar = '•';
            caixaSenha.Size = new Size(240, 27);
            caixaSenha.TabIndex = 4;
            // 
            // botaoEntrar
            // 
            botaoEntrar.Location = new Point(170, 135);
            botaoEntrar.Name = "botaoEntrar";
            botaoEntrar.Size = new Size(75, 34);
            botaoEntrar.TabIndex = 5;
            botaoEntrar.Text = "Entrar";
            // 
            // botaoCancelar
            // 
            botaoCancelar.Location = new Point(255, 135);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(75, 34);
            botaoCancelar.TabIndex = 6;
            botaoCancelar.Text = "Cancelar";
            // 
            // FormLogin
            // 
            AcceptButton = botaoEntrar;
            CancelButton = botaoCancelar;
            ClientSize = new Size(360, 190);
            Controls.Add(rotuloTitulo);
            Controls.Add(rotuloUsuario);
            Controls.Add(caixaUsuario);
            Controls.Add(rotuloSenha);
            Controls.Add(caixaSenha);
            Controls.Add(botaoEntrar);
            Controls.Add(botaoCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
