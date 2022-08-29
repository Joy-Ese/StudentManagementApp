using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models.DataObjects;
using StudentManagement.Models.Entities;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> studentDetails = new List<Student>
            {
                //new Student
                //{
                //    Id = 1,
                //    RegNumber = 20221234567,
                //    FirstName = "Sarah",
                //    MiddleName = "Ade",
                //    LastName = "Michael",
                //    Email = "sarahademichael@gmail.com",
                //    Department = "Chemistry",
                //    Gender = "female",
                //    Address = "24 Ajose Adeogu, VI",
                //    CreatedBy = "Joy Eseosa Ihama",
                //    CreatedDate = 2022-08-24,
                //    UpdatedBy = "Joy Eseosa Ihama",
                //    UpdatedDate = 2022-08-26
                //}
            };
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var studentDetail = await _context.Students.FindAsync(id);
            if (studentDetail == null)
                return BadRequest("Student not found");
            return Ok(studentDetail);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] StudentDto student)
        {
            Student studentInfo = new Student
            {
                RegNumber = student.RegNumber,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Email = student.Email,
                Department = student.Department,
                Gender = student.Gender,
                Address = student.Address,
                CreatedBy = student.CreatedBy,
                CreatedDate = student.CreatedDate,
                UpdatedBy = student.UpdatedBy,
                UpdatedDate = student.UpdatedDate,
            };
            _context.Students.Add(studentInfo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent([FromRoute] int id, StudentDto request)
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
            dbStudentDetail.CreatedBy = request.CreatedBy;
            dbStudentDetail.CreatedDate = request.CreatedDate;
            dbStudentDetail.UpdatedBy = request.UpdatedBy;
            dbStudentDetail.UpdatedDate = request.UpdatedDate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbStudentDetail = await _context.Students.FindAsync(id);
            if (dbStudentDetail == null)
                return BadRequest("Student not found");

            _context.Students.Remove(dbStudentDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
    }
}
