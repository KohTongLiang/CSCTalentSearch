using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TalentSearch.Models;

namespace TalentSearch.Controllers
{
    public class TalentsController : ApiController
    {
        CSCAssignment2Entities db = new CSCAssignment2Entities();
        static readonly InterfaceTalentRepository repository = new TalentRepository();
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        //Get all
        [AllowAnonymous]
        [HttpGet]
        [Route("api/talents")]
        public IEnumerable<Talent> GetAllTalents()
        {
            return repository.GetAll();
            //return db.Talents.ToList();
        }

        //Get one
        [AllowAnonymous]
        [HttpGet]
        [Route("api/talents/{id:int}")]
        public Talent GetTalent(int id)
        {
            Talent talent = repository.Get(id);
            if (talent == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return talent;
        }

        //Add
        [Authorize]
        [HttpPost]
        [Route("api/talents")]
        public HttpResponseMessage PostTalent(Talent talent)
        {
            //talent = repository.Add(talent);

            db.Talents.Add(talent);
            db.SaveChanges();

            var response = Request.CreateResponse<Talent>(HttpStatusCode.Created, talent);

            string uri = Url.Link("AddTalent", new { id = talent.Id });

            response.Headers.Location = new Uri(uri);
            return response;
        }

        //Update
        [Authorize]
        [HttpPut]
        [Route("api/talents/{id:int}")]
        public void PutTalent(int id, Talent talent)
        {
            talent.Id = id;
            if (!repository.Update(talent))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //Delete
        [Authorize]
        [HttpDelete]
        [Route("api/talents/{id:int}")]
        public void DeleteTalent(int id)
        {
            Talent talent = repository.Get(id);
            if (talent == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }

    }
}
