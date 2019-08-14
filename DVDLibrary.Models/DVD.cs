using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.DVDINFO;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public RPAA Rating { get; set; }
        public string MovieDirector { get; set; }
        public string Studio { get; set; }
        public int DvdId { get; set; }
        public string Website { get; set; }
        public bool Loan { get; set; }
    }
}
