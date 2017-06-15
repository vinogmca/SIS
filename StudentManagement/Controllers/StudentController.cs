using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using StudentManagement.Helpers;

namespace StudentManagement.Controllers
{

    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(Task.Run(() => StudentApiClient.GetAsync("GetAll")).Result,
                    System.Text.Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                               ex.Message));
            }
        }

        [HttpGet]
        [Route("api/Students/Enrollment/{id}")]
        public HttpResponseMessage GetEnrollment(string id)
        {
            try
            {
                if (!ValidateRequest(id))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid StudentId");
                else
                    return new HttpResponseMessage {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(Task.Run(() => StudentApiClient.GetAsync("GetEnrollment", id)).Result,
                        System.Text.Encoding.UTF8, "application/json")
                    };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpGet]
        [Route("api/Students/Assignment/{id}")]
        public HttpResponseMessage GetAssignment(string id)
        {
            try
            {
                if (!ValidateRequest(id))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid StudentId");
                else
                    return new HttpResponseMessage {
                        Content = new StringContent(Task.Run(() => StudentApiClient.GetAsync("GetAssignment", id)).Result,
                        System.Text.Encoding.UTF8, "application/json")
                    };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }
        }

        private bool ValidateRequest(string id)
        {
            int studentId;
            if (string.IsNullOrWhiteSpace(id) || !int.TryParse(id, out studentId))
                return false;
            return true;
        }
    }
}
