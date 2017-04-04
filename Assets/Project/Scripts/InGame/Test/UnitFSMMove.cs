using UnityEngine;
using System.Collections;

public class UnitFSMMove : FSM_State<UnitBase> {

    static readonly UnitFSMMove instance = new UnitFSMMove();

    public static UnitFSMMove Instance
    {
        get
        {
            return instance;
        }
    }
    static UnitFSMMove() { }
    private UnitFSMMove() { }

    public override void EnterState(UnitBase owner)
    {
        owner.m_UnitAct = UNITACT.MOVE;
    }

    public override void UpdateState(UnitBase owner)
    {
        owner.transform.position += owner.transform.forward * owner.m_Speed * Time.deltaTime;
    }

    public override void FixedUpdateState(UnitBase owner)
    {
        
    }

    public override void ExitState(UnitBase owner)
    {
        
    }
}
