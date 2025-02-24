using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.SubscriberDtos;
using BookStore.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public SubscriberController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IActionResult> SubscriberList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7190/api/Subscribers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscriberDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7190/api/Subscribers?id={id}");
            return RedirectToAction("SubscriberList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Subscribers/GetSubscribers?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto updateSubscriberDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSubscriberDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7190/api/Subscribers/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscriberList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SendEmail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7190/api/Subscribers/GetSubscriber?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var valuesDto = JsonConvert.DeserializeObject<Subscriber>(jsonData);
                var value = _mapper.Map<MailRequest>(valuesDto);
                
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress(mailRequest.Name,mailRequest.SenderAddress);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.RecieverAddress);
            
            mimeMessage.From.Add(mailboxAddress);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MailBody;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            //For this password code visit https://myaccount.google.com/apppasswords
            smtpClient.Authenticate(mailRequest.SenderAddress, "efiqxffbqgmmvxfd");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("SubscriberList");
        }
    }
}
