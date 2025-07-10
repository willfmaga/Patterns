using RedisAnimals.DTOs;
using RedisAnimals.Filters;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace RedisAnimals.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Cache(true, ForceExpiration = true, Expiracao = 300, ResponseType = typeof(Animal))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var animal = new Animal() { name = "Gato" };

                if (animal is null)
                    return BadRequest();

                return Ok(animal);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
              
    }
}
