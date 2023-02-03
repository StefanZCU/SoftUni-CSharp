namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    using System.Text;

    public class Mission : IMission
    {
        public string CodeName { get; private set; }
        public State State { get; private set; }

        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }
        public void CompleteMission(IMission mission)
        {
            State = State.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
