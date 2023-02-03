using System.Reflection.Metadata;
using MilitaryElite.IO.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core
{
    using Interface;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public Engine()
        {
            soldiers = new HashSet<ISoldier>();
        }

        public void Start()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    ISoldier privateSoldier = new Private(id, firstName, lastName, salary);
                    soldiers.Add(privateSoldier);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    ICollection<IPrivate> privates = FindPrivates(cmdArgs);
                    ISoldier lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    soldiers.Add(lieutenantGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsText = cmdArgs[5];
                    bool isCorpsValid = Enum.TryParse(corpsText, true, out Corps corps);

                    if (isCorpsValid)
                    {
                        ICollection<IRepair> repairs = CreateRepairs(cmdArgs);
                        ISoldier soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        soldiers.Add(soldier);
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsText = cmdArgs[5];
                    bool isCorpsValid = Enum.TryParse(corpsText, true, out Corps corps);

                    if (isCorpsValid)
                    {
                        ICollection<IMission> missions = CreateMission(cmdArgs);
                        ISoldier soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                        soldiers.Add(soldier);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    ISoldier soldier = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(soldier);
                }
            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }


        private ICollection<IPrivate> FindPrivates(string[] cmdArgs)
        {
            int[] newArray = cmdArgs.Skip(5).Select(int.Parse).ToArray();

            var collection = new List<IPrivate?>();

            foreach (var privateID in newArray)
            {
                var currentPrivate = (IPrivate)this.soldiers.FirstOrDefault(x => x.ID == privateID);

                collection.Add(currentPrivate);
            }

            return collection;
        }
        private ICollection<IRepair> CreateRepairs(string[] cmdArgs)
        {
            ICollection<IRepair> repairs = new List<IRepair>();

            string[] repairsToMake = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairsToMake.Length; i += 2)
            {
                string repairPart = repairsToMake[i];
                int repairHour = int.Parse(repairsToMake[i + 1]);

                IRepair repair = new Repair(repairPart, repairHour);
                repairs.Add(repair);
            }

            return repairs;
        }
        private ICollection<IMission> CreateMission(string[] cmdArgs)
        {
            ICollection<IMission> missions = new List<IMission>();

            string[] missionsToCreate = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < missionsToCreate.Length; i += 2)
            {
                string missionName = missionsToCreate[i];
                string missionState = missionsToCreate[i + 1];

                bool isMissionStateValid = Enum.TryParse(missionState, out State state);
                if (isMissionStateValid)
                {
                    IMission mission = new Mission(missionName, state);
                    missions.Add(mission);
                }
            }

            return missions;
        }
    }
}
