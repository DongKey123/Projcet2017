using UnityEngine;
using System.Collections;
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
    private string _url = "localhost:8090";

    public Avatar m_Avatar;
    public RemoteAvatar m_RemoteAvatar;
    public bool m_IsAliveServer = true;

    [HideInInspector]
    public Vector3 m_RUserMoveVector;
    [HideInInspector]
    public Vector3 m_REnemyMoveVector;


    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Init();
    }

    void Init()
    {

    }

	// Use this for initialization
	void Start () {
        StartCoroutine(ConnectServer());
	}
	
	// Update is called once per frame
	void Update () {
	    if(_userSocket.IsAlive && _enemySocket.IsAlive && _chatSocket.IsAlive)
        {
            Debug.Log("Alive Server");
            m_IsAliveServer = true;
        }
        else
        {
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

    IEnumerator ConnectServer()
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

        yield return null;
    }


    void ReceiveMessageUserMoveServer(object sender, MessageEventArgs e)
    {
        JSONObject json = new JSONObject(e.Data);
        JSONObject UserData = new JSONObject(json.GetField("Users").ToString());
        for (int i = 0; i < UserData.Count; i++)
        {
            string name = UserData[i].GetField("UserName").str;
            float x = float.Parse(UserData[i].GetField("X").ToString());
            float y = float.Parse(UserData[i].GetField("Y").ToString());
            float z = float.Parse(UserData[i].GetField("Z").ToString());
            bool controling = bool.Parse(UserData[i].GetField("Dir").ToString());
            JSONObject jsonDir = new JSONObject(UserData[i].GetField("DirVector").ToString());
            //Debug.Log(jsonDir.GetField("x").ToString());
            //Debug.Log(jsonDir);
            if (name == "Control1")
            {
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

    }

}


