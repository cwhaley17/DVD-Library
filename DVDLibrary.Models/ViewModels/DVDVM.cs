using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DVDLibrary.Models.DVDINFO;

namespace DVDLibrary.Models.ViewModels
{
    public class Dvdvm
    {
        public DVD Dvd { get; set; }
        public List<SelectListItem> RpaaItems { get; set; }
        public List<SelectListItem> UserRateItems { get; set; }


        public Dvdvm()
        {
            Dvd = new DVD();
            RpaaItems = new List<SelectListItem>();
            UserRateItems = new List<SelectListItem>();
        }

        public void SetRpaaItems(IEnumerable<RPAA> rating)
        {
            foreach (var rate in rating)
            {
                RpaaItems.Add(new SelectListItem()
                {
                    Value = rate.RatingId.ToString(),
                    Text = rate.RatingName
                });
            }
        }

        public void SetUserRateItems(IEnumerable<UserRate> rating)
        {
            foreach (var rate in rating)
            {
                UserRateItems.Add(new SelectListItem()
                {
                    Value= rate.UserRateInt.ToString(),
                    Text= rate.UserName
                });
            }
        }
    }
}
