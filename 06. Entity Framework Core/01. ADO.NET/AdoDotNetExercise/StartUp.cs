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
            string output = await ChangeTownNamesCasing(sqlConnection);
            Console.WriteLine(output);

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
            StringBuilder sb = new StringBuilder();
            int id = int.Parse(Console.ReadLine());

            await using (SqlCommand sqlCommandFindVillainName = new SqlCommand(SqlQueries.GetVillainNameWithId, connection))
            {
                sqlCommandFindVillainName.Parameters.AddWithValue("@Id", id);

                await using (SqlDataReader villainReader = await sqlCommandFindVillainName.ExecuteReaderAsync())
                {
                    if (!villainReader.HasRows)
                    {
                        sb.AppendLine($"No villain with ID {id} exists in the database.");
                        return sb.ToString().TrimEnd();
                    }

                    while (villainReader.Read())
                    {
                        string villainName = (string)villainReader["Name"];
                        sb.AppendLine($"Villain: {villainName}");
                    }


                }

            }

            await using (SqlCommand sqlCommandFindMinionsNameAndAge = new SqlCommand(SqlQueries.GetMinionsWithVillainId, connection))
            {
                sqlCommandFindMinionsNameAndAge.Parameters.AddWithValue("@Id", id);

                await using (SqlDataReader minionReader = await sqlCommandFindMinionsNameAndAge.ExecuteReaderAsync())
                {

                    if (!minionReader.HasRows)
                    {
                        sb.AppendLine("(no minions)");
                    }

                    while (minionReader.Read())
                    {
                        long rowNum = (long)minionReader["RowNum"];
                        string minionName = (string)minionReader["Name"];
                        int minionAge = (int)minionReader["Age"];

                        sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                    }
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
    }
}