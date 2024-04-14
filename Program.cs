using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddDbContext<BDD>(
    options => options.UseInMemoryDatabase("lojas")
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/
builder.Services.AddDbContext<BDD>();

//Config swag
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Bem Vindo ao Ifode bebezinhu!");
app.MapGet("/lojas", async (BDD db) => {

    //select * from Lojas
    return await db.Lojas.ToListAsync();

});
app.MapGet("/lojas/infos", async (BDD db)=>{
    //select * from Lojas t where t.Entrega = true
    return await db.Lojas.Where(t => t.Entrega).ToListAsync();

    //traz as entregas feita(true)

});
app.MapGet("/lojas/infos/{id}", async (int id,BDD db) =>{
    
    return await db.Lojas.FindAsync(id)
        is Lojas lojas ? Results.Ok(lojas) : Results.NotFound();
});


app.MapPost("/lojas", async (Lojas lojas, BDD db) => {
    db.Lojas.Add(lojas);
    //insert into
    await db.SaveChangesAsync();

    return Results.Created($"/lojas/{lojas.Id}",lojas);
});

app.MapPut("/lojas/{id}", async (int id, Lojas LojaAlterado, BDD db)=>{
    // select * from tarefas where Id = ?
    var lojas = await db.Lojas.FindAsync(id);
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
    if (await db.Lojas.FindAsync(id) is Lojas lojas)
    {
        db.Lojas.Remove(lojas);
        // delete from ... where id = ?
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();

});

app.Run();
