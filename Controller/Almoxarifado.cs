namespace pastanova.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class Almoxarifado
    {
       
        public Almoxarifado(){}

       
       public static void criar(ListView lista, List<Model.Almoxarifado> almoxarifados, pastanova.View.FormularioAlmoxarifado formulario)
       {
           string nome = formulario.nomeProduto.Text.Trim();
           if (nome != "")
           {
               try
               {
                   Model.Almoxarifado novoAlmoxarifado = new Model.Almoxarifado() { Nome = nome, Id = almoxarifados.Count() + 1 };
                   Database.Contexto db = new Database.Contexto();
                   db.Almoxarifados.Add(novoAlmoxarifado);
                   db.SaveChanges();
                   listar(lista);
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
        public static void listar(ListView lista){
            try{
                Database.Contexto db = new Database.Contexto();
                List<Model.Almoxarifado> almoxarifados = db.Almoxarifados.ToList();
                AtualizarListaProdutos(lista,almoxarifados);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public static void remover(ListView lista)
        {
            if (lista.SelectedItems.Count > 0)
            {
                Model.Almoxarifado selecionado = (Model.Almoxarifado)lista.SelectedItems[0].Tag;
                // Remove o almoxarifado da lista
                Database.Contexto db = new Database.Contexto();
                var produtoToRemove = db.Almoxarifados.Find(selecionado.Id);
                if (produtoToRemove != null)
                {
                    try
                    {
                        db.Almoxarifados.Remove(produtoToRemove);
                        db.SaveChanges();
                        listar(lista);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao remover o produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
        } 
       public static void editar(ListView lista, List<Model.Almoxarifado> almoxarifados, pastanova.View.FormularioAlmoxarifado formulario, Model.Almoxarifado selecionado)
       {
           string nome = formulario.nomeProduto.Text.Trim();
           if (nome != "")
           {
               try
               {
                   Database.Contexto db = new Database.Contexto();
                   Model.Almoxarifado almoxarifado = db.Almoxarifados.Find(selecionado.Id);
                   if (almoxarifado != null)
                   {
                       almoxarifado.Nome = nome;
                       db.SaveChanges();
                   }
                   listar(lista);
               }
               catch (Exception ex)
               {
                    MessageBox.Show("Ocorreu um Erro" + ex.Message, "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               }
           }
           else
           { 
                MessageBox.Show("Infome o Nome", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           }
       }
        private static ListView AtualizarListaProdutos(ListView lista, List<Model.Almoxarifado> almoxarifados)
        {
            try
            {
                // Limpa todos os itens da lista de almoxarifados
                lista.Items.Clear();
        
                // Adiciona cada almoxarifado da lista na lista de almoxarifados
                foreach (Model.Almoxarifado almoxarifado in almoxarifados)
                {
                    ListViewItem item = new ListViewItem(almoxarifado.Nome);
                    item.Tag = almoxarifado;
                    lista.Items.Add(item);
                }
        
                return lista;
            }
            catch (Exception ex)
            {
                // handle any exceptions that occur during the update process
                MessageBox.Show("Ocorreu um erro ao atualizar a lista de produtos: " + ex.Message);
                return null;
            }
        }
    }
}