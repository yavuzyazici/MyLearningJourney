using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.ContactDtos;
using MongoDbProject.Services.ContactServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeFooterComponent(IContactService _contactService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _contactService.GetAllAsync();
            var contact = _mapper.Map<ResultContactDto>(value.FirstOrDefault());
            return View(contact);
        }
    }
}
