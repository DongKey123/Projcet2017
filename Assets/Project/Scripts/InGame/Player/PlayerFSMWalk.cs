using UnityEngine;
using System.Collections;

public class PlayerFSMWalk : FSM_State<Player> {

    static readonly PlayerFSMWalk instance = new PlayerFSMWalk();
    
    public static PlayerFSMWalk Instance
    {
        get
        {
            return instance;
        }
    }

    static PlayerFSMWalk() { }
    private PlayerFSMWalk() { }

    public override void EnterState(Player owner)
    {
        owner.m_Act = PlayerAct.IDLE;
        owner.GetComponent<Animator>().Play("Walk");
    }

    public override void UpdateState(Player owner)
    {
        JoyStick stick = owner.m_Joystick;
        float h = stick.GetHorizontalValue();
        float v = stick.GetVerticalValue();
        if (h == 0 && v == 0)
        {
            owner.ChangeState(PlayerFSMIdle.Instance);
            return;
        }
        //Quaternion.LookRotation((nextTile.transform.position - owner.transform.position).normalized);
        owner.transform.position += new Vector3(h, 0, v) * owner.m_walkSpeed * Time.deltaTime;
        owner.transform.rotation = Quaternion.LookRotation((new Vector3(h, 0, v).normalized));
    }

    public override void FixedUpdateState(Player owner)
    {
    }

    public override void ExitState(Player owner)
    {
    }
}
