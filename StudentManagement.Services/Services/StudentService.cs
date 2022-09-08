using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.DataObjects;
using StudentManagement.Models.Entities;
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

        public StudentService(DataContext context) {
            _context = context;
        }


        public async Task<List<StudentViewModel>> AddStudent(StudentDto student)
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            try
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
                };
                await _context.Students.AddAsync(studentInfo);
                var result = await _context.SaveChangesAsync();

                students = await GetAllStudents();


                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }

        public async Task<List<StudentViewModel>> DeleteStudent(int id)
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            try
            {
                var data = await _context.Students.FindAsync(id);
                if (data == null) return null;
                _context.Students.Remove(data);
                await _context.SaveChangesAsync();

                students = await GetAllStudents();

                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }

        public async Task<List<StudentViewModel>> GetAllStudents()
        {
                List<StudentViewModel> studentDetailsList = new List<StudentViewModel>();

            try
            {
                var data = await _context.Students.ToListAsync();
                data.ForEach(student => studentDetailsList.Add(new StudentViewModel
                {
                    Id = student.Id,
                    RegNumber = student.RegNumber,
                    FirstName = student.FirstName,
                    MiddleName = student.MiddleName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Department = student.Department,
                    Gender = student.Gender,
                    Address = student.Address,

                }));
                return studentDetailsList;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return studentDetailsList;
            }

        }

        public async Task<StudentViewModel> GetStudent(int id)
        {
            StudentViewModel student = new StudentViewModel();

            try
            {
                var data = await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
                if (data == null) return null;
                student.Id = data.Id;
                student.RegNumber = data.RegNumber;
                student.FirstName = data.FirstName;
                student.MiddleName = data.MiddleName;
                student.LastName = data.LastName;
                student.Email = data.Email;
                student.Address = data.Address;
                student.Department = data.Department;
                student.Gender = data.Gender;

                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return student;
            }
        }

        public Task<List<StudentViewModel>> UpdateStudent(int id, StudentDto student)
        {
            throw new NotImplementedException();
        }

    }
}
