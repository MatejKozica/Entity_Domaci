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
            context.Players.Add(new Player()
            {
                FirstName = "Mate",
                LastName = "Matic",
                PhoneNumber = 001,
                Email = "mate.matic@gmail.com"
            }
            );
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
