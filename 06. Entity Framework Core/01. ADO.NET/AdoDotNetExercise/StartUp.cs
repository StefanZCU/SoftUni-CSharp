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
    }
}