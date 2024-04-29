namespace WebApplication1.Models;

public class EstudanteAssunto
{
    public Estudante? Estudante { get; set; }
    public int EstudanteId { get; set; }
    public Assunto? Assunto { get; set; }
    public int AssuntoId { get; set; }
}
