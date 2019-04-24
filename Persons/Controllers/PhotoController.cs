using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Persons.Controllers {
    public class PhotoController : Controller
    {
        [OutputCache(Duration = 600, Location = OutputCacheLocation.Server, VaryByParam = "id")]
        public FileContentResult GetImage(int id) {
            PersonsEntities db = new PersonsEntities();
            var q = db.Persons.Where(p => p.PersonID == id).FirstOrDefault();
            byte[] photo = q.Photo;
            return File(photo, "image/jpg");
        }
    }
}