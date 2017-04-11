using UnityEngine;
using System.Collections;

public class ElementalFSMMove : FSM_State<Elemental> {

    static readonly ElementalFSMMove instance = new ElementalFSMMove();

    public static ElementalFSMMove Instance
    {
        get
        {
            return instance;
        }
    }

    static ElementalFSMMove() { }
    private ElementalFSMMove() { }

    public override void EnterState(Elemental owner)
    {
        owner.m_UnitAct = UNITACT.MOVE;
    }

    public override void UpdateState(Elemental owner)
    {
        owner.transform.position += Vector3.right * owner.m_moveSpeed * Time.deltaTime;
        owner.transform.LookAt(owner.transform.position+Vector3.right);
    }

    public override void FixedUpdateState(Elemental owner)
    {

    }

    public override void ExitState(Elemental owner)
    {

    }
}
