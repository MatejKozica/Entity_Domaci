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

        public void CreateNewPlayer(string name, string lastname, int number, string mail)
        {
            using (var context = new MatchContext())
            { 
                if(context.Players.FirstOrDefault(x => x.FirstName + x.LastName == name + lastname) == null)
                {
                    context.Players.Add(new Player()
                    {
                        FirstName = name,
                        LastName = lastname,
                        PhoneNumber = number,
                        Email = mail
                    });
                    context.SaveChanges();
                }          
            }
        }




    }
    }
