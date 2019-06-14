using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class PhotoController : Controller
    {
        IGenericService<PhotoDTO> photoService;
        IGenericService<GoodDTO> goodService;
        public PhotoController(IGenericService<PhotoDTO> photoService, IGenericService<GoodDTO> goodService)
        {
            this.photoService = photoService;
            this.goodService = goodService;
        }
        public ActionResult PhotoList(int id=1)
        {
            GoodDTO good = goodService.Get(id);
            ViewBag.GoodInfo = $"{good.GoodName}, price - {good.Price} uah";
            ViewBag.GoodId = id;
            var model = photoService.FindBy(g => g.GoodId == id);
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">товара Goood</param>
        /// <returns></returns>
        public ActionResult Upload(int id)
        {
            ViewBag.GoodId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> fileUploadMulti)
        {
            string idstr = Request.Params["id"];
            int id = Convert.ToInt32(idstr);
            foreach (var file in fileUploadMulti)
            {
                if (file == null) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "Files/";
                string filename = Path.GetFileName(file.FileName);
                string newfilename = Guid.NewGuid().ToString() + Path.GetExtension(filename);
                if (filename != null)
                {

                    file.SaveAs(Path.Combine(path, newfilename));
                    PhotoDTO photo = new PhotoDTO
                    {
                        GoodId = id,
                        PhotoPath = "/Files/" + newfilename
                    };
                    photoService.Add(photo);

                }
            }
            return RedirectToAction("PhotoList", new { id=id});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id - фото</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            photoService.Delete(id);
            return Json("OK");
        }
    }
}