using UnityEngine;
using System.Collections;

public enum PlayerAct
{
    IDLE,
    ATTACK,
    WALK,
    SKILL1,
    DEATH
}

public class Player : MonoBehaviour {

    public PlayerAct m_Act;
    public JoyStick m_Joystick;
    public float m_walkSpeed = 3.0f;
    public GameObject m_pfFire;
    public float m_Skill1Distance = 5.0f;

    protected StateMachine<Player> stateMachine = null;


    // Use this for initialization
    void Start () {
        stateMachine = new StateMachine<Player>();
        stateMachine.Initial_Setting(this,PlayerFSMIdle.Instance);
	}
	
	// Update is called once per frame
	void Update () {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void ChangeState(FSM_State<Player> _State)
    {
        stateMachine.ChangeState(_State);
    }

    // 이전 상태로 회귀
    public void StateRevert()
    {
        stateMachine.StateRevert();
    }

    public void Skill1()
    {
        float h = m_Joystick.GetHorizontalValue();
        float v = m_Joystick.GetVerticalValue();

        Vector3 firePos = this.transform.position + (this.transform.forward * m_Skill1Distance);
        Debug.Log((new Vector3(h, 0, v).normalized * m_Skill1Distance));
        Debug.Log(firePos);

        Instantiate(m_pfFire, firePos,Quaternion.identity);
    }
}
