using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Song.Data;

namespace Song.Domain.DTO_s
{
    class SongDTO
    {
        public int Id { get; set; }
        public string NameAndDuration { get; set; }
        public Author Author { get; set; }

        public static SongDTO EntitySongDTO(int id)
        {
            using (var context = new SongDBEntities1())
            {
                return new SongDTO()
                {
                    Id = context.Songs.FirstOrDefault(x => x.Id == id).Id,
                    NameAndDuration = context.Songs.FirstOrDefault(x => x.Id == id).SongName + context.Songs.FirstOrDefault(x => x.Id == id).Duration,
                    Author = context.Songs.FirstOrDefault(x => x.Id == id).Author
                };
        }
    }
}
}
