using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        IGenericService<CategoryDTO> categoryService;

        public CategoryController(IGenericService<CategoryDTO> c)
        {
            categoryService = c;
        }
        public ActionResult Index()
        {
            var model = categoryService.GetAll();
            return View(model);
        }
    }
}