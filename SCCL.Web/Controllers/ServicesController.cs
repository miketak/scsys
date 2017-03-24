using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCCL.Domain.Abstract;
using SCCL.Web.ViewModels;

namespace SCCL.Web.Controllers
{
    public class ServicesController : Controller
    {
        private IServiceRepository _repository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }

        // GET: Services
        public ActionResult Index()
        {
            var solutionservices = new SolutionServiceViewModel() {Services = _repository.Services};
            ViewBag.NavTitle = "Services";
            return View("../Solutions/Index", solutionservices);
        }

        public ActionResult Detail()
        {
            throw new NotImplementedException();
        }
    }
}