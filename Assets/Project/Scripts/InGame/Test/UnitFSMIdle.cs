using UnityEngine;
using System.Collections;

public class UnitFSMIdle : FSM_State<UnitBase>
{
    static readonly UnitFSMIdle instance = new UnitFSMIdle();

    public static UnitFSMIdle Instance
    {
        get
        {
            return instance;
        }
    }
    static UnitFSMIdle() { }
    private UnitFSMIdle() { }

    public override void EnterState(UnitBase owner)
    {
    }

    public override void UpdateState(UnitBase owner)
    {
        
    }

    public override void FixedUpdateState(UnitBase owner)
    {
    }

    public override void ExitState(UnitBase owner)
    {

    }
}
