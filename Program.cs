using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Config banco de dados
builder.Services.AddDbContext<BDD>();

//Config swag
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Bem Vindo ao Ifode bebezinhu!");
app.MapGet("/lojas", async (BDD db) => {

    //select * from Loja
    return await db.Loja.ToListAsync();

});
app.MapGet("/lojas/infos", async (BDD db)=>{
    //select * from Loja t where t.Entrega = true
    return await db.Loja.Where(t => t.Entrega).ToListAsync();

    //traz as entregas feita(true)

});
app.MapGet("/lojas/infos/{id}", async (int id,BDD db) =>{
    
    return await db.Loja.FindAsync(id)
        is Loja lojas ? Results.Ok(lojas) : Results.NotFound();
});

                            //recebe os dados, as informações
app.MapPost("/lojas", async (Loja lojas, BDD db) => {
    db.Loja.Add(lojas);
    //insert into
    await db.SaveChangesAsync();

    return Results.Created($"/lojas/{lojas.Id}",lojas);
});

app.MapPut("/lojas/{id}", async (int id, Loja LojaAlterado, BDD db)=>{
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

app.MapDelete("/lojas/{id}", async (int id, BDD db)=>{
    if (await db.Loja.FindAsync(id) is Loja lojas)
    {
        db.Loja.Remove(lojas);
        // delete from ... where id = ?
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();

});

app.Run();
