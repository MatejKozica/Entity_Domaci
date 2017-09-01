using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Data.Models;


namespace Manager.Domain
{
    public class MatchRepository
    {

        public List<Player> GetAllPlayers()
        {
            using (var context = new MatchContext())
            {
                return context.Players.ToList();
            }
        }

        public void CreateNewPlayer(string name, string lastname, int number, string mail, string team)
        {
            using (var context = new MatchContext())
            {
                if (context.Players.FirstOrDefault(x => x.FirstName + x.LastName == name + lastname) == null)
                {
                    context.Players.Add(new Player()
                    {
                        FirstName = name,
                        LastName = lastname,
                        PhoneNumber = number,
                        Email = mail,
                        PlayerTeam = context.Teams.FirstOrDefault(x => x.Name == team)

                    });
                    context.SaveChanges();
                }
            }
        }
        
        public void CreateNewTeam(string name, string logo)
        {
            using (var context = new MatchContext())
            {              
                if(context.Teams.FirstOrDefault(x => x.Name== name) == null && context.Teams.FirstOrDefault(x => x.LogoAnimalName == logo) == null)
                {
                    context.Teams.Add(new Team()
                    {
                        Name = name,
                        LogoAnimalName = logo,
                        LastTournamentWonDate = null,
                        TournamentsWon = 0,
                        Win = false
                        
                    });
                }
                context.SaveChanges();
            }
        }

        public void RemovePlayerFromTeam(string name)
        {
            using (var context = new MatchContext())
            {
                context.Players.FirstOrDefault(x => x.FirstName == name).PlayerTeam = null;
                context.SaveChanges();
            }
        }

        public void AddPlayerToTeam(string name, string team)
        {
            using (var context = new MatchContext())
            {
                context.Players.FirstOrDefault(x => x.FirstName == name).PlayerTeam = context.Teams.FirstOrDefault(y => y.Name == team);
                context.SaveChanges();
            }
        }

        public void CreateFriendlyMatch(string team1, string team2)
        {
            using ( var context = new MatchContext())
            {
                Match match = new Match()
                {
                    Name = "meč",
                    Round = 0,
                    IsTournamentMatch = false
                };
                
                Random rnd = new Random();
                List<Team> lista = new List<Team>();
                lista.Add(context.Teams.FirstOrDefault(x => x.Name == team1));
                lista.Add(context.Teams.FirstOrDefault(x => x.Name == team2));
                var Winner = lista[rnd.Next(0, 1)];

                match.Round += 1;
                Winner.FriendlyMatchesWon += 1;

                context.SaveChanges();
            }
        }

        public void CreateNewMatch(string team1, string team2)
        {
            using (var context = new MatchContext())
            {
                Match match = new Match()
                {
                    Name = "meč",
                    Round = 0,
                    IsTournamentMatch = true
                };

                Random rnd = new Random();
                List<Team> lista = new List<Team>();

                lista.Add(context.Teams.FirstOrDefault(x => x.Name == team1));
                lista.Add(context.Teams.FirstOrDefault(x => x.Name == team2));

                int a = rnd.Next(0, 1);
                var Winner = lista[a];
                Winner.Win = true;

                match.Round += 1;

                context.SaveChanges();
            }
        }

        public static void Organise(List<Team> lista)
        {
            using (var context = new MatchContext())
            {
                Random rnd = new Random();
                int n = lista.Count;
                while (n > 1)
                {
                    n--;
                    int k = rnd.Next(n + 1);
                    Team value = lista[k];
                    lista[k] = lista[n];
                    lista[n] = value;
                }
                context.SaveChanges();
            }
            
        }

        public void CreateNewTournament(string name, DateTime date,string team1, string team2, string team3, string team4)
        {
            using (var contex = new MatchContext())
            {
                contex.Tournaments.Add(new Tournament()
                {
                    Name = name,
                    StartDate = DateTime.Now,
                    EndDate = date,                   
                });

               

                List<Team> Lista = new List<Team>();

                Lista.Add(contex.Teams.FirstOrDefault(x => x.Name == team1));
                Lista.Add(contex.Teams.FirstOrDefault(x => x.Name == team2));
                Lista.Add(contex.Teams.FirstOrDefault(x => x.Name == team3));
                Lista.Add(contex.Teams.FirstOrDefault(x => x.Name == team4));

                Organise(Lista);

                CreateNewMatch(Lista[0].Name, Lista[1].Name);
                CreateNewMatch(Lista[2].Name, Lista[3].Name);

                for (int i = 0; i < Lista.Count(); i++)
                {
                    if(Lista[i].Win != true)
                    {
                        Lista.Remove(Lista[i]);
                    }
                }               

                CreateNewMatch(Lista[0].Name, Lista[1].Name);

                foreach (Team item in Lista)
                {
                    if (item.Win == true)
                    {
                        item.LastTournamentWonDate = date;
                        item.TournamentsWon += 1;
                        item.Win = false;
                    }
                }

                contex.SaveChanges();
            }
        }


    }
}
