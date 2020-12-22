using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if PLATFORM_LUMIN
using UnityEngine.XR.MagicLeap.Native;
#endif
using UnityEngine.XR.MagicLeap;


public class PersistentDeviceData : IComparable<PersistentDeviceData>
{

    public string deviceName;
    public string CFUID;
    public string otherInputs;

    public int CFUID2;

    //need to save transform info too.

    public PersistentDeviceData(string newDeviceName, string newCFUID, string newOtherInputs)
    {
        deviceName = newDeviceName;
        CFUID = newCFUID;
        otherInputs = newOtherInputs;
    }

    public int CompareTo(PersistentDeviceData other)
    {
        if (other == null)
        {
            return 1;
        }
        return CFUID2 - other.CFUID2;
    }
}
