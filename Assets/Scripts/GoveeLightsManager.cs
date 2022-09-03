using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class GoveeLightsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SendTestRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendTestRequest()
    {
        var url = "https://developer-api.govee.com/v1/devices/control";

        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        httpRequest.Method = "PUT";

        httpRequest.ContentType = "application/json";

        httpRequest.Headers["Govee-API-Key"] = "5c8c7eb9-08e4-47f6-8b5a-3a6b121a5ee6";

            var data = @"{
              ""Id"": 12345,
              ""Customer"": ""John Smith"",
              ""Quantity"": 1,
              ""Price"": 10.00
            }";


        var redCMD = @"{
            ""device"": ""C4:B6:A4:C1:38:B3:2F:8E"",
            ""model"": ""H6117"",
            ""cmd"": {
                ""name"": ""color"",
                ""value"": {
                    ""r"": 255,
                    ""g"": 0,
                    ""b"": 0
                }
            }
        }";

        var greenCMD = @"{
            ""device"": ""C4:B6:A4:C1:38:B3:2F:8E"",
            ""model"": ""H6117"",
            ""cmd"": {
                ""name"": ""color"",
                ""value"": {
                    ""r"": 0,
                    ""g"": 255,
                    ""b"": 0
                }
            }
        }";


        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        {
            streamWriter.Write(greenCMD);
        }

        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }

        Debug.Log(httpResponse.StatusCode);
    }
}
