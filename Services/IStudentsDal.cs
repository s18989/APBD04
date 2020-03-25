using APDB04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APDB04.Service
{
    public interface IStudentsDal
    {
        public IEnumerable<Student> GetStudents();
    }
}
