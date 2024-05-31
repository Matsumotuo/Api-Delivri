using Microsoft.EntityFrameworkCore;
public static class EnderecoApi{
    public static void MapEnderecoApi(this WebApplication app){

        var group = app.MapGroup("/enderecos");

        group.MapGet("/enderecos", async (BDD db) => {

            return await db.Endereco.ToListAsync();
        });


        group.MapGet("/enderecoid/{id}", async (int id, BDD db) =>
        {

            return await db.Endereco.FindAsync(id)
                is Endereco enderecos ? Results.Ok(enderecos) : Results.NotFound();
        });

        //recebe os dados, as informações
        group.MapPost("/novocep", async (Endereco enderecos, BDD db) =>
        {
            db.Endereco.Add(enderecos);
            //insert into
            await db.SaveChangesAsync();

            return Results.Created($"/enderecos/{enderecos.Id}", enderecos);
        });

        group.MapPut("/alterarendereco{id}", async (int id, Endereco EnderecoAlterado, BDD db) =>
        {
            // select * from endereco where Id = ?
            var Enderecos = await db.Endereco.FindAsync(id);
            if (Enderecos == null) return Results.NotFound();

            Enderecos.Rua = EnderecoAlterado.Rua;
            Enderecos.Numero = EnderecoAlterado.Numero;
            Enderecos.CEP = EnderecoAlterado.CEP;
            Enderecos.Complemento = EnderecoAlterado.Complemento;
          
            // update from ...
            await db.SaveChangesAsync();
            return Results.NoContent();

        });

        group.MapDelete("/deletarendereco/{id}", async (int id, BDD db) =>
        {
            if (await db.Endereco.FindAsync(id) is Endereco Enderecos)
            {
                db.Endereco.Remove(Enderecos);
                // delete from ... where id = ?
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();

        });

    }
}