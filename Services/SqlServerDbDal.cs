using APDB04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APDB04.Service
{
    public class SqlServerDbDal : IStudentsDal
    {
        public IEnumerable<Student> GetStudents()
        {
            //.. sql con
            return null;
        }
    }
}
