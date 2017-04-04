using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Skill1Button : MonoBehaviour ,IPointerClickHandler{

    /// <summary>
    /// Test용
    /// </summary>
    public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void OnPointerClick(PointerEventData eventData)
    {
        player.ChangeState(PlayerFSMSkill1.Instance);
    }

}
