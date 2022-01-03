
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(
    "Data Source=DESKTOP-HOME-LE;Initial Catalog=MINIMALAPINET6;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionarProduto", async (Produto produto, Contexto contexto) => { 
    
    contexto.Produto.Add(produto); await contexto.SaveChangesAsync();
});

app.MapDelete("RemoverProduto/{id}", async (int id, Contexto contexto) => {

    var produto = await contexto.Produto.FindAsync(id);

    if(produto != null)
    {
        contexto.Produto.Remove(produto); await contexto.SaveChangesAsync();
    }
});

app.MapGet("ListarProdutoPorId/{id}", async (int id, Contexto contexto) =>
{
   return await contexto.Produto.FindAsync(id);
});

app.MapGet("ListarProdutos", async (Contexto contexto) =>
{
   return await contexto.Produto.ToListAsync();
});

app.UseSwaggerUI();

app.Run();
