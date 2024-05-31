using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Config banco de dados
builder.Services.AddDbContext<BDD>();

//Evitar circulação referencial 
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

//Config swag
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Bem Vindo ao Delivris!");

//API'S foram isoladas
app.MapLojaApi();
app.MapCardapioApi();
app.MapPedidoApi();
app.MapEnderecoApi();
app.MapUsuarioApi();

app.Run();
