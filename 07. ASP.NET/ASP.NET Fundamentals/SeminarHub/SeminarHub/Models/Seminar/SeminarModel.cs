namespace SeminarHub.Models.Seminar;

public class SeminarModel
{
    public int Id { get; set; }
    public string Topic { get; set; }

    public string Lecturer { get; set; }

    public string Category { get; set; }

    public string DateAndTime { get; set; }
    
    public string Organizer { get; set; }
    
}