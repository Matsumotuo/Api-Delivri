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

        /*mb.Entity<Endereco>() // relacionamento entre usuario e endereco
        .HasMany(e => e.Usuarios)
        .WithMany(u => u.Enderecos)
        .UsingEntity<Dictionary<string, object>>(
            "UsuarioEndereco",
            j => j.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioId"),
            j => j.HasOne<Endereco>().WithMany().HasForeignKey("EnderecoId")
        );*/

        mb.Entity<Loja>()
            .HasMany(l => l.Cardapios)
            .WithMany(c => c.Lojas)
            .UsingEntity<Dictionary<string, object>>(
                "LojaCardapio",
                j => j.HasOne<Cardapio>().WithMany().HasForeignKey("CardapioId"),
                j => j.HasOne<Loja>().WithMany().HasForeignKey("LojaId"),
                je =>
                {
                    je.HasKey("LojaId", "CardapioId");
                    je.ToTable("LojaCardapio");
                }
            );
    }

    //tabelas do banco de dados ficam junto no banco de dados
    public DbSet<Loja> Loja  => Set<Loja>();

    public DbSet<Cardapio> Cardapio => Set<Cardapio>();

    public DbSet<Pedido> Pedido => Set<Pedido>();

    public DbSet<Usuario> Usuario => Set<Usuario>();

    public DbSet<Endereco> Endereco => Set<Endereco>(); 
    //add as outras tabelas

}