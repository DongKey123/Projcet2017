using UnityEngine;
using System.Collections;

public class UnitFSMAttack : FSM_State<UnitBase>
{

    static readonly UnitFSMAttack instance = new UnitFSMAttack();

    public static UnitFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }
    static UnitFSMAttack() { }
    private UnitFSMAttack() { }

    public override void EnterState(UnitBase owner)
    {
        owner.m_UnitAct = UNITACT.ATTACK;
        owner.GetComponent<Animator>().Play("Attack");
    }

    public override void UpdateState(UnitBase owner)
    {
    }

    public override void FixedUpdateState(UnitBase owner)
    {
    }

    public override void ExitState(UnitBase owner)
    {
    }
}
