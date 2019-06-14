using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class GoodController : Controller
    {
        IGenericService<CategoryDTO> categoryService;
        IGenericService<ManufacturerDTO> manufacturerService;
        IGenericService<GoodDTO> goodService;
        public GoodController(IGenericService<CategoryDTO> categoryService,
                                    IGenericService<ManufacturerDTO> manufacturerService,
                                    IGenericService<GoodDTO> goodService)
        {
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            this.goodService = goodService;
        }

        public ActionResult Index()
        {
            var model = goodService.GetAll();
            return View(model);
        }

        public ActionResult GoodFind()
        {
            var model = new VmGoodFind(categoryService, manufacturerService);
            return View(model);
        }
    }
}