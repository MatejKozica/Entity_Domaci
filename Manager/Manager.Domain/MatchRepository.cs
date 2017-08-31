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
                        TournamentsWon = 0
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


    }
}
