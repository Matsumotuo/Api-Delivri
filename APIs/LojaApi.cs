using Microsoft.EntityFrameworkCore;

public static class LojaApi
{
    public static void MapLojaApi(this WebApplication app)
    {
        var group = app.MapGroup("/lojas");


        group.MapGet("/", async (BDD db) =>
        {

            //select * from Loja
            return await db.Loja.Include(c => c.Cardapios).ToListAsync();

        });
        group.MapGet("/infos", async (BDD db) =>
        {
            //select * from Loja t where t.Entrega = true
            return await db.Loja.Where(t => t.Entrega).ToListAsync();

            //traz as entregas feita(true)

        });
        group.MapGet("/infos/{id}", async (int id, BDD db) =>
        {
            return await db.Loja.FindAsync(id)
                is Loja lojas ? Results.Ok(lojas) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/addloja", async (Loja lojas, BDD db) =>
        {

            Console.WriteLine($"Loja: {lojas}");

            //tratamento para salvar cardapios com e sem ids
            lojas.Cardapios = await SalvarCardapio(lojas, db);

            db.Loja.Add(lojas);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/lojas/{lojas.Id}", lojas);
        }); 

        async Task<List<Cardapio>> SalvarCardapio(Loja lojas, BDD db)
    {
      List<Cardapio> cardapios = new();
      if (lojas is not null && lojas.Cardapios is not null 
          && lojas.Cardapios.Count > 0){

        foreach (var cardapio in lojas.Cardapios)
        {
          Console.WriteLine($"Cardapio: {cardapios}");
          if (cardapio.Id > 0)
          {
            var dExistente = await db.Cardapio.FindAsync(cardapio.Id);
            if (dExistente is not null)
            {
              cardapios.Add(dExistente);
            }
          }
          else
          {
            cardapios.Add(cardapio);
          }
        }
      }
      return cardapios;
    }


        group.MapPut("/trocarloja/{id}", async (int id, Loja LojaAlterado, BDD db) =>
        {
            // select * from tarefas where Id = ?
            var lojas = await db.Loja.FindAsync(id);
            if (lojas == null) return Results.NotFound();

            lojas.Nome = LojaAlterado.Nome;
            lojas.Taxa = LojaAlterado.Taxa;
            lojas.Nota = LojaAlterado.Nota;
            lojas.Entrega = LojaAlterado.Entrega;

            lojas.Cardapios = await SalvarCardapio(lojas, db);

            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/deletar/{id}", async (int id, BDD db) =>
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