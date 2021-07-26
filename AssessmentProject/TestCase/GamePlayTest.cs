using AssessmentProject.Models;
using AssessmentProject.WrapperClass;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharpDemo.BaseConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AssessmentProject.TestCase
{
   public class GamePlayTest
    {
       
        GamePlayRequestModel gamePlayRequestModel;
        GamePlay gamePlay; 
        GamePlayResponseModel gamePlayResponseModel;
        



        GamePlayRequestModel testdata = JsonConvert.DeserializeObject<GamePlayRequestModel>(File.ReadAllText(@"TestData\GamePlayTestData.json"));
        [Test]

        public async void GetBalanceAPI()
        {

            LoginTest login = new LoginTest();
            login.LoginTestAPI();
            var token =LoginTest.token;

            gamePlayRequestModel = new GamePlayRequestModel();
            gamePlayRequestModel.packetR.packetType = testdata.packetR.packetType;
            gamePlayRequestModel.packetR.payload = testdata.packetR.payload;
            gamePlayRequestModel.packetR.useFilter = testdata.packetR.useFilter;
            gamePlayRequestModel.packetR.isBase64Encoded = testdata.packetR.isBase64Encoded;

            
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
