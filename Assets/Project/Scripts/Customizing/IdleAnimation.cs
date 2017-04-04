using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class IdleAnimation : MonoBehaviour , IPointerClickHandler{

    public PlayerSkill skill;

    public void OnPointerClick(PointerEventData eventData)
    {
        skill.PlayAnimation(PlayerAct.IDLE);
    }
}
