using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public ActionResult Shop()
        {
            return View();
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