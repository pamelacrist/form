using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace pastanova
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Formulario());
        }
    }

    public class Formulario : Form
    {

        Button botaoProduto;
        Button botaoSair;

        public Formulario()
        {
            this.Text = "Titulo da Janela";
            this.botaoProduto = new Button();
            botaoProduto.Text = "Produto";
            botaoProduto.Location = new Point((this.Width / 2 - botaoProduto.Width / 2), (this.Height / 2 - botaoProduto.Height / 2) - 50);
            botaoProduto.Click += new EventHandler(this.botaoProduto_Click);
            this.Controls.Add(botaoProduto);
            this.botaoSair = new Button();
            botaoSair.Text = "Sair";
            botaoSair.Location = new Point((this.Width / 2 - botaoSair.Width / 2), (this.Height / 2 - botaoSair.Height / 2));
            botaoSair.Click += new EventHandler(this.botaoSair_Click);
            this.Controls.Add(botaoSair);
        }
        private void botaoProduto_Click(object sender, EventArgs e)
        {
            TelaProduto tela = new TelaProduto();
            tela.ShowDialog();
        }

        private void botaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }


    public class TelaProduto : Form
    {
        Button botaoCriar;
        Button botaoEditar;
        Button botaoRemover;
        Button botaoSalvar;
        TextBox nomeProduto;
        TextBox quantidadeProduto;
        ListView listaProdutos;

        List<Produto> produtos = new List<Produto>();

        public TelaProduto()
        {
            this.Text = "Produto";
            this.Width = 600;
            this.botaoCriar = new Button();
            botaoCriar.Text = "Criar";
            botaoCriar.Location = new Point(10, 10);
            botaoCriar.Click += new EventHandler(this.botaoCriar_Click);
            this.Controls.Add(botaoCriar);

            this.botaoEditar = new Button();
            botaoEditar.Text = "Editar";
            botaoEditar.Location = new Point(botaoCriar.Right + 10, 10);
            botaoEditar.Click += new EventHandler(this.botaoEditar_Click);
            this.Controls.Add(botaoEditar);

            this.botaoRemover = new Button();
            botaoRemover.Text = "Remover";
            botaoRemover.Location = new Point(botaoEditar.Right + 10, 10);
            botaoRemover.Click += new EventHandler(this.botaoRemover_Click);
            this.Controls.Add(botaoRemover);

            this.nomeProduto = new TextBox();
            nomeProduto.Location = new Point(10, botaoCriar.Bottom + 10);
            nomeProduto.Width = 150;
            this.Controls.Add(nomeProduto);

            this.quantidadeProduto = new TextBox();
            quantidadeProduto.Location = new Point(nomeProduto.Right + 10, botaoCriar.Bottom + 10);
            quantidadeProduto.Width = 150;
            this.Controls.Add(quantidadeProduto);
            this.botaoSalvar = new Button();
            botaoSalvar.Text = "Salvar";
            botaoSalvar.Location = new Point(botaoRemover.Right + 10, 10);
            botaoSalvar.Click += new EventHandler(this.botaoSalvar_Click);
            this.Controls.Add(botaoSalvar);
            this.listaProdutos = new ListView();
            listaProdutos.Location = new Point(10, nomeProduto.Bottom + 10);
            listaProdutos.Width = 300;
            listaProdutos.Height = 300;
            listaProdutos.View = View.Details;
            listaProdutos.FullRowSelect = true;
            listaProdutos.SelectedIndexChanged += new EventHandler(this.listaProdutos_SelectedIndexChanged);
            listaProdutos.Columns.Add("Nome", 150);
            listaProdutos.Columns.Add("Quantidade", 150);
            listaProdutos.FullRowSelect = true;
            this.Controls.Add(listaProdutos);
        }
        private void botaoCriar_Click(object sender, EventArgs e)
        {
            string nome = nomeProduto.Text.Trim();
            int quantidade = int.Parse(quantidadeProduto.Text.Trim());

            if (nome != "" && quantidade > 0)
            {
                Produto novoProduto = new Produto() { Nome = nome, Quantidade = quantidade };
                produtos.Add(novoProduto);

                AtualizarListaProdutos();
            }
        }
        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            if (nomeProduto.Text.Trim() != "" && int.TryParse(quantidadeProduto.Text.Trim(), out int novaQuantidade) && novaQuantidade > 0)
            {
                if (listaProdutos.SelectedItems.Count > 0)
                {
                    Produto produtoSelecionado = (Produto)listaProdutos.SelectedItems[0].Tag;
                    produtoSelecionado.Nome = nomeProduto.Text.Trim();
                    produtoSelecionado.Quantidade = novaQuantidade;

                    // Atualizar subitens do item selecionado na lista
                    listaProdutos.SelectedItems[0].SubItems[0].Text = produtoSelecionado.Nome;
                    listaProdutos.SelectedItems[0].SubItems[1].Text = produtoSelecionado.Quantidade.ToString();
                }
            }
        }
        private void AtualizarListaProdutos()
        {
            // Limpa todos os itens da lista de produtos
            listaProdutos.Items.Clear();

            // Adiciona cada produto da lista na lista de produtos
            foreach (Produto produto in produtos)
            {
                ListViewItem item = new ListViewItem(produto.Nome);
                item.SubItems.Add(produto.Quantidade.ToString());
                item.Tag = produto;
                listaProdutos.Items.Add(item);
            }
        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (listaProdutos.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listaProdutos.SelectedItems[0];

                if (itemSelecionado != null && itemSelecionado.Tag != null)
                {
                    Produto produtoSelecionado = (Produto)itemSelecionado.Tag;
                    nomeProduto.Text = produtoSelecionado.Nome;
                    quantidadeProduto.Text = produtoSelecionado.Quantidade.ToString();
                }
            }
        }
        private void botaoRemover_Click(object sender, EventArgs e)
        {
            if (listaProdutos.SelectedItems.Count > 0)
            {
                Produto produtoSelecionado = (Produto)listaProdutos.SelectedItems[0].Tag;

                foreach (Produto produto in produtos)
                {
                    if (produto.Nome == produtoSelecionado.Nome && produto.Quantidade == produtoSelecionado.Quantidade)
                    {
                        // Remove o produto da lista
                        produtos.Remove(produto);

                        // Remove o produto da ListView
                        listaProdutos.Items.Remove(listaProdutos.SelectedItems[0]);

                        break;
                    }
                }
            }
        }

        private void listaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado
            if (listaProdutos.SelectedItems.Count > 0 && listaProdutos.SelectedItems != null)
            {
                // Obtém o produto selecionado
                Produto produtoSelecionado = (Produto)listaProdutos.SelectedItems[0].Tag;

                // Atualiza o TelaProduto com as informações do produto selecionado
                nomeProduto.Text = produtoSelecionado.Nome;
                quantidadeProduto.Text = produtoSelecionado.Quantidade.ToString();
            }
        }
    }
}
