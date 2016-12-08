using Scutum.Business;
using Scutum.Model.Interface;
using Scutum.WebAPI.Config.Filters;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Scutum.WebAPI.Controllers
{
    public abstract class BaseApiController<TBusiness, TData, TModel> : ApiController
        where TBusiness : Business.Base<TData, TModel>, new()
        where TData : Data.Base<TModel>, new()
        where TModel : class, IEntityWithID
    {
        protected TBusiness business = new TBusiness();

        // GET: API/TModel
        public virtual IQueryable<TModel> Get()
        {
            return this.business.Get();
        }

        // GET: API/TModel/5
        public virtual IHttpActionResult Get(int id)
        {
            var model = this.business.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST: API/TModel
        public virtual IHttpActionResult Post(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.business.Save(model);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // PUT: API/TModel/5
        public virtual IHttpActionResult Put(int id, TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                this.business.Update(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.business.Exists(id))
                {
                    throw;
                }

                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: API/TModel/5
        [AuthorizeFilter(Roles = "Admin")]
        public virtual IHttpActionResult Delete(int id)
        {
            var model = this.business.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            this.business.Remove(model);
            return Ok(model);
        }
    }
}