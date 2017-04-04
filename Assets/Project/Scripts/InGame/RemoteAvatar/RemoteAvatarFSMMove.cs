using UnityEngine;
using System.Collections;

public class RemoteAvatarFSMMove : FSM_State<RemoteAvatar> {


    static readonly RemoteAvatarFSMMove instance = new RemoteAvatarFSMMove();

    public static RemoteAvatarFSMMove Instance
    {
        get
        {
            return instance;
        }
    }

    static RemoteAvatarFSMMove() { }
    private RemoteAvatarFSMMove() { }

    public override void EnterState(RemoteAvatar owner)
    {
        owner.m_Act = AvatarAct.MOVE;
        owner.GetComponent<Animator>().Play("Move");
    }

    public override void UpdateState(RemoteAvatar owner)
    {
        //스테이트 변환 
        if (owner.m_IsControlling == true)
        {
            owner.m_LookVec = (owner._RecVec - owner._prevRecVec).normalized;
            owner.transform.position += (owner._RecVec - owner._prevRecVec) * owner._DelayTime;
            owner.transform.rotation = Quaternion.LookRotation(owner.m_LookVec);
        }
        else
        {
            owner.ChangeState(RemoteAvatarFSMIdle.Instance);
        }
       
    }

    public override void FixedUpdateState(RemoteAvatar owner)
    {
    }

    public override void ExitState(RemoteAvatar owner)
    {
    }



}
