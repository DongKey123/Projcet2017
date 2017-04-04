using UnityEngine;
using System.Collections;

public class UnitAttack : MonoBehaviour
{

    private UnitBase _owner;

    // Use this for initialization
    void Start()
    {
        _owner = this.GetComponentInParent<UnitBase>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Unit")
        {
            if(other.GetComponent<UnitBase>().m_UnitAct != UNITACT.DEATH)
            {
                _owner.ChangeState(UnitFSMAttack.Instance);
                other.GetComponent<UnitBase>().GetDamage(_owner.m_AttackPower);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Unit")
        {
            if(_owner.m_UnitAct == UNITACT.MOVE)
            {
                _owner.ChangeState(UnitFSMAttack.Instance);
                other.GetComponent<UnitBase>().GetDamage(_owner.m_AttackPower);
            }
        }
    }
}
