using Microsoft.EntityFrameworkCore;
public static class PedidoApi{
    public static void MapPedidoApi(this WebApplication app){

        var group = app.MapGroup("/pedido");

        group.MapGet("/pedidos", async (BDD db) => {

            return await db.Pedido.ToListAsync();
        });


        group.MapGet("/buscarpedido/{id}", async (int id, BDD db) =>
        {

            return await db.Pedido.FindAsync(id)
                is Pedido Pedidos ? Results.Ok(Pedidos) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/novopedido", async (Pedido Pedidos, BDD db) =>
        {
            db.Pedido.Add(Pedidos);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/pedidos/{Pedidos.Id}", Pedidos);
        });

        group.MapPut("/trocarpedido/{id}", async (int id, Pedido PedidoAlterado, BDD db) =>
        {
            // select * from tarefas where Id = ?
            var Pedidos = await db.Pedido.FindAsync(id);
            if (Pedidos == null) return Results.NotFound();

            Pedidos.PedidoId = PedidoAlterado.PedidoId;
            Pedidos.Detalhes = PedidoAlterado.Detalhes;
            Pedidos.Quantidade = PedidoAlterado.Quantidade;
          
            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/deletarpedido{id}", async (int id, BDD db) =>
        {
            if (await db.Pedido.FindAsync(id) is Pedido Pedidos)
            {
                db.Pedido.Remove(Pedidos);
                // delete from ... where id = ?
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();

        });

    }
}