using UnityEngine;
using System.Collections;
using WebSocketSharp;
using System.Collections.Generic;
using System.Text;


public class RemoteAvatar : MonoBehaviour {

    public AvatarAct m_Act;
    protected StateMachine<RemoteAvatar> stateMachine = null;

    WebSocket _Socket;
    private string _url = "localhost:8090";
    [HideInInspector]
    public Vector3 m_LookVec;
    private float _lastRecTime = 0;
    private float _RecTime = 0;
    [HideInInspector]
    public float _DelayTime = 0;

    [HideInInspector]
    public Vector3 _prevRecVec = Vector3.zero;
    [HideInInspector]
    public Vector3 _RecVec = Vector3.zero;
    [HideInInspector]
    public bool _timeCk = false;

    [HideInInspector]
    public bool m_IsControlling = false;

    // Use this for initialization
    void Start () {
        stateMachine = new StateMachine<RemoteAvatar>();
        stateMachine.Initial_Setting(this, RemoteAvatarFSMIdle.Instance);

        StartCoroutine(ConnectServer());
        
    }
	
	// Update is called once per frame
	void Update () {


        if (_Socket.IsAlive)
        {
            //딜레이 체크
            _lastRecTime += Time.deltaTime;
            if (_timeCk)
            {
                this.transform.position = _RecVec;
                _DelayTime = _lastRecTime - _RecTime;
                _timeCk = false;
            }

            stateMachine.Update();

            

            //스테이트 변환 
            if(_prevRecVec != _RecVec)
            {
                //Debug.Log("Idle");
                transform.position += (_RecVec - _prevRecVec) * _DelayTime;
                transform.rotation = Quaternion.LookRotation((_RecVec - _prevRecVec));
            }
            else
            {
                //Debug.Log("Idle");
                this.transform.position = _RecVec;
            }
        }
        else
        {
            Debug.Log("Not Connect Server");
        }
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    

    public void ChangeState(FSM_State<RemoteAvatar> _State)
    {
        stateMachine.ChangeState(_State);
    }

    // 이전 상태로 회귀
    public void StateRevert()
    {
        stateMachine.StateRevert();
    }



    /// <summary>
    /// 서버 관련
    /// </summary>
    /// <returns></returns>
    IEnumerator ConnectServer()
    {
        _Socket = new WebSocket("ws://" + _url + "/enemy/move");
        _Socket.OnMessage += ReceiveMessage;
        _Socket.Connect();
        yield return null;
    }

    void ReceiveMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
        JSONObject json = new JSONObject(e.Data);
        JSONObject UserData = new JSONObject(json.GetField("Users").ToString());
        for (int i = 0; i < UserData.Count; i++)
        {
            string name = UserData[i].GetField("UserName").str;
            float x = float.Parse(UserData[i].GetField("x").ToString());
            float y = float.Parse(UserData[i].GetField("y").ToString());
            float z = float.Parse(UserData[i].GetField("z").ToString());
            bool controling = bool.Parse(UserData[i].GetField("dir").ToString());
            if (name == "Control2")
            {
                _prevRecVec = _RecVec;
                _RecVec = new Vector3(x, 0, z);
                _timeCk = true;
                m_IsControlling = controling;

                _lastRecTime = 0;
                _RecTime = 0;
            }
        }
    }
}
