using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace pastanova.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }

        public ICollection<Saldo> Saldos { get; set; }
    }
}