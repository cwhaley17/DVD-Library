using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Data.Repository;

namespace DVDLibrary.Data.Factory
{
    public class RepositoryFactory
    {
        public static IRepo GetRepo()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            { // this is fairly irrelevant right now as I have only the mock repository. Will be linked to a Database soon
                case "Prod":
                    return new MockRepository();
                case "Test":
                    return new MockRepository();
                default:
                    return new MockRepository();
            }
        }
    }
}
