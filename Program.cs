var builder = WebApplication.CreateBuilder(args);

//Config swag

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Bem Vindo ao Ifode bebezinhu!");
app.MapGet("/lojas", () => "Lojas");
app.MapGet("/lojas/{id}", ()=> "Lojas por id");
app.MapGet("/lojas/pedidos/{id}", ()=> "Pedidos na loja(id)");


app.MapPost("/pedidos", ()=> "Pedidos");

app.MapPut("/pedidos/{id}", ()=> "Atualizar pedidos");

app.MapDelete("/pedidos/{id}", ()=> "Deletar pedido");

app.Run();
