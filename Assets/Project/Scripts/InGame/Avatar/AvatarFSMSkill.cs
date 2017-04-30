using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFSMSkill : FSM_State<Avatar>
{
    static readonly AvatarFSMSkill instance = new AvatarFSMSkill();

    public static AvatarFSMSkill Instance
    {
        get
        {
            return instance;
        }
    }

    static AvatarFSMSkill() { }
    private AvatarFSMSkill() { }

    private Animator anim;

    public override void EnterState(Avatar owner)
    {
        anim = owner.GetComponent<Animator>();
        owner.m_Act = AvatarAct.SKILL;
        owner.GetComponent<Animator>().Play("LeftAttack");
        GameObject obj = GameObject.Instantiate(owner.m_SkillPrefab);
        obj.transform.position = owner.transform.position;
        obj.transform.position = owner.m_SkillPos.position;
        obj.transform.LookAt( owner.m_SkillPos.position+owner.transform.forward);
        GameObject.Destroy(obj, 3f);
        owner.m_SkillAudio.Play();
    }

    public override void UpdateState(Avatar owner)
    {
        JoyStick stick = owner.m_Joystick;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("LeftAttack"))
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
