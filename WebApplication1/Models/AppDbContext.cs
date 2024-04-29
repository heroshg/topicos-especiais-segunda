using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace WebApplication1.Models;

public class AppDbContext : DbContext
{

    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CompaniaDeCarro> CompaniaDeCarros { get; set; }
    public DbSet<ModeloCarro> ModeloDeCarros { get; set; }
    public DbSet<Doutor> Doutores { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }
    public DbSet<EstudanteAssunto> EstudanteAssuntos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relacionamento um para um : CompanhiaDeCarro(Pai), ModeloDeCarro(Filha)
        modelBuilder.Entity<CompaniaDeCarro>()
                .HasOne(a => a.ModeloCarro)
                .WithOne(c => c.CompanhiaDeCarro)
                .HasForeignKey<ModeloCarro>(k => k.CompaniaDeCarroId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento um para muitos: Doutor(pai), Paciente(filho)
        modelBuilder.Entity<Doutor>()
                 .HasMany(d => d.Pacientes)
                 .WithOne(p => p.Doutor)
                 .HasForeignKey(k => k.DoutorId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.NoAction);

        // Relacionamento muitos para muitos : Estudante, Assunto
        modelBuilder.Entity<EstudanteAssunto>(entity =>
        {
            entity.HasKey(ea => new { ea.EstudanteId, ea.AssuntoId }); // chave composta

            entity.HasOne(e => e.Estudante)
            .WithMany(e => e.EstudanteAssuntos)
            .HasForeignKey(ea => ea.EstudanteId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(a => a.Assunto)
            .WithMany(a => a.EstudanteAssuntos)
            .HasForeignKey(ea => ea.AssuntoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
        });

    }
}
