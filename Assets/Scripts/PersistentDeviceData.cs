using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if PLATFORM_LUMIN
using UnityEngine.XR.MagicLeap.Native;
#endif
using UnityEngine.XR.MagicLeap;


[Serializable]
public class PersistentDeviceData : IComparable<PersistentDeviceData>
{


    public string id;
    public string deviceName;
    public string prefabType;

    public string ipAddress;

    //public string CFUID;
    //public string otherInputs;
    public int sortID;

    //need to save transform info too.

    public PersistentDeviceData(string newid, string newDeviceName, string newPrefabType)
    {
        deviceName = newDeviceName;
        id = newid;
        prefabType = newPrefabType;
    }

    public int CompareTo(PersistentDeviceData other)
    {
        if (other == null)
        {
            return 1;
        }
        return sortID - other.sortID;
    }
}
