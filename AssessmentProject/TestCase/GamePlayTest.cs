using AssessmentProject.Models;
using AssessmentProject.WrapperClass;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharpDemo.BaseConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.TestCase
{
   public class GamePlayTest
    {
       
        GamePlayRequestModel gamePlayRequestModel;
        GamePlay gamePlay; 
        GamePlayResponseModel gamePlayResponseModel;
        



        GamePlayRequestModel testdata = JsonConvert.DeserializeObject<GamePlayRequestModel>(File.ReadAllText(@"C:\Users\BHAGVAT\source\repos\AssessmentProject\AssessmentProject\TestData\GamePlayTestData.json"));
        [Test]

        public async Task GetBalanceAPI()
        {

            LoginTest login = new LoginTest();
            login.LoginTestAPI();
            var token =LoginTest.token;

            gamePlayRequestModel = new GamePlayRequestModel();
            gamePlayRequestModel.packetType = testdata.packetType;
            gamePlayRequestModel.payload = testdata.payload;
            gamePlayRequestModel.useFilter = testdata.useFilter;
            gamePlayRequestModel.isBase64Encoded = testdata.isBase64Encoded;
            
            string productid = ConfigData.ProductId;
            string moduleid = ConfigData.ModuleId;
            string clientid = ConfigData.ClientId;

            gamePlay = new GamePlay();

            var response = await gamePlay.GetBalance(productid, moduleid,token, clientid, gamePlayRequestModel);
            var userBalance = response.context.balances.totalInAccountCurrency;
            

            if (response != null)
            {
                Console.WriteLine("Balance in your account is:"+ userBalance);
            }
            
        }
    }
}
