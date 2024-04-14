using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});
var app = builder.Build();


app.MapGet("/api/produtos",
    async (AppDbContext context) =>
    await context.Produtos.ToListAsync());


app.MapGet("/api/produtos/{nome}", async ([FromRoute] string nome, AppDbContext context) => {
   var tarefa = await context.Produtos.FirstOrDefaultAsync(p => p.Nome.ToUpper() == nome.ToUpper());
    if(tarefa is null)
    {
        return  Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(tarefa);
});
app.MapPost("/api/produtos",
    async ([FromBody] Produto produto, AppDbContext context) => {
        if(produto != null)
        {
            context.Produtos.Add(produto);
            await context.SaveChangesAsync();
            return Results.Created("Criado com sucesso!", produto);
        }
        return Results.BadRequest("Falha ao registrar produto!");
    });


app.MapPut("/api/produtos/{nome}", async ([FromRoute] string nome, [FromBody] Produto produto, AppDbContext context) =>
{
    Produto? produtoRecuperado = await context.Produtos.FirstOrDefaultAsync(p => p.Nome.ToUpper() == nome.ToUpper());
    if (produtoRecuperado == null)
    {
        return Results.NotFound();
    }
    produtoRecuperado.Nome = produto.Nome;
    produtoRecuperado.Descricao = produto.Descricao;
    produtoRecuperado.Quantidade = produto.Quantidade;
    await context.SaveChangesAsync();
    return Results.NoContent();

});
app.MapDelete("/api/produtos/{nome}", async ([FromRoute] string nome, AppDbContext context) =>
{
    var produtoADeletar = await context.Produtos.FirstOrDefaultAsync(a => a.Nome.ToUpper() == nome.ToUpper());
    if(produtoADeletar == null) return Results.NotFound("Produto não encontrado!");
    context.Remove(produtoADeletar);
    await context.SaveChangesAsync();
    return Results.Ok(produtoADeletar);
});


app.Run();


