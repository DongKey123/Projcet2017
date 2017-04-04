using UnityEngine;
using System.Collections;

public class RemoteAvatarFSMIdle : FSM_State<RemoteAvatar> {

    static readonly RemoteAvatarFSMIdle instance = new RemoteAvatarFSMIdle();

    public static RemoteAvatarFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }

    static RemoteAvatarFSMIdle() { }
    private RemoteAvatarFSMIdle() { }


    public override void EnterState(RemoteAvatar owner)
    {
        owner.m_Act = AvatarAct.IDLE;
        owner.GetComponent<Animator>().Play("Idle");
    }

    public override void UpdateState(RemoteAvatar owner)
    {
        //스테이트 변환 
        if (owner.m_IsControlling == true)
        {
            owner.ChangeState(RemoteAvatarFSMMove.Instance);
        }
        else
        {
            owner.transform.position = owner._RecVec;
        }
    }

    public override void FixedUpdateState(RemoteAvatar owner)
    {
    }

    public override void ExitState(RemoteAvatar owner)
    {
    }


}
