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
            string output = await AddMinionsAndVillains(sqlConnection);
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

        //Problem 04. Start

        static async Task<string> AddMinionsAndVillains(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();
            string[] villainInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();

            string minionName = minionInfo[0];
            string minionAge = minionInfo[1];
            string town = minionInfo[2];

            string villainName = villainInfo[0];


            //Find townId, if it doesn't exist, insert it into DB and display message

            await using SqlCommand findTownIdCommand = new SqlCommand(SqlQueries.GetTownIdByName, connection);
            findTownIdCommand.Parameters.AddWithValue("@townName", town);

            using (SqlDataReader reader = await findTownIdCommand.ExecuteReaderAsync())
            {
                while (!reader.Read())
                {
                    await using SqlCommand createTownAndInsertCommand = new SqlCommand(SqlQueries.InsertIntoTownsTable, connection);
                    createTownAndInsertCommand.Parameters.AddWithValue("@townName", town);
                    createTownAndInsertCommand.ExecuteNonQuery();
                    sb.AppendLine($"Town {town} was added to the database.");
                }
            }

            //Find villainId, if it doesn't exist, insert it into DB and display message

            await using SqlCommand findVillainIdCommand = new SqlCommand(SqlQueries.GetVillainIdByName, connection);
            findVillainIdCommand.Parameters.AddWithValue("@Name", villainName);

            using (SqlDataReader reader = await findVillainIdCommand.ExecuteReaderAsync())
            {
                while (!reader.Read())
                {
                    await using SqlCommand createVillainAndInsertCommand = new SqlCommand(SqlQueries.InsertIntoVillainsTable, connection);
                    createVillainAndInsertCommand.Parameters.AddWithValue("@villainName", villainName);
                    createVillainAndInsertCommand.ExecuteNonQuery();
                    sb.AppendLine($"Villain {villainName} was added to the database.");
                }
            }

            await using (SqlCommand createMinionAndInsertCommand =
                         new SqlCommand(SqlQueries.InsertIntoMinionsTable, connection))
            {
                int townId = (int)findTownIdCommand.ExecuteScalar();

                createMinionAndInsertCommand.Parameters.AddWithValue("@name", minionName);
                createMinionAndInsertCommand.Parameters.AddWithValue("@age", minionAge);
                createMinionAndInsertCommand.Parameters.AddWithValue("@townId", townId);
                createMinionAndInsertCommand.ExecuteNonQuery();
            }

            await using (SqlCommand addMinionToVillainCommand =
                         new SqlCommand(SqlQueries.InsertIntoMinionsVillainsTable, connection))
            {
                int villainId = (int)findVillainIdCommand.ExecuteScalar();

                await using (SqlCommand findMinionIdByName = new SqlCommand(SqlQueries.GetMinionIdByName, connection))
                {
                    findMinionIdByName.Parameters.AddWithValue("@Name", minionName);

                    using (SqlDataReader reader = await findMinionIdByName.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            var loop = true;
                            while (loop)
                            {
                                int minionId = (int)reader["Id"];
                                loop = reader.Read();
                                if (loop) continue;

                                addMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);
                                addMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);

                            }
                        }
                    }

                    addMinionToVillainCommand.ExecuteNonQuery();
                    sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04. End


    }
}