using Microsoft.EntityFrameworkCore;

public class BDD :  DbContext{
    
     public BDD(DbContextOptions<BDD> options)
     : base(options){    }

    //configurando o sql
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=1234");
    }

    protected override void OnModelCreating(ModelBuilder mb){

        mb.Entity<Endereco>() // herança entre usuario e endereco
        .HasMany(e => e.Usuarios)
        .WithMany(u => u.Enderecos)
        .UsingEntity<Dictionary<string, object>>(
            "UsuarioEndereco",
            j => j.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioId"),
            j => j.HasOne<Endereco>().WithMany().HasForeignKey("EnderecoId")
        );

         mb.Entity<Lojas>() // herança entre loja e cardapio
        .HasMany(c => c.Cardapios)
        .WithMany(l => l.Lojas)
        .UsingEntity<Dictionary<string, object>>(
            "LojasCardapio",
            j => j.HasOne<Cardapio>().WithMany().HasForeignKey("CardapioId"),
            j => j.HasOne<Lojas>().WithMany().HasForeignKey("LojasId")
        );
    }

    //tabelas do banco de dados ficam junto no banco de dados
    public DbSet<Lojas> Lojas  => Set<Lojas>();

    public DbSet<Cardapio> Cardapio => Set<Cardapio>();

    public DbSet<Pedido> Pedido => Set<Pedido>();
    //add as outras tabelas

}