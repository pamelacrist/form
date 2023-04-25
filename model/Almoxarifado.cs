using System.Collections.Generic;

namespace pastanova.Model
{
    public class Almoxarifado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Saldo> Saldos { get; set; }
    }
}