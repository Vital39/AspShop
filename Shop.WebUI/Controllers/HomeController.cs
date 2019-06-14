using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileUpload)//name parameter ....
        {
            //HttpPostedFileBase file = Request.Files["fileUpload"];
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/");

            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                fileUpload.SaveAs(Path.Combine(path, fileName));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadMulti(IEnumerable<HttpPostedFileBase> fileUploadMulti)//name parameter ....
        {

            foreach (var file in fileUploadMulti)
            {
                if (file == null) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
                string filename = Path.GetFileName(file.FileName);
                if (filename != null) file.SaveAs(Path.Combine(path, filename));
            }
            return RedirectToAction("Index");

        }

        //[HttpPost]
        //public ActionResult Upload()
        //{
        //    HttpPostedFileBase file = Request.Files["fileUpload"];
        //    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/");

        //    if (file != null && file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        file.SaveAs(Path.Combine(path, fileName));
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}