using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.DVDINFO;

namespace DVDLibrary.Data.Repository.RatingRepos
{
    public class RPAARepository
    {
        private static List<RPAA> _rating;

        public RPAARepository()
        {
            _rating = new List<RPAA>()
            {
                new RPAA {RatingId = 0, RatingName = "NA"},
                new RPAA {RatingId = 1, RatingName = "G"},
                new RPAA {RatingId = 2, RatingName = "PG"},
                new RPAA {RatingId = 3, RatingName = "PG-13"},
                new RPAA {RatingId = 4, RatingName = "R"},
                new RPAA {RatingId = 5, RatingName = "NC-17"}
            };
        }

        public static IEnumerable<RPAA> GetAll()
        {
            return _rating;
        }

        public RPAA Get(int id)
        {
            return _rating.FirstOrDefault(r => r.RatingId == id);
        }
    }
}
