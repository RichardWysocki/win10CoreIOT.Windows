using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using win10Core.Business.Model;
using Microsoft.Data.OData;

namespace Services.ControllersApi
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using win10Core.Business.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Gift>("Example");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ExampleController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Example
        public async Task<IHttpActionResult> GetExample(ODataQueryOptions<Gift> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Gift>>(gifts);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Example(5)
        public async Task<IHttpActionResult> GetGift([FromODataUri] int key, ODataQueryOptions<Gift> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Gift>(gift);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Example(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Gift> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(gift);

            // TODO: Save the patched entity.

            // return Updated(gift);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Example
        public async Task<IHttpActionResult> Post(Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(gift);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Example(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Gift> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(gift);

            // TODO: Save the patched entity.

            // return Updated(gift);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Example(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
