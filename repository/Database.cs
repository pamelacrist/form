namespace pastanova.Database
{
    using Microsoft.EntityFrameworkCore;
    using pastanova.Model;

    public class Contexto : DbContext
    {
         private string _connectionString = "Server=localhost;User Id=root;pwd=pamela;Database=Almoxarifado;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Almoxarifado> Almoxarifados { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
    }
}