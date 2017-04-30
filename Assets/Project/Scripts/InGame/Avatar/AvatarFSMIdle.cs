using UnityEngine;
using System.Collections;

public class AvatarFSMIdle : FSM_State<Avatar> {

    static readonly AvatarFSMIdle instance = new AvatarFSMIdle();

    public static AvatarFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }

    static AvatarFSMIdle() { }
    private AvatarFSMIdle() { }


    public override void EnterState(Avatar owner)
    {
        owner.m_IsControling = false;
        owner.m_Act = AvatarAct.IDLE;
        owner.GetComponent<Animator>().Play("Idle");
    }

    public override void UpdateState(Avatar owner)
    {
        if (owner.m_Joystick == null)
            return;

        JoyStick stick = owner.m_Joystick;
        

        if (stick.GetHorizontalValue() != 0 || stick.GetVerticalValue() != 0)
        {
            owner.ChangeState(AvatarFSMMove.Instance);
        }
    }

    public override void FixedUpdateState(Avatar owner)
    {
    }

    public override void ExitState(Avatar owner)
    {
    }
}
