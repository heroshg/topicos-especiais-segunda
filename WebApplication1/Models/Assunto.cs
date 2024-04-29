using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Assunto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    //Relacionamento: Muitos para muitos
    [JsonIgnore]
    public ICollection<EstudanteAssunto>? EstudanteAssuntos { get; set; }
}
