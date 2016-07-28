using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            return db.Talents.ToList();
        }

        //Get one
        [AllowAnonymous]
        [HttpGet]
        [Route("api/talents/{id:int}")]
        public Talent GetTalent(int id)
        {
            return db.Talents.ToList().Find(t => t.Id == id);
        }

        //Add
        [Authorize]
        [HttpPost]
        [Route("api/talents")]
        public HttpResponseMessage PostTalent(Talent talent)
        {
            //talent = repository.Add(talent);

            talent.CreatedAt = DateTime.Now;
            talent.UpdatedAt = DateTime.Now;

            try
            {
                db.Talents.Add(talent);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                HttpResponseMessage error = Request.CreateResponse(HttpStatusCode.OK, "value");
                error.Content = new StringContent(ex.Message, Encoding.Unicode);
                return error;
            }
            //var response = Request.CreateResponse<Talent>(HttpStatusCode.Created, talent);

            //string uri = Url.Link("AddTalent", new { id = talent.Id });

            //response.Headers.Location = new Uri(uri);
            //return response;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Success fully added to Talents Database :)", Encoding.Unicode);
            return response;
        }

        //Update
        [Authorize]
        [HttpPut]
        [Route("api/talents/{id:int}")]
        public HttpResponseMessage PutTalent(int id, Talent talent)
        {
            try
            {
                Talent toUpdate = db.Talents.ToList().Find(t => t.Id == id);
                toUpdate.Name = talent.Name;
                toUpdate.ShortName = talent.ShortName;
                toUpdate.Bio = talent.Bio;
                toUpdate.ImageLink = talent.ImageLink;
                toUpdate.Reknown = talent.Reknown;
                toUpdate.UpdatedBy = talent.UpdatedBy;
                toUpdate.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                HttpResponseMessage error = Request.CreateResponse(HttpStatusCode.OK, "value");
                error.Content = new StringContent(ex.Message, Encoding.Unicode);
                return error;
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Success fully updated to Talents Database :)", Encoding.Unicode);
            return response;
        }
        
        //Delete
        [Authorize]
        [HttpDelete]
        [Route("api/talents/{id:int}")]
        public HttpResponseMessage Talents(int id)
        {
            try
            {
                db.Talents.Remove(db.Talents.ToList().Find(t => t.Id == id));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                HttpResponseMessage error = Request.CreateResponse(HttpStatusCode.OK, "value");
                error.Content = new StringContent(ex.Message, Encoding.Unicode);
                return error;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Success deleted talent from Talents Database :)", Encoding.Unicode);
            return response;
        }

        ////Delete
        //[Authorize]
        //[HttpPut]
        //[Route("api/talents/{id:int}/{para}")]
        //public HttpResponseMessage Talents(int id, string deletedBy)
        //{
        //    try
        //    {
        //        Talent toDelete = db.Talents.ToList().Find(t => t.Id == id);
        //        toDelete.DeletedBy = deletedBy;
        //        toDelete.DeletedAt = DateTime.Now;
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        HttpResponseMessage error = Request.CreateResponse(HttpStatusCode.OK, "value");
        //        error.Content = new StringContent(ex.Message, Encoding.Unicode);
        //        return error;
        //    }
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
        //    response.Content = new StringContent("Success deleted talent from Talents Database :)", Encoding.Unicode);
        //    return response;
        //}

    }
}
