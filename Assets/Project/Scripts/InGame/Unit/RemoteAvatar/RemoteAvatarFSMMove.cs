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
        owner.transform.position = owner._RecVec;
    }

    public override void UpdateState(RemoteAvatar owner)
    {
        //스테이트 변환 
        if (owner.m_IsControlling == true)
        {
            float DelayTime = owner._DelayTime;
            Vector3 velocity = (owner._RecVec - owner._prevRecVec) / DelayTime * Time.deltaTime;
            
            //추측항법
            owner.transform.position += velocity;
            //owner.transform.position += (owner._RecVec - owner._prevRecVec) / owner._DelayTime * Time.deltaTime - 0.5f * owner.m_LookVec*3.0f * Time.deltaTime * Time.deltaTime;
            //보간
            //owner.transform.position = Vector3.Lerp(owner._prevRecVec, owner._RecVec, owner.curLerp );
            owner.transform.rotation = Quaternion.LookRotation(owner.m_LookVec);
            //Debug.Log("Rot");
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
