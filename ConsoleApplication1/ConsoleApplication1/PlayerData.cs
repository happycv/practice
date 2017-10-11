using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PlayerData
    {
        public List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        public void Show()
        {
            foreach (Player p in _players)
            {
                Console.WriteLine($"{p.FName}   {p.NickName}   {p.LName}  from:  {p.TeamName}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
