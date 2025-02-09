using Cental.DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Contact
{
    public class _ContactSendMessageComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CreateMessageDto createMessageDto = new CreateMessageDto();
            return View(createMessageDto);
        }
    }
}
