using UnityEngine;
using System.Collections;

public class UnitSwordCollider : MonoBehaviour {

    private UnitBase _owner;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _owner = this.GetComponentInParent<UnitBase>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sword Collider");
        if (other.transform.tag == "Unit")
        {
            if (_owner != other)
            {
                other.GetComponent<UnitBase>().GetDamage(_owner.m_AttackPower);
            }
        }
    }
}
