using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultAboutComponent(IAboutService _aboutService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetFirst();
            var abouts = _mapper.Map<UIAboutDto>(values);
            return View(abouts);
        }
    }
}
