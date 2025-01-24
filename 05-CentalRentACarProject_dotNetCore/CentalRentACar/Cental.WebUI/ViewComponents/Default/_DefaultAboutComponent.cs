using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public _DefaultAboutComponent(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetFirst();
            var abouts = _mapper.Map<UIAboutDto>(values);
            return View(abouts);
        }
    }
}
