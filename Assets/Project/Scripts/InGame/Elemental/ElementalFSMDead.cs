using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalFSMDead : FSM_State<Elemental> {

    // Use this for initialization
    static readonly ElementalFSMDead instance = new ElementalFSMDead();

    public static ElementalFSMDead Instance
    {
        get
        {
            return instance;
        }
    }

    static ElementalFSMDead() { }
    private ElementalFSMDead() { }

    public override void EnterState(Elemental owner)
    {
        owner.m_UnitAct = ElementalACT.DEATH;
        owner.m_Animator.Play("Die");
        owner.GetComponent<Collider>().enabled = false;
        owner.GetComponent<Rigidbody>().useGravity = false;
        GameObject.Destroy(owner.gameObject, 1.5f);
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
