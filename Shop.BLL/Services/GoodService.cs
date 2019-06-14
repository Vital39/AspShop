using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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
    public class GoodService : IGenericService<GoodDTO>
    {
        IGenericRepository<Good> goodRepository;
        private readonly IMapper _mapper;
        public GoodService(IGenericRepository<Good> goodRepository)
        {
            this.goodRepository = goodRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Good, GoodDTO>()
                 .ForMember("CategoryName", opt => opt.MapFrom(g => g.Category.CategoryName))
                 .ForMember("ManufacturerName", opt => opt.MapFrom(g => g.Manufacturer.ManufacturerName))
                 ;
                cfg.CreateMap<GoodDTO, Good>();

            }).CreateMapper();
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return goodRepository.GetAll().Select(g => _mapper.Map<GoodDTO>(g));
            //var collection = goodRepository.GetAll()
            //    .Select(c => new GoodDTO()
            //    {
            //        GoodId = c.GoodId,
            //        GoodName = c.GoodName,
            //        ManufacturerId = c.Manufacturer.ManufacturerId,
            //        ManufacturerName = c.Manufacturer.ManufacturerName,
            //        CategoryId = c.Category.CategoryId,
            //        CategoryName = c.Category.CategoryName,
            //        GoodCount = c.GoodCount,
            //        Price = c.Price
            //    });
            //return collection;
        }

        public GoodDTO Add(GoodDTO obj)
        {
            Good good = _mapper.Map<Good>(obj);
            goodRepository.AddOrUpdate(good);
            goodRepository.Save();
            return _mapper.Map<GoodDTO>(good);
        }

        public GoodDTO Delete(int id)
        {
            Good good = goodRepository.Get(id);
            goodRepository.Delete(good);
            goodRepository.Save();
            return _mapper.Map<GoodDTO>(good);
        }

        public IEnumerable<GoodDTO> FindBy(Expression<Func<GoodDTO, bool>> predicate)
        {
            try
            {
                var predicateGood = _mapper.Map<Expression<Func<Good, bool>>>(predicate);
                return goodRepository.FindBy(predicateGood)
                    .Select(c => _mapper.Map<GoodDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GoodDTO Get(int id)
        {
            Good good = goodRepository.Get(id);
            return _mapper.Map<GoodDTO>(good);
        }
       

        public GoodDTO Update(GoodDTO obj)
        {
            Good good = _mapper.Map<Good>(obj);
            goodRepository.AddOrUpdate(good);
            goodRepository.Save();
            return _mapper.Map<GoodDTO>(good);
        }
    }
}
