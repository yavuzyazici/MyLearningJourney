using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminProcessController(IProcessService _processService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _processService.TGetAll();
            var processes = _mapper.Map<List<ResultProcessDtos>>(data);
            return View(processes);
        }
        [HttpGet]
        public IActionResult DeleteProcess(int id)
        {
            _processService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateProcess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProcess(CreateProcessDtos data)
        {
            if (_processService.TGetAll().Count() == 3)
            {
                ModelState.AddModelError("YouCantAddMore", "You cant add more than 3 process");
                return RedirectToAction("Index");
            }
            _processService.TCreate(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProcess(int id)
        {
            var process = _processService.TGetById(id);
            return View(process);
        }
        [HttpPost]
        public IActionResult UpdateProcess(UpdateProcessDtos data)
        {
            _processService.TUpdate(data);
            return RedirectToAction("Index");
        }
    }
}
