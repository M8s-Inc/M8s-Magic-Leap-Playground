using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System;
using UnityEngine;


public class GoveeLightsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GoveeDevice smartBulb1 = new GoveeDevice();
        smartBulb1.deviceName = "SmartBulb1";
        smartBulb1.device = "DB:2A:D4:AD:FC:42:69:5E";
        smartBulb1.model = "H6008";

        GoveeDevice smartBulb2 = new GoveeDevice();
        smartBulb2.deviceName = "SmartBulb2";
        smartBulb2.device = "23:60:D4:AD:FC:41:D0:BE";
        smartBulb2.model = "H6008";

        GoveeDevice smartBulb3 = new GoveeDevice();
        smartBulb3.deviceName = "SmartBulb3";
        smartBulb3.device = "CF:DB:D4:AD:FC:44:B2:22";
        smartBulb3.model = "H6008";

        GoveeDevice smartBulb4 = new GoveeDevice();
        smartBulb4.deviceName = "SmartBulb4";
        smartBulb4.device = "73:B2:D4:AD:FC:44:C2:42";
        smartBulb4.model = "H6008";


        DeviceList.Add(smartBulb1);
        DeviceList.Add(smartBulb2);
        DeviceList.Add(smartBulb3);
        DeviceList.Add(smartBulb4);

        //new RGB Command test
        Debug.Log("Testing SetDeviceRGB");
        SetDeviceRGB(smartBulb1, 255, 0, 255);
        SetDeviceRGB(smartBulb2, 0, 255, 0);
        SetDeviceRGB(smartBulb3, 0, 0, 255);
        SetDeviceRGB(smartBulb4, 255, 255, 0);

        //Debug.Log("Testing SendTestRequest");
       // SendTestRequest();

        //Set up my static devices for now.


    }
    //public class GoveeDevice : MonoBehaviour
    [Serializable]
    public class GoveeDevice
    {
        public string deviceName;
        public string device;
        public string model;
    }

    public List<GoveeDevice> DeviceList = new List<GoveeDevice>();

    public struct GoveeCMDData
    {
        public string device;
        public string model;

        [SerializeField] public GoveeCMD cmd;
    }

    //Using an interface so I can have multiple command types. 
    public interface GoveeCMD
    {

    }

    public struct GoveeCMD_Val : GoveeCMD
    {
        public string name;
        public int value;
    }

    public struct GoveeCMD_RGB : GoveeCMD
    {
        public string name;
        public RGB value;
    }

    public struct GoveeCMD_Switch : GoveeCMD
    {
        public string name;
        public string value;
    }

    public struct RGB
    {
        public int r;
        public int g;
        public int b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /* how do I go back
     *
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cmd
    {
        public string name { get; set; }
        public int value { get; set; }
    }

    public class Root
    {
        public string device { get; set; }
        public string model { get; set; }
        public Cmd cmd { get; set; }
    }


     */


    //get call to https://developer-api.govee.com/v1/devices
    // Govee-API-Key 5c8c7eb9-08e4-47f6-8b5a-3a6b121a5ee6
    //have it defined in postman. Need to be able to deserialize those. 
    public void GetAllDevices()
    {
        //
    }

     
    public void SetDeviceRGB(GoveeDevice myDevice, int red, int green, int blue)
    {
        GoveeCMDData data = new GoveeCMDData();
        data.device = myDevice.device;
        data.model = myDevice.model;

        GoveeCMD_RGB rgb_CMD = new GoveeCMD_RGB();
        rgb_CMD.name = "color";
        rgb_CMD.value.r = red;
        rgb_CMD.value.g = green;
        rgb_CMD.value.b = blue;

        data.cmd = rgb_CMD;

        //now how to serialize it into json easily?

        //string CMDString = @"{
        //    ""device"": ""{data.device}"",
        //    ""model"": ""{data.model}"",
        //    ""cmd"": {
        //        ""name"": ""color"",
        //        ""value"": {
        //            ""r"": {red},
        //            ""g"": {green},
        //            ""b"": {blue}
        //        }
        //    }
        //}";

        string CMDString2 = @"{{
            ""device"": ""{0}"",
            ""model"": ""{1}"",
            ""cmd"": {{
                ""name"": ""color"",
                ""value"": {{
                    ""r"": {2},
                    ""g"": {3},
                    ""b"": {4}
                }}
            }}
        }}"; ;

        string CMDString2Result = string.Format(CMDString2, data.device, data.model, red, green, blue);

        //This didn't serialize the interface structs.
        //string jsonresult = JsonUtility.ToJson(data);


        Debug.Log(CMDString2Result);
        var url = "https://developer-api.govee.com/v1/devices/control";

        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        httpRequest.Method = "PUT";

        httpRequest.ContentType = "application/json";

        httpRequest.Headers["Govee-API-Key"] = "5c8c7eb9-08e4-47f6-8b5a-3a6b121a5ee6";

        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        {
            streamWriter.Write(CMDString2Result);
        }
        

        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }

        Debug.Log(httpResponse.StatusCode);
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

        Debug.Log("heeyyyyyyy " + greenCMD);
        Debug.Log(httpResponse.StatusCode);
    }
}
