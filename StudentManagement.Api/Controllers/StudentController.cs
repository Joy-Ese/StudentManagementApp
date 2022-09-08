using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.DataObjects;
using StudentManagement.Models.Entities;
using StudentManagement.Services.Interfaces;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext _context;
        private IStudent _studentService;

        public StudentController(DataContext context, IStudent studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentViewModel>>> GetAllStudents()
        {
            var result = await _studentService.GetAllStudents();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetStudent(int id)
        {
            var result = await _studentService.GetStudent(id);

            var now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Console.WriteLine(now);
            result.FirstName = now;
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] StudentDto student)
        {
            var result = await _studentService.AddStudent(student);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<StudentViewModel>>> UpdateStudent([FromRoute] int id, StudentDto request)
        {
            var dbStudentDetail = await _context.Students.FindAsync(id);
            if (dbStudentDetail == null)
                return BadRequest("Student not found");

            dbStudentDetail.RegNumber = request.RegNumber;
            dbStudentDetail.FirstName = request.FirstName;
            dbStudentDetail.MiddleName = request.MiddleName;
            dbStudentDetail.LastName = request.LastName;
            dbStudentDetail.Email = request.Email;
            dbStudentDetail.Department = request.Department;
            dbStudentDetail.Gender = request.Gender;
            dbStudentDetail.Address = request.Address;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentViewModel>>> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);

            return Ok(result);
        }
    }
}
