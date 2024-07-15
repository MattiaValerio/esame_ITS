using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class Appuntamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Docente Docente { get; set; }
    public Studente Studente { get; set; }
    public DateTime DataColloquioRichiesta { get; set; } 

    public bool Confermato { get; set; }
    public Appuntamento()
    {
        DataColloquioRichiesta = DateTime.UtcNow;
    }
}