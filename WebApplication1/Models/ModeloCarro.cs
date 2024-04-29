namespace WebApplication1.Models;

public class ModeloCarro
{
        public int Id { get; set; }
        public string? Model { get; set; }
        //Relacionamento : um para um
        public CompaniaDeCarro? CompanhiaDeCarro { get; set; } // Propriedade de navegação
        public int CompaniaDeCarroId { get; set; } // FK
    
}
