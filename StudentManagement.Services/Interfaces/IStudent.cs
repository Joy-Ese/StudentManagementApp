using StudentManagement.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IStudent
    {
        Task<List<StudentViewModel>> GetAllStudents();
        Task<StudentViewModel> GetStudent(int id);
        Task<List<StudentViewModel>> AddStudent(StudentDto student);
        Task<List<StudentViewModel>> UpdateStudent(int id, StudentDto student);
        Task<List<StudentViewModel>> DeleteStudent(int id);
    }
}
