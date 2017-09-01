using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Song.Domain;

namespace Song.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var songRepository = new SongRepository();
            songRepository.GetAllAuthors().ForEach(x => Console.WriteLine(x.FullName));
        }
    }
}
