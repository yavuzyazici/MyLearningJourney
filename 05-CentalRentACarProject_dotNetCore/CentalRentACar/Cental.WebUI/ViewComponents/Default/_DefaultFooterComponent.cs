using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFooterComponent(IContactService _contactService, IAboutService _aboutService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contact = _contactService.TGetFirst();

            var contactDto = _mapper.Map<UIFooterContactDto>(contact);
            contactDto.Description1 = _aboutService.TGetFirst().Description1;
            return View(contactDto);
        }
    }
}
