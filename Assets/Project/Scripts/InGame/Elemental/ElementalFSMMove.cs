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
        owner.m_UnitAct = ElementalACT.MOVE;
    }

    public override void UpdateState(Elemental owner)
    {
        owner.transform.position += owner.transform.forward * owner.m_moveSpeed * Time.deltaTime;
        RaycastHit hit;
        if(Physics.Raycast(owner.transform.position, owner.transform.position + owner.transform.forward, out hit,1f))
        {
            Debug.Log("Attack Elemental!!!");
            //if(hit.transform.tag =="Avatar")
            //{
            //    owner.ChangeState(ElementalFSMAttack.Instance);
            //}
        }
    }

    public override void FixedUpdateState(Elemental owner)
    {

    }

    public override void ExitState(Elemental owner)
    {

    }
}
