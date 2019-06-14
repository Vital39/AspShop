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
    public class PhotoService : IGenericService<PhotoDTO>
    {

        IGenericRepository<Photo> photoRepository;
        private readonly IMapper _mapper;
        public PhotoService(IGenericRepository<Photo> photoRepository)
        {
            this.photoRepository = photoRepository;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Photo, PhotoDTO>();
                cfg.CreateMap<PhotoDTO, Photo>();
            }).CreateMapper();
        }


        public PhotoDTO Add(PhotoDTO obj)
        {
            Photo photo = _mapper.Map<Photo>(obj);
            photoRepository.AddOrUpdate(photo);
            photoRepository.Save();
            return _mapper.Map<PhotoDTO>(photo);
        }

        public PhotoDTO Delete(int id)
        {
            Photo photo = photoRepository.Get(id);
            photoRepository.Delete(photo);
            photoRepository.Save();
            return _mapper.Map<PhotoDTO>(photo);
        }

        public IEnumerable<PhotoDTO> FindBy(Expression<Func<PhotoDTO, bool>> predicate)
        {
            try
            {
                var predicateGood = _mapper.Map<Expression<Func<Photo, bool>>>(predicate);
                return photoRepository.FindBy(predicateGood)
                    .Select(c => _mapper.Map<PhotoDTO>(c));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PhotoDTO Get(int id)
        {
            Photo photo = photoRepository.Get(id);
            return _mapper.Map<PhotoDTO>(photo);
        }

        public IEnumerable<PhotoDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhotoDTO Update(PhotoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
