using Newtonsoft.Json;

using RedisAnimals.Filters;

using RedisAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisAPI.Controllers
{
    public class FoodController : ApiController
    {

        [Cache(true, DB = 1, Expiracao = 180, ResponseType = typeof(List<Animal>))]
        public IHttpActionResult Get()
        {
            var animals = new List<Food> {  new Food { Name = "Maçã", Id = 1 },
                                            new Food { Name = "Arroz", Id = 2 },
                                            new Food { Name = "Carne", Id = 3 } };

            return Ok(animals);
        }

        [Cache(true,DB =1, Expiracao = 120, ResponseType = typeof(Animal))]
        [Route("api/Food/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id != 1)
                    return Ok(new { ErrorNumber = 999, ErrorMessage = "Comida nao cadastrada." });

                var food = new Food { Name = "Maçã", Id = 1 };

                return Ok(food);
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return InternalServerError(ex);
            }

        }

        [Cache(false, DB = 1, Expiracao = 120, ResponseType = typeof(Animal))]
        [Route("api/Food/{nome}")]
        public IHttpActionResult Get(string nome)
        {
            try
            {
                if ("maca".Equals(nome))
                    return Ok(new Food { Name = "Maçã", Id = 1 });
                else if ("arroz".Equals(nome))
                    return Ok(new { ErrorNumber = 999, ErrorMessage = "Comida nao cadastrada." });
                else
                    return InternalServerError(new Exception("Cominda nao cadastrada."));
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return InternalServerError(ex);
            }



        }
    }
}