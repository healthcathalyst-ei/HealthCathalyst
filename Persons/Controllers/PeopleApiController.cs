using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Persons.Models;
using Newtonsoft.Json;

namespace Persons.Controllers {
    public class PeopleApiController : ApiController {
        private PersonsEntities context = new PersonsEntities();

        [HttpGet]
        public List<string> Search(string name) {
            name = System.Web.HttpUtility.UrlDecode(name);
            return context.Persons.Where(w => w.PersonNames.Contains(name)).Select(s => s.PersonNames).ToList();
        }
    }
}
