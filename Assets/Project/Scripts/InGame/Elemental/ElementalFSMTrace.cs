using UnityEngine;
using System.Collections;

public class ElementalFSMTrace : FSM_State<Elemental> {

    static readonly ElementalFSMTrace instance = new ElementalFSMTrace();

    public static ElementalFSMTrace Instance
    {
        get
        {
            return instance;
        }
    }

    static ElementalFSMTrace() { }
    private ElementalFSMTrace() { }

    public override void EnterState(Elemental owner)
    {
        owner.m_UnitAct = ElementalACT.MOVE;
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
