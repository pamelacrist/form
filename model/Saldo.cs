namespace pastanova.Model
{
    public class Saldo
    {
        public int Id { get; set; }
        public int ProdutoId  { get; set; }
        public int Quantidade { get; set; }
        public int AlmoxarifadoId { get; set; }
        public string NomeProduto // propriedade que retorna o nome do produto associado
        {
            get { return Produto?.Nome; }
        }
         public Produto Produto { get; set; }
        public Almoxarifado Almoxarifado { get; set; }
    }
}