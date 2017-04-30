using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using WebSocketSharp;

public enum SockeType
{
    USERMOVE,
    ENEMYMOVE,
    CHAT
};

public class NetManager : MonoBehaviour {

    #region Instance
    private static NetManager _instance;

    public static NetManager GetInstance()
    {
        return _instance;
    }
    #endregion
    WebSocket _userSocket;
    WebSocket _enemySocket;
    WebSocket _chatSocket;
    private string _url = "13.124.98.25:8090";
    private string _localurl = "localhost:8090";

    public Avatar m_Avatar;
    public RemoteAvatar m_RemoteAvatar;
    public bool m_IsAliveServer = true;

    [HideInInspector]
    public Vector3 m_RUserMoveVector;
    [HideInInspector]
    public Vector3 m_REnemyMoveVector;

    public string m_userName;

    List<string> messagesBox;

    public Text[] m_Message;
    public Text m_InputFieldTxt;

    public Text AliveCk;

    public string m_Cookie;


    void Awake()
    {
        _instance = this;
        //if(_instance == null)
        //{
        //    _instance = this;
        //}
        //else if(_instance != this)
        //{
        //    Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);

        //Init();
    }

    void Init()
    {

    }

	// Use this for initialization
	void Start () {
        messagesBox = new List<string>();
        //StartCoroutine(ConnectServer());

        ConnectServer();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (IsAlivedServer())
        {

            if(AliveCk != null)
                AliveCk.text = "Alive";
            
            m_IsAliveServer = true;

            //채팅
            if (messagesBox.Count > 0)
            {
                if (m_InputFieldTxt == null || m_Message == null)
                    return;

                for (int i = 1; i < m_Message.Length; i++)
                {
                    m_Message[m_Message.Length - i].text = m_Message[m_Message.Length - i - 1].text;
                }
                m_Message[0].text = messagesBox[0];
                messagesBox.RemoveAt(0);
            }

        }
        else
        {

            if (AliveCk != null )
                AliveCk.text = "Dead";

            Debug.Log("Dead SERVER");

            //ConnectServer();
            m_IsAliveServer = false;
        }
	}

    public void SendMessage(SockeType type,string Message)
    {

        switch(type)
        {
            case SockeType.USERMOVE:
                {
                    _userSocket.Send(Message);
                }
                break;
            case SockeType.ENEMYMOVE:
                {
                    _enemySocket.Send(Message);
                }
                break;
            case SockeType.CHAT:
                {
                    _chatSocket.Send(Message);
                }
                break;
        }
    }

    public void ConnectServer()
    {
        _userSocket = new WebSocket("ws://" + _url + "/user/move");
        _userSocket.OnMessage += ReceiveMessageUserMoveServer;
        _userSocket.Connect();

        _enemySocket = new WebSocket("ws://" + _url + "/enemy/move");
        _enemySocket.OnMessage += ReceiveMessageEnemyMoveServer;
        _enemySocket.Connect();

        _chatSocket = new WebSocket("ws://" + _url + "/echo");
        _chatSocket.OnMessage += ReceiveMessageChatServer;
        _chatSocket.Connect();
    }


    void ReceiveMessageUserMoveServer(object sender, MessageEventArgs e)
    {
        if (m_RemoteAvatar == null )
            return;

        Debug.Log(e.Data);

        JSONObject json = new JSONObject(e.Data);
        if (json.GetField("Users") == null )
        {
            Debug.Log("NUll");
            return;
        }

        JSONObject UserData = new JSONObject(json.GetField("Users").ToString());
        for (int i = 0; i < UserData.Count; i++)
        {
            string name = UserData[i].GetField("UserName").str;
            float x = float.Parse(UserData[i].GetField("X").ToString());
            float y = float.Parse(UserData[i].GetField("Y").ToString());
            float z = float.Parse(UserData[i].GetField("Z").ToString());

            //float damage = float.Parse(UserData[i].GetField("HP").ToString());

            bool controling = bool.Parse(UserData[i].GetField("Dir").ToString());
            JSONObject jsonDir = new JSONObject(UserData[i].GetField("DirVector").ToString());

            if (name == "test1")
            {

                //m_RemoteAvatar.m_curHp -= damage;

                m_RemoteAvatar.m_LookVec.x = float.Parse(jsonDir.GetField("X").ToString());
                m_RemoteAvatar.m_LookVec.y = float.Parse(jsonDir.GetField("Y").ToString());
                m_RemoteAvatar.m_LookVec.z = float.Parse(jsonDir.GetField("Z").ToString());
                m_RemoteAvatar.m_IsControlling = controling;
                //전에 받은 Vector3 저장
                m_RemoteAvatar._prevRecVec = m_RUserMoveVector;
                //현재 벡터 저장
                m_RUserMoveVector = new Vector3(x, y, z);
                m_RemoteAvatar._RecVec = m_RUserMoveVector;
                
                m_RemoteAvatar._timeCk = true;

                //m_RemoteAvatar._lastRecTime = 0;
                //m_RemoteAvatar._RecTime = 0;
            }
        }
    }

    void ReceiveMessageEnemyMoveServer(object sender, MessageEventArgs e)
    {

    }

    void ReceiveMessageChatServer(object sender, MessageEventArgs e)
    {
        messagesBox.Add(e.Data);
    }

    public void SendChattingMessage()
    {
        Debug.Log("Send Chatting Message");
        _chatSocket.Send(m_InputFieldTxt.text);
        m_InputFieldTxt.text = " ";
        Debug.Log(m_InputFieldTxt.text);
        //m_InputFieldTxt.GetComponent<InputField>().
    }


    public bool IsAlivedServer()
    {
        return (_userSocket.ReadyState == WebSocketState.Open && _enemySocket.ReadyState == WebSocketState.Open && _chatSocket.ReadyState == WebSocketState.Open);

    }
}


