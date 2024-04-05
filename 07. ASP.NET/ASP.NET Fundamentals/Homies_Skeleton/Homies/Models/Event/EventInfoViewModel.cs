using Homies.Data;

namespace Homies.Models.Event;

public class EventInfoViewModel
{

    public EventInfoViewModel(int id, string name, DateTime start, string type, string organiser)
    {
        Id = id;
        Name = name;
        Type = type;
        Organiser = organiser;
        Start = start.ToString(DataConstants.DateFormat);
    }
    
    public int Id { get; set; }

    public string Name { get; set; }

    public string Start { get; set; }

    public string Type { get; set; }

    public string Organiser { get; set; }
}