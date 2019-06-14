using Shop.BLL.Models;
using Shop.DAL.DbLayer;
using Step.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class CategoryService : IGenericService<CategoryDTO>
    {
        IGenericRepository<Category> categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var collection = categoryRepository.GetAll()
                .Select(c => new CategoryDTO()
                {
                     CategoryId = c.CategoryId , CategoryName=c.CategoryName
                });
            return collection;
        }

        public CategoryDTO Add(CategoryDTO obj)
        {
            Category category = new Category()
            {
                CategoryId = obj.CategoryId,
                CategoryName = obj.CategoryName
            };
            categoryRepository.AddOrUpdate(category);
            categoryRepository.Save();
            return new CategoryDTO()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
        }

        public CategoryDTO Delete(int id)
        {
            Category category = categoryRepository.Get(id);
            try
            {
                categoryRepository.Delete(category);
                categoryRepository.Save();
                return new CategoryDTO
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            }
            catch (Exception exc)
            {
                ///Логгтрование
                throw new Exception("Error delete from database");
            }
        }
        public CategoryDTO Delete(CategoryDTO obj)
        {
            Category category = new Category()
            {
                CategoryId = obj.CategoryId,
                CategoryName = obj.CategoryName
            };
            try
            {
                categoryRepository.Delete(category);
                categoryRepository.Save();
                return obj;
            }
            catch(Exception exc)
            {
                ///Логгтрование
                throw new Exception("Error delete from database");
            }
        }

        public IEnumerable<CategoryDTO> FindBy(Expression<Func<CategoryDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }



        public CategoryDTO Update(CategoryDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
