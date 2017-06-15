using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.Helpers
{
    public sealed class StudentApiClient
    { 
        private static string _studentApiUrl;
        private static string _studentApiUserName;
        private static string _studentApiPassword;
        private static IDictionary<string,string> _studentApiEndpoints;

        #region Properties
        private static String StudentApiUrl
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_studentApiUrl))
                    _studentApiUrl =ConfigurationManager.AppSettings.Get("StudentAPIUrl");

                return _studentApiUrl;
            }
        }

        private static String StudentApiUserName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_studentApiUserName))
                    _studentApiUserName = ConfigurationManager.AppSettings.Get("StudentAPIUserName");

                return _studentApiUserName;
            }
        }

        private static String StudentApiPassword
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_studentApiPassword))
                    _studentApiPassword = ConfigurationManager.AppSettings.Get("StudentAPIPassword");

                return _studentApiPassword;
            }
        }

        private static IDictionary<String,String> StudentApiEndpoints
        {
            get
            {
                if (_studentApiEndpoints==null)
                    _studentApiEndpoints = ConfigurationManager.AppSettings.Get("StudentAPIEndpoints").Split(new[] { "|" }, StringSplitOptions.None)
                                     .Select(ht => ht.Split(new[] { ":" }, StringSplitOptions.None))
                                     .ToDictionary(kv => kv[0],kv => kv[1]);

                return _studentApiEndpoints;
            }
        }

        #endregion

        #region Sync Methods

        public static String Get(string endpoint)
        {
            string endpointUrl = string.Empty;
            StudentApiEndpoints.TryGetValue(endpoint, out endpointUrl);
            if (String.IsNullOrWhiteSpace(endpointUrl))
                throw new Exception("EndPoint Not found");
            else
                return InvokeStudentApi(endpointUrl);
        }

        private static String InvokeStudentApi(String endpointUrl)
        {
            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes(StudentApiUserName + ":" + StudentApiPassword);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                HttpResponseMessage response =  client.GetAsync(StudentApiUrl + endpointUrl).Result;
                HttpContent content = response.Content;
                return content.ReadAsStringAsync().Result;
            }
        }

        #endregion

        #region Async Methods

        /// <summary>
        /// Method to identify the StudentApi endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="reqparameter"></param>
        /// <returns></returns>
        public static async Task<String> GetAsync(string endpoint, string reqparameter = null)
        {
            string endpointUrl =string.Empty;
            StudentApiEndpoints.TryGetValue(endpoint, out endpointUrl);
            if (String.IsNullOrWhiteSpace(endpointUrl))
                throw new Exception("EndPoint Not found");
            else
              return await InvokeStudentApiAsync(endpointUrl, reqparameter);
        }

        /// <summary>
        /// Method to get the details from Student API 
        /// </summary>
        /// <param name="endpointUrl"></param>
        /// <param name="reqparameter"></param>
        /// <returns></returns>
        private static async Task<String> InvokeStudentApiAsync(String endpointUrl, string reqparameter = null)
        {
            using (var client = new HttpClient())
            {
                    var byteArray = Encoding.ASCII.GetBytes(StudentApiUserName + ":" + StudentApiPassword);
                    client.Timeout = new TimeSpan(0, 0, 0, 30);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var requestUrl = string.IsNullOrWhiteSpace(reqparameter) ? StudentApiUrl + endpointUrl : StudentApiUrl + string.Format(endpointUrl, reqparameter);
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode();
                    HttpContent content = response.Content;
                    return await content.ReadAsStringAsync();                
              }
        }

        #endregion
    }
}