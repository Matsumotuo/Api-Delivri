using Microsoft.EntityFrameworkCore;
public static class UsuarioApi{
    public static void MapUsuarioApi(this WebApplication app){

        var group = app.MapGroup("/usuario");

        group.MapGet("/usuarios", async (BDD db) => {

            return await db.Usuario.ToListAsync();
        });


        group.MapGet("/buscaruser/{id}", async (int id, BDD db) =>
        {

            return await db.Usuario.FindAsync(id)
                is Usuario usuarios ? Results.Ok(usuarios) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/novousuer", async (Usuario usuarios, BDD db) =>
        {
            db.Usuario.Add(usuarios);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/usuarios/{usuarios.Id}", usuarios);
        });

        group.MapPut("/trocaruser/{id}", async (int id, Usuario CardapioAlterado, BDD db) =>
        {
            // select * from usuario where Id = ?
            var usuarios = await db.Usuario.FindAsync(id);
            if (usuarios == null) return Results.NotFound();

            usuarios.NomeUser = CardapioAlterado.NomeUser;
            usuarios.UserAvalicao = CardapioAlterado.UserAvalicao;
            
          
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