using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteAvatarFSMDead : FSM_State<RemoteAvatar>
{

    static readonly RemoteAvatarFSMDead instance = new RemoteAvatarFSMDead();

    public static RemoteAvatarFSMDead Instance
    {
        get
        {
            return instance;
        }
    }

    static RemoteAvatarFSMDead() { }
    private RemoteAvatarFSMDead() { }


    public override void EnterState(RemoteAvatar owner)
    {
        owner.GetComponent<Animator>().Play("Dead");
    }

    public override void UpdateState(RemoteAvatar owner)
    {
        
    }

    public override void FixedUpdateState(RemoteAvatar owner)
    {
    }

    public override void ExitState(RemoteAvatar owner)
    {
    }
}
