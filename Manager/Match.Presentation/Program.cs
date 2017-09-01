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
            matchRepository.CreateNewTeam("Lycanthrops", "Wolf");
            matchRepository.CreateNewTeam("Venom", "Cobra");

            matchRepository.CreateNewPlayer("Josip","Bartulović", 101, "jole.bartulo@gmail.com", "Navy");
            matchRepository.CreateNewPlayer("Roko", "Radanović", 102, "roko.radanovic@gmail.com", "Navy");
            matchRepository.CreateNewPlayer("Matej", "Kožica", 103, "matej.kozica@gmail.com", "Cloud9");
            matchRepository.CreateNewPlayer("Bruno", "Vego", 104, "bruno.vego@gmail.com", "Cloud9");
            matchRepository.CreateNewPlayer("Zvonimir", "Delaš", 105, "zvone.delas@gmail.com", "Lycanthrops");
            matchRepository.CreateNewPlayer("Ivan", "Vukorepa", 106, "ivan.vukorepa@gmail.com", "Lycanthrops");
            matchRepository.CreateNewPlayer("Ivo", "Jovanović", 107, "ivo.jovanovic@gmail.com", "Venom");
            matchRepository.CreateNewPlayer("Luka", "Kovačušić", 108, "luka.kovacusic@gmail.com", "Venom");

            matchRepository.CreateFriendlyMatch("Cloud9", "Venom");

            matchRepository.CreateNewTournament("T1",DateTime.Now, "Cloud9", "Lycanthrops", "Navy", "Venom");




            matchRepository.GetAllPlayers().ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));           
        }
    }
}
