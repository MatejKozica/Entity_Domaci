using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Domain;
using Manager.Data;

namespace Match.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchRepository = new MatchRepository();

            matchRepository.CreateNewPlayer("Luka", "Bulić", 202, "luka.bulic@gmail.com");
            matchRepository.CreateNewPlayer("Luka", "Korda", 202, "luka.korda@gmail.com");
            matchRepository.CreateNewTeam("Cloud9", "Hawk");
            matchRepository.CreateNewTeam("Navy", "Seal");

            matchRepository.GetAllPlayers().ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));           
        }
    }
}
