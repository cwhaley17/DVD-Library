using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDLibrary.BLL;
using DVDLibrary.Data.Repository;
using DVDLibrary.Models;

namespace DVDLibrary.Controllers
{
    public class DVDsController : ApiController
    {
        Manager _manager = new Manager();

        public List<DVD> Get()
        {
            return _manager.ListDvds();
        }

        [HttpPut]
        public HttpResponseMessage Update(DVD dvd)
        {
            dvd = _manager.SetRatingNames(dvd);
            _manager.EditDvd(dvd);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _manager.RemoveDvd(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(DVD dvd)
        {
            dvd = _manager.SetRatingNames(dvd);
            _manager.AddDvd(dvd);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
