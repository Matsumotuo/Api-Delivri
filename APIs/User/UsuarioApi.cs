using Microsoft.EntityFrameworkCore;
public static class UsuarioApi{
    public static void MapUsuarioApi(this WebApplication app){

        var group = app.MapGroup("/usuario");

        group.MapGet("/usuarios", async (BDD db) => {

            return await db.Usuario.Include(c => c.Enderecos).ToListAsync();
        });


        group.MapGet("/buscaruser/{id}", async (int id, BDD db) =>
        {

            return await db.Usuario.FindAsync(id)
                is Usuario usuarios ? Results.Ok(usuarios) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/novousuer", async (Usuario usuarios, BDD db) =>
        {
            Console.Write($"Usuario: {usuarios}");

            usuarios.Enderecos = await SalvarEnde(usuarios, db);

            db.Usuario.Add(usuarios);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/usuarios/{usuarios.Id}", usuarios);
        });

        async Task<List<Endereco>> SalvarEnde(Usuario usuarios, BDD db)
      {
      List<Endereco> Enderecos = new();
      if (usuarios is not null && usuarios.Enderecos is not null 
          && usuarios.Enderecos.Count > 0){

        foreach (var Endereco in usuarios.Enderecos)
        {
          Console.WriteLine($"Endereco: {Enderecos}");
          if (Endereco.Id > 0)
          {
            var dExistente = await db.Endereco.FindAsync(Endereco.Id);
            if (dExistente is not null)
            {
              Enderecos.Add(dExistente);
            }
          }
          else
          {
            Enderecos.Add(Endereco);
          }
        }
      }
      return Enderecos;
    }


        group.MapPut("/trocaruser/{id}", async (int id, Usuario EnderecoAlterado, BDD db) =>
        {
            // select * from usuario where Id = ?
            var usuarios = await db.Usuario.FindAsync(id);
            if (usuarios == null) return Results.NotFound();

            usuarios.NomeUser = EnderecoAlterado.NomeUser;
            usuarios.UserAvalicao = EnderecoAlterado.UserAvalicao;
            
          
            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/deletarusuario{id}", async (int id, BDD db) =>
        {
            if (await db.Usuario.FindAsync(id) is Usuario usuarios)
            {
                db.Usuario.Remove(usuarios);
                // delete from ... where id = ?
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();

        });

    }
}