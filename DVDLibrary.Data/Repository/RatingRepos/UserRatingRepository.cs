using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.DVDINFO;

namespace DVDLibrary.Data.Repository.RatingRepos
{
    public class UserRatingRepository
    {
        //I plan on removing this soon
        //it no longer serves a purpose for me
        //but I do not with to remove until I am positive I will not use
        private static List<UserRate> _rating;

        public UserRatingRepository()
        {
            _rating = new List<UserRate>()
            {
                new UserRate {UserRateInt = 1, UserName = "Keith"},
                new UserRate {UserRateInt = 2, UserName = "Emre"},
                new UserRate {UserRateInt = 3, UserName = "Brett"},
                new UserRate{UserRateInt = 4, UserName = "Elijah"},
                new UserRate{UserRateInt = 5, UserName = "Dave"},
                new UserRate{UserRateInt = 6, UserName = "Sophia"}
            };
        }

        public static IEnumerable<UserRate> GetAll()
        {
            return _rating;
        }

        public UserRate Get(int id)
        {
            return _rating.FirstOrDefault(s => s.UserRateInt == id);
        }
    }
}
