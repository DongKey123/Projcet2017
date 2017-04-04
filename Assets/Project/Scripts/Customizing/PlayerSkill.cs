using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {

    public PlayerAct act;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	public void PlayAnimation(PlayerAct skill)
    {
        switch(skill)
        {
            case PlayerAct.IDLE:
                {
                    anim.Play("Idle");
                }
                break;
            case PlayerAct.WALK:
                {
                    anim.Play("Walk");
                }
                break;
            case PlayerAct.ATTACK:
                {
                    anim.Play("Attack");
                }
                break;
        }
    }
}
