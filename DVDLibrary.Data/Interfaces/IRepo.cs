using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data.Interfaces
{
    public interface IRepo
    {
        List<DVD> ListDvds();
        DVD GetDvd(int id);
        void AddDvd(DVD dvd);
        void EditDvd(DVD dvd);
        void RemoveDvd(int id);
    }
}
