var builder = WebApplication.CreateBuilder(args);

//Config swag

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Bem Vindo ao Ifode bebezinhu!");

app.Run();
