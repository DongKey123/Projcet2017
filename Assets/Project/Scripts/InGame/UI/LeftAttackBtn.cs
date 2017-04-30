using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftAttackBtn : MonoBehaviour , IPointerClickHandler {

    public Avatar m_Avatar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        m_Avatar.ChangeState(AvatarFSMAttackL.Instance);
    }
}
