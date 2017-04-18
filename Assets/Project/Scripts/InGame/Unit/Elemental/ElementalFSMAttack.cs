using UnityEngine;
using System.Collections;

public class ElementalFSMAttack : FSM_State<Elemental>
{

    static readonly ElementalFSMAttack instance = new ElementalFSMAttack();

    public static ElementalFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }

    static ElementalFSMAttack() { }
    private ElementalFSMAttack() { }

    public override void EnterState(Elemental owner)
    {
        owner.m_UnitAct = UNITACT.MOVE;
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
