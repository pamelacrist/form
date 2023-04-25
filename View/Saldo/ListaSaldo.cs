
namespace pastanova.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class ListaSaldo : Form
    {
        Button botaoCriar;
        Button botaoEditar;
        Button botaoRemover;
        ListView lista;
        List<Model.Saldo> produtos = new List<Model.Saldo>();
        public ListaSaldo()
        {
            this.Text = "Saldo";
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
            this.lista = new ListView();
            lista.Location = new Point(10, botaoRemover.Bottom + 10);
            lista.Width = 600;
            lista.Height = 300;
            lista.View = View.Details;
            lista.FullRowSelect = true;
            lista.Columns.Add("Id", 150);
            lista.Columns.Add("Produto", 150);
            lista.Columns.Add("Almoxarifado", 150);
            lista.Columns.Add("Quantidade", 150);
            lista.FullRowSelect = true;
            this.Controls.Add(lista);
            Controller.Saldo.listar(lista);
        }
        private void botaoCriar_Click(object sender, EventArgs e)
        {
            FormularioSaldo formulario = new pastanova.View.FormularioSaldo();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                Controller.Saldo.criar(lista, produtos, formulario);
            }
        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = lista.SelectedItems[0];

                if (itemSelecionado != null && itemSelecionado.Tag != null)
                {
                    Model.Saldo produtoSelecionado = (Model.Saldo)itemSelecionado.Tag;
                    FormularioSaldo formulario = new FormularioSaldo(produtoSelecionado.Produto.ToString(), produtoSelecionado.Quantidade.ToString(),produtoSelecionado.Almoxarifado.ToString());
                    // Show testDialog as a modal dialog and determine if DialogResult = OK.
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        Controller.Saldo.editar(lista, produtos, formulario,produtoSelecionado);
                    }
                }
            }
        }
        private void botaoRemover_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Certeza que quer remover ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {
                Controller.Saldo.remover(lista);
            }
        }

    }
}