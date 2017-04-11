using UnityEngine;
using System.Collections;

public enum ElementalACT
{
    MOVE,
    ATTACK,
    DEATH
};

public class Elemental : MonoBehaviour {

    public UNITACT m_UnitAct = UNITACT.MOVE;

    public int m_Level = 1;
    public float m_curHp;
    public float m_maxHp;
    public float m_moveSpeed = 2.5f;

    protected StateMachine<Elemental> stateMachine = null;

	// Use this for initialization
	void Start () {
        stateMachine = new StateMachine<Elemental>();
        stateMachine.Initial_Setting(this, ElementalFSMMove.Instance);
        //StartCoroutine(SendPosition());
	}
	
	// Update is called once per frame
	void Update () {
        stateMachine.Update();
	}

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void ChangeState(FSM_State<Elemental> _State)
    {
        stateMachine.ChangeState(_State);
    }

    // 이전 상태로 회귀
    public void StateRevert()
    {
        stateMachine.StateRevert();
    }

    IEnumerator SendPosition()
    {
        //NetManager nm = NetManager.GetInstance();
        //while (true)
        //{
        //    if (!nm.m_IsAliveServer)
        //        yield return null;

        //    //Debug.Log("Send");

        //    JSONObject json = new JSONObject();
        //    JSONObject DirVec = new JSONObject();
        //    DirVec.AddField("X", this.m_LookVec.x);
        //    DirVec.AddField("Y", this.m_LookVec.y);
        //    DirVec.AddField("Z", this.m_LookVec.z);

        //    json.AddField("UserName", "Control2");
        //    json.AddField("X", this.transform.position.x);
        //    json.AddField("Y", this.transform.position.y);
        //    json.AddField("Z", this.transform.position.z);
        //    json.AddField("Dir", m_IsControling);
        //    json.AddField("DirVector", DirVec);

        //    //Debug.Log(json.ToString());
        //    nm.SendMessage(SockeType.USERMOVE, json.ToString());
            yield return new WaitForSeconds(0.1f);
        
    }
}
