using Microsoft.EntityFrameworkCore;

public class BDD :  DbContext{
    
     public BDD(DbContextOptions<BDD> options):base(options){    }

    //configurando o sql
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=projeto;user=root;password=1234");
    }

    //tabelas do banco de dados ficam junto no banco de dados
    public DbSet<Lojas> Lojas { get; set; }
    //add as outras tabelas

}