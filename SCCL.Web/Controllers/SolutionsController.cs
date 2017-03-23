using System.Web.Mvc;

namespace SCCL.Web.Controllers
{
    public class SolutionsController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //id = 1;
            //return View(id);
            return View();
        }

        //public ViewResult Solution(int id)
        //{
        //    return View("Index");
        //}
    }
}