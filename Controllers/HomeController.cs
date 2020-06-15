using ImageUploadEF.Models.Managers;
using ImageUploadEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUploadEF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContex db = new DatabaseContex();
            HomePageViewModel model = new HomePageViewModel();
            model.Images = db.Images.ToList();
            return View(model);
        }

      
    }
}