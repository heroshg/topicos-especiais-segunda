using System.Numerics;

namespace WebApplication1.Models;

public class Paciente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    //Relacionamento: Muitos para um
    //Muitos pacientes, um doutor
    public Doutor? Doutor { get; set; }
    public int DoutorId { get; set; }
}
