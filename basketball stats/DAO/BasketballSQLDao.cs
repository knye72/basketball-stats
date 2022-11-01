using basketball_stats.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace basketball_stats.DAO
{
    public class BasketballSQLDao : IBasketballDAO
    {
        private readonly string connectionString;

        public BasketballSQLDao(string connString)
        {
            connectionString = connString;
        }



        public IList<Player> GetPlayer(string userSearchTerm)
        {
            List<Player> playerList = new List<Player>();
            Player player = null;
            using (SqlConnection mySqlConn = new SqlConnection(connectionString))
            {
                mySqlConn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Points WHERE Player LIKE @search", mySqlConn);
                string searchTerm = "%" + userSearchTerm + "%";

                cmd.Parameters.AddWithValue("@search", searchTerm);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    player = CreatePlayerFromReader(reader);
                    playerList.Add(player);
                }
            }
                return playerList;
        }

        public void DeletePlayer(int rank)
        {

            Console.WriteLine("That dude is gone.");
        }

        private Player CreatePlayerFromReader(SqlDataReader reader)
        {
            Player player = new Player();
            player.Age = Convert.ToInt32(reader["Age"]);
            player.PlayerName = Convert.ToString(reader["Player"]);
            if (reader["FG1"] is DBNull)
            {
                player.ThreePointPct = null;
            }
            else
            {
                player.FieldGoalPct = Convert.ToDecimal(reader["FG1"]);

            }

            //Converting database's null -> C# null
            if (reader["_3P1"] is DBNull)
            {
                player.ThreePointPct = null;
            }
            else
            {

            player.ThreePointPct = Convert.ToDecimal(reader["_3P1"]);
            }
            player.Rank = Convert.ToInt32(reader["Rk"]);
            player.Points = Convert.ToInt32(reader["PTS"]);
            player.Team = Convert.ToString(reader["Tm"]);

            return player;
        }


    }
}
