using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PersistentDeviceList : MonoBehaviour
{
    List<PersistentDeviceData> PersistentDevicesDataList = new List<PersistentDeviceData>();

Dictionary<string, PersistentDeviceData> persistentDevices = new Dictionary<string, PersistentDeviceData>();


    // Start is called before the first frame update
    void Start()
    {
        //I think I'm going to work off serialization. I need to do JSON serialization/deserialization here. 

        PersistentDevicesDataList.Add(new PersistentDeviceData("newDeviceName", "12345", "newOtherInputs"));
        PersistentDevicesDataList.Add(new PersistentDeviceData("newDeviceName2", "67890", "newOtherInputs2"));

        PersistentDevicesDataList.Sort();
        
        foreach(PersistentDeviceData pdd in PersistentDevicesDataList)
        {
            Debug.Log(pdd.deviceName + " " + pdd.CFUID);
        }

        //dictionary tutorial
        //MagicLeap.PersistentDevice pd1 = new pd(constructor);

        //persistentDevices.Add("testLight", pd1);

        //MagicLeap.PersistentDevice pd2 =  persistentDevices["testLight"];

        //not efficient but safe since it won't throw an exception if there is no key
        //PersistentDeviceData temp = null;

        //if (persistentDevices.TryGetValue("testLight2", out temp))
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
        
    }
}
