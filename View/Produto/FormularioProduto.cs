namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormularioProduto : Form
    {
        Button botaoSalvar;
        public TextBox nomeProduto;
        public TextBox precoProduto;

        Label nome;

        Label preco;
        private Button botaoCancelar;

        public FormularioProduto(string nomeProdutoAtual = "", string precoProdutoAtual = "")
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
            this.preco = new Label();
            preco.Location = new Point(10, 80);
            preco.Text = "Preco";
            preco.Width = 150;
            this.Controls.Add(preco);
            this.precoProduto = new TextBox();
            precoProduto.Location = new Point(10, 120);
            precoProduto.Width = 150;
            precoProduto.Text = precoProdutoAtual;
            this.Controls.Add(precoProduto);
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