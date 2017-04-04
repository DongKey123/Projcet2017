using UnityEngine;
using System.Collections;

public class StateMachine<T>
{
    private T _Owner;
    private FSM_State<T> _CurrentState;
    private FSM_State<T> _PreviousState;

    //초기 설정 & 초기화
    public void Initial_Setting(T owner, FSM_State<T> _InitialState)
    {
        Awake();
        _Owner = owner;
        ChangeState(_InitialState);
    }

    //초기화
    public void Awake()
    {
        _CurrentState = null;
        _PreviousState = null;
    }

    //상태변경
    public void ChangeState(FSM_State<T> newstate)
    {
        //같은 상태일시 리턴
        if (newstate == _CurrentState)
        {
            return;
        }

        _PreviousState = _CurrentState;

        // 현재 상태가 있다면 종료
        if (_CurrentState != null)
        {
            _CurrentState.ExitState(_Owner);
        }

        _CurrentState = newstate;

        if (_CurrentState != null)
        {
            _CurrentState.EnterState(_Owner);
        }
    }

    public void Update()
    {
        if (_CurrentState != null)
        {
            _CurrentState.UpdateState(_Owner);
        }
    }

    public void FixedUpdate()
    {
        if (_CurrentState != null)
        {
            _CurrentState.FixedUpdateState(_Owner);
        }
    }

    // 이전 상태로 회귀
    public void StateRevert()
    {
        if (_PreviousState != null)
        {
            ChangeState(_PreviousState);
        }
    }
}

