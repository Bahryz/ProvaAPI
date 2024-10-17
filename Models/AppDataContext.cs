using Aluno2.Models;
using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> funcionarios { get; set; }
    public DbSet<Folha> folhas { get; set; }

    // Construtor que aceita DbContextOptions
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Opcional, já que o DbContext é configurado no Program.cs
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=Aluno.db");
        }
    }
}
