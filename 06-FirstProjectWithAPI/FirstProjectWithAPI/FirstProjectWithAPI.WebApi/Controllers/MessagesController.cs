using AutoMapper;
using FirstProjectWithAPI.WebApi.Context;
using FirstProjectWithAPI.WebApi.Dtos.FeatureDtos;
using FirstProjectWithAPI.WebApi.Dtos.MessageDtos;
using FirstProjectWithAPI.WebApi.Dtos.ProductDtos;
using FirstProjectWithAPI.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWithAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
           var value =  _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Message added succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Deleting process completed succesfully");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Updating process completed succesfully");
        }
    }
}
