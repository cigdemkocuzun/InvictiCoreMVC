using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreTemplate.Business.Abstract;
using MVCCoreTemplate.Entities.DbEntities;
using MVCCoreTemplate.Models.ApplicationViewModels;

namespace MVCCoreTemplate.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private IApplicationService _applicationService;
        private readonly ILogger _logger;
        public ApplicationController(IApplicationService applicationService, ILogger<ApplicationController> logger)
        {
            _applicationService = applicationService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_applicationService.GetAll());
        }

        [HttpGet]
        public IActionResult AddorUpdate(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var model = new ApplicationViewModel
                {
                    Application = _applicationService.GetById(id.Value)
                };

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult AddorUpdate(ApplicationViewModel model)
        {
            ModelState.Remove("Application.ApplicationId");
            if (ModelState.IsValid)
            {
                if (model.Application.ApplicationId == 0)
                {
                    _applicationService.Insert(model.Application);
                }
                else
                {

                    if (model.Application != null)
                    {
                        if (_applicationService.Update(model.Application) == 0)
                        {
                            ModelState.AddModelError("", "Error");
                            _logger.LogError("Error!");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "DataBaseError!");
                        _logger.LogError("DataBaseError!");
                        return View(model);
                    }

                }
                TempData["message"] = $"{model.Application.Name} kayıt edildi.";
                return RedirectToAction("Index", "Application");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogError("BadRequestResult!");
                return new BadRequestResult();
            }
            Application application = _applicationService.GetById(id.Value);
            if (application != null)
            {
                _applicationService.Delete(application);
            }

            TempData["message"] = $"{application.Name} silindi.";
            return RedirectToAction("Index", "Application");
        }
    }
}