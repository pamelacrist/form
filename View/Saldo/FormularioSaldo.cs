namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormularioSaldo : Form
    {
        Button botaoSalvar;
        public TextBox produto;
        public TextBox quantidadeProduto;
        public TextBox almoxarifado;

        Label nomeproduto;

        Label quantidade;
        Label nomeAlmoxarifado;
        private Button botaoCancelar;

        public FormularioSaldo(string nomeProdutoAtual = "", string quantidadeProdutoAtual = "",string nomeAlmoxarifadoAtual = "" )
        {
            this.Text = "Saldo";
            this.Width = 600;
            //produto
            this.nomeproduto = new Label();
            nomeproduto.Location = new Point(10, 10);
            nomeproduto.Width = 150;
            nomeproduto.Text = "Produto";
            this.Controls.Add(nomeproduto);
            this.produto = new TextBox();
            produto.Location = new Point(10, 40);
            produto.Width = 150;
            produto.Text = nomeProdutoAtual;
            this.Controls.Add(produto);

            //almoxarifado
            this.nomeAlmoxarifado = new Label();
            nomeAlmoxarifado.Location = new Point(10, 80);
            nomeAlmoxarifado.Width = 150;
            nomeAlmoxarifado.Text = "Almoxarifado";
            this.Controls.Add(nomeAlmoxarifado);
            this.almoxarifado = new TextBox();
            almoxarifado.Location = new Point(10, 120);
            almoxarifado.Width = 150;
            almoxarifado.Text = nomeAlmoxarifadoAtual;
            this.Controls.Add(almoxarifado);
            
            this.quantidade = new Label();
            quantidade.Location = new Point(10, 160);
            quantidade.Text = "Quantidade";
            quantidade.Width = 150;
            this.Controls.Add(quantidade);
            this.quantidadeProduto = new TextBox();
            quantidadeProduto.Location = new Point(10, 190);
            quantidadeProduto.Width = 150;
            quantidadeProduto.Text = quantidadeProdutoAtual;
            this.Controls.Add(quantidadeProduto);
            this.botaoSalvar = new Button();
            botaoSalvar.Text = "Salvar";
            botaoSalvar.Location = new Point(20, 230);
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