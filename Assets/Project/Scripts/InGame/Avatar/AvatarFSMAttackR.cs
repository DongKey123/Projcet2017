using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFSMAttackR : FSM_State<Avatar> {

    static readonly AvatarFSMAttackR instance = new AvatarFSMAttackR();

    public static AvatarFSMAttackR Instance
    {
        get
        {
            return instance;
        }
    }

    static AvatarFSMAttackR() { }
    private AvatarFSMAttackR() { }

    private Animator anim;

    public override void EnterState(Avatar owner)
    {
        owner.m_IsControling = false;
        owner.m_Act = AvatarAct.ATTACK_R;
        anim = owner.GetComponent<Animator>();
        owner.GetComponent<Animator>().Play("RightAttack");
    }

    public override void UpdateState(Avatar owner)
    {
        JoyStick stick = owner.m_Joystick;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("RightAttack"))
        {
            if (stateInfo.normalizedTime >= 0.99f)
            {
                if (stick.GetHorizontalValue() != 0 || stick.GetVerticalValue() != 0)
                {
                    owner.ChangeState(AvatarFSMMove.Instance);
                }
                else
                {
                    owner.ChangeState(AvatarFSMIdle.Instance);
                }
            }
        }
    }

    public override void FixedUpdateState(Avatar owner)
    {
    }

    public override void ExitState(Avatar owner)
    {
    }
}
