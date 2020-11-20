using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

//This Controller gets added as Page 357 Step 5
namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        //Page 357 Step 6:
        //[HttpGet]
        //See FavoritesController.cs and the Index action method there.
        //The only difference is you also want to populate the UserName 
        //property of the TeamListViewModel variable
        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                UserName = session.GetName()
            };

            return View(model);
        }
        //Page 357 Step 7 (copy verbatim from text):
        //[HttpPost]
        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }
    }
}
