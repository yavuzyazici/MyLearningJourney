using System.Globalization;
using System.Resources;
using BookStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace BookStore.BusinessLayer.Concrete
{
    public class ResourceService : IResourceService
    {
        private readonly ResourceManager _resourceManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceService(IHttpContextAccessor httpContextAccessor)
        {
            _resourceManager = new ResourceManager("BookStore.BusinessLayer.Resources.SharedResource", typeof(ResourceService).Assembly);
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetString(string key)
        {
            var culture = _httpContextAccessor.HttpContext?.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture
                          ?? CultureInfo.CurrentCulture;

            return _resourceManager.GetString(key, culture) ?? key;
        }
    }
}
