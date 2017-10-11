using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=NavyIncorpBD; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            SqlCommand command = new SqlCommand("SELECT U.FName, U.LName, U.MName, T.Name FROM Users U INNER JOIN Player P ON P.UserId = U.Id INNER JOIN Team T ON P.TeamId = T.Id GROUP BY T.Name, U.FName, U.LName, U.MName", connection);
            connection.Open();
            //command.CommandText = "SELECT TeamInfo.Name, TourInfo.Name, DispInfo.Name, TTinfo.Place FROM TeamTournament TTinfo JOIN Team TeamInfo ON TTinfo.TeamId = TeamInfo.Id JOIN Tournament TourInfo ON TTinfo.TournamentId = TourInfo.Id JOIN Discipline DispInfo ON TourInfo.DisciplineId = DispInfo.Id";
            SqlDataReader reader = command.ExecuteReader();
            PlayerData playersList = new PlayerData();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    playersList.AddPlayer(new Player(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3)));
                    if (playersList._players.Count > 1)
                    {
                        if (playersList._players[playersList._players.Count - 1].NickName == playersList._players[playersList._players.Count - 2].NickName)
                            playersList._players.RemoveAt(playersList._players.Count - 1);
                    }
                    //new Player(reader.GetString(0), reader.GetString(1), reader.GetString(2),reader.GetString(5), reader.GetString(3),  reader.GetFieldValue<int>(5))
                }
            }
            playersList.Show();
            connection.Close();

            Console.ReadKey();
        }
    }
}
