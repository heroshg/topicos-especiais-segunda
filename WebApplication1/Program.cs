var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto>();

Produto produto1 = new Produto("Teclado", "Teclado gamer");
Produto produto2 = new Produto("Iphone", "Iphone 12 128gb");
Produto produto3 = new Produto("Notebook", "Notebook ASUS Gamer, 2060ti i7-9700k");
produtos.Add(produto1);
produtos.Add(produto2);
produtos.Add(produto3);


app.MapGet("/api/produtos", () => produtos);
app.MapPost("/api/produtos", (Produto produto) => produtos.Add(produto));


app.Run();

public record Produto(string Nome, string Descricao);

