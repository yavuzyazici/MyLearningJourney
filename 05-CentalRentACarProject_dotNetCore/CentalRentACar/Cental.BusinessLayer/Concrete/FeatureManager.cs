using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class FeatureManager(IFeatureDal _featureDal, IMapper _mapper) : IFeatureService
    {
        public void TCreate(Feature entity)
        {
            _featureDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Feature>(dto);
            _featureDal.Create(data);
        }

        public void TDelete(int id)
        {
            _featureDal.Delete(id);
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public Feature TGetFirst()
        {
            return _featureDal.GetFirst();
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Feature>(dto);
            _featureDal.Update(data);
        }
    }
}
