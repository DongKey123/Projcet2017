using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFSMAttackL : FSM_State<Avatar> {

    static readonly AvatarFSMAttackL instance = new AvatarFSMAttackL();

    public static AvatarFSMAttackL Instance
    {
        get
        {
            return instance;
        }
    }

    static AvatarFSMAttackL() { }
    private AvatarFSMAttackL() { }

    private Animator anim;
    private bool AttackOn = true;

    public override void EnterState(Avatar owner)
    {
        anim = owner.GetComponent<Animator>();
        AttackOn = true;
        owner.m_IsControling = false;
        owner.m_Act = AvatarAct.ATTACK_L;
        owner.GetComponent<Animator>().Play("LeftAttack");

        owner.m_AttackMissAudio.PlayDelayed(0.2f);

    }

    public override void UpdateState(Avatar owner)
    {
        JoyStick stick = owner.m_Joystick;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("LeftAttack"))
        {
            if(stateInfo.normalizedTime >= 0.05 && AttackOn)
            {
                
            }

            if(stateInfo.normalizedTime >= 0.3 && AttackOn)
            {
                RaycastHit hit;
                if(Physics.Raycast(owner.transform.position,owner.transform.forward,out hit,2f))
                {
                    if(hit.transform.tag == "Elemental")
                    {
                        AttackOn = false;
                        Elemental ele = hit.transform.GetComponent<Elemental>();
                        ele.m_curHp -= 5;
                        owner.m_AttackAudio.Play();
                    }
                    else if(hit.transform.tag == "Tower")
                    {
                        AttackOn = false;
                        Tower tower = hit.transform.GetComponent<Tower>();
                        tower.m_curHp -= 5;
                    }
                    else if(hit.transform.tag == "RemoteAvatar")
                    {
                        AttackOn = false;
                        RemoteAvatar rAvatar = hit.transform.GetComponent<RemoteAvatar>();
                        rAvatar.m_curHp -= 5;

                        owner.m_Damage = 5;
                    }
                }
                else if (Physics.Raycast(owner.transform.position, owner.transform.right+owner.transform.forward, out hit, 2f))
                {
                    if (hit.transform.tag == "Elemental")
                    {
                        AttackOn = false;
                        Elemental ele = hit.transform.GetComponent<Elemental>();
                        ele.m_curHp -= 5;
                        owner.m_AttackAudio.Play();
                    }
                    else if (hit.transform.tag == "Tower")
                    {
                        AttackOn = false;
                        Tower tower = hit.transform.GetComponent<Tower>();
                        tower.m_curHp -= 5;
                    }
                    else if (hit.transform.tag == "RemoteAvatar")
                    {
                        AttackOn = false;
                        RemoteAvatar rAvatar = hit.transform.GetComponent<RemoteAvatar>();
                        rAvatar.m_curHp -= 5;

                        owner.m_Damage = 5;
                    }
                }
                else if (Physics.Raycast(owner.transform.position, -owner.transform.right + owner.transform.forward, out hit, 2f))
                {
                    if (hit.transform.tag == "Elemental")
                    {
                        AttackOn = false;
                        Elemental ele = hit.transform.GetComponent<Elemental>();
                        ele.m_curHp -= 5;
                        owner.m_AttackAudio.Play();
                    }
                    else if (hit.transform.tag == "Tower")
                    {
                        AttackOn = false;
                        Tower tower = hit.transform.GetComponent<Tower>();
                        tower.m_curHp -= 5;
                    }
                    else if (hit.transform.tag == "RemoteAvatar")
                    {
                        AttackOn = false;
                        RemoteAvatar rAvatar = hit.transform.GetComponent<RemoteAvatar>();
                        rAvatar.m_curHp -= 5;

                        owner.m_Damage = 5;
                    }
                }
                else
                {
                   
                }
            }

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
