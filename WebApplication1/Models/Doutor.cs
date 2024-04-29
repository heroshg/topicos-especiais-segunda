using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Doutor
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    //Relacionamento: Um para muitos
    //Um doutor, muitos pacientes
    [JsonIgnore] // Serve para não retornar a lista de clientes no json de doutor.
    public List<Paciente>? Pacientes { get; set; }
}
