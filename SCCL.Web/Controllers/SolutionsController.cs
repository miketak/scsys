using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SCCL.Domain.Abstract;
using SCCL.Domain.DataAccess;
using SCCL.Domain.Entities;
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


        // Admin Functionality

        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Description")] Solution solution)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!SolutionsAccessor.CreateSolution(solution))
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
        public ActionResult Edit( [Bind(Include = "Id, Name, Description")] Solution newSolution )
        {
            if (ModelState.IsValid)
            {
                var oldSolution = _repository.Solutions.FirstOrDefault(b => b.Id == newSolution.Id);
                try
                {
                    if (SolutionsAccessor.UpdateSolution(oldSolution, newSolution))
                    {
                        return RedirectToAction("Index", "SiteAdmin", new { area = "" });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return View(newSolution);
        }
 
        public ActionResult Edit(int id)
        {
            solutionservices = new SolutionServiceViewModel { Solutions = _repository.Solutions };

            var solution = _repository.Solutions.FirstOrDefault(p => p.Id == id);

            return View("Edit", solution);    
        }

        public ActionResult Delete(int id)
        {

            SolutionsAccessor.DeleteSolution(id);

            return RedirectToAction("Index", "SiteAdmin", new { area = ""});

        }
    }
}