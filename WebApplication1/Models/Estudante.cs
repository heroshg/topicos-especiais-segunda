namespace WebApplication1.Models;

public class Estudante
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    //Relacionamento: Muitos para muitos
    public ICollection<EstudanteAssunto>? EstudanteAssuntos { get; set; }

}
