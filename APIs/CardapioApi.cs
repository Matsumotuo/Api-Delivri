using Microsoft.EntityFrameworkCore;
public static class CardapioApi{
    public static void MapCardapioApi(this WebApplication app){

        var group = app.MapGroup("/cardapios");

        group.MapGet("/cardapio", async (BDD db) => {

            return await db.Cardapio.ToListAsync();
        });


        group.MapGet("/Cardapios/cardapio/{id}", async (int id, BDD db) =>
        {

            return await db.Cardapio.FindAsync(id)
                is Cardapio Cardapios ? Results.Ok(Cardapios) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/Cardapios", async (Cardapio cardapios, BDD db) =>
        {
            db.Cardapio.Add(cardapios);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/Cardapios/{cardapios.Id}", cardapios);
        });

        group.MapPut("/Cardapios/cardapio{id}", async (int id, Cardapio CardapioAlterado, BDD db) =>
        {
            // select * from tarefas where Id = ?
            var Cardapios = await db.Cardapio.FindAsync(id);
            if (Cardapios == null) return Results.NotFound();

            Cardapios.Item = CardapioAlterado.Item;
            Cardapios.ItemNome = CardapioAlterado.ItemNome;
            Cardapios.Preco = CardapioAlterado.Preco;
          
            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/cardapio/{id}", async (int id, BDD db) =>
        {
            if (await db.Cardapio.FindAsync(id) is Cardapio Cardapios)
            {
                db.Cardapio.Remove(Cardapios);
                // delete from ... where id = ?
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();

        });

    }
}