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

            string output = await GetVillainNamesWithThreeOrMoreMinionsAsync(sqlConnection);
            Console.WriteLine(output);

        }

        //Problem 02.

        static async Task<string> GetVillainNamesWithThreeOrMoreMinionsAsync(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.VillainNameWithThreeOrMoreMinions, connection);

            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while(reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}