using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace Shared.Models;

public class Docente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public Specializzazione Specializzazione { get; set; }
    public ModRicevimento ModRicevimento { get; set; }
    public List<GiorniSettimana> GiornateDiInsegnamento { get; set; }
    public List<DateTime> DisponibilitaRicevimento { get; set; }

    public Docente()
    {
        
    }
    public Docente(
        string name, 
        string lastName, 
        Specializzazione specializzazione, 
        ModRicevimento modRicevimento, 
        List<GiorniSettimana> giornateDiInsegnamento, 
        List<DateTime> disponibilitaRicevimento)
    {
        Name = name;
        LastName = lastName;
        Specializzazione = specializzazione;
        ModRicevimento = modRicevimento;
        GiornateDiInsegnamento = giornateDiInsegnamento;
        DisponibilitaRicevimento = disponibilitaRicevimento;
    }
    
    public Docente(
        int id,
        string name, 
        string lastName, 
        Specializzazione specializzazione, 
        ModRicevimento modRicevimento, 
        List<GiorniSettimana> giornateDiInsegnamento, 
        List<DateTime> disponibilitaRicevimento)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Specializzazione = specializzazione;
        ModRicevimento = modRicevimento;
        GiornateDiInsegnamento = giornateDiInsegnamento;
        DisponibilitaRicevimento = disponibilitaRicevimento;
    }
}