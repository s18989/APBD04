using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APDB04.Models;
using APDB04.Service;
using Microsoft.AspNetCore.Mvc;

namespace APDB04.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IStudentsDal _dbService;

        public StudentsController(IStudentsDal dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult getStudents([FromServices]IStudentsDal dbService)
        {
            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18989;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = "select firstname, lastname, birthdate, name, semester from students inner join enrollment on idenrollment = idenrollment inner join studies on idstudy = idstudy";
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                    st.Name = dr["Name"].ToString();
                    st.Semester = Int16.Parse(dr["Semester"].ToString());
                    list.Add(st);

                }
            }
            
            return Ok(list);
        }

        [HttpGet("{IndexNumber}")]
        public IActionResult getStudent(string indexNumber)
        {

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18989;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from students where indexnumber ='" + indexNumber + "'";
                com.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();

                    if (dr["IndexNumver"] == DBNull.Value)
                    {

                    }
                    var st2 = new Student();

                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                    st.Name = dr["Name"].ToString();
                    st.Semester = Int16.Parse(dr["Semester"].ToString());
                    return Ok(st2);

                }

            return NotFound();
                
            }
        }
    }
}