namespace P07.Models.Interfaces
{
    using Enums;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
