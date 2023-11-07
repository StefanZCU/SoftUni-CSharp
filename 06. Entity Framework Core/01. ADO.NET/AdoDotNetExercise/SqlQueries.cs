namespace AdoDotNetExercise
{
    internal static class SqlQueries
    {
        public const string VillainNameWithThreeOrMoreMinions =
            @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
            GROUP BY v.Id, v.Name 
                HAVING COUNT(mv.VillainId) > 3 
            ORDER BY COUNT(mv.VillainId)";

        public const string GetVillainNameWithId = "SELECT Name FROM Villains WHERE Id = @Id";

        public const string GetMinionsWithVillainId = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                                 m.Name, 
                                                                 m.Age
                                                            FROM MinionsVillains AS mv
                                                            JOIN Minions As m ON mv.MinionId = m.Id
                                                           WHERE mv.VillainId = @Id
                                                        ORDER BY m.Name";

        public const string GetVillainIdByName = "SELECT Id FROM Villains WHERE Name = @Name";
        public const string GetMinionIdByName = "SELECT Id FROM Minions WHERE Name = @Name";
        public const string GetTownIdByName = "SELECT Id FROM Towns WHERE Name = @townName";

        public const string InsertIntoMinionsVillainsTable =
            "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public const string InsertIntoVillainsTable =
            "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertIntoMinionsTable = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
        public const string InsertIntoTownsTable = "INSERT INTO Towns (Name) VALUES (@townName)";


        public const string ChangeCasesOfTownsTable = @"UPDATE Towns
                                                           SET Name = UPPER(Name)
                                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string GetTownsForCountry = @" SELECT t.Name 
                                                       FROM Towns as t
                                                       JOIN Countries AS c ON c.Id = t.CountryCode
                                                      WHERE c.Name = @countryName";

        public const string GetVillainNameById = "SELECT Name FROM Villains WHERE Id = @villainId";

        public const string RemoveFromMinionsVillainsTable = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

        public const string RemoveFromVillainsTable = @"DELETE FROM Villains
      WHERE Id = @villainId";

        public const string GetAllMinionNames = "SELECT Name FROM Minions";

        public const string ChangeAgeAndChangeFirstLetterOfMinions = @"UPDATE Minions
                                                                       SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                                     WHERE Id = @Id";

        public const string GetNameAndAgeOfMinions = @"SELECT Name, Age FROM Minions";

        public const string GetNameAndAgeOfMinionById = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
