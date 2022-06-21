using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using P01InitialSetup;

namespace P04AddMinion
{
    public class StartUp
    {
        public static int TownId;
        public static int MinionId;
        public static int VillainId;


        public static void Main(string[] args)
        {

            Console.WriteLine("Please enter minion information in format \"Minion: < Name > < Age > < TownName > \"");


            string input = Console.ReadLine()?
                .Split(":", StringSplitOptions.RemoveEmptyEntries)[1];
            if (input == null) return;
            string[] minionInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            Console.WriteLine("Please enter villain information in format \"Villain: <Name>\"");
            string[] villainInfo = Console.ReadLine()?
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            if (villainInfo == null) return;

            string villainName = villainInfo[1];


            using SqlConnection connection = new SqlConnection(string.Format(Configuration.ConnectionString, Configuration.databaseName));
            connection.Open();


            using (connection)
            {
                using SqlCommand townCmd = new SqlCommand(Queries.TakeTownId, connection);
                townCmd.Parameters.AddWithValue("@townName", minionTown);
                object targetTownId = townCmd.ExecuteScalar();

                if (targetTownId != null)
                {
                    TownId = (int)targetTownId;
                }
                else
                {
                    using SqlCommand townCmdToAdd = new SqlCommand(Queries.InsertTownName, connection);

                    townCmdToAdd.Parameters.AddWithValue("@townName", minionTown);

                    townCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                using SqlCommand minionCmd = new SqlCommand(Queries.TakeMinionId, connection);

                minionCmd.Parameters.AddWithValue("@Name", minionName);

                object targetMinionId = minionCmd.ExecuteScalar();

                if (targetMinionId != null)
                {
                    MinionId = (int)targetMinionId;
                }
                else
                {
                    using SqlCommand minionCmdToAdd = new SqlCommand(Queries.InsertMinion, connection);

                    minionCmdToAdd.Parameters.AddWithValue("@name", minionName);
                    minionCmdToAdd.Parameters.AddWithValue("@age", minionAge);
                    minionCmdToAdd.Parameters.AddWithValue("@townId", TownId);

                    minionCmdToAdd.ExecuteNonQuery();
                }

                using SqlCommand villainCmd = new SqlCommand(Queries.TakeVillainId, connection);

                villainCmd.Parameters.AddWithValue("@Name", villainName);

                object targetVillainId = villainCmd.ExecuteScalar();

                if (targetVillainId != null)
                {
                    VillainId = (int)targetVillainId;
                }
                else
                {
                    using SqlCommand villainCmdToAdd = new SqlCommand(Queries.InsertVillain, connection);

                    villainCmdToAdd.Parameters.AddWithValue("@villainName", villainName);

                    villainCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                using SqlCommand minionOfVillainCmd = new SqlCommand(Queries.InsertMinionVillain, connection);
                minionOfVillainCmd.Parameters.AddWithValue("@villainId", VillainId);
                minionOfVillainCmd.Parameters.AddWithValue("@minionId", MinionId);

                minionOfVillainCmd.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}