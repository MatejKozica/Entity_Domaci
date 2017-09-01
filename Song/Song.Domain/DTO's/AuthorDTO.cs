using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Song.Data;

namespace Song.Domain.DTO_s
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static AuthorDTO AuthorSongDTO(int id)
        {
            using (var context = new SongDBEntities1())
            {
                return new AuthorDTO()
                {
                    Id = context.Authors.FirstOrDefault(x => x.Id == id).Id,
                    FullName = context.Authors.FirstOrDefault(x => x.Id == id).FullName,

            };
        }
    }


}
}
