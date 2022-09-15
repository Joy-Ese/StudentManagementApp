using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, Authorize(Roles = "Admin")]
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

        [HttpPut("{id}")]
        public async Task<ActionResult<List<StudentViewModel>>> UpdateStudent([FromRoute] int id, StudentDto request)
        {
            var result = await _studentService.UpdateStudent(id, request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentViewModel>>> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<List<Student>>> RestoreStudent(int id)
        {
            var result = await _studentService.RestoreStudent(id);

            return Ok(result);
        }
    }
}
