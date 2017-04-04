using UnityEngine;
using System.Collections;

public class UnitFSMDeath : FSM_State<UnitBase>
{
    static readonly UnitFSMDeath instance = new UnitFSMDeath();

    public static UnitFSMDeath Instance
    {
        get
        {
            return instance;
        }
    }
    static UnitFSMDeath() { }
    private UnitFSMDeath() { }

    public override void EnterState(UnitBase owner)
    {
        owner.m_UnitAct = UNITACT.DEATH;
        owner.GetComponent<Animator>().Play("Death");
        owner.GetComponent<Collider>().enabled = false;
        owner.GetComponent<Rigidbody>().useGravity = false;
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
