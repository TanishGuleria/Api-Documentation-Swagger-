using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBapi.Models;
using Microsoft.EntityFrameworkCore;
namespace WEBapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private StudentContext context;
        public StudentController(StudentContext Context)
        {
            context = Context;
        }
        // GET: api/Student
      [HttpGet]
        public IEnumerable<Student> Get()
        {
            return context.Students;
        }
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
           var result =  context.Students.SingleOrDefault(c => c.StudentId == id);
            if (result == null)
            {
                return NotFound("No Such Records....");
            }
            else
                return Ok(result);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post([FromBody] Student st)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                context.Students.Add(st);
                context.SaveChanges();
                return Ok(StatusCodes.Status201Created);
            }
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student st)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!=st.StudentId)
                {
                return BadRequest();
            }

            try
            {
                context.Students.Update(st);
                context.SaveChanges(true);
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return NotFound("no data found");
            }
            return StatusCode(StatusCodes.Status201Created);

        }
        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = context.Students.SingleOrDefault(c => c.StudentId == id);
            if (result == null)
            {
                return NotFound("No Such Records....");
            }
            else
                context.Students.Remove(result);
            context.SaveChanges(true);
                return Ok("Product Deleted");
        }
    }
}
