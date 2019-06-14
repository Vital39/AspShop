using LinqKit;
using Shop.BLL.Models;
using Shop.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Shop.WebUI.Models
{

    public class CategoryCheck
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ManufacturerCheck
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public bool IsCheck { get; set; }
    }
    public class VmGoodFind
    {
        IGenericService<CategoryDTO> categoryService;
        IGenericService<ManufacturerDTO> manufacturerService;

        public VmGoodFind(IGenericService<CategoryDTO> categoryService,
                                    IGenericService<ManufacturerDTO> manufacturerService)
        {
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            CategorySelects = categoryService.GetAll()
                .Select(c => new CategoryCheck
                { CategoryId = c.CategoryId, CategoryName=c.CategoryName }).ToList();
            ManufacturerSelects = manufacturerService.GetAll()
                .Select(c => new ManufacturerCheck
                {  ManufacturerId = c.ManufacturerId,  ManufacturerName = c.ManufacturerName }).ToList();
        }

        public string GoodName { get; set; }
        public List<CategoryCheck> CategorySelects { get; set; }
        public List<ManufacturerCheck> ManufacturerSelects { get; set; }
        public Expression<Func<GoodDTO, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<GoodDTO>(true);
                return predicate;
            }
        }
    }
}