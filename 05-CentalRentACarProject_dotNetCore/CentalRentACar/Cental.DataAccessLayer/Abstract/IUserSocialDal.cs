﻿using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IUserSocialDal : IGenericDal<UserSocial>
    {
        List<UserSocial> GetSocialsByUserId(int userId);
    }
}
