using Microsoft.EntityFrameworkCore;

public static class LojaApi
{

    public static void MapLojaApi(this WebApplication app)
    {
        var group = app.MapGroup("/lojas");


        group.MapGet("/lojas", async (BDD db) =>
        {

            //select * from Loja
            return await db.Loja.ToListAsync();

        });
        group.MapGet("/lojas/infos", async (BDD db) =>
        {
            //select * from Loja t where t.Entrega = true
            return await db.Loja.Where(t => t.Entrega).ToListAsync();

            //traz as entregas feita(true)

        });
        group.MapGet("/lojas/infos/{id}", async (int id, BDD db) =>
        {

            return await db.Loja.FindAsync(id)
                is Loja lojas ? Results.Ok(lojas) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/lojas", async (Loja lojas, BDD db) =>
        {
            db.Loja.Add(lojas);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/lojas/{lojas.Id}", lojas);
        });

        group.MapPut("/lojas/{id}", async (int id, Loja LojaAlterado, BDD db) =>
        {
            // select * from tarefas where Id = ?
            var lojas = await db.Loja.FindAsync(id);
            if (lojas == null) return Results.NotFound();

            lojas.Nome = LojaAlterado.Nome;
            lojas.Taxa = LojaAlterado.Taxa;
            lojas.Nota = LojaAlterado.Nota;
            lojas.Entrega = LojaAlterado.Entrega;

            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/lojas/{id}", async (int id, BDD db) =>
        {
            if (await db.Loja.FindAsync(id) is Loja lojas)
            {
                db.Loja.Remove(lojas);
                // delete from ... where id = ?
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();

        });

    }





}