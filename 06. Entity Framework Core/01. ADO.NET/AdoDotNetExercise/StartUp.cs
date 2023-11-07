using System.Data;
using System.Xml.Linq;

namespace AdoDotNetExercise
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();

            //Problem 02.
            //string output = await GetVillainNamesWithThreeOrMoreMinionsAsync(sqlConnection);
            //Console.WriteLine(output);

            //Problem 03.
            //string output = await GetAllMinionsNamesAndAgeForCurrentVillainIdAsync(sqlConnection);
            //Console.WriteLine(output);

            //Problem 04.
            //string output = await AddMinionsAndVillains(sqlConnection);
            //Console.WriteLine(output);

            //Problem 05.
            //string output = await ChangeTownNamesCasing(sqlConnection);
            //Console.WriteLine(output);

            //Problem 06.
            //string output = await RemoveVillainFromDB(sqlConnection);
            //Console.WriteLine(output);

            //Problem 07.
            //string output = await PrintAllMinionNames(sqlConnection);
            //Console.WriteLine(output);

            //Problem 08.
            //string output = await IncreaseMinionAge(sqlConnection);
            //Console.WriteLine(output);

            //Problem 09.
            //string output = await IncreaseAgeStoredProcedureAsync(sqlConnection);
            //Console.WriteLine(output);
        }

        //Problem 02.

        static async Task<string> GetVillainNamesWithThreeOrMoreMinionsAsync(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.VillainNameWithThreeOrMoreMinions, connection);

            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 03.

        static async Task<string> GetAllMinionsNamesAndAgeForCurrentVillainIdAsync(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCmd =
                new SqlCommand(SqlQueries.GetVillainNameWithId, connection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();
            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            SqlCommand getAllMinionsCmd =
                new SqlCommand(SqlQueries.GetMinionsWithVillainId, connection);
            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            string output =
                GenerateVillainWithMinionsOutput(villainName, minionsReader);
            return output;
        }

        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //Problem 04.

        static async Task<string> AddMinionsAndVillains(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();
            string[] villainInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();

            string minionName = minionInfo[0];
            string minionAge = minionInfo[1];
            string townName = minionInfo[2];

            string villainName = villainInfo[0];

            SqlCommand checkTownIdByNameCmd = new SqlCommand(SqlQueries.GetTownIdByName, connection);
            checkTownIdByNameCmd.Parameters.AddWithValue("@townName", townName);
            object? foundTown = await checkTownIdByNameCmd.ExecuteScalarAsync();

            if (foundTown == null)
            {
                SqlCommand insertTownToDBCmd = new SqlCommand(SqlQueries.InsertIntoTownsTable, connection);
                insertTownToDBCmd.Parameters.AddWithValue("@townName", townName);
                await insertTownToDBCmd.ExecuteNonQueryAsync();
                sb.AppendLine($"Town {townName} was added to the database.");
            }

            int townId = (int)await checkTownIdByNameCmd.ExecuteScalarAsync();

            SqlCommand checkVillainIdByNameCmd = new SqlCommand(SqlQueries.GetVillainIdByName, connection);
            checkVillainIdByNameCmd.Parameters.AddWithValue("@Name", villainName);
            object? foundVillain = await checkVillainIdByNameCmd.ExecuteScalarAsync();

            if (foundVillain == null)
            {
                SqlCommand insertVillainToDBCmd = new SqlCommand(SqlQueries.InsertIntoVillainsTable, connection);
                insertVillainToDBCmd.Parameters.AddWithValue("@villainName", villainName);
                await insertVillainToDBCmd.ExecuteNonQueryAsync();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)await checkVillainIdByNameCmd.ExecuteScalarAsync();

            SqlCommand insertMinionToDBCmd = new SqlCommand(SqlQueries.InsertIntoMinionsTable, connection);
            insertMinionToDBCmd.Parameters.AddWithValue("@name", minionName);
            insertMinionToDBCmd.Parameters.AddWithValue("@age", minionAge);
            insertMinionToDBCmd.Parameters.AddWithValue("@townId", townId);

            await insertMinionToDBCmd.ExecuteNonQueryAsync();

            SqlCommand findMinionIdByName = new SqlCommand(SqlQueries.GetMinionIdByName, connection);
            findMinionIdByName.Parameters.AddWithValue("@Name", minionName);
            int minionId = 0;

            SqlDataReader minionReader = await findMinionIdByName.ExecuteReaderAsync();

            while (minionReader.Read())
            {
                minionId = (int)minionReader[0];
            }

            minionReader.Close();

            SqlCommand insertMinionToVillainTableCmd =
                new SqlCommand(SqlQueries.InsertIntoMinionsVillainsTable, connection);
            insertMinionToVillainTableCmd.Parameters.AddWithValue("@minionId", minionId);
            insertMinionToVillainTableCmd.Parameters.AddWithValue("@villainId", villainId);
            await insertMinionToVillainTableCmd.ExecuteNonQueryAsync();

            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return sb.ToString().TrimEnd();
        }

        //Problem 05.

        static async Task<string> ChangeTownNamesCasing(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            string countryName = Console.ReadLine();

            SqlCommand getCountryTownsCmd = new SqlCommand(SqlQueries.GetTownsForCountry, connection);
            getCountryTownsCmd.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader countryTownsReader = await getCountryTownsCmd.ExecuteReaderAsync();

            if (!countryTownsReader.HasRows)
            {
                sb.AppendLine("No town names were affected.");
                return sb.ToString().TrimEnd();
            }
            
            countryTownsReader.Close();

            SqlCommand changeTownCasesCommand = new SqlCommand(SqlQueries.ChangeCasesOfTownsTable, connection);
            changeTownCasesCommand.Parameters.AddWithValue("@countryName", countryName);
            int rowsAffected = await changeTownCasesCommand.ExecuteNonQueryAsync();

            sb.AppendLine($"{rowsAffected} town names were affected.");
            SqlDataReader townNameReader = await getCountryTownsCmd.ExecuteReaderAsync();

            while (townNameReader.Read())
            {
                sb.Append($"{(string)townNameReader[0]}, ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString().TrimEnd();
        }

        //Problem 06.

        static async Task<string> RemoveVillainFromDB(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCommand = new SqlCommand(SqlQueries.GetVillainNameById, connection);
            getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);
            string? villainName = (string)await getVillainNameCommand.ExecuteScalarAsync();

            if (villainName == null)
            {
                sb.AppendLine("No such villain was found.");
                return sb.ToString().TrimEnd();
            }

            sb.AppendLine($"{villainName} was deleted.");

            SqlCommand removeFromMinionsVillainsTable =
                new SqlCommand(SqlQueries.RemoveFromMinionsVillainsTable, connection);
            removeFromMinionsVillainsTable.Parameters.AddWithValue("@villainId", villainId);
            int removedMinions = await removeFromMinionsVillainsTable.ExecuteNonQueryAsync();

            SqlCommand removeVillainFromVillainTable = new SqlCommand(SqlQueries.RemoveFromVillainsTable, connection);
            removeVillainFromVillainTable.Parameters.AddWithValue("@villainId", villainId);
            await removeVillainFromVillainTable.ExecuteNonQueryAsync();

            sb.AppendLine($"{removedMinions} minions were released.");

            return sb.ToString().TrimEnd();
        }

        //Problem 07.

        static async Task<string> PrintAllMinionNames(SqlConnection connection)
        {
            var sb = new StringBuilder();
            var minionNames = new List<string>();
            SqlCommand getAllMinionNamesCommand = new SqlCommand(SqlQueries.GetAllMinionNames, connection);
            SqlDataReader minionNameReader = await getAllMinionNamesCommand.ExecuteReaderAsync();

            while (minionNameReader.Read())
            {
                minionNames.Add((string)minionNameReader["Name"]);
            }

            int countMinions = minionNames.Count();

            for (int i = 0; i <= countMinions / 2; i++)
            {
                if (i < countMinions)
                {
                    sb.AppendLine(minionNames[i]);
                }

                if (i < countMinions - 1)
                {
                    sb.AppendLine(minionNames[countMinions - 1 - i]);
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08.

        static async Task<string> IncreaseMinionAge(SqlConnection connection)
        {
            
            var sb = new StringBuilder();

            int[] minionIds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SqlCommand alterMinionAgeAndNameCommand =
                new SqlCommand(SqlQueries.ChangeAgeAndChangeFirstLetterOfMinions, connection);

            SqlParameter minionIdParam = new SqlParameter("@Id", SqlDbType.Int);

            foreach (var id in minionIds)
            {
                minionIdParam.Value = id;
                alterMinionAgeAndNameCommand.Parameters.Add(minionIdParam);
                await alterMinionAgeAndNameCommand.ExecuteNonQueryAsync();
                alterMinionAgeAndNameCommand.Parameters.Remove(minionIdParam);
            }

            SqlCommand nameAndAgeOfMinionsCommand = new SqlCommand(SqlQueries.GetNameAndAgeOfMinions, connection);
            SqlDataReader minionNameAndAgeReader = await nameAndAgeOfMinionsCommand.ExecuteReaderAsync();

            while (minionNameAndAgeReader.Read())
            {
                string minionName = (string)minionNameAndAgeReader["Name"];
                int minionAge = (int)minionNameAndAgeReader["Age"];
                sb.AppendLine($"{minionName} {minionAge}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09.

        static async Task<string> IncreaseAgeStoredProcedureAsync(SqlConnection connection)
        {
            /*
                CREATE PROC usp_GetOlder @id INT
                    AS
                UPDATE Minions
                SET Age += 1
                WHERE Id = @id
             */

            var sb = new StringBuilder();
            int minionId = int.Parse(Console.ReadLine());

            SqlCommand storedProcedureCommandToIncreaseAge = new SqlCommand("usp_GetOlder", connection);
            storedProcedureCommandToIncreaseAge.CommandType = CommandType.StoredProcedure;
            storedProcedureCommandToIncreaseAge.Parameters.Add(new SqlParameter("@Id", minionId));
            await storedProcedureCommandToIncreaseAge.ExecuteNonQueryAsync();

            SqlCommand getMinionNameAndAge = new SqlCommand(SqlQueries.GetNameAndAgeOfMinionById, connection);
            getMinionNameAndAge.Parameters.AddWithValue("@Id", minionId);
            SqlDataReader minionReader = await getMinionNameAndAge.ExecuteReaderAsync();

            while (minionReader.Read())
            {
                string minionName = (string)minionReader["Name"];
                int minionAge = (int)minionReader["Age"];
                sb.AppendLine($"{minionName} - {minionAge} years old");
            }

            return sb.ToString().TrimEnd();
        }
    }
}