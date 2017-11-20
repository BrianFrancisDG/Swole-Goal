using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace SwoleGoal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            Models.HomePageInputs myInputs = new Models.HomePageInputs();
            return View();
        }
        public ActionResult Submission()
        {
            return View();
        }
        public ActionResult Results(Models.HomePageInputs myInputs)
        {
            Models.ParagraphCreator myCreator = new SwoleGoal.Models.ParagraphCreator(myInputs);
            System.Web.HttpContext.Current.Session["outputs"] = myCreator;
            return View(myCreator.Outputs);
        }
        public ActionResult NutritionWiki()
        {
            if (System.Web.HttpContext.Current.Session.Count != 0)
            {
                SwoleGoal.Models.ParagraphCreator myCreator = (SwoleGoal.Models.ParagraphCreator)System.Web.HttpContext.Current.Session["outputs"];
                return View(myCreator);
            }
            //TDEE = TDEE +10%/-20%
            return View();
        }
        public ActionResult FitnessWiki()
        {
            return View();
        }


    }
}
