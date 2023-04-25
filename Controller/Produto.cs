namespace pastanova.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class Produto
    {
        public Produto() { }

        public static void criar(ListView listaProdutos, List<Model.Produto> produtos, pastanova.View.FormularioProduto formulario)
        {
            string nome = formulario.nomeProduto.Text.Trim();
            int preco = int.Parse(formulario.precoProduto.Text.Trim());
            if (nome != "" && preco > 0)
            {
                try
                {
                    Model.Produto novoProduto = new Model.Produto() { Nome = nome, Preco = preco, Id = produtos.Count() + 1 };
                    Database.Contexto db = new Database.Contexto();
                    db.Produtos.Add(novoProduto);
                    db.SaveChanges();
                    listar(listaProdutos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao criar o novo produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um nome para o produto.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void remover(ListView listaProdutos, List<Model.Produto> produtos)
        {
            if (listaProdutos.SelectedItems.Count > 0)
            {
                try
                {
                    Model.Produto produtoSelecionado = (Model.Produto)listaProdutos.SelectedItems[0].Tag;
                    // Remove o produto da lista
                    Database.Contexto db = new Database.Contexto();
                    var produtoToRemove = db.Produtos.Find(produtoSelecionado.Id);
                    if (produtoToRemove != null)
                    {
                        db.Produtos.Remove(produtoToRemove);
                        db.SaveChanges();
                    }
                    listar(listaProdutos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void listar(ListView listaProdutos)
        {
            try
            {
                Database.Contexto db = new Database.Contexto();
                List<Model.Produto> produtos = db.Produtos.ToList();
                AtualizarListaProdutos(listaProdutos, produtos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public static void editar(ListView listaProdutos,List<Model.Produto> produtos, pastanova.View.FormularioProduto formulario,Model.Produto produtoSelecionado)
        {
            string nome = formulario.nomeProduto.Text.Trim();
            string preco = formulario.precoProduto.Text.Trim();
            if ( preco == "" || preco == " "|| int.Parse(preco) <= 0)
            {
                MessageBox.Show("Por favor, insira um preço válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nome == "" || nome == " ")
            {
                MessageBox.Show("Por favor, insira um nome válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Database.Contexto db = new Database.Contexto();
                Model.Produto produto = db.Produtos.Find(produtoSelecionado.Id);
                if (produto != null)
                {
                    produto.Nome = nome;
                    produto.Preco = int.Parse(preco);
                    db.SaveChanges();
                }
                listar(listaProdutos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao editar o produto: "+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static ListView AtualizarListaProdutos(ListView listaProdutos, List<Model.Produto> produtos)
        {
            try
            {
                // Limpa todos os itens da lista de produtos
                listaProdutos.Items.Clear();

                // Adiciona cada produto da lista na lista de produtos
                foreach (Model.Produto produto in produtos)
                {
                    ListViewItem item = new ListViewItem(produto.Nome);
                    item.SubItems.Add(produto.Preco.ToString());
                    item.Tag = produto;
                    listaProdutos.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar a lista de produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaProdutos;
        }
    }
}