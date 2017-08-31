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

            matchRepository.CreateNewTeam("Cloud9", "Hawk");

            matchRepository.CreateNewPlayer("Mate","Matić", 101, "mate.matic@gmail.com", "Navy");
            matchRepository.CreateNewPlayer("Luka", "Bulić", 102, "luka.bulic@gmail.com", "Navy");
            matchRepository.CreateNewPlayer("Luka", "Korda", 103, "luka.korda@gmail.com", "Cloud9");
            
            


            matchRepository.GetAllPlayers().ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));           
        }
    }
}
