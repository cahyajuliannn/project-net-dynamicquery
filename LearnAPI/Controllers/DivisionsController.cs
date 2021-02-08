using System;
using LearnAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnAPI.Repositories;
using System.Threading.Tasks;
using LearnAPI.ViewModel;
using System.Web.Mvc;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;

namespace LearnAPI.Controllers
{
    public class DivisionsController : ApiController
    {
        DivisionRepository divisionRepository = new DivisionRepository();
        // GET: api/Divisions
        public async Task<IEnumerable<DivisionVM>> Get()
        {
            return await divisionRepository.Get();
        }

        // GET: api/Divisions/5
        public async Task<DivisionVM> Get(int id)
        {
            return await divisionRepository.Get(id);
        }

        // POST: api/Divisions
        public IHttpActionResult Post(Division division)
        {
            var post = divisionRepository.Create(division);
            if (post > 0)
            {
                return Ok("Data has been inserted");
            }
            else
            {
                return BadRequest("Insert data failed");
            }
        }

        // PUT: api/Divisions/5
        [HttpPut]
        [ActionName("update/{id}")]
        public IHttpActionResult Put(int id, DivisionVM divisionVM)
        {
            divisionRepository.Update(id, divisionVM);
            return Ok("Data has been updated");
        }

        // DELETE: api/Divisions/5
        public IHttpActionResult Delete(int id)
        {
            divisionRepository.Delete(id);
            return Ok("Data has been deleted");
        }
    }
}
