using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalFSMIdle : FSM_State<Elemental> {

    static readonly ElementalFSMIdle instance = new ElementalFSMIdle();

    public static ElementalFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }

    static ElementalFSMIdle() { }
    private ElementalFSMIdle() { }

    public override void EnterState(Elemental owner)
    {
        owner.m_UnitAct = ElementalACT.IDLE;
        owner.m_Animator.Play("Move");
    }

    public override void UpdateState(Elemental owner)
    {
        
    }

    public override void FixedUpdateState(Elemental owner)
    {

    }

    public override void ExitState(Elemental owner)
    {

    }
}
