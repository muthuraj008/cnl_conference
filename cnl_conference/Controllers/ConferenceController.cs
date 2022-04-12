using cnl_conference.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Threading.Tasks;

namespace cnl_conference.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceServices _service;
        public ConferenceController(IConferenceServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            var conference = await _service.GetAll();
            return View(await _service.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid && model.Name != null)
                await _service.Add(model);

            return RedirectToAction("Index");
        }
    }
}
