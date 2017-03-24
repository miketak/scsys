using System.Web.Mvc;
using SCCL.Domain.Abstract;
using SCCL.Web.ViewModels;

namespace SCCL.Web.Controllers
{
    public class SolutionsController : Controller
    {
        private ISolutionRepository _repository;

        public SolutionsController(ISolutionRepository solutionRepository)
        {
            _repository = solutionRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            var solutionservices = new SolutionServiceViewModel {Solutions = _repository.Solutions};
            ViewBag.NavTitle = "Solutions";
            return View(solutionservices);
        }

        public ViewResult Detail(int id)
        {
            return View("Index");
        }
    }
}