namespace pastanova.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.EntityFrameworkCore;

    public class Saldo
    {
       
        public Saldo(){}

       
        public static void criar(ListView lista,List<Model.Saldo> saldos, pastanova.View.FormularioSaldo formulario)
        {
            string almoxarifado = formulario.almoxarifado.Text.Trim();
            string saldo = formulario.produto.Text.Trim();
            string quantidade = formulario.quantidadeProduto.Text.Trim();
        
            
        
            if (saldo != "" && almoxarifado != "" && int.Parse(quantidade) > 0)
            {
                try
                {
                    Model.Saldo novoSaldo = new Model.Saldo() { ProdutoId = int.Parse(saldo) , AlmoxarifadoId = int.Parse(almoxarifado) , Quantidade =  int.Parse(quantidade), Id = saldos.Count() + 1 };
                    Database.Contexto db = new Database.Contexto();
                    db.Saldos.Add(novoSaldo);
                    db.SaveChanges();
                    listar(lista);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao salvar o saldo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         public static void listar(ListView lista){
            try{
                Database.Contexto db = new Database.Contexto();
                List<Model.Saldo> saldos = db.Saldos.Include(p => p.Produto).Include(p => p.Almoxarifado).ToList();
                AtualizarListaProdutos(lista,saldos); 
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        } 

        public static void remover(ListView lista){
            if (lista.SelectedItems.Count > 0)
            {
                Model.Saldo selecionado = (Model.Saldo)lista.SelectedItems[0].Tag;
                Database.Contexto db = new Database.Contexto();
                var saldo = db.Saldos.Find(selecionado.Id);
                if (saldo != null)
                {
                    try
                    {
                        db.Saldos.Remove(saldo);
                        db.SaveChanges();
                        listar(lista);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Saldo não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um saldo para remover", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }   
        public static void editar(ListView lista,List<Model.Saldo> saldos, pastanova.View.FormularioSaldo formulario,Model.Saldo selecionado)
        {
            string almoxarifado = formulario.almoxarifado.Text.Trim();
            string produto = formulario.produto.Text.Trim();
            string quantidade = formulario.produto.Text.Trim();
        
            if (quantidade != "" && produto != "" && almoxarifado != "" && int.Parse(quantidade) > 0)
            {
                try
                {
                    Database.Contexto db = new Database.Contexto();
                    Model.Saldo saldo = db.Saldos.Find(selecionado.Id);
                    if (saldo != null)
                    {
                        saldo.ProdutoId = int.Parse(produto);
                        saldo.Quantidade = int.Parse(quantidade);
                        saldo.AlmoxarifadoId = int.Parse(almoxarifado);
                        db.SaveChanges();
                    }
                   listar(lista);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro durante a edição do saldo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static ListView AtualizarListaProdutos(ListView lista, List<Model.Saldo> saldos)
        {
            try
            {
                // Limpa todos os itens da lista de saldos
                lista.Items.Clear();
        
                // Adiciona cada saldo da lista na lista de saldos
                foreach (Model.Saldo saldo in saldos)
                {
                    ListViewItem item = new ListViewItem(saldo.Id.ToString());
                    item.SubItems.Add(saldo.Produto.Nome.ToString());
                    item.SubItems.Add(saldo.Almoxarifado.Nome.ToString());
                    item.SubItems.Add(saldo.Quantidade.ToString());
                    item.Tag = saldo;
                    lista.Items.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: "+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}