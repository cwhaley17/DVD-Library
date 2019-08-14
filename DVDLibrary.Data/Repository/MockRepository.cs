using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models;
using DVDLibrary.Models.DVDINFO;

namespace DVDLibrary.Data.Repository
{
    public class MockRepository : IRepo
    {
        private static List<DVD> _dvd;
        static MockRepository()
        {
            _dvd = new List<DVD>()
            {
                new DVD()
                {
                    Title = "Malibu's most wanted",
                    ReleaseDate = 2003,
                    Rating = new RPAA()
                    {
                        RatingId = 3,
                        RatingName = "PG-13"
                    },
                    MovieDirector = "John Whitesell",
                    Studio = "Warner Bros. Pictures",
                    DvdId = 1,
                    Website = "http://www.imdb.com/title/tt0328099/",
                    Loan = false
                },
                new DVD()
                {
                    Title = "A Beautiful Mind",
                    ReleaseDate = 2001,
                    Rating = new RPAA()
                    {
                        RatingId = 3,
                        RatingName = "PG-13"
                    },
                    MovieDirector = "Ron Howard",
                    Studio = "Universal Pictures",
                    DvdId = 2,
                    Website = "http://www.imdb.com/title/tt0268978/",
                    Loan = true
                }
            };
        }

        public List<DVD> ListDvds()
        {
            return _dvd;
        }

        public DVD GetDvd(int id)
        {
            return _dvd.FirstOrDefault(m => m.DvdId == id);
        }

        public void AddDvd(DVD dvd)
        {
            dvd.Loan = false;
            dvd.DvdId = _dvd.OrderBy(m => m.DvdId).Max(m => m.DvdId) + 1;
            _dvd.Add(dvd);
        }

        public void EditDvd(DVD dvd)
        {
            _dvd.RemoveAll(m => m.DvdId == dvd.DvdId);
            _dvd.Add(dvd);
        }

        public void RemoveDvd(int id)
        {
            _dvd.RemoveAll(m => m.DvdId == id);
        }
    }
}
