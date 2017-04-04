using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AttackAnimation : MonoBehaviour , IPointerClickHandler{

    public PlayerSkill skill;

    public void OnPointerClick(PointerEventData eventData)
    {
        skill.PlayAnimation(PlayerAct.ATTACK);
    }
}
