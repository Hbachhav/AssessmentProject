using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

using AssessmentProject.Models;
using AssessmentProject.Helper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharpDemo.BaseConfig;

namespace AssessmentProject.WrapperClass
{
   public class Login
    {

        RestRequest restRequest;
        RestClient restClient;
        private static string hostName;
        LoginResponseModel loginResponseModel;

       public Login()
        {
            hostName = ConfigData.HostName;
        }
        public async Task<LoginResponseModel> GetToken (string guid,LoginModel postBody)
        {
            try
            {

                loginResponseModel = new LoginResponseModel();
                var apiUrl = string.Format(PostUrl.Login);
                var url = $"{hostName}/{apiUrl}";

                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("X-CorrelationId", guid);
                restRequest.AddHeader("X-Forwarded-For", guid);
                restRequest.AddHeader("X-Clienttypeid", "5");
                var content = JsonConvert.SerializeObject(postBody);
                restRequest = (RestRequest)new RestRequest(url).AddJsonBody(content);
                var response = await restClient.PostAsync<dynamic>(restRequest);


                return response;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Login API failed {0}",e);
                return null;
            }
        }
    }
}
