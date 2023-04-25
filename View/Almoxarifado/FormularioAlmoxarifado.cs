namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormularioAlmoxarifado : Form
    {
        Button botaoSalvar;
        public TextBox nomeProduto;
        public TextBox quantidadeProduto;

        Label nome;

        Label quantidade;
        private Button botaoCancelar;

        public FormularioAlmoxarifado(string nomeProdutoAtual = "", string quantidadeProdutoAtual = "")
        {
            this.Text = "Produto";
            this.Width = 600;
            this.nome = new Label();
            nome.Location = new Point(10, 10);
            nome.Width = 150;
            nome.Text = "Nome";
            this.Controls.Add(nome);
            this.nomeProduto = new TextBox();
            nomeProduto.Location = new Point(10, 40);
            nomeProduto.Width = 150;
            nomeProduto.Text = nomeProdutoAtual;
            this.Controls.Add(nomeProduto);
          
          
          
            this.botaoSalvar = new Button();
            botaoSalvar.Text = "Salvar";
            botaoSalvar.Location = new Point(20, 200);
            botaoSalvar.Click += new EventHandler(this.botaoSalvar_Click);
            this.Controls.Add(botaoSalvar);
            this.botaoCancelar = new Button();
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.Location = new Point(20, 200);
            botaoCancelar.Click += new EventHandler(this.botaoCancelar_Click);
            this.Controls.Add(botaoSalvar);
        }
        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}