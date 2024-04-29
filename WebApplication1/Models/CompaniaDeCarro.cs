using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class CompaniaDeCarro
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    //Relacionamento: um para um
    [JsonIgnore]
    public ModeloCarro? ModeloCarro { get; set; } // propriedade de navegação

}
