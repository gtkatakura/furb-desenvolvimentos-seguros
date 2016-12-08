using Scutum.Business;
using Scutum.Model.Interface;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Scutum.WebAPI.Controllers
{
    public abstract class BaseODataController<TBusiness, TData, TModel> : ODataController
        where TBusiness : Business.Base<TData, TModel>, new()
        where TData : Data.Base<TModel>, new()
        where TModel : class, IEntityWithID
    {
        protected TBusiness business = new TBusiness();

        // GET: OData/TModel
        [EnableQuery(PageSize = 20)]
        public virtual IQueryable<TModel> Get()
        {
            return this.business.Get();
        }

        // GET: OData/TModel?ID=5
        [EnableQuery]
        public virtual SingleResult<TModel> Get(int id)
        {
            return SingleResult.Create(this.business.Get(id));
        }

        // POST: OData/TModel
        public virtual IHttpActionResult Post(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.business.Save(model);
            return Created(model);
        }

        // PUT: OData/TModel?ID=5
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

            return Updated(model);
        }

        // DELETE: OData/TModel?ID=5
        public virtual IHttpActionResult Delete(int id)
        {
            var model = this.business.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            business.Remove(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}