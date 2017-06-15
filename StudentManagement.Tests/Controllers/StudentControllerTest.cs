using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Controllers.Tests
{
    

    [TestClass()]
    public class StudentControllerTest
    {
        [TestMethod()]
        public void GetAlltest()
        {
            StudentController student = new StudentController();
            var response = student.GetAll();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
       
        [TestMethod()]
        public void GetEnrollmentTestMethod()
        {
            StudentController student = new StudentController();
            var response = student.GetEnrollment("1");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod()]
        public void GetAssignmentTestMethod()
        {
            StudentController student = new StudentController();
            var response = student.GetAssignment("00");
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}