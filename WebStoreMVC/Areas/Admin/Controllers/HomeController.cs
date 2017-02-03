using System.Web.Mvc;
using WebStoreMVC.ServiceReference1;

namespace WebStoreMVC.Areas.Admin
{
    //[Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private Service1Client db = new Service1Client();


        // GET: Produits
        public ActionResult Index()
        {
            var list = db.GetProduits();

            return View(list);
        }



        [ChildActionOnly]
        public ActionResult _GenreMenu()
        {
            ViewBag.GenreId = db.GetGenres();
            ViewBag.MarqueId = db.GetMarques();
            return PartialView();
        }


      
        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}