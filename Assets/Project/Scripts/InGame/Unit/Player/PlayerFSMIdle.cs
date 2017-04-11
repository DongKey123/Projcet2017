using UnityEngine;
using System.Collections;

public class PlayerFSMIdle : FSM_State<Player> {

    static readonly PlayerFSMIdle instance = new PlayerFSMIdle();

    public static PlayerFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }
    static PlayerFSMIdle() { }
    private PlayerFSMIdle() { }




    public override void EnterState(Player owner)
    {
        owner.m_Act = PlayerAct.IDLE;
        owner.GetComponent<Animator>().Play("Idle");
    }

    public override void UpdateState(Player owner)
    {
        JoyStick stick = owner.m_Joystick;
        if (stick.GetHorizontalValue() != 0 || stick.GetVerticalValue() != 0 )
        {
            owner.ChangeState(PlayerFSMWalk.Instance);
        }
    }

    public override void FixedUpdateState(Player owner)
    {
    }

    public override void ExitState(Player owner)
    {
    }

}
