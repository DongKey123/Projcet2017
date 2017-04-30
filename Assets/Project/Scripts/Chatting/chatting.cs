using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine.UI;

public class chatting : MonoBehaviour {

    WebSocket m_socket;
    private string _url = "13.124.98.25:8090";
    List<string> messagesBox;

    public Text[] m_Message;
    public Text m_InputFieldTxt;

    // Use this for initialization
    void Start () {
        messagesBox = new List<string>();
        StartCoroutine(ConnectServer());
    }
	
	// Update is called once per frame
	void Update () {
	    if(m_socket.IsAlive)
        {
            Debug.Log("Conneting");
            if(messagesBox.Count > 0)
            {
                Debug.Log(messagesBox.Count);
                for(int i =1;i< m_Message.Length; i++)
                {
                    m_Message[m_Message.Length-i].text = m_Message[m_Message.Length - i - 1].text;
                }
                m_Message[0].text = messagesBox[0];
                messagesBox.RemoveAt(0);
            }
        }
        else
        {
            Debug.Log("Not Connect Server");
            //StartCoroutine(ConnectServer());
        }
	}

    public void SendMessageToServer()
    {
        m_socket.Send(m_InputFieldTxt.text);
        m_InputFieldTxt.text = "";
    }

    void ReceiveMessage(object sender, MessageEventArgs e)
    {
        messagesBox.Add(e.Data);
    }

    IEnumerator ConnectServer()
    {
        m_socket = new WebSocket("ws://" + _url + "/echo");
        m_socket.OnMessage += ReceiveMessage;
        m_socket.Connect();
        yield return null;
    }

    
}
