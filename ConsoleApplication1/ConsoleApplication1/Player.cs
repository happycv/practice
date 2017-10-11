using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Player
    {
        public string FName { get; private set; }
        public string LName { get; private set; }
        public string NickName { get; private set; }
        public string TeamName { get; private set; }


        public Player(string fname, string lastname, string nickname, string teamname)
        {
            FName = fname;
            LName = lastname;
            NickName = nickname;
            TeamName = teamname;

        }
    }
}
