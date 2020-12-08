using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TCPTestClient : MonoBehaviour {  	
	#region private members 	
	private TcpClient socketConnection; 	
	private Thread clientReceiveThread;
    #endregion

    #region public members
    public Button m_AppleTVMenu_Button, m_AppleTVHome_Button, m_AppleTVUp_Button, m_AppleTVDown_Button, m_AppleTVLeft_Button,
                  m_AppleTVRight_Button, m_AppleTVSelect_Button, m_AppleTVBackSkip_Button, m_AppleTVRewind_Button, m_AppleTVPlayPause_Button,
                  m_AppleTVFFWD_Button, m_AppleTVForwardSkip_Button;

    public Slider m_AppleTVPlayTime_Slider;
    #endregion

    // Use this for initialization 	
    void Start () {
		ConnectToTcpServer();
        m_AppleTVMenu_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Menu_Press"); });
        m_AppleTVHome_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Home_Press"); });
        m_AppleTVUp_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Up_Press"); });
        m_AppleTVDown_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Down_Press"); });
        m_AppleTVLeft_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Left_Press"); });
        m_AppleTVRight_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Right_Press"); });
        m_AppleTVSelect_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Select_Press"); });
        m_AppleTVBackSkip_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_BackSkip_Press"); });
        m_AppleTVRewind_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_Rewind_Press"); });
        m_AppleTVPlayPause_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_PlayPause_Press"); });
        m_AppleTVFFWD_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_FFWD_Press"); });
        m_AppleTVForwardSkip_Button.onClick.AddListener(delegate { TaskWithParameters("AppleTV_ForwardSkip_Press"); });

        //If I use onValueChanged, will this send every damn time the value is updated? for playtime that doesnt work. 
        //Maybe I should have a virtual bar for the progress? and update the real one when I press...?
        m_AppleTVPlayTime_Slider.onValueChanged.AddListener(delegate { SliderTask("AppleTV_PlayTime_Change", m_AppleTVPlayTime_Slider.value); });
        //m_AppleTVPlayTime_Slider.

        //m_AppleTVUp_Button.onClick.AddListener(() => ButtonClicked(42));
    }
    // Update is called once per frame
    void Update () {         
		if (Input.GetKeyDown(KeyCode.Space)) {             
			SendMessage();         
		}

        if (Input.GetKeyDown(KeyCode.G))
        {
            SendMessage2();
        }
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


    private void ConnectToTcpServer () {
        Debug.Log(" Inside ConnectToTcpServer");

        try {  			
			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  		
		} 		
		catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		} 	
	}  	
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData() {
        Debug.Log(" Inside ListenForData");

        try
        { 			
            //IP Address of the crestron processer.
			socketConnection = new TcpClient("192.168.1.10", 60000);    //was localhost		
            Byte[] bytes = new Byte[1024];             
			while (true) { 				
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream()) { 					
					int length; 					
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
						var incommingData = new byte[length]; 						
						Array.Copy(bytes, 0, incommingData, 0, length); 						
						// Convert byte array to string message. 						
						string serverMessage = Encoding.ASCII.GetString(incommingData); 						
						Debug.Log("server message received as: " + serverMessage); 					
					} 				
				} 			
			}         
		}         
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}  	
	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	private void SendMessage() {
        Debug.Log(" Inside SendMessage");

        if (socketConnection == null) {
            Debug.Log(" socketConnection == null");
            return;
        }
        try { 			
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream(); 			
			if (stream.CanWrite) {                 
				string clientMessage = "This is a message from one of your clients."; 				
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                 
				Debug.Log("Client sent his message - should be received by server");             
			}         
		} 		
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}

    private void SendMessage2()
    {
        Debug.Log(" Inside SendMessage2");

        if (socketConnection == null)
        {
            Debug.Log(" socketConnection == null");
            return;
        }
        try
        {
            // Get a stream object for writing.             
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "Client Pressed G";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent message G - should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
}