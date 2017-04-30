using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Skill1Button : MonoBehaviour ,IPointerClickHandler{


    public Avatar m_Avatar;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void OnPointerClick(PointerEventData eventData)
    {
        m_Avatar.ChangeState(AvatarFSMSkill.Instance);
    }

}
