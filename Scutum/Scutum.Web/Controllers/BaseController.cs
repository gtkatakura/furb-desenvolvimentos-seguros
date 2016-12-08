using Scutum.Model.Interface;
using Scutum.WebAPI.Client;
using Scutum.WebAPI.Client.RequestControllers;
using System.Configuration;
using System.Net;
using System.Web.Mvc;

namespace Scutum.Web.Controllers
{
    public class BaseController<T> : Controller
        where T : IEntityWithID, new()
    {
        protected ScutumClient scutum;
        protected BaseRequestController<T> requestController;

        public BaseController()
        {
            this.scutum = new ScutumClient(ConfigurationManager.AppSettings["ScutumBaseAdress"]);
            this.scutum.Authorize(ConfigurationManager.AppSettings["ScutumUsername"], ConfigurationManager.AppSettings["ScutumPassword"]);

            this.requestController = this.scutum.CreateRequestController<T>();
        }

        public virtual ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(T model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            this.requestController.Save(model);
            return View();
        }

        public virtual ActionResult Edit(int id)
        {
            return View(this.requestController.Find(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(T model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            this.requestController.Update(model);
            return View();
        }

        public virtual ActionResult Details(int id)
        {
            return View(this.requestController.Find(id));
        }

        public virtual ActionResult Delete(int id)
        {
            return View(this.requestController.Find(id));
        }

        [HttpPost]
        public virtual ActionResult Delete(T model)
        {
            this.requestController.Remove(model.Id);
            return View();
        }

        public virtual ActionResult List()
        {
            return View(this.requestController.Get());
        }
    }
}