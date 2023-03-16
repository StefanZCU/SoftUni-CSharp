namespace Easter.Models.Workshops
{
    using System.Linq;

    using Contracts;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy != 0 && bunny.Dyes.Any(x => !x.IsFinished()))
            {
                var currentDye = bunny.Dyes.First(x => !x.IsFinished());
                bunny.Work();
                currentDye.Use();
                egg.GetColored();

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
