using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Models;

namespace API.Context;

public class DataContext : DbContext
{
    private DbContextOptions<DataContext> _options;
    private IConfiguration _conf;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
    {
        _options = options;
        _conf = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_conf.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // seed data
        modelBuilder.Entity<Studente>().HasData(
            new Studente(1,"Mattia", "Valerio", 
                new DateTime(2002, 11, 19, 0, 0, 0, DateTimeKind.Utc), 
                "mattia.valerio2002@gmail.com",
                "3341306267", "esame finale da consegnare"),
            new Studente( 2, "Mario", "Rossi", 
                new DateTime(2001, 10, 10, 0, 0, 0, DateTimeKind.Utc), 
                "mariorossi@gmail.com", "3394587654", "esame da ripetere")
        );
        
        modelBuilder.Entity<Docente>().HasData(
            new Docente(1,"Marino", "Verdi", Specializzazione.Arte, 
                ModRicevimento.Presenza, 
                new List<GiorniSettimana> { GiorniSettimana.Lunedi, GiorniSettimana.Martedi }, 
                new List<DateTime>
                {
                    new DateTime(2024, 07, 18, 10, 20, 0, DateTimeKind.Utc),
                    new DateTime(2024, 07, 22, 09, 15, 0, DateTimeKind.Utc),
                    new DateTime(2024, 07, 27, 14, 30, 0,DateTimeKind.Utc),
                }),
            new Docente(2,"Alessia", "Viola", Specializzazione.Musica, 
                ModRicevimento.Videochiamata, 
                new List<GiorniSettimana> { GiorniSettimana.Venerdi, GiorniSettimana.Mercoledi }, 
                new List<DateTime>
                {
                    new DateTime(2024, 07, 16, 10, 0, 0,DateTimeKind.Utc),
                    new DateTime(2024, 07, 17, 15, 0, 0,DateTimeKind.Utc),
                    new DateTime(2024, 07, 18, 11, 30, 0,DateTimeKind.Utc),
                })
        );
    }

    // Add your DbSets here
    public DbSet<Studente> Studenti { get; set; }
    public DbSet<Docente> Docenti { get; set; }
    public DbSet<Appuntamento> Colloqui { get; set; }
}