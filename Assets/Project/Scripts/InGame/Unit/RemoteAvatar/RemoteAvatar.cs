using UnityEngine;
using System.Collections;
using WebSocketSharp;
using System.Collections.Generic;
using System.Text;


public class RemoteAvatar : MonoBehaviour {

    public AvatarAct m_Act;
    protected StateMachine<RemoteAvatar> stateMachine = null;

    /// <summary>
    /// Status
    /// </summary>
    public float m_curHp;
    public float m_maxHp;

    //----------------------------------------------------------//

    [HideInInspector]
    public Vector3 m_LookVec;
    [HideInInspector]
    public float _lastRecTime = 0;
    [HideInInspector]
    public float _RecTime = 0;
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
    [HideInInspector]
    public float curLerp = 0.0f;

    //----------------------------------------------------------//

    // Use this for initialization
    void Start () {
        stateMachine = new StateMachine<RemoteAvatar>();
        stateMachine.Initial_Setting(this, RemoteAvatarFSMIdle.Instance);     
    }
	
	// Update is called once per frame
	void Update () {


        if (NetManager.GetInstance().m_IsAliveServer)
        {

            stateMachine.Update();

            //딜레이 체크
            curLerp += _DelayTime;
            _lastRecTime += Time.deltaTime;
            if (_timeCk)
            {
                curLerp = 0.0f;
                //this.transform.position = _RecVec;
                _DelayTime = _lastRecTime - _RecTime;
                
                _RecTime = 0;
                _lastRecTime = 0;
                _timeCk = false;
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

}
