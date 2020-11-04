using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
public class HelloWorld : MonoBehaviour
{
    public static PubNub pubnub;
    private float sendTimeController;
    // Use this for initialization
    void Start()
    {
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-270dafe4-6c23-47e4-b9eb-62d9590a9846";
        pnConfiguration.SubscribeKey = "sub-c-2e822568-1d76-11eb-8a07-eaf684f78515";
        pnConfiguration.Secure = true;
        pubnub = new PubNub(pnConfiguration);
    }

    // Update is called once per frame
    void Update()
    {
        if (sendTimeController <= Time.deltaTime)
        { // Restrict how quickly messages are sent.
            pubnub.Publish()
                      .Channel("MagicLeap")
                      .Message("HelloWorld")
                      .Async((result, status) => {
                          if (!status.Error)
                          {
                              Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                          }
                          else
                          {
                              Debug.Log(status.Error);
                              Debug.Log(status.ErrorData.Info);
                          }
                      });
            sendTimeController = 1.0f; // Restrict how quickly messages are sent.
        }
        else
        {
            sendTimeController -= Time.deltaTime; // Update the timer.
        }
    }
}