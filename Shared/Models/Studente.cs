using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Studente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime DataNascita { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string?  Note { get; set; }

    public Studente()
    {
        
    }
    public Studente(int id, string nome, string cognome, DateTime dataNascita, string email, string telefono, string note)
    {
        Id = id;
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        Email = email;
        Telefono = telefono;
        Note = note;
    }
    
    public Studente(string nome, string cognome, DateTime dataNascita, string email, string telefono, string note)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        Email = email;
        Telefono = telefono;
        Note = note;
    }
}