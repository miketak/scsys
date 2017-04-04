using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCCL.Domain.Abstract;
using SCCL.Domain.DataAccess;
using SCCL.Domain.Entities;
using SCCL.Web.ViewModels;

namespace SCCL.Web.Controllers
{
    public class ServicesController : Controller
    {
        private IServiceRepository _repository;
        private SolutionServiceViewModel solutionServices;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        // GET: Services
        public ActionResult Index()
        {
            var solutionservices = new SolutionServiceViewModel() {Services = _repository.Services};
            ViewBag.NavTitle = "Services";

            var service = _repository.Services.FirstOrDefault(p => p.Id == 1);
            solutionservices.Service = service;

            return View("../Solutions/Index", solutionservices);
        }

        public ActionResult Detail(int id)
        {
            var solutionservices = new SolutionServiceViewModel { Services = _repository.Services };
            ViewBag.NavTitle = "Services";

            var service = _repository.Services.FirstOrDefault(p => p.Id == id);
            solutionservices.Service = service;

            return View("../Solutions/Index", solutionservices);
        }

        // Admin Functionality

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Description")] Service service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!ServicesAccessor.CreateService(service))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }


                return RedirectToAction("Index", "SiteAdmin");
            }

            return RedirectToAction("Index", "SiteAdmin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description")] Service newService)
        {
            if (ModelState.IsValid)
            {
                var oldService = _repository.Services.FirstOrDefault(b => b.Id == newService.Id);
                try
                {
                    if (ServicesAccessor.UpdateSolution(oldService, newService))
                    {
                        return RedirectToAction("Index", "SiteAdmin", new { area = "" });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return View(newService);
        }

        public ActionResult Edit(int id)
        {
            solutionServices = new SolutionServiceViewModel { Services = _repository.Services };

            var service = _repository.Services.FirstOrDefault(p => p.Id == id);

            return View("Edit", service);
        }

        public ActionResult Delete(int id)
        {

            ServicesAccessor.DeleteService(id);

            return RedirectToAction("Index", "SiteAdmin", new { area = "" });

        }
    }
}