using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpGet]
        public IActionResult SubscriberList()
        {
            return Ok(_subscriberService.TGetAll());
        }

        [HttpPost]
        public IActionResult Subscribe(Subscriber subscriber)
        {
            var existingSubscriber = _subscriberService.TGetAll().FirstOrDefault(x => x.Email == subscriber.Email);

            if (existingSubscriber != null && !string.IsNullOrEmpty(existingSubscriber.Email))
            {
                return BadRequest("This email is already subscribed.");
            }
            _subscriberService.TAdd(subscriber);
            return Ok("Subscribed succesfully");
        }

        [HttpPut]
        public IActionResult UpdateSubscriber(Subscriber subscriber)
        {
            _subscriberService.TUpdate(subscriber);
            return Ok("Subscriber updated succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteSubscriber(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Subscriber deleted succesfully");
        }

        [HttpGet("GetSubscriber")]
        public IActionResult GetSubscriber(int id)
        {
            return Ok(_subscriberService.TGetById(id));
        }
    }
}
