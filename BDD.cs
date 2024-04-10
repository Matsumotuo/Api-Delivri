using Microsoft.EntityFrameworkCore;

public class BDD :  DbContext{
    //configurando o sql
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3606;database=ifode;user=root;passaword=123");
    }


    //tabelas do banco de dados ficam junto no banco de dados

    public DbSet<Lojas>Lojas { get; set; }
    //add as outras tabelas

}