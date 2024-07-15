namespace Shared.DTOs;

public class AddAppuntamento
{
    public int DocenteId { get; set; }
    public int StudenteId { get; set; }
    public DateTime Appuntamento { get; set; }
}