using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAttackCollider : MonoBehaviour {

    private Avatar avatar;


	// Use this for initialization
	void Start () {
        avatar = this.GetComponentInParent<Avatar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Elenemtal")
        {

        }
    }
}
