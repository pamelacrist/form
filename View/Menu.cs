namespace pastanova.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class Menu : Form
    {

        Button botaoProduto;
        Button botaoSair;
        Button botaoAlmoxarifado;
        Button botaoSaldo;

        public Menu()
        {
            Text = "Titulo da Janela";
            this.botaoProduto = new Button();
            botaoProduto.Text = "Produto";
            botaoProduto.Width = 100;
            botaoProduto.Location = new Point(Width / 2 - botaoProduto.Width / 2, Height / 2 - botaoProduto.Height / 2 - 50);
            botaoProduto.Click += new EventHandler(botaoProduto_Click);
            Controls.Add(botaoProduto);
            this.botaoAlmoxarifado = new Button();
            botaoAlmoxarifado.Text = "Almoxarifado";
            botaoAlmoxarifado.Width = 100;
            botaoAlmoxarifado.Location = new Point(Width / 2 - botaoAlmoxarifado.Width / 2, Height / 2 - botaoAlmoxarifado.Height / 2 - 90);
            botaoAlmoxarifado.Click += new EventHandler(botaoAlmoxarifado_Click);
            Controls.Add(botaoAlmoxarifado);
            this.botaoSaldo = new Button();
            botaoSaldo.Text = "Saldo";
            botaoSaldo.Width = 100;
            botaoSaldo.Location = new Point(Width / 2 - botaoProduto.Width / 2, Height / 2 - botaoProduto.Height / 2 - 120);
            botaoSaldo.Click += new EventHandler(botaoSaldo_Click);
            Controls.Add(botaoSaldo);
            this.botaoSair = new Button();
            botaoSair.Text = "Sair";
            botaoSair.Width = 100;
            botaoSair.Location = new Point(Width / 2 - botaoSair.Width / 2, Height / 2 - botaoSair.Height / 2);
            botaoSair.Click += new EventHandler(botaoSair_Click);
            Controls.Add(botaoSair);
        }
        private void botaoProduto_Click(object sender, EventArgs e)
        {
            var tela = new pastanova.View.ListaProduto();
            tela.ShowDialog();
        }
        private void botaoAlmoxarifado_Click(object sender, EventArgs e)
        {
            var tela = new pastanova.View.ListaAlmoxarifado();
            tela.ShowDialog();
        }

        private void botaoSaldo_Click(object sender, EventArgs e)
        {
            var tela = new pastanova.View.ListaSaldo();
            tela.ShowDialog();
        }
        private void botaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCancelarClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}