using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    private List<State> _states = new List<State>();

    private State _state;

    /// <summary>
    /// 增加状态
    /// </summary>
    /// <param name="state">State.</param>
    public void AddState(State state)
    {
        if (!_states.Contains(state)){
            _states.Add(state);
        }

    }

    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="state">State.</param>
    public void DeleteState(State state)
    {
        if (!_states.Contains(state))
        {
            Debug.Log("_state中不存在,无法删除");
            return;
        }

        _states.Remove(state);
    }

    /// <summary>
    /// 设置当前状态
    /// </summary>
    public void SetState(State state)
    {
        if (!_states.Contains(state))
        {

            Debug.Log("设置当前状态未成功");
        }
        _state = state;
    }

    /// <summary>
    /// 获取_state
    /// </summary>
    /// <returns>The state.</returns>
    public State GetState()
    {
        if(_state != null)
        {
            return _state;
        }
        return _state;
    }


    public abstract void Walk();
    public abstract void Run();
    public abstract void Stop();

    public virtual void Alive() { }
    public virtual void Died() { }

}



public enum State
{
    alive,
    died,

    walk,
    run,
    stop,
}