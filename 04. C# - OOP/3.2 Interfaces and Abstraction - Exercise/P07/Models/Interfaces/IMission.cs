
namespace MilitaryElite.Models.Interfaces
{
    using Enums;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        public void CompleteMission(IMission mission);
    }
}
