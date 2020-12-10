using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CrestronTCPClient_AVData : MonoBehaviour
{
    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    #endregion

    #region public members
    public Button m_AVOn_Button, m_AVOff_Button, m_PowerToggle_Button, m_AppleTVSource_Button, m_PS4Source_Button,
                  m_VolumeUp_Button, m_VolumeDown_Button, m_MuteToggle_Button;

    public Slider m_ReceiverVolume_Slider;

    public bool m_TVPowerOn;
    public bool m_ReceiverPowerOn;


    #endregion

    // Use this for initialization 	
    void Start()
    {
        ConnectToTcpServer();
        m_AVOn_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_Power_On_Press"); });
        m_AVOff_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_Power_Off_Press"); });
        m_PowerToggle_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_Power_Toggle_Press"); });
        m_AppleTVSource_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_AppleTV_Source_Press"); });
        m_PS4Source_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_PS4_Source_Press"); });
        m_VolumeUp_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_Volume_Up_Press"); });
        m_VolumeDown_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_Volume_Down_Press"); });
        m_MuteToggle_Button.onClick.AddListener(delegate { TaskWithParameters("LoftAV_MuteToggle_Press"); });


        //Need to figure out the crestron string parsing shit.
        m_ReceiverVolume_Slider.onValueChanged.AddListener(delegate { SliderTask("LoftAV_Volume_Change", m_ReceiverVolume_Slider.value); });

    }
    // Update is called once per frame
    void Update()
    {
    }
    /// <summary> 	
    /// Setup socket connection. 	
    /// </summary> 	

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);

        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing.             
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                //string clientMessage = "Client Pressed G";
                string clientMessage = message;
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent message" + message + " should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }


    void SliderTask(string message, float value)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message + "@" + value);

        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing.             
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                //string clientMessage = "Client Pressed G";
                string clientMessage = message + "@" + value;
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent message" + clientMessage + " should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }


    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }


    private void ConnectToTcpServer()
    {
        Debug.Log(" Inside ConnectToTcpServer");

        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    /// <summary> 	
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    /// </summary>     
    private void ListenForData()
    {
        Debug.Log(" Inside ListenForData");

        try
        {
            //IP Address of the crestron processer.
            socketConnection = new TcpClient("192.168.1.10", 50001);    //was localhost		
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("server message received as: " + serverMessage);
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
   
}