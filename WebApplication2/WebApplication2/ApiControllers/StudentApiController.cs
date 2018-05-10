using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ApiControllers
{
    [Route("api/[controller]/[action]")]
    public class StudentApiController : Controller
    {
        // GET: api/StudentApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StudentApi/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(int id)
        {
            return Student.Get(id);
        }
        
        // POST: api/StudentApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPost]
        public List<Student> GetAllStudent()
        {
            return Student.getStudentList();
        }

        [HttpPost]
        public Student Create([FromBody]dynamic data)
        {
            List<Student> studentList = Student.getStudentList();
            Student student = new Student();
            student.FirstName = data.firstName;
            student.LastName = data.lastName;
            student.MidName = data.midName;
            return Student.addStudent(student);
        }

        // PUT: api/StudentApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Student.DeleteStudent(id);
        }
    }
}
