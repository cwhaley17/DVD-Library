using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Factory;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public class Manager
    {
        private IRepo _repo;

        public Manager()
        {
            _repo = RepositoryFactory.GetRepo();
        }

        public List<DVD> ListDvds()
        {
            return _repo.ListDvds();
        }

        public void AddDvd(DVD dvd)
        {
            var url = "http://www.imdb.com/find?ref_=nv_sr_fn&q=";
            var urlBack = "&s=all";
            try
            {
                var splitTitle = dvd.Title.Split(' ');
                foreach (var word in splitTitle)
                {
                    url += word + "+";
                }
                url = url.Substring(0, url.Length - 1) + urlBack;
            }
            catch
            {
                url = url + dvd.Title + urlBack;
            }
            finally
            {
                dvd.Website = url;
                _repo.AddDvd(dvd);
            }
        }

        public DVD SetRatingNames(DVD dvd)
        {
            if (dvd.Rating.RatingId == 0)
            {
                dvd.Rating.RatingName = "NA";
            }
            if (dvd.Rating.RatingId == 1)
            {
                dvd.Rating.RatingName = "G";
            }
            else if (dvd.Rating.RatingId == 2)
            {
                dvd.Rating.RatingName = "PG";
            }
            else if (dvd.Rating.RatingId == 3)
            {
                dvd.Rating.RatingName = "PG13";
            }
            else if (dvd.Rating.RatingId == 4)
            {
                dvd.Rating.RatingName = "R";
            }
            else if (dvd.Rating.RatingId == 5)
            {
                dvd.Rating.RatingName = "NR17";
            }
            return dvd;
        }

        public void EditDvd(DVD dvd)
        {
            _repo.EditDvd(dvd);
        }

        public void RemoveDvd(int id)
        {
            _repo.RemoveDvd(id);
        }

        public DVD LoadDvd(int id)
        {
           return _repo.GetDvd(id);
        }
    }
}
