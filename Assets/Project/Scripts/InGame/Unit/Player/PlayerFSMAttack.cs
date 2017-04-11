using UnityEngine;
using System.Collections;

public class PlayerFSMAttack : FSM_State<Player> {

    static readonly PlayerFSMAttack instance = new PlayerFSMAttack();

    public static PlayerFSMAttack Instance
    {
        get
        {
            return instance;
        }
    }

    static PlayerFSMAttack() { }
    private PlayerFSMAttack() { }


    public override void EnterState(Player owner)
    {
        owner.m_Act = PlayerAct.ATTACK;
    }

    public override void UpdateState(Player owner)
    {
    }

    public override void FixedUpdateState(Player owner)
    {
    }

    public override void ExitState(Player owner)
    {
    }
}
