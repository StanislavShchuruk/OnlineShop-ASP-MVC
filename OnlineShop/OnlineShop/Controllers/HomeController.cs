using System;
using System.Web.Mvc;
using System.IO;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View("ShopIndex");
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Pictures/"), fileName);
                    file.SaveAs(path);
                    return Json(fileName);
                }
            }
            return null;
        }
    }
}