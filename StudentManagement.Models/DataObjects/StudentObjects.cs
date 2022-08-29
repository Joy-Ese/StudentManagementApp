﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DataObjects
{
    public class StudentViewModel
    {
        private DateTime createdDate;
        private DateTime updatedDate;

        public int Id { get; set; }
        public long RegNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = null;
        public string Department { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string? Address { get; set; } = null;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }
    }

    public class StudentDto
    {
        private DateTime createdDate;
        private DateTime updatedDate;

        public long RegNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = null;
        public string Department { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string? Address { get; set; } = null;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }

    }
}
