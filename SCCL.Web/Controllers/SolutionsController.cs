using System.Linq;
using System.Web.Mvc;
using SCCL.Domain.Abstract;
using SCCL.Web.ViewModels;

namespace SCCL.Web.Controllers
{
    public class SolutionsController : Controller
    {
        private readonly ISolutionRepository _repository;
        private SolutionServiceViewModel solutionservices;

        public SolutionsController(ISolutionRepository solutionRepository)
        {
            _repository = solutionRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            solutionservices = new SolutionServiceViewModel {Solutions = _repository.Solutions};
            ViewBag.NavTitle = "Solutions";

            var solution = _repository.Solutions.FirstOrDefault(p => p.Id == 1);
            solutionservices.Solution = solution;

            return View(solutionservices); //View(solutionservices);
        }

        public ViewResult Detail(int id)
        {
            solutionservices = new SolutionServiceViewModel { Solutions = _repository.Solutions };
            ViewBag.NavTitle = "Solutions";

            var solution = _repository.Solutions.FirstOrDefault(p => p.Id == id);
            solutionservices.Solution = solution;

            return View("Index", solutionservices);
        }
    }
}