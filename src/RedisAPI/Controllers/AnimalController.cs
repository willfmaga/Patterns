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
    public class AnimalController : ApiController
    {
      
        [Cache(true,DB =0,Expiracao = 180,ResponseType = typeof(List<Animal>))]
        public IHttpActionResult Get()
        {
            var animals = new List<Animal> { new Animal { name = "gato", type = "manifero" }, new Animal { name = "cachorro", type = "mamifero" } };

            return Ok(animals);
        }

        [Cache(true,Expiracao = 120,ResponseType = typeof(Animal))]
        [Route("api/Animal/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id != 1)
                    return Ok(new { ErrorNumber = 999, ErrorMessage = "Animal nao cadastrado." });

                var animal = new Animal { name = "gato", type = "mamifero" };

                return Ok(animal);
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return InternalServerError(ex);
            }

        }

        [Cache(true, Expiracao = 120, ResponseType = typeof(Animal))]
        [Route("api/Animal/{nome}")]
        public IHttpActionResult Get(string nome)
        {
            try
            {
                if ("gato".Equals(nome))
                    return Ok(new Animal { type = "mamifero", name = "gato" });
                else if ("cachorro".Equals(nome))
                    return Ok(new { ErrorNumber = 999, ErrorMessage = "Animal nao cadastrado." });
                else 
                    return InternalServerError (new Exception("Animal nao cadastrado."));
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return InternalServerError(ex);
            }



        }
    }
}