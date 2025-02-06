using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class UserSocialManager(IUserSocialDal _userSocialDal, IMapper _mapper) : IUserSocialService
    {
        public void TCreate(UserSocial entity)
        {
            _userSocialDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var social = _mapper.Map<UserSocial>(dto);
            _userSocialDal.Create(social);
        }

        public void TDelete(int id)
        {
            _userSocialDal.Delete(id);
        }

        public List<UserSocial> TGetAll()
        {
            return _userSocialDal.GetAll();
        }

        public UserSocial TGetById(int id)
        {
            return _userSocialDal.GetById(id);
        }

        public UserSocial TGetFirst()
        {
            return _userSocialDal.GetFirst();
        }

        public List<ResultUserSocialDto> TGetSocialsByUserId(int userId)
        {
            var data = _userSocialDal.GetSocialsByUserId(userId);
            var userSocials = _mapper.Map<List<ResultUserSocialDto>>(data);
            return userSocials;
        }

        public void TUpdate(UserSocial entity)
        {
            _userSocialDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var social = _mapper.Map<UserSocial>(dto);
            _userSocialDal.Update(social);
        }
    }
}
