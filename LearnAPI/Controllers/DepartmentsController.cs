using LearnAPI.Models;
using LearnAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LearnAPI.Controllers
{
    //[RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        DepartmentRepository departmentRepository = new DepartmentRepository(); 
        // GET: api/Departments
        //[HttpGet]
        //[Route("getAll")]
        public async Task<IEnumerable<Department>> Get()
        {
            return await departmentRepository.Get();
        }
        // GET: api/Departments/5
        //[HttpGet]
        //[ActionName("getById/{id}")]
        public async Task<Department> Get(int id)
        {
            return await departmentRepository.Get(id) ;
        }

        // POST: api/Departments
        public IHttpActionResult Post(Department department)
        {
            departmentRepository.Create(department);
            return Ok("Insert data successfully");
        }

        // PUT: api/Departments/5
        public IHttpActionResult Put(int id, Department department)
        {
            departmentRepository.Update(id, department);
            return Ok("Data has been updated");
        }

        // DELETE: api/Departments/5
        public IHttpActionResult Delete(int id)
        {
            departmentRepository.Delete(id);
            return Ok("Data has been deleted");
        }
    }
}
