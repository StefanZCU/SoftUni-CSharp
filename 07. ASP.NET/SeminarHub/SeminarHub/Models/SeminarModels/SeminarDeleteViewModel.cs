namespace SeminarHub.Models.SeminarModels;

public class SeminarDeleteViewModel
{
    public int Id { get; set; }
    
    public string Topic { get; set; } = null!;

    public DateTime DateAndTime { get; set; }
}