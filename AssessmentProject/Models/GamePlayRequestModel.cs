using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentProject.Models
{
    public class GamePlayRequestModel

        {
            public int packetType { get; set; }
            public string payload { get; set; }
            public bool useFilter { get; set; }
            public bool isBase64Encoded { get; set; }
        }

       
           
        
    }

