using Microsoft.AspNetCore.Mvc;
using mongoASPTutorial.Models;
using mongoASPTutorial.Services;


namespace mongoASPTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return studentService.GetStudents();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(string id)
        {
            var student = studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound($"Student with ID of {id} not found.");
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            // Create the student in the DB.
            studentService.Create(student);

            // CreatedAtAction() will return a 201 status code.
            // Params: 1. Action name, 2. Route param values, 3. Newly created object.
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentService.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID of {id} not found.");
            }
            studentService.Update(id, student);
            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = studentService.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID of {id} not found.");
            }
            studentService.Delete(id);
            // Ok() will return a 200 status code.
            return Ok($"Student with ID of {id} deleted.");
        }
    }
}
