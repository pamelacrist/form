
namespace pastanova.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class ListaProduto : Form
    {
        Button botaoCriar;
        Button botaoEditar;
        Button botaoRemover;
        ListView listaProdutos;
        List<Model.Produto> produtos = new List<Model.Produto>();
        public ListaProduto()
        {
             Console.WriteLine("asd");
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
            this.listaProdutos = new ListView();
            listaProdutos.Location = new Point(10, botaoRemover.Bottom + 10);
            listaProdutos.Width = 300;
            listaProdutos.Height = 300;
            listaProdutos.View = View.Details;
            listaProdutos.FullRowSelect = true;
            listaProdutos.Columns.Add("Nome", 150);
            listaProdutos.Columns.Add("Preco", 150);
            listaProdutos.FullRowSelect = true;
            this.Controls.Add(listaProdutos);
            Controller.Produto.listar(listaProdutos);
        }
        private void botaoCriar_Click(object sender, EventArgs e)
        {
            FormularioProduto formulario = new pastanova.View.FormularioProduto();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                Controller.Produto.criar(listaProdutos, produtos, formulario);
            }
        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (listaProdutos.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listaProdutos.SelectedItems[0];

                if (itemSelecionado != null && itemSelecionado.Tag != null)
                {
                    Model.Produto produtoSelecionado = (Model.Produto)itemSelecionado.Tag;
                    FormularioProduto formulario = new FormularioProduto(produtoSelecionado.Nome, produtoSelecionado.Preco.ToString());
                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        Controller.Produto.editar(listaProdutos, produtos, formulario,produtoSelecionado);
                    }
                }
            }
        }
        private void botaoRemover_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Certeza que quer remover ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {Console.Write("asd");
                Controller.Produto.remover(listaProdutos, produtos);
            }
        }

    }
}