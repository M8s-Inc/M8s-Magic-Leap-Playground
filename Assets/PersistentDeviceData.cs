using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
