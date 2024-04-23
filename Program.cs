
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

//API'S foram isoladas
app.MapLojaApi();


app.Run();
