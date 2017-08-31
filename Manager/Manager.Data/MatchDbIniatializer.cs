using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Manager.Data.Models;

namespace Manager.Data
{
    class MatchDbIniatializer: DropCreateDatabaseAlways<MatchContext>
    {
        protected override void Seed(MatchContext context)
        {
            context.Teams.Add(new Team()
            {
                Name = "Navy",
                LogoAnimalName = "Seal",
                TournamentsWon = 0,
                LastTournamentWonDate = null
            }
            );
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
