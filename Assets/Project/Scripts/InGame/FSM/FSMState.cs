using UnityEngine;
using System.Collections;

abstract public class FSM_State<T>
{
    abstract public void EnterState(T owner);

    abstract public void UpdateState(T owner);

    abstract public void FixedUpdateState(T owner);

    abstract public void ExitState(T owner);
}