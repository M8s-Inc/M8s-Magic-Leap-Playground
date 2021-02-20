using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using SimpleJSON;

using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

[Serializable]
public class PersistentDeviceList : MonoBehaviour
{
    List<PersistentDeviceData> PersistentDevicesDataList = new List<PersistentDeviceData>();

    Dictionary<string, PersistentDeviceData> persistentDevices = new Dictionary<string, PersistentDeviceData>();
    Dictionary<string, PersistentDeviceData> persistentDevices2 = new Dictionary<string, PersistentDeviceData>();

    Dictionary<string, PersistentDeviceData> persistentDevices3 = new Dictionary<string, PersistentDeviceData>();
    Dictionary<string, PersistentDeviceData> persistentDevices4 = new Dictionary<string, PersistentDeviceData>();

    PersistentDeviceData deviceData1;
    PersistentDeviceData deviceData2;

    string fullPath;

    private string fileName = "DeviceDataTest.json";

    bool ranonce = false;

    // Start is called before the first frame update
    void Start()
    {
        //I think I'm going to work off serialization. I need to do JSON serialization/deserialization here. 

        PersistentDevicesDataList.Add(new PersistentDeviceData("newDeviceName", "12345", "newOtherInputs"));
        PersistentDevicesDataList.Add(new PersistentDeviceData("newDeviceName2", "67890", "newOtherInputs2"));

        PersistentDevicesDataList.Sort();
        
        foreach(PersistentDeviceData pdd in PersistentDevicesDataList)
        {
            Debug.Log(pdd.deviceName + " " + pdd.id);
        }

        fullPath = Path.Combine(Application.dataPath, "Data", this.fileName);

        //string json = JsonConvert.SerializeObject(persistentDevices, Formatting.Indented);

        //dictionary tutorial
        //MagicLeap.PersistentDevice pd1 = new pd(constructor);


        //persistentdevices.add("testlight", pd1);

        //magicleap.persistentdevice pd2 = persistentdevices["testlight"];

        //not efficient but safe since it won't throw an exception if there is no key
        //persistentdevicedata temp = null;

        //if (persistentdevices.trygetvalue("testlight2", out temp))
        //{
        //    //success
        //}
        //else
        //{
        //    //failure
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(!ranonce)
        {
            //public PersistentDeviceData(string newid, string newDeviceName, string newPrefabType)

            deviceData1 = new PersistentDeviceData("testID 1", "Pubnub_Light1", "Pubnub_Light");
            deviceData2 = new PersistentDeviceData("testID 2", "Crestron_Light1", "Crestron_Light");

            persistentDevices.Add(deviceData1.id, deviceData1);
            persistentDevices.Add(deviceData2.id, deviceData2);

            Debug.Log("Printing dictionary1 ");
            foreach (var device in persistentDevices)
            {
                Debug.Log("device id: " + device.Value.id + "  prefab type: " + device.Value.prefabType);
            }


            string json = JsonConvert.SerializeObject(persistentDevices, Formatting.Indented);

            Debug.Log("Testing dictionary Serialization" + json);

            //Alright cooooooool
            persistentDevices2 = JsonConvert.DeserializeObject<Dictionary<string, PersistentDeviceData>>(json);



            Debug.Log("Testing dictionary deserialization");
            foreach (var device in persistentDevices2)
            {
                Debug.Log("device id: " + device.Value.id + "prefab type: " + device.Value.prefabType);
            }

            Debug.Log(Application.dataPath);
            Debug.Log(Application.dataPath + " Data");

            SaveFile(persistentDevices2);
            LoadFile();
            ranonce = true;
        }
    }

    private void SaveFile(Dictionary<string, PersistentDeviceData> devicesToSave)
    {

        //File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(persistentDevices, Formatting.Indented));

        File.WriteAllText(fullPath, JsonConvert.SerializeObject(devicesToSave, Formatting.Indented));

        // serialize JSON directly to a file
        //using (StreamWriter file = File.CreateText(fullPath))
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    serializer.Serialize(file, devicesToSave);
        //}
    }

    private void LoadFile()
    {
        persistentDevices3 = JsonConvert.DeserializeObject<Dictionary<string, PersistentDeviceData>>(File.ReadAllText(fullPath));

        // deserialize JSON directly from a file
        //using (StreamReader file = File.OpenText(fullPath))
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    persistentDevices4 = (Dictionary<string, PersistentDeviceData>)serializer.Deserialize(file, typeof(Dictionary<string, PersistentDeviceData>));
        //}

        Debug.Log("Testing dictionary3 deserialization from file");
        foreach (var device in persistentDevices3)
        {
            Debug.Log("device id: " + device.Value.id + "prefab type: " + device.Value.prefabType);
        }

        //Debug.Log("Testing dictionary4 deserialization from file");
        //foreach (var device in persistentDevices4)
        //{
        //    Debug.Log("device id: " + device.Value.id + "prefab type: " + device.Value.prefabType);
        //}
    }
}
