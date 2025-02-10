using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTopbarComponent(IContactService _contactService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _contactService.TGetFirst();
            var contact = _mapper.Map<UITopbarContactDto>(data);
            return View(contact);
        }
    }
}
