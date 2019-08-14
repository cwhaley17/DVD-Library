using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.DVDINFO
{
    public class Borrower
    {
        public string Name { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
        //When a move is loaned, I will prompt the user to enter in this info, which will be kept for each dvd in a collection
    }
}
