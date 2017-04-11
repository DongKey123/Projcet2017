using UnityEngine;
using System.Collections;

public class PlayerFSMSkill1 : FSM_State<Player> {

    static readonly PlayerFSMSkill1 instance = new PlayerFSMSkill1();
    public static PlayerFSMSkill1 Instance
    {
        get
        {
            return instance;
        }
    }

    static PlayerFSMSkill1() { }
    private PlayerFSMSkill1() { }

    Animator anim;
    bool Check = true;

    public override void EnterState(Player owner)
    {
        anim = owner.GetComponent<Animator>();
        owner.m_Act = PlayerAct.SKILL1;
        anim.Play("Skill1");

        
    }

    public override void UpdateState(Player owner)
    {
        JoyStick stick = owner.m_Joystick;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Skill1"))
        {
            if(stateInfo.normalizedTime >= 0.45f && Check)
            {
                Check = false;
                owner.Skill1();
            }

            if (stateInfo.normalizedTime >= 0.99f)
            {
                if (stick.GetHorizontalValue() != 0 || stick.GetVerticalValue() != 0)
                {
                    owner.ChangeState(PlayerFSMWalk.Instance);
                }
                else
                {
                    owner.ChangeState(PlayerFSMIdle.Instance);
                }
            }
        }


        
    }

    public override void FixedUpdateState(Player owner)
    {
    }

    public override void ExitState(Player owner)
    {
        Check = true;
    }
}
