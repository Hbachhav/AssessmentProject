using AssessmentProject.Models;
using AssessmentProject.WrapperClass;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharpDemo.BaseConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject.TestCase
{
    public class LoginTest
    {
        LoginModel loginModel;
        Login login;
        LoginResponseModel loginResponseModel;
        public static string token;

        LoginModel testdata = JsonConvert.DeserializeObject<LoginModel>(File.ReadAllText(@"C:\Users\BHAGVAT\source\repos\AssessmentProject\AssessmentProject\TestData\LoginTestData.json"));
        
        
        [Test]
        public async Task LoginTestAPI()
        {
            loginModel = new LoginModel();
            loginModel.userName = testdata.userName;
            loginModel.password = testdata.password;
            loginModel.sessionProductId = testdata.sessionProductId;
            loginModel.clientTypeId = testdata.clientTypeId;
            loginModel.languageCode = testdata.languageCode;
            loginModel.numLaunchTokens = testdata.numLaunchTokens;
            loginModel.marketType = testdata.marketType;

            string guid = ConfigData.Guid;

            login = new Login();

            var response = await login.GetToken(guid, loginModel);
            
            if(response!=null)
            {
                Console.WriteLine("Login API passed");
            }
            token = response.tokens.userToken;
           
        }
        
    }
}
