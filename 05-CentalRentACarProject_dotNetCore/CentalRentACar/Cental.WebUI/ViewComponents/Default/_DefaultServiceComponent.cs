using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent(IServiceService _serviceService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _serviceService.TGetAll();
            var services = data.Adapt<List<UIServiceDto>>();
            return View(services);
        }
    }
}
