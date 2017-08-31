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




    }
}
