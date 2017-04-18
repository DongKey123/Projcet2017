using UnityEngine;
using System.Collections;

public class AvatarFSMMove : FSM_State<Avatar> {

    static readonly AvatarFSMMove instance = new AvatarFSMMove();

    public static AvatarFSMMove Instance
    {
        get
        {
            return instance;
        }
    }

    static AvatarFSMMove() { }
    private AvatarFSMMove() { }

    public override void EnterState(Avatar owner)
    {
        owner.m_IsControling = true;
        owner.m_Act = AvatarAct.MOVE;
        owner.GetComponent<Animator>().Play("Move");
    }

    public override void UpdateState(Avatar owner)
    {
        JoyStick stick = owner.m_Joystick;
        float h = stick.GetHorizontalValue();
        float v = stick.GetVerticalValue();
        if (h == 0 && v == 0)
        {
            owner.ChangeState(AvatarFSMIdle.Instance);
            return;
        }
        owner.m_LookVec = new Vector3(h, 0, v);
        owner.m_LookVec.Normalize();

        //Quaternion.LookRotation((nextTile.transform.position - owner.transform.position).normalized);
        owner.transform.position += owner.m_LookVec * owner.m_MovementSpeed * Time.deltaTime;
        owner.transform.position = new Vector3(owner.transform.position.x, owner.transform.position.y, Mathf.Clamp(owner.transform.position.z,-5,3));
        owner.transform.rotation = Quaternion.LookRotation(owner.m_LookVec);
    }

    public override void FixedUpdateState(Avatar owner)
    {
    }

    public override void ExitState(Avatar owner)
    {
    }
}
