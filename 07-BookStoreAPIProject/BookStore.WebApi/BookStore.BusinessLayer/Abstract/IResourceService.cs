using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public interface IResourceService
    {
        string GetString(string key);
    }

}
