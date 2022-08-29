using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.DataObjects;
using StudentManagement.Services.Data;
using StudentManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Services
{
    public class StudentService : IStudent
    {
        private readonly DataContext _context;

        public StudentService() { }

        public Task<List<StudentViewModel>> AddStudent(StudentDto student)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentViewModel>> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentViewModel>> GetAllStudents()
        {
            //try
            //{
            //    List<StudentViewModel> studentDetailsList = new List<StudentViewModel>();
            //    var data = await _context.Students.ToListAsync();

            //    studentDetailsList.AddRange((IEnumerable<StudentViewModel>)data);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            throw new NotImplementedException();

        }

        public Task<List<StudentViewModel>> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentViewModel>> UpdateStudent(int id, StudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
