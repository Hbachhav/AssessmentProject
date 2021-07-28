using RestSharp;
using RestSharpDemo.BaseConfig;
using System;
using AssessmentProject.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AssessmentProject.Helper;
using Newtonsoft.Json;
using System.Net.Http;

namespace AssessmentProject.WrapperClass
{
   public class GamePlay
    {

        IRestClient restClient = new RestClient();
        IRestRequest restRequest = new RestRequest();
        GamePlayResponseModel gamePlayResponseModel;
        private static string hostName;
       

        public GamePlay()
        {
            hostName = ConfigData.HostName;

        }
        public async Task<GamePlayResponseModel> GetBalance(string moduleID,string productId, string clientID,string token, GamePlayRequestModel postBody)
        {
            try
            {

                gamePlayResponseModel = new GamePlayResponseModel();
                var apiUrl = string.Format(PostUrl.GamePlay,moduleID,clientID);
                var url = $"{hostName}/{apiUrl}";

                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("Authorization",string.Format("Bearer " + token));
                restRequest.AddHeader("X-Clienttypeid", "38");
                restRequest.AddHeader("X - correlationid", "93D10259 - 30F8 - 4339 - B456 - 3F30A43F65A2");
                restRequest.AddHeader("X-Route-ProductId", productId);
                restRequest.AddHeader("X-Route-ModuleId", moduleID);

                var content = JsonConvert.SerializeObject(postBody);
                restRequest = (RestRequest)new RestRequest(url).AddJsonBody(content);
                var response = await restClient.PostAsync<dynamic>(restRequest);


                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("Login API failed {0}", e);
                return null;
            }
        }
    }
}

