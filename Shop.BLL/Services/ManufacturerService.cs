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
    public class ManufacturerService : IGenericService<ManufacturerDTO>
    {
        IGenericRepository<Manufacturer> manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IGenericRepository<Manufacturer> r)
        {
            this.manufacturerRepository = r;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Manufacturer, ManufacturerDTO>();
                cfg.CreateMap<ManufacturerDTO, Manufacturer>();

            }).CreateMapper();
        }



        public ManufacturerDTO Add(ManufacturerDTO obj)
        {
            Manufacturer manufacturer = _mapper.Map<Manufacturer>(obj);
            manufacturerRepository.AddOrUpdate(manufacturer);
            manufacturerRepository.Save();
            return _mapper.Map<ManufacturerDTO>(manufacturer);
        }

        public ManufacturerDTO Delete(int id)
        {
            Manufacturer manufacturer = manufacturerRepository.Get(id);
            manufacturerRepository.Delete(manufacturer);
            manufacturerRepository.Save();
            return _mapper.Map<ManufacturerDTO>(manufacturer);
        }

        public IEnumerable<ManufacturerDTO> FindBy(Expression<Func<ManufacturerDTO, bool>> predicate)
        {
            try
            {
                var predicateManufacturer = _mapper.Map<Expression<Func<Manufacturer, bool>>>(predicate);
                return manufacturerRepository.FindBy(predicateManufacturer)
                    .Select(c => _mapper.Map<ManufacturerDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ManufacturerDTO Get(int id)
        {
            Manufacturer manufacturer = manufacturerRepository.Get(id);
            return _mapper.Map<ManufacturerDTO>(manufacturer);
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return manufacturerRepository.GetAll()
                     .Select(c => _mapper.Map<ManufacturerDTO>(c));
        }

        public ManufacturerDTO Update(ManufacturerDTO obj)
        {
            Manufacturer manufacturer = _mapper.Map<Manufacturer>(obj);
            manufacturerRepository.AddOrUpdate(manufacturer);
            manufacturerRepository.Save();
            return _mapper.Map<ManufacturerDTO>(manufacturer);
        }
    }
}
