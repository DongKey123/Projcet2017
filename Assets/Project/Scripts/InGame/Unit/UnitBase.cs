using UnityEngine;
using System.Collections;

public enum UNITACT
{
    MOVE,
    ATTACK,
    DEATH
}

public class UnitBase : MonoBehaviour {

    public UNITACT m_UnitAct = UNITACT.MOVE;

    public float m_Hp = 100.0f;
    public float m_Speed = 3.0f;
    public float m_AttackPower = 10.0f;

    protected StateMachine<UnitBase> stateMachine = null;

    void Awake()
    {
        stateMachine = new StateMachine<UnitBase>();
        stateMachine.Initial_Setting(this, UnitFSMMove.Instance);
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void GetDamage(float Damage)
    {
        this.m_Hp -= Damage;
        if(m_Hp <= 0)
        {
            ChangeState(UnitFSMDeath.Instance);
        }
    }

    public void ChangeState(FSM_State<UnitBase> _State)
    {
        stateMachine.ChangeState(_State);
    }

    // 이전 상태로 회귀
    public void StateRevert()
    {
        stateMachine.StateRevert();
    }
}
