using AutoMapper;
using Scutum.Business;
using Scutum.Data;
using Scutum.Library.Security;
using Scutum.Model;
using Scutum.WebAPI.Config.Filters;
using Scutum.WebAPI.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;

namespace Scutum.WebAPI.Controllers
{
    [AuthorizeFilter(Roles = "Atendente")]
    public class CartaoCreditosController : ApiController
    {
        private Business.CartaoCredito business = new Business.CartaoCredito();

        // GET: API/TModel/5
        public IHttpActionResult Get(int id)
        {
            var password = string.Join("", Request.Headers.GetValues("Password"));
            
            var model = this.business.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            model.Senha = password;

            try
            {
                var viewModel = Mapper.Map<Model.CartaoCredito, CartaoCreditoViewModel>(model);

                return Ok(new {
                    Id = viewModel.Id,
                    Numero = viewModel.Numero
                });
            }
            catch (AutoMapperMappingException)
            {
                return BadRequest();
            }
        }

        // POST: API/TModel
        public IHttpActionResult Post(CartaoCreditoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = Mapper.Map<CartaoCreditoViewModel, Model.CartaoCredito>(viewModel);
            this.business.Save(model);

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, new {
                Id = model.Id,
                Numero = viewModel.Numero
            });
        }

        // PUT: API/TModel/5
        public virtual IHttpActionResult Put(int id, CartaoCreditoViewModel viewModel)
        {
            var model = Mapper.Map<CartaoCreditoViewModel, Model.CartaoCredito>(viewModel);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.Id)
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
    }
}