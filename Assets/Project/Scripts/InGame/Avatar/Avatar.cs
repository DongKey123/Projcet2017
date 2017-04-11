using UnityEngine;
using System.Collections;
using WebSocketSharp;

public enum AvatarAct
{
    IDLE,
    ATTACK,
    MOVE,
    DEATH
};

public class Avatar : MonoBehaviour {

    WebSocket _Socket;
    private string _url = "localhost:8090";
    [HideInInspector]
    public bool m_IsControling = false;

    public AvatarAct m_Act;
    public JoyStick m_Joystick; //Prefab에서 들고온 조이스틱 게임오브젝트

    [HideInInspector]
    public Vector3 m_LookVec;

    //유닛의 파라미터
    public int m_maxHp;                     //최대 체력
    public int m_curHp;                     //현재 체력
    public int m_maxMp;                     //최대 마나
    public int m_curMp;                     //현재 마나
    public float m_AttackPower;             //공격력
    public float m_RecoveryPower;           //회복력
    public int m_ArmorIgnore;               //방어력무시
    public float m_ArmorPenetration;        //방관
    public int m_CriticalChance;            //치명타확률
    public float m_CriticalDamage;          //치명타 위력
    public float m_LifeSteal;               //피흡
    public float m_Armor;                   //방어력
    public float m_MovementSpeed;           //이동속도
    

    protected StateMachine<Avatar> stateMachine = null;

    // Use this for initialization
    void Start () {
        stateMachine = new StateMachine<Avatar>();
        stateMachine.Initial_Setting(this,AvatarFSMIdle.Instance);
        StartCoroutine(SendPosition());
    }
	
	// Update is called once per frame
	void Update () {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void ChangeState(FSM_State<Avatar> _State)
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
        NetManager nm = NetManager.GetInstance();
        while (true)
        {
            if (!nm.m_IsAliveServer)
                yield return null;

            //Debug.Log("Send");

            JSONObject json = new JSONObject();
            JSONObject DirVec = new JSONObject();
            DirVec.AddField("X", this.m_LookVec.x);
            DirVec.AddField("Y", this.m_LookVec.y);
            DirVec.AddField("Z", this.m_LookVec.z);

            json.AddField("UserName", "Control2");
            json.AddField("X", this.transform.position.x);
            json.AddField("Y", this.transform.position.y);
            json.AddField("Z", this.transform.position.z);
            json.AddField("Dir", m_IsControling);
            json.AddField("DirVector",DirVec);

            //Debug.Log(json.ToString());
            nm.SendMessage(SockeType.USERMOVE, json.ToString());
            yield return new WaitForSeconds(0.1f);
        }
    }
}
