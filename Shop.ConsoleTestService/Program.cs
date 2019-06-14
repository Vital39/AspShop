using Autofac;
using Shop.BLL.Models;
using Shop.BLL.Modules;
using Shop.BLL.Services;

namespace Shop.ConsoleTestService
{
    class Program
    {
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            return builder.Build();
        }
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var goodService = container.Resolve<IGenericService<GoodDTO>>();
            GoodFilter goodFilter = new GoodFilter
            {
                 MinPrice=1000, MaxPrice = 4000, GoodName = "sam"
            };
            //CategoryDTO c = new CategoryDTO() { CategoryName = "test" };
            //categoryService.Add(c);
            //System.Console.WriteLine("------------------------");

            var collection = goodService.FindBy(goodFilter.Predicate);
            foreach (var item in collection)
            {
                System.Console.WriteLine($"{item.GoodName} {item.Price}");
            }
        }
    }
}
