using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

//This Script is to manage the discovered devices, manage the prefabs that I have made, and help manage the device pairing / placement with the PCF behaviour.
public class DeviceManager : MonoBehaviour
{
    public MagicLeap.MyPCF myPCF;
    public M8MLController myController;
    public UIManager uiManager;

    public List<GameObject> devicePrefabs = new List<GameObject>();

    public Dictionary<string, PersistentDeviceData> deviceDataDictionary;
    public Dictionary<string, GameObject> deviceDictionary = new Dictionary<string, GameObject>();

    private string fileName_deviceData = "DeviceData.json";
    private string fileName_deviceDictionary = "DeviceDictionary.json";

    string fullPath_deviceData;
    string fullPath_deviceDictionary;

    //so I can translate from an ID to what gameobject to be instantiated.


    // Start is called before the first frame update
    void Start()
    {
        //Add 
        //deviceDataDictionary.Add(devicePrefabs[0].name, devicePrefabs[0]);

        fullPath_deviceData = Path.Combine(Application.dataPath, "Data", this.fileName_deviceData);
        fullPath_deviceDictionary = Path.Combine(Application.dataPath, "Data", this.fileName_deviceDictionary);

        LoadAllDevices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This will be the function called from the main menu. I'm making this simple for now. 
    public void AddDevice(string deviceToAdd,string ipAddressToAdd)
    {
        Debug.Log("Inside Device Management Add Device" + deviceToAdd);

        //GameObject prefab = new GameObject();

        GameObject prefab;

        if (deviceToAdd == "Pubnub_Light")
        {
            Debug.Log("Inside Device Management - Adding Pubnub_Light");
            prefab = devicePrefabs[0];

        }
        else if (deviceToAdd == "Crestron_Light")
        {
            Debug.Log("Inside Device Management - Adding Crestron_Light");
            prefab = devicePrefabs[1];
        }
        else if (deviceToAdd == "Crestron_AppleTV")
        {
            Debug.Log("Inside Device Management - Adding Crestron_AppleTV");
            prefab = devicePrefabs[2];
        }
        else
        {
            Debug.Log("Inside Device Management - Adding else");
            prefab = devicePrefabs[0];
        }

        GameObject gameObj = Instantiate(prefab, myController.attachPoint.transform.position, myController.attachPoint.transform.rotation);

        MagicLeap.PersistentDevice persistentContent = gameObj.GetComponent<MagicLeap.PersistentDevice>();

        //**Should I find these gameObjects within the PlaceableDevice Script? 
        PlaceableDevice placeableDevice = gameObj.GetComponent<PlaceableDevice>();
        placeableDevice.myController = myController;
        placeableDevice.uiManager = uiManager;
        placeableDevice.deviceManager = this;

        persistentContent.deviceData.ipAddress = ipAddressToAdd;
        persistentContent.deviceData.prefabType = deviceToAdd;
        persistentContent.deviceData.id = gameObj.GetInstanceID().ToString();

        //I don't want this to just be clone for each one.
        //persistentContent.deviceData.deviceName = gameObj.name;

        persistentContent.deviceData.deviceName = deviceToAdd + persistentContent.deviceData.id;

        gameObj.name = persistentContent.deviceData.deviceName;

        Debug.Log("Trying to figure out whats breaking when creating new device. " + ipAddressToAdd + "   " + deviceToAdd + "   " + gameObj.name);

        myPCF.CreateDevicePCF(gameObj);
    }

    //loads all devices from file and instantiates their game objects.
    public void LoadAllDevices()
    {
        //load deviceDataDictionary from JSON.
        Debug.Log("Loading JSON");

        //Whats going on with this crap.
        //if (!File.Exists(fullPath_deviceData))
        //{
        //    Debug.Log("no " + fullPath_deviceData + " file exists");
        //    StreamWriter w = File.AppendText(fullPath_deviceData);
        //}

        deviceDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, PersistentDeviceData>>(File.ReadAllText(fullPath_deviceData));


        //Fill Up the deviceDictionary.
        if(deviceDataDictionary != null && deviceDataDictionary.Count > 0)
        {
            foreach (KeyValuePair<string, PersistentDeviceData> device in deviceDataDictionary)
            {
                GameObject prefab;
                Debug.Log("device key: " + device.Key + "device value: " + device.Value.id);

                if (device.Value.prefabType == "Pubnub_Light")
                {
                    prefab = devicePrefabs[0];
                }
                else if (device.Value.prefabType == "Crestron_Light")
                {
                    prefab = devicePrefabs[1];
                }
                else if (device.Value.prefabType == "Crestron_AppleTV")
                {
                    prefab = devicePrefabs[2];
                }
                else
                {
                    prefab = new GameObject();
                    Debug.Log("Shouldn't end up here. inside else prefab : " + prefab.name + " device key " + device.Key + "device value. ID " + device.Value.id);

                }

                //Debug.Log("prefab : " + prefab.name + " device key " + device.Key + "device value. ID " + device.Value.id);

                GameObject gameObj = Instantiate(prefab, myController.attachPoint.transform.position, myController.attachPoint.transform.rotation);

                Debug.Log("Inside LoadAllDevices - Gameobject :" + gameObj.name);
                MagicLeap.PersistentDevice persistentContent = gameObj.GetComponent<MagicLeap.PersistentDevice>();

                //**Should I find these gameObjects within the PlaceableDevice Script? 
                PlaceableDevice placeableDevice = gameObj.GetComponent<PlaceableDevice>();
                placeableDevice.myController = myController;
                placeableDevice.uiManager = uiManager;
                placeableDevice.deviceManager = this;

                //Copy data to the gameObject.
                persistentContent.deviceData.id = device.Value.id;
                persistentContent.deviceData.ipAddress = device.Value.ipAddress;
                persistentContent.deviceData.prefabType = device.Value.prefabType;

                //I don't want them all named clone.
                //persistentContent.deviceData.deviceName = device.Value.deviceName;

                persistentContent.deviceData.deviceName = device.Value.prefabType + device.Value.id;
                gameObj.name = persistentContent.deviceData.deviceName;

                deviceDictionary.Add(device.Value.id, gameObj);

            }
        }
        else
        {
            Debug.Log("deviceDataDictionary is null");
            deviceDataDictionary = new Dictionary<string, PersistentDeviceData>();
        }

        //double check the DeviceDictionary filled up.
        Debug.Log("Checking Device Dictionary");
        foreach (var device in deviceDictionary)
        {
            Debug.Log("device name: " + device.Value.name + "  prefab type: " + device.Value.GetComponent<MagicLeap.PersistentDevice>().deviceData.prefabType + "  ID : " + device.Value.GetComponent<MagicLeap.PersistentDevice>().deviceData.id);
        }

        Debug.Log("Device Data Dictionary count " + deviceDataDictionary.Count);
        Debug.Log("Device Dictionary count " + deviceDictionary.Count);

        //myPCF.deviceDictionary = deviceDictionary;
    }


    public void SaveDevices()
    {

        //File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(persistentDevices, Formatting.Indented));
        Debug.Log("Saving deviceDataDictionary.");

        File.WriteAllText(fullPath_deviceData, JsonConvert.SerializeObject(deviceDataDictionary, Formatting.Indented));

        //Debug.Log("Will this even work? Save Device Dictionary.");
        //File.WriteAllText(fullPath_deviceDictionary, JsonConvert.SerializeObject(deviceDictionary, Formatting.Indented));
    }

    public void DeleteDevices()
    {
        //Ok this utilzation breaks the controller. lets try to modify it. 
        // check if file exists
        if (!File.Exists(fullPath_deviceData))
        {
            Debug.Log( "no " + fullPath_deviceData + " file exists" );
        }
        else
        {
            //Delete Data file
            Debug.Log(fullPath_deviceData + " file exists, deleting..." );

            //File.Delete(fullPath_deviceData);
            File.WriteAllText(fullPath_deviceData,"");

        }

        //delete device dictionary and gameObjects
        foreach (var device in deviceDictionary)
        {
            Debug.Log("Destroying device gameobject " + device.Value.gameObject.name);
            Destroy(device.Value.gameObject);
        }

        deviceDictionary.Clear();
        deviceDataDictionary.Clear();

        //Debug.Log("Deleting All Devices");
        //foreach(var device in deviceDictionary)
        //{
        //    DeleteDevice(device.Value.GetComponent<MagicLeap.PersistentDevice>().deviceData);
        //    device.Value.GetComponent<MagicLeap.PersistentDevice>().DestroyContent(this.gameObject);
        //}

        //this is from the single device deletion. so maybe I'm missing something. 
        //deviceManager.DeleteDevice(this.gameObject.GetComponent<MagicLeap.PersistentDevice>().deviceData);
        //this.gameObject.GetComponent<MagicLeap.PersistentDevice>().DestroyContent(this.gameObject);
    }

    public void DeleteDevice(PersistentDeviceData deviceData)
    {
        //find deviceData inside deviceDataDictionary
        //deviceData.id = "test";

        PersistentDeviceData temp;
        if (deviceDataDictionary.TryGetValue(deviceData.id, out temp))
        {
            //success
            Debug.Log("Deleting device with id " + deviceData.id);
            deviceDataDictionary.Remove(deviceData.id);
            deviceDictionary.Remove(deviceData.id);
            SaveDevices();
        }
        else
        {
            //failure
            Debug.Log("Deleting device failed with id " + deviceData.id);

        }
    }

    private void OnDestroy()
    {
        //SaveDevices();
    }
}
