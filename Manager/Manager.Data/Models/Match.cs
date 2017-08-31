using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Round { get; set; }
        public bool IsTournamentMatch { get; set; }
    }
}
