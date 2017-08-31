using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Domain;

namespace MatchPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchRepository = new MatchRepository();


            matchRepository.GetAllPlayers();
        }
    }
}
